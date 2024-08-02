using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingAtoms
{
    
    //This is supposed to play the game
    static class ComputerDreams
    {
        
        public static int depth = 9;
        public static int currentdepth = 0;
        public static World Omega;

        
        public static void excludePlayer(int[][] score, Queue<Player> pQ, int n) 
        {
            score[n][0] = 0;
            score[n][1] = 0;
            //not sure I need to remove them from Q
            //if they had move before, the branch if futile.
            int num = pQ.Count;
            Player H;            
            for (int i = 1; i <= num; i++)
            {
                H = pQ.Dequeue();
                if (H.number != n) pQ.Enqueue(H);
            }
        }

        public static void play(int[,] map, int[,] pground, int[][] score, Queue<Player> pQ, Player turn, int perspectivity, int[] p)
        {
            int depth = 0;
            int[] tile;
            bool test = false;//triggers testing for a loop  
            //bool win = false;
            
            Game.tileQ = new Queue<int[]>();//there's only need for one tileQ
            Game.LoopTest = new List<int[]>();
            Game.tileQ.Enqueue(p);
            //inside loop deals with the consequences in waves given by "depth"

            while (Game.tileQ.Count > 0)//we still want to be able to stop the game while computing
            {
                tile = Game.tileQ.Dequeue();//using a queue
                if (p[0] == -1) //nowhere to play, loses the game
                {
                    excludePlayer(score, pQ, turn.number);
                    break;
                }
                //if the point is fine, but the score is high enough for the possibility of loop, we're testing for a loop
                if (test)//a loop can only happen when the capacity of the playground is basically full, so it means a win...
                {
                    if (Game.antiLoop(p))
                    {
                        turn.score = Game.total;
                        score[turn.number][1] = Game.total;
                        break;
                    }
                }
                test = Game.antiLoopInit(p);//this just checks if there's a point in doing the loop test, and activates it
                //index 2 keeps a wave mark = how far the point is from the original
                if (p[2] > depth)
                {

                    if (Game.inGame == false || Game.exit) break;//in case we've started a new game while this was happening

                    depth = p[2];
                    while (Game.tidyQ.Count > 0)//we only need one of these
                    {
                        p = Game.tidyQ.Dequeue();
                        Game.tidyUp(p);
                    }

                }
                place(map, pground, score, pQ, turn, tile);
                turn.score = score[turn.number][1];
            }

            //annihilation means that if a player lost all their current atoms, they're excluded from the game
            if (pQ.Count == 1 && Game.annihilation)
            {
                turn.score = Game.total;
                score[turn.number][1] = Game.total;
            }
            
        }

        public static void place(int[,] map, int[,] pground, int[][] score, Queue<Player> pQ, Player turn, int[] tile)
        {
            int x = tile[0];//col
            int y = tile[1];//row
            int depth = tile[2];
            int max = Game.capacity[x, y];
            int opponentScore;

            if (pground[x, y] < max)//value can increase without the atom exploding
            {
                pground[x, y]++;//value has to increase
                if (map[x, y] != turn.number && map[x, y] != 0)//it's already occupied
                {
                    opponentScore = --score[map[x, y]][1];//opponent loses a point (and maybe his life too)
                    if (opponentScore == 0 && Game.annihilation) excludePlayer(score, pQ, map[x, y]);
                    score[turn.number][1]++;//we gain one
                }
                map[x, y] = turn.number;//the atom is ours
                if (pground[x, y] == 1) score[turn.number][1]++;//if the atom was empty, we gain a point
            }
            else //atom will explode
            {
                pground[x, y]++;//atom is now exploding
                if (map[x, y] != turn.number)//exploded atom belonged to the opponent
                {
                    opponentScore = --score[map[x, y]][1];//who loses a point or game (we don't gain a point from this atom)
                    if (opponentScore == 0 && Game.annihilation) excludePlayer(score, pQ, map[x, y]);

                }
                else
                {
                    if (pground[x, y] == max + 1)
                        score[turn.number][1]--;//or it was ours and we lose a point
                    if (pground[x, y] == max + 2 && Game.ovflow)//this is an alternative that keeps the overflow elektrons
                        score[turn.number][1]++;
                }
                map[x, y] = turn.number;//color will be turned neutral by the tidy up function...
                if (pground[x, y] == max + 1)
                    Game.tidyQ.Enqueue(tile);
                //we need to add all the surrounding 2 - 4 atoms to a queue that will be dealt with presently...
                //waves are divided by the additional third coordinate depth.
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != j && i != -j && x + i >= 0 && y + j >= 0 && x + i < Game.size && y + j < Game.size)
                        {
                            if (pground[x, y] == max + 1)
                                Game.tileQ.Enqueue(tile = new int[3] { x + i, y + j, depth + 1 });
                        }
                    }
                }
            }
        }

        
        //starts with a playground and an AI player
        //calls the Explore method recursively and builds a tree of roughly a certain depth from scratch
        public static void startSearch()
        {
        }

        public static void search(int d) 
        {
        }


        //checks if there are enemy atoms in the neighbourhood
        //count[0] is the number of enemie
        //count[1] is the most volitile enemy atom around
        //count[2] is the number of friends around
        //count[3] the highest power
        public static int[] neighborhood(int x, int y, World W) 
        {
            int[] count = new int[4];
            int h;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    
                    if (i != j && i != -j && x + i >= 0 && y + j >= 0 && x + i < Game.size && y + j < Game.size)
                    {

                        if (W.map[x + i, y + j] != W.turn.number && W.map[x + i, y + j] != 0)
                        {
                            count[0]++;//number of enemies
                            h = Game.capacity[x + i, y + j] - W.pground[x + i, y + j];
                            if (h > count[1]) count[1] = h;
                        }
                        else if (W.map[x + i, y + j] == W.turn.number)
                        {
                            count[2]++;
                            if (W.pground[x + i, y + j] > count[3]) count[3] = W.pground[x + i, y + j];
                        }
                    }
                }
            }
            return count;
        }

        public static Random rnd = new Random();
        public static PriorityQ findCandidates(World W) 
        {
            int[] p;
            int enemies;//surrounding enemies
            int power;//highest number of electrons in neigh
            int friends;//surrounding friends
            int capacity;
            int prognosis = 0;
            PriorityQ C = new PriorityQ("int");
            for (int x = 0; x < Game.size; x++) {
                for (int y = 0; y < Game.size; y++) 
                {
                    
                    if (W.map[x, y] != W.turn.number && W.map[x, y] != 0) continue;//skipping enemy positions since we can't play there
                    capacity = Game.capacity[x, y];
                    enemies = neighborhood(x, y, W)[0];
                    power = neighborhood(x, y, W)[1];
                    friends = neighborhood(x, y, W)[2];
                    //our atoms close to explosion
                    if (W.map[x, y] == W.turn.number)
                    {//our atom is being checked
                        if (friends > 0) prognosis -= 5*friends;
                        if (W.pground[x, y] == capacity)
                        {
                            prognosis += 16;
                            if (power == capacity - W.pground[x, y]) {
                                W.C.Enqueue(p = new int[2] { x, y }, 1); //priority 1: neigh enemy atom is full and will also explode ours

                            }
                            else if (enemies > 0) C.Enqueue(p = new int[2] { x, y }, 3);//priority 2: enemies around

                            else C.Enqueue(p = new int[2] { x, y }, 4);//priority 4: will explode mostly among friends or alone
                        }
                        else
                        {
                            if (capacity - W.pground[x, y] < 2)
                            {

                                C.Enqueue(p = new int[2] { x, y }, 5);//eneymy too strong
                                prognosis+=8;
                            }
                            
                            else if (power == capacity - W.pground[x, y]) C.Enqueue(p = new int[2] { x, y }, 2);//priority 2: conflict with enemy, measuring electrons
                            else if (power < capacity - W.pground[x, y])
                            {

                                C.Enqueue(p = new int[2] { x, y }, 16);//eneymy too strong
                                prognosis-=4;
                            }
                            else C.Enqueue(p = new int[2] { x, y }, rnd.Next(5, 10));//any atom that is ours
                        }
                    }
                    else 
                    {
                        if (enemies == 0 && W.map[x,y] == 0)
                        {
                            C.Enqueue(p = new int[2] { x, y }, rnd.Next(10, 16));//any empty atom with no surroundings
                            prognosis++;
                        }
                        
                    }                    
                    //so we have some sort of a queue containing pretty much all the positions that are ours or empty
                    //we can limit which ones we pick for actual search()
                }
            }
            C.setZero(prognosis);//the first element gives us a number based on how many dangerous and promising positions there are
            return C;
        }

    }
}
