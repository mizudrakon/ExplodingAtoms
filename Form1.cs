using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingAtoms
{
    public partial class Form1 : Form
    {
        //important variables
        //public bool exit = false;
        //public bool inGame = false;
        public bool placed; //helps with human player turns
       
        public int unit;
        public int side;
        public int speedV = 600;
        
        Image empty = Properties.Resources.Empty;

        public Form1()
        {
            InitializeComponent();
            
        }

        //The game basically runs a simple demonstration of its mechanics
        private void playGround_Paint(object sender, PaintEventArgs e)
        {
            while (Game.exit == false)
            {
                if (Game.cont) gamePlay(Game.mode);
                Application.DoEvents();
            }

            
        }

        //mode 0 = demo, mode 1 = game
        public void gamePlay(int mode) {
            Game.inGame = true;//in game for the demo
            //cont = continue, it needs to be false for the app not to start loading another game after this one ends
            Game.cont = false;//new game turns it on...
            int[] p;
            int depth;
            bool test = false;//triggers testing for a loop  
            Graphics gObject = canvas.CreateGraphics();
            
            if (mode == 0) Game.demoInit();//loads demo properties if enebled
            Game.gameInit();//actualizes basic game properties

            unit = canvas.Width / Game.size;
            side = (canvas.Width % Game.size) / 2; //remaining space is simply redistributed to the sides
            drawPG(gObject);//draws the initial playground
            List<int[]> LoopTest = new List<int[]>();
            Game.turn = Game.nextTurn(Game.pQ);//loads the first player (used to change turns later)
            //sets up the score labels
            newScore();
            changeScore();
            //Outside loop makes decisions where to play
            while (Game.inGame && Game.exit == false)
            {
                placed = false;
                turnLabel.Text = "Player" + Game.turn.number;
                turnLabel.ForeColor = Game.turn.pColor();
                
                if (mode == 0) Game.demoIter();
                else 
                {
                    if (Game.turn.human)
                    {
                        while (placed == false && Game.inGame && Game.exit == false)
                        {
                            wait(100); //waiting for the MouseClick event to happen properly
                        }                      
                    }
                    else 
                    {
                        int[] tile = new int[2] { Game.size / 2, Game.size / 2 };
                        Game.tileQ.Enqueue(Game.findEmpty(tile));
                        /*
                        if (Game.inGame == false || Game.exit) break;
                        World W;
                        ComputerDreams.startSearch();
                        W = ComputerDreams.Omega.E.Dequeue("W");
                        W.O = null;
                        Game.tileQ = new Queue<int[]>();
                        Game.tileQ.Enqueue(W.cause);
                        ComputerDreams.currentdepth--;
                        
                        ComputerDreams.Omega = W;                        
                        */
                    }
                
                }
                //inside loop deals with the consequences, draws them in waves given by "depth"
                depth = 0;
                while (Game.tileQ.Count > 0 && Game.inGame && Game.exit == false)
                {
                    p = Game.tileQ.Dequeue();//using a queue
                    //Game.tidyQ = new Queue<int[]>();
                    if (Game.turn.human && ComputerDreams.Omega != null) 
                    {
                        //ComputerDreams.check(ComputerDreams.Omega, p);
                    }
                    if (p[0] == -1) //nowhere to play, loses the game
                    {
                        Game.excludePlayer(Game.turn,Game.pQ, Game.pL);
                        changeScore();
                        wait(speedV);
                        Game.turn = Game.nextTurn(Game.pQ);
                        break; 
                    }
                    //if the point is fine, but the score is high enough, we're testing for a loop
                    if (test)//a loop can only happen when the capacity of the playground is basically full, so it means a win...
                    {
                        if (Game.antiLoop(p))
                        {
                            turnLabel.Text = "Winner!";
                            Game.inGame = false;
                        }
                    }
                    test = Game.antiLoopInit(p);//this just checks if there's a point in doing the loop test, and activates it
                    //index 2 keeps a wave mark = how far the point is from the original
                    if (p[2] > depth)
                    {
                        wait(speedV);
                        if (Game.inGame == false || Game.exit) break;//in case we've started a new game while this was happening 
                        changeScore();
                        depth = p[2];
                        if (Game.tidyQ.Count > 0)
                            tidyUp(gObject);
                    }

                    Game.place(p, Game.turn, Game.pL,Game.pground,Game.map);
                    drawTile(gObject, p);
                }
                changeScore();
                //annihilation means that if a player lost all their current atoms, they're excluded from the game
                if (Game.pQ.Count == 1 && Game.annihilation) 
                {
                    turnLabel.Text = "Winner!";
                    Game.inGame = false;
                }
                
                wait(800);
                if (Game.inGame == false || Game.exit) break;
                Game.turn = Game.nextTurn(Game.pQ);
            }

        }

        //waits while accepting new events
        private void wait(int t) 
        {
            int pause = 50;
            int total = 0;
            while ((total += pause) < t)
            {
                Application.DoEvents();
                Thread.Sleep(pause);
            }
        }

        public void tidyUp(Graphics g) 
        {
            int[] p;
            while (Game.tidyQ.Count > 0) 
            {
                p = Game.tidyQ.Dequeue();
                Game.tidyUp(p);
                drawTile(g, p);
            }
        }

        //draw Play Ground - used for the initial drawing
        private void drawPG(Graphics g) 
        {
            for (int i = 0; i < Game.size; i++) {
                for (int j = 0; j < Game.size; j++) {
                    g.DrawImage(empty, j * unit + side, i * unit + side, unit, unit);
                    
                }
            }
        }

        private void drawTile(Graphics g,int[] p) {
            g.DrawImage(Game.turn.properI(p), p[1] * unit + side, p[0] * unit + side, unit, unit);
        }

        private void ruleButton_Click(object sender, EventArgs e)
        {
            Form rulesWindow = new rules();
            //rulesWindow = rules;
            rulesWindow.ShowDialog(this);
        }

        private void NGbutton_Click(object sender, EventArgs e)
        {
            Form NG = new NGform();
            NG.ShowDialog(this);
        }

        public void newScore() {
            string NA = "N/A";
            score1.Text = NA;
            score2.Text = NA;
            score3.Text = NA;
            score4.Text = NA;
        }

        public void changeScore() {
            foreach (Player p in Game.pL)
            {
                
                switch (p.number)
                {
                    case 1:
                        if (p.alive) score1.Text = "" + p.score;
                        else score1.Text = "N/A";
                        break;
                    case 2:
                        if (p.alive) score2.Text = "" + p.score;
                        else score2.Text = "N/A";
                        break;
                    case 3:
                        if (p.alive) score3.Text = "" + p.score;
                        else score3.Text = "N/A";
                        break;
                    case 4:
                        if (p.alive) score4.Text = "" + p.score;
                        else score4.Text = "N/A";
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.exit = true;
        }

        private void speed_ValueChanged(object sender, EventArgs e)
        {
            switch (speed.Value) 
            {
                case 5:
                    speedV = 100;
                    break;
                case 4:
                    speedV = 300;
                    break;
                case 3:
                    speedV = 600;
                    break;
                case 2:
                    speedV = 1200;
                    break;
                default:
                    speedV = 2000;
                    break;
            }
        }


        
        
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int row = (x - side) / unit;
            int col = (y - side) / unit;

            int[] tile;
            if (Game.mode == 1 && (Game.map[col, row] == 0 || Game.map[col,row] == Game.turn.number) && placed == false)
            {
                tile = new int[3] { col, row, 0 };
                Game.tileQ.Enqueue(tile);
                placed = true;
                
            }            
        }
    }
}
