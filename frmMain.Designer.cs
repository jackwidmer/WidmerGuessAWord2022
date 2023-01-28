namespace WidmerGuessAWord2022
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.txtTries = new System.Windows.Forms.TextBox();
            this.lblLettersUsed = new System.Windows.Forms.Label();
            this.btnGuess = new System.Windows.Forms.Button();
            this.lblWord = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.chkSoundEffects = new System.Windows.Forms.CheckBox();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guess a letter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of tries:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Letters used:";
            // 
            // txtGuess
            // 
            this.txtGuess.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtGuess.Location = new System.Drawing.Point(118, 119);
            this.txtGuess.MaxLength = 1;
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(49, 22);
            this.txtGuess.TabIndex = 3;
            this.txtGuess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuess_KeyDown);
            // 
            // txtTries
            // 
            this.txtTries.Location = new System.Drawing.Point(118, 168);
            this.txtTries.Name = "txtTries";
            this.txtTries.ReadOnly = true;
            this.txtTries.Size = new System.Drawing.Size(49, 22);
            this.txtTries.TabIndex = 4;
            this.txtTries.TabStop = false;
            // 
            // lblLettersUsed
            // 
            this.lblLettersUsed.AutoSize = true;
            this.lblLettersUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLettersUsed.Location = new System.Drawing.Point(113, 272);
            this.lblLettersUsed.Name = "lblLettersUsed";
            this.lblLettersUsed.Size = new System.Drawing.Size(64, 25);
            this.lblLettersUsed.TabIndex = 5;
            this.lblLettersUsed.Text = "label4";
            // 
            // btnGuess
            // 
            this.btnGuess.Location = new System.Drawing.Point(220, 122);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(107, 68);
            this.btnGuess.TabIndex = 6;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(12, 72);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(130, 23);
            this.lblWord.TabIndex = 7;
            this.lblWord.Text = "hiddenword";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "status line";
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(375, 122);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(112, 68);
            this.btnPlayAgain.TabIndex = 9;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Player Name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(108, 28);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(166, 22);
            this.txtPlayerName.TabIndex = 11;
            // 
            // chkSoundEffects
            // 
            this.chkSoundEffects.AutoSize = true;
            this.chkSoundEffects.Location = new System.Drawing.Point(303, 28);
            this.chkSoundEffects.Name = "chkSoundEffects";
            this.chkSoundEffects.Size = new System.Drawing.Size(111, 20);
            this.chkSoundEffects.TabIndex = 12;
            this.chkSoundEffects.Text = "Sound Effects";
            this.chkSoundEffects.UseVisualStyleBackColor = true;
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefinition.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDefinition.Location = new System.Drawing.Point(13, 338);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(189, 23);
            this.lblDefinition.TabIndex = 13;
            this.lblDefinition.Text = "Definition goes here...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 407);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.chkSoundEffects);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.lblLettersUsed);
            this.Controls.Add(this.txtTries);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Guess A Word";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.TextBox txtTries;
        private System.Windows.Forms.Label lblLettersUsed;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.CheckBox chkSoundEffects;
        private System.Windows.Forms.Label lblDefinition;
    }
}

