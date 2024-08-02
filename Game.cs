using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*  Main Game play methods
 *  the actual gameplay session is run from Form1.cs gamePlay(int mode)
 *  AI is dealt with in ComputerDreams.cs
 */

namespace ExplodingAtoms
{
    
    
    static class Game
    {
        public static int demoSize = 8;
        public static bool cont = true;
        public static bool exit = false;
        public static bool inGame = false;
        public static bool ovflow = false;
        public static bool annihilation = false;
        public static bool placed = false;
        public static int mode = 0;
        public static int size;
        public static int total;
        public static int[,] pground; //tracks number of atoms
        public static int[,] map; //tracks colors of tiles
        public static int[,] capacity;
        public static Queue<Player> pQ; //player queue
        public static List<Player> pL; //player list
        public static Queue<int[]> tileQ;
        public static Queue<int[]> tidyQ;
        public static Player turn;
        

        //images
        public static Image empty = Properties.Resources.Empty;
        static public List<Image> One = new List<Image>(new Image[]
        {
            Properties.Resources._11, Properties.Resources._12, Properties.Resources._13, Properties.Resources._14,
            Properties.Resources._12_00, Properties.Resources._12_10, Properties.Resources._12_11, Properties.Resources._12_01,//corners exploding 4-7
            Properties.Resources._13_x0, Properties.Resources._13_1y, Properties.Resources._13_x1, Properties.Resources._13_0y//sides exploding 8-11
        });
        static public List<Image> Two = new List<Image>(new Image[]
        {
            Properties.Resources._21, Properties.Resources._22, Properties.Resources._23, Properties.Resources._24,
            Properties.Resources._22_00, Properties.Resources._22_10, Properties.Resources._22_11, Properties.Resources._22_01,//corners exploding 4-7
            Properties.Resources._23_x0, Properties.Resources._23_1y, Properties.Resources._23_x1, Properties.Resources._23_0y//sides exploding 8-11
        });
        static public List<Image> Three = new List<Image>(new Image[]
        {
            Properties.Resources._31, Properties.Resources._32, Properties.Resources._33, Properties.Resources._34,
            Properties.Resources._32_00, Properties.Resources._32_10, Properties.Resources._32_11, Properties.Resources._32_01,//corners exploding 4-7
            Properties.Resources._33_x0, Properties.Resources._33_1y, Properties.Resources._33_x1, Properties.Resources._33_0y//sides exploding 8-11
        });
        static public List<Image> Four = new List<Image>(new Image[]
        {
            Properties.Resources._41, Properties.Resources._42, Properties.Resources._43, Properties.Resources._44,
            Properties.Resources._42_00, Properties.Resources._42_10, Properties.Resources._42_11, Properties.Resources._42_01,//corners exploding 4-7
            Properties.Resources._43_x0, Properties.Resources._43_1y, Properties.Resources._43_x1, Properties.Resources._43_0y//sides exploding 8-11
        });

        

        public static int[,] capacityInit(int size) {
            capacity = new int[size, size];
            for (int i = 0; i < size; i++) { 
                for (int j = 0; j < size; j++)
                {
                    //corners have two neighbours
                    if (((i == 0) && (j == i || j == size - 1)) || ((i == size - 1) && (j == 0 || j == i)))
                        capacity[i, j] = 1;
                    //sides have three
                    else if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                        capacity[i, j] = 2;
                    //all the atoms on the inside have four
                    else
                        capacity[i, j] = 3;
                }
            }
            return capacity;
        }

        public static Player nextTurn(Queue<Player> Q)
        {
            Player t = Q.Dequeue();
            Q.Enqueue(t);
            return t;
        }

        

        //basic setup for the game... the rest is done in the NGform
        public static void gameInit() 
        {
            total = size * size;
            pground = new int[size, size];
            map = new int[size, size];
            capacity = capacityInit(size);
        }

