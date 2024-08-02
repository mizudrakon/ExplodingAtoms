using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingAtoms
{
    public partial class NGform : Form
    {
        public List<Player> L = new List<Player>();
        public NGform()
        {
            InitializeComponent();
            playerPick1.SelectedIndex = 0;
            playerPick2.SelectedIndex = 0;
            playerPick3.SelectedIndex = 0;
            playerPick4.SelectedIndex = 0;
        }

        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            NGform.ActiveForm.Dispose();
        }

        /*
        private void overflowBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Game.ovflow == false) Game.ovflow = true;
            else Game.ovflow = false;
        }

        private void annihilationBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Game.annihilation == false) Game.annihilation = true;
            else Game.annihilation = false;
        }
        */

        public void addPlayer(int number, int index) 
        {
            Player P = new Player(number, index);
            L.Add(P);
        }

        public void enqueueP() 
        {
            Game.pQ = new Queue<Player>();
            for (int i = 0; i < Game.pL.Count; i++) 
            {
                Game.pQ.Enqueue(Game.pL[i]);
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            //yeah, I think I could have iterated over them somehow, but can't figure it out
            
            
            if (playerPick1.SelectedIndex != 0) addPlayer(1, playerPick1.SelectedIndex);
            if (playerPick2.SelectedIndex != 0) addPlayer(2, playerPick2.SelectedIndex);
            if (playerPick3.SelectedIndex != 0) addPlayer(3, playerPick3.SelectedIndex);
            if (playerPick4.SelectedIndex != 0) addPlayer(4, playerPick4.SelectedIndex);
            
            if (L.Count > 0)
            {
                //Game.pL = new List<Player>();
                Game.pL = L; 
                enqueueP();
                Game.tileQ = new Queue<int[]>();
                if (annihilationBox.Checked) Game.annihilation = true;
                if (overflowBox.Checked) Game.ovflow = true;
                Game.size = (int)sizeBox.Value;
                Game.inGame = false;
                Game.cont = true;
                //Game.exit = true;
                Game.mode = 1;
                NGform.ActiveForm.Dispose();
            }
            
        }
    }
}
