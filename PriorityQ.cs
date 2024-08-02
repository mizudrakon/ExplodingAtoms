using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingAtoms
{
    


    class PriorityQ
    {
        public int last;
        public int[][] IntQ;
        public World[] WorldQ;
        public Dictionary<World, int> WDict;
        public List<World> WorldL;

        public PriorityQ(string type)
        {
            if (type == "int")
            {
                IntQ = new int[2 * Game.total][];
            }
            else
            {
                WorldQ = new World[2 * Game.total];
                WDict = new Dictionary<World, int>();
                WorldL = new List<World>();
            }
            last = 0;
        }


        public void setZero(int i) 
        {
            IntQ[0] = new int[2] { i, 0 };
        }

        public int Zero() 
        {
            return IntQ[0][0];
        }

        public int Count()
        {
            return last;
        }

        public void Enqueue(int[] point, int priority)
        {

            int i = ++last;
            int p;
            int[] element = new int[3] { point[0], point[1], priority };

            
            
            while (i > 1 && element[2] > IntQ[p = i / 2][2] && p != 0)
            {
                IntQ[i] = IntQ[p];
                i = p;
            }
            IntQ[i] = element;
            

        }

        public void Enqueue(World W)
        {
            int priority = W.perspectivity;

            int i = ++last;
            int p;
            
            while (i > 1 && priority > WorldQ[p = i / 2].perspectivity && p != 0)
            {
                WorldQ[i] = WorldQ[p];
                WDict[WorldQ[i]] = i;
                i = p;
            }
            WorldQ[i] = W;
            WDict.Add(W, i);
            WorldL.Add(W);
        }

        int findMax(int v, int a)
        {
            int u = 2 * v + 1;
            //if (2 * v > last) return -1;
            if (u > last || IntQ[u] == null) return 2 * v;
            if (IntQ[2 * v][2] >= IntQ[u][2]) return 2 * v;
            
            return u;
        }

        int findMax(int v, string A)
        {
            int u = 2 * v + 1;
            //if (2 * v > last) return -1;
            if (u > last || WorldQ[u] == null) return 2 * v;
            if (WorldQ[2 * v].perspectivity >= WorldQ[u].perspectivity) return 2 * v;
            return u;
        }

        public int[] Dequeue(int a)
        {
            int v = 1;
            int u;
            int[] helper = new int[4];
            helper = IntQ[last];
            int[] result = IntQ[v];
            IntQ[last] = null;
            last--;
            while (2 * v <= last && IntQ[2 * v] != null && IntQ[u = findMax(v,1)][2] > helper[2])
            {
                IntQ[v] = IntQ[u];
                v = u;
            }
            IntQ[v] = helper;
            return result;
        }

        public World Dequeue(string A)
        {
            int v = 1;
            int u = 1;
            World result = WorldQ[v];
            WDict.Remove(result);
            World helper = WorldQ[last];           
            

            WorldQ[last] = null;
            last--;
            while (2*v <= last && WorldQ[2*v] != null && WorldQ[u = findMax(v,"W")].perspectivity > helper.perspectivity)
            {
                WorldQ[v] = WorldQ[u];
                WDict[WorldQ[u]] = v;
                v = u;
            }
            WorldQ[v] = helper;
            WDict[helper] = v;
            return result;
        }

        public void ChangeP(World W, int perspect) 
        {
            int i = WDict[W];
            int p;
            World H;
            if (WorldQ[i].perspectivity < perspect)//increase 
            {
                WorldQ[i].perspectivity = perspect;
                while ((p = i / 2) > 0 && perspect > WorldQ[p].perspectivity) 
                {
                    H = WorldQ[p];
                    WorldQ[p] = WorldQ[i];
                    WDict[WorldQ[p]] = p;
                    WorldQ[i] = H;
                    i = p;
                }
            }
            if (WorldQ[i].perspectivity > perspect)//decrease
            {
                WorldQ[i].perspectivity = perspect;
                while (W.perspectivity > WorldQ[p = findMax(WDict[W],"W")].perspectivity)
                {
                    H = WorldQ[p];
                    WorldQ[p] = WorldQ[i];
                    WDict[WorldQ[p]] = p;
                    WorldQ[i] = H;
                    i = p;
                }
            }
            
        }

        public void Remove(World W) 
        {
            World N;
            ChangeP(W, WorldQ[1].perspectivity + 1);//push it up
            N = Dequeue("W");//dequeue it
            N.O = null;//I think this should make it finally gone
            WorldL.Remove(W);
            
        }

        //Gives us next world in queue from some starting world, without dequeueing it
        public World Next(World W) 
        {
            if (W != null)
            {
                int i = findMax(WDict[W], "W");
                if (i < last)
                    return WorldQ[i];
            }
            return null;
        }

        public World First() 
        {
            return WorldQ[1];
        }

    }



}