        //start screen demo needs more specific setup
        public static void demoInit() {
            size = demoSize;
            pQ = new Queue<Player>();
            pL = new List<Player>();
            tileQ = new Queue<int[]>();
            tidyQ = new Queue<int[]>();
            Player One = new Player(1,2);
            Player Two = new Player(2,2);
            pQ.Enqueue(One);
            pL.Add(One);
            pQ.Enqueue(Two);
            pL.Add(Two);
        }

       
        //places the first electron, NEEDS TO BE CONTINUED
        public static void demoIter() {
            
            int[] tile;
            int h = size / 2;
            if (turn.number == 1)
            {
                tile = new int[3] { h-1, h-1, 0 };
            }
            else
            {
                tile = new int[3] { h, h, 0 };
            }
            if (checkMap(tile))
            {
                tileQ.Enqueue(tile);
            }
            else
            {
                tileQ.Enqueue(findEmpty(tile));
            }
            
        }

        //simple search for an available position to play = simple BFS AI used in Demo
        public static int[] findEmpty(int[] tile) {
            int[] result = new int[3] { -1, -1, 0};
            int[] v;
            int[] u;
            Queue<int[]> Q = new Queue<int[]>();
            Q.Enqueue(tile);
            while (Q.Count > 0) {
                v = Q.Dequeue();
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((i != 0 || j != 0) && v[0] + i > 0 && v[1] + j > 0 && v[0] + i < size && v[1] + j < size)
                        {
                            if (map[v[0] + i, v[1] + j] == turn.number || map[v[0] + i, v[1] + j] == 0) {
                                result[0] = v[0] + i;
                                result[1] = v[1] + j;
                                return result;
                            }
                            Q.Enqueue(u = new int[3] { v[0] + i, v[1] + j, 0 });
                        }
                    }
                }

            }

