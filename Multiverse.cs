using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingAtoms
{
    
    /* World is a specific game state:
     * playground, map - both change when a player thakes their turn
     * list of players - used to check if they're still in game or not
     * queue of players - used to queue players, makes it easier to take a player out of the game
     * turn - the player who's turn it is - picked out of the queue (so the first in the current queue is the next player)
     * 
     * In each world we generate a list of edges to some next world that are entirely given by what the turn player can do in this one;
     * every element in this list refers to another specific world.
     */
    class World 
    {
        public int[,] map;
        public int[,] pground;
        public Queue<Player> pQ = new Queue<Player>();        
        public Player turn;
        public World O;//Origin
        public int[] cause;
        public int depth;
        public int perspectivity;//for the player who's one layer up
        public int inter;
        public int[][] score;
        public int remain;

        public List<Player> perspL = new List<Player>();
        
        
        public PriorityQ C;
        public PriorityQ E; //edges 

        public World(int[,] map, int[,] pground, Queue<Player> pQ, Player turn) 
        {
            this.map = copyField(map);
            this.pground = copyField(pground);
            this.pQ = copyQueue(pQ);
            score = setScore(Game.pL);
            remain = Remain(score);
            this.turn = new Player(turn);
            O = null;
            cause = null;
            depth = 0;
            perspectivity = 0;
            inter = 0;
            C = new PriorityQ("int");            
            E = null;
            
        }

        public World(World W, int[] point) 
        {
            map = copyField(W.map);
            pground = copyField(W.pground);
            pQ = copyQueue(W.pQ);
            score = copyScore(W.score);
            turn = new Player(W.turn);
            O = W;
            cause = point;
            depth = W.depth + 1;
            perspectivity = 0;
            inter = 0;
            ComputerDreams.play(map, pground, score, pQ, turn, perspectivity, point);
            turn = Game.nextTurn(pQ);
            remain = Remain(score);
            
            
            C = new PriorityQ("int");
            E = null;
        }

        int[][] setScore(List<Player> pL) 
        {
            Player P;
            int[][] result = new int[5][];
            result[0] = new int[2] { 0, 0 };
            for (int i = 1; i < 5; i++) {
                P = Game.getPlayer(i, Game.pL);
                if (P != null)
                { 
                    result[i] = new int[2];
                    if (P.alive) result[i][0] = 1;
                    result[i][1] = P.score;
                }
                else result[i] = new int[2] { 0, 0 };
            }
            return result;
        }

        int[,] copyField(int[,] field) 
        {
            int[,] result = new int[Game.size,Game.size];
            for (int i = 0; i < Game.size; i++) 
            {
                for (int j = 0; j < Game.size; j++) 
                {
                    result[i, j] = field[i, j];
                }
            }
            return result;
        }

        int[][] copyScore(int[][] score) 
        {
            int[][] result = new int[5][];
            for (int i = 0; i < 5; i++) 
            {
                if (score[i] != null)
                    result[i] = new int[2] { score[i][0], score[i][1] };
                else result[i] = new int[2] { 0, 0 };
            }
            return result;
        }

        Queue<Player> copyQueue(Queue<Player> Q)
        {
            Queue<Player> result = new Queue<Player>();
            Player P;
            Player H;
            int i = 0;
            while (i < Q.Count) 
            {
                P = Q.Dequeue();
                H = new Player(P);
                Q.Enqueue(P);
                result.Enqueue(H);
                i++;
            }
            return result;
        }

        int Remain(int[][] score) 
        {
            int r = 0;
            foreach (int[] P in score) 
            {
                if (P != null)
                    r += P[1];
            }
            return Game.total - r;
        }
    }
   
}
