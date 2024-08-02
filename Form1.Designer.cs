namespace ExplodingAtoms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InterfacePanel = new System.Windows.Forms.Panel();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.score4 = new System.Windows.Forms.Label();
            this.score3 = new System.Windows.Forms.Label();
            this.score2 = new System.Windows.Forms.Label();
            this.score1 = new System.Windows.Forms.Label();
            this.NGbutton = new System.Windows.Forms.Button();
            this.score = new System.Windows.Forms.Label();
            this.ruleButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.Panel();
            this.turnLabel = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.NumericUpDown();
            this.speedLabel = new System.Windows.Forms.Label();
            this.InterfacePanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // InterfacePanel
            // 
            this.InterfacePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterfacePanel.Controls.Add(this.speedLabel);
            this.InterfacePanel.Controls.Add(this.speed);
            this.InterfacePanel.Controls.Add(this.turnLabel);
            this.InterfacePanel.Controls.Add(this.scorePanel);
            this.InterfacePanel.Controls.Add(this.NGbutton);
            this.InterfacePanel.Controls.Add(this.score);
            this.InterfacePanel.Controls.Add(this.ruleButton);
            this.InterfacePanel.Location = new System.Drawing.Point(1, 2);
            this.InterfacePanel.Name = "InterfacePanel";
            this.InterfacePanel.Size = new System.Drawing.Size(700, 52);
            this.InterfacePanel.TabIndex = 0;
            // 
            // scorePanel
            // 
            this.scorePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scorePanel.Controls.Add(this.score4);
            this.scorePanel.Controls.Add(this.score3);
            this.scorePanel.Controls.Add(this.score2);
            this.scorePanel.Controls.Add(this.score1);
            this.scorePanel.Location = new System.Drawing.Point(232, 12);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(236, 28);
            this.scorePanel.TabIndex = 5;
            // 
            // score4
            // 
            this.score4.AutoSize = true;
            this.score4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score4.ForeColor = System.Drawing.Color.Red;
            this.score4.Location = new System.Drawing.Point(175, 7);
            this.score4.Name = "score4";
            this.score4.Size = new System.Drawing.Size(31, 16);
            this.score4.TabIndex = 3;
            this.score4.Text = "N/A";
            // 
            // score3
            // 
            this.score3.AutoSize = true;
            this.score3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score3.ForeColor = System.Drawing.Color.Orange;
            this.score3.Location = new System.Drawing.Point(118, 7);
            this.score3.Name = "score3";
            this.score3.Size = new System.Drawing.Size(31, 16);
            this.score3.TabIndex = 2;
            this.score3.Text = "N/A";
            // 
            // score2
            // 
            this.score2.AutoSize = true;
            this.score2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2.ForeColor = System.Drawing.Color.Lime;
            this.score2.Location = new System.Drawing.Point(57, 7);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(31, 16);
            this.score2.TabIndex = 1;
            this.score2.Text = "N/A";
            // 
            // score1
            // 
            this.score1.AutoSize = true;
            this.score1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.score1.Location = new System.Drawing.Point(3, 7);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(31, 16);
            this.score1.TabIndex = 0;
            this.score1.Text = "N/A";
            // 
            // NGbutton
            // 
            this.NGbutton.Location = new System.Drawing.Point(601, 17);
            this.NGbutton.Name = "NGbutton";
            this.NGbutton.Size = new System.Drawing.Size(79, 22);
            this.NGbutton.TabIndex = 4;
            this.NGbutton.Text = "New Game";
            this.NGbutton.UseVisualStyleBackColor = true;
            this.NGbutton.Click += new System.EventHandler(this.NGbutton_Click);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(179, 21);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(47, 16);
            this.score.TabIndex = 3;
            this.score.Text = "Score:";
            // 
            // ruleButton
            // 
            this.ruleButton.Location = new System.Drawing.Point(11, 17);
            this.ruleButton.Name = "ruleButton";
            this.ruleButton.Size = new System.Drawing.Size(81, 22);
            this.ruleButton.TabIndex = 2;
            this.ruleButton.Text = "Show Rules";
            this.ruleButton.UseVisualStyleBackColor = true;
            this.ruleButton.Click += new System.EventHandler(this.ruleButton_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(0, 56);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(700, 700);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.playGround_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.turnLabel.Location = new System.Drawing.Point(112, 18);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(61, 20);
            this.turnLabel.TabIndex = 6;
            this.turnLabel.Text = "Player1";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(538, 20);
            this.speed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(33, 20);
            this.speed.TabIndex = 7;
            this.speed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.speed.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(493, 22);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(39, 13);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "speed:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(702, 758);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.InterfacePanel);
            this.Name = "Form1";
            this.Text = "Exploding Atoms";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.InterfacePanel.ResumeLayout(false);
            this.InterfacePanel.PerformLayout();
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InterfacePanel;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Button ruleButton;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label score4;
        private System.Windows.Forms.Label score3;
        private System.Windows.Forms.Label score2;
        private System.Windows.Forms.Label score1;
        private System.Windows.Forms.Button NGbutton;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.NumericUpDown speed;
    }
}