            return result;
        }
        //start screen Demo code end

        //true if the tile already belongs to the player who's capturing it, or is empty
        public static bool checkMap(int[] tile) {
            int x = tile[0];
            int y = tile[1];
            if (map[x, y] == turn.number || map[x, y] == 0)
                return true;
            else
                return false;
        }

        //adds an electron to an atom according to the rules, also enqueues neighbouring atoms if necessary
        public static void place(int[] tile, Player p, List<Player> pL, int[,] pground, int[,] map) {
            int x = tile[0];//col
            int y = tile[1];//row
            int depth = tile[2];
            int max = capacity[x,y];
            Player opponent;
          
            if (pground[x,y] < max)//value can increase without the atom exploding
            {
                pground[x,y]++;//value has to increase
                if (map[x, y] != p.number && map[x,y] != 0)//it's already occupied
                {
                    opponent = getPlayer(map[x, y],pL);
                    opponent.score--;//opponent loses a point (and maybe his life too)
                    if (opponent.score == 0 && annihilation) excludePlayer(opponent,pQ,pL);
                    p.score++;//we gain one
                }
                map[x, y] = p.number;//the atom is ours
                if (pground[x,y] == 1) p.score++;//if the atom was empty, we gain a point
            }
            else //atom will explode
            {
                pground[x,y]++;//atom is now exploding
                if (map[x, y] != p.number)//exploded atom belonged to the opponent
                {
                    opponent = getPlayer(map[x, y],pL);
                    opponent.score--;//who loses a point or game (we don't gain a point from this atom)
                    if (opponent.score == 0 && annihilation) excludePlayer(opponent,pQ,pL);
                    
                }
                else  
                {
                    if (pground[x, y] == max + 1)
                        p.score--;//or it was ours and we lose a point
                    if (pground[x, y] == max + 2 && ovflow)//this is an alternative that keeps the overflow elektrons
                        p.score++;
                }
                map[x,y] = p.number;//color will be turned neutral by the tidy up function...
                if (pground[x, y] == max + 1)
                    tidyQ.Enqueue(tile);
                //we need to add all the surrounding 2 - 4 atoms to a queue that will be dealt with presently...
                //waves are divided by the additional third coordinate depth.
                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        if (i != j && i != -j && x + i >= 0 && y + j >= 0 && x+i < size && y + j < size) {
                            if (pground[x,y] == max + 1)
                                tileQ.Enqueue(tile = new int[3] { x + i, y + j, depth+1 });
                        }
                    }
                }
            }
        }

        //The filled atoms remain until this functions deals with them
        //There can be more electrons than the capacity allows and these either stay after the explosion or disappear
        public static void tidyUp(int[] tile) 
        {
            int x = tile[0];
            int y = tile[1];
            int s = (ovflow) ? capacity[x, y] + 1 : pground[x, y];
            //pground[x, y] = 0;
            pground[x, y] -= s;
            map[x, y] = (pground[x, y] == 0) ? 0 : map[x, y];
        }

        //Returns a specific player based on their number
        public static Player getPlayer(int number, List<Player> pL)
        {
            foreach (Player P in pL)
            {
                if (number == P.number) return P;
            }
            return null;
        }
        public static void excludePlayer(Player P, Queue<Player> Q, List<Player> L)
        {
            int num = Q.Count;
            Player H;

            getPlayer(P.number,L).alive = false;
            for (int i = 1; i <= num; i++)
            {
                H = Q.Dequeue();
                if (H.number != P.number) Q.Enqueue(H);
            }
        }

        

        //If we have captured atoms all over the place, we can fall into an infinite loop,
        //because of the lower capacity of the border atoms...
        //if the playgorund is mostly filled, we need to test if the spread is looped
        public static List<int[]> LoopTest = new List<int[]>();
        public static int index = 0;
        public static int r = 0;

        //returns true if two points have the same coordinates
        public static bool compare(int[] a, int[] b) 
        {
            if (a[0] == b[0] && a[1] == b[1]) return true;
            return false;
        }

        //enables the loop test based on the score
        public static bool antiLoopInit(int[] tile) 
        {
            int limit = total - 2 * size;
            //index = 0;
            //r = 0;
            if (turn.score < limit) return false;
            //LoopTest = new List<int[]>();
            LoopTest.Add(tile);
            return true;
        }

        //adds points that go to place() after dequeuing to a list,
        //if we find that we're adding the same sequence of points again, we call loop
        public static bool antiLoop(int[] tile) 
        {
            if (LoopTest.Count <= 1) return false;
            if (compare(LoopTest[index], tile)) 
            {
                if (index == 0) 
                {
                    r = (LoopTest.Count > 2) ? LoopTest.Count : 0;
                }
                if (r > 0 && index == r)
                    return true;
                index++;
                if (index > 10) 
                {
                    LoopTest = new List<int[]>();
                    index = 0;
                    r = 0;
                    antiLoopInit(tile);
                }
                
            }
            LoopTest.Add(tile);
            return false;
        }

        public static List<Player> newCopy(List<Player> L) 
        {
            List<Player> pL = new List<Player>();
            foreach (Player P in L) 
            {
                pL.Add(P);
            }
            return pL;
        }

    }

    

    public class Player 
    {
        public int number;
        public int score;
        public bool human;
        public bool alive;
        public List<Image> I;
        

        public Player(int number, int choice) {
            this.number = number;
            score = 0;
            alive = true;
            if (choice == 1) human = true;
            else human = false;
            I = assignColor(number);
        }

        public Player(Player P)
        {
            number = P.number;
            score = P.score;
            alive = P.alive;
            human = P.human;
            I = assignColor(number);
        }

        List<Image> assignColor(int number) {
            switch (number) 
            {
                case 1:
                    return Game.One;
                case 2:
                    return Game.Two;
                case 3:
                    return Game.Three;
                default: 
                    return Game.Four;
            }
        }

        public Image properI(int[] p) {
            int x = p[0];
            int y = p[1];
            int max = Game.capacity[x, y] + 1;
            int end = Game.size - 1;

            
            if (Game.pground[x,y] < max) //not exploding
            {
                switch (Game.pground[p[0], p[1]])
                {
                    case 1:
                        return I[0];
                    case 2:
                        return I[1];
                    case 3:
                        return I[2];
                    default:
                        return Game.empty;
                }
            }
            else //if the atom is exploding
            {
                //all the ifs are about less than four electrons
                if (x == 0)
                {
                    if (y == 0)
                        return I[4];
                    if (y == end)
                        return I[5];
                    return I[8];
                }
                if (y == 0)
                {
                    if (x == end)
                        return I[7];
                    return I[11];
                }
                if (x == end)
                {
                    if (x == y)
                        return I[6];
                    return I[10];
                }
                if (y == end)
                    return I[9];

                return I[3]; //four electrons
            }
        }

        public Color pColor() {
            switch (number) 
            {
                case 1:
                    return Color.DeepSkyBlue;
                case 2:
                    return Color.Lime;
                case 3:
                    return Color.Orange;
                default:
                    return Color.Red;

            }
        }

    }

}
