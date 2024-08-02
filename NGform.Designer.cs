namespace ExplodingAtoms
{
    partial class NGform
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
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeBox = new System.Windows.Forms.NumericUpDown();
            this.sizeNote = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.playerPick1 = new System.Windows.Forms.DomainUpDown();
            this.playerPick2 = new System.Windows.Forms.DomainUpDown();
            this.playerPick3 = new System.Windows.Forms.DomainUpDown();
            this.playerPick4 = new System.Windows.Forms.DomainUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.overflowBox = new System.Windows.Forms.CheckBox();
            this.annihilationBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.Location = new System.Drawing.Point(23, 48);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(124, 20);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "Playground size:";
            // 
            // sizeBox
            // 
            this.sizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeBox.Location = new System.Drawing.Point(153, 48);
            this.sizeBox.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.sizeBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(36, 22);
            this.sizeBox.TabIndex = 1;
            this.sizeBox.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // sizeNote
            // 
            this.sizeNote.AutoSize = true;
            this.sizeNote.Location = new System.Drawing.Point(195, 53);
            this.sizeNote.Name = "sizeNote";
            this.sizeNote.Size = new System.Drawing.Size(78, 13);
            this.sizeNote.TabIndex = 4;
            this.sizeNote.Text = "( 4X4 - 16X16 )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(44, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Player1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(44, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Player2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(44, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Player3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(44, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Player4";
            // 
            // playerPick1
            // 
            this.playerPick1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPick1.Items.Add("N/A");
            this.playerPick1.Items.Add("Human");
            this.playerPick1.Items.Add("Computer");
            this.playerPick1.Location = new System.Drawing.Point(118, 120);
            this.playerPick1.Name = "playerPick1";
            this.playerPick1.Size = new System.Drawing.Size(87, 22);
            this.playerPick1.TabIndex = 3;
            this.playerPick1.Text = "choose";
            // 
            // playerPick2
            // 
            this.playerPick2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPick2.Items.Add("N/A");
            this.playerPick2.Items.Add("Human");
            this.playerPick2.Items.Add("Computer");
            this.playerPick2.Location = new System.Drawing.Point(118, 157);
            this.playerPick2.Name = "playerPick2";
            this.playerPick2.Size = new System.Drawing.Size(87, 22);
            this.playerPick2.TabIndex = 4;
            this.playerPick2.Text = "choose";
            // 
            // playerPick3
            // 
            this.playerPick3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPick3.Items.Add("N/A");
            this.playerPick3.Items.Add("Human");
            this.playerPick3.Items.Add("Computer");
            this.playerPick3.Location = new System.Drawing.Point(118, 196);
            this.playerPick3.Name = "playerPick3";
            this.playerPick3.Size = new System.Drawing.Size(87, 22);
            this.playerPick3.TabIndex = 5;
            this.playerPick3.Text = "choose";
            // 
            // playerPick4
            // 
            this.playerPick4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPick4.Items.Add("N/A");
            this.playerPick4.Items.Add("Human");
            this.playerPick4.Items.Add("Computer");
            this.playerPick4.Location = new System.Drawing.Point(118, 239);
            this.playerPick4.Name = "playerPick4";
            this.playerPick4.Size = new System.Drawing.Size(87, 22);
            this.playerPick4.TabIndex = 6;
            this.playerPick4.Text = "choose";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(290, 196);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(290, 238);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // overflowBox
            // 
            this.overflowBox.AutoSize = true;
            this.overflowBox.Location = new System.Drawing.Point(290, 96);
            this.overflowBox.Name = "overflowBox";
            this.overflowBox.Size = new System.Drawing.Size(66, 17);
            this.overflowBox.TabIndex = 11;
            this.overflowBox.Text = "overflow";
            this.overflowBox.UseVisualStyleBackColor = true;
            // 
            // annihilationBox
            // 
            this.annihilationBox.AutoSize = true;
            this.annihilationBox.Location = new System.Drawing.Point(290, 141);
            this.annihilationBox.Name = "annihilationBox";
            this.annihilationBox.Size = new System.Drawing.Size(79, 17);
            this.annihilationBox.TabIndex = 12;
            this.annihilationBox.Text = "annihilation";
            this.annihilationBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "(lose all atoms, lose the game)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "(additional electrons stay in the game)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "default: N/A";
            // 
            // NGform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 315);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.annihilationBox);
            this.Controls.Add(this.overflowBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playerPick4);
            this.Controls.Add(this.playerPick3);
            this.Controls.Add(this.playerPick2);
            this.Controls.Add(this.playerPick1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeNote);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.sizeLabel);
            this.Name = "NGform";
            this.Text = "NGform";
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown sizeBox;
        private System.Windows.Forms.Label sizeNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DomainUpDown playerPick1;
        private System.Windows.Forms.DomainUpDown playerPick2;
        private System.Windows.Forms.DomainUpDown playerPick3;
        private System.Windows.Forms.DomainUpDown playerPick4;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox overflowBox;
        private System.Windows.Forms.CheckBox annihilationBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}