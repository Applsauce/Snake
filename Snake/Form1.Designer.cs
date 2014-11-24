namespace Snake
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbxMeny = new System.Windows.Forms.GroupBox();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.tbxHighScore = new System.Windows.Forms.TextBox();
            this.lblPoäng = new System.Windows.Forms.Label();
            this.tbxPoäng = new System.Windows.Forms.TextBox();
            this.btnNyttSpel = new System.Windows.Forms.Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.SliderSpeed = new System.Windows.Forms.TrackBar();
            this.lblHastighet = new System.Windows.Forms.Label();
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.gbxMeny.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // gbxMeny
            // 
            this.gbxMeny.BackColor = System.Drawing.Color.Sienna;
            this.gbxMeny.Controls.Add(this.wmp);
            this.gbxMeny.Controls.Add(this.lblHastighet);
            this.gbxMeny.Controls.Add(this.SliderSpeed);
            this.gbxMeny.Controls.Add(this.lblHighscore);
            this.gbxMeny.Controls.Add(this.tbxHighScore);
            this.gbxMeny.Controls.Add(this.lblPoäng);
            this.gbxMeny.Controls.Add(this.tbxPoäng);
            this.gbxMeny.Controls.Add(this.btnNyttSpel);
            this.gbxMeny.Controls.Add(this.lblTitel);
            this.gbxMeny.Enabled = false;
            this.gbxMeny.Location = new System.Drawing.Point(12, 12);
            this.gbxMeny.Name = "gbxMeny";
            this.gbxMeny.Size = new System.Drawing.Size(274, 252);
            this.gbxMeny.TabIndex = 1;
            this.gbxMeny.TabStop = false;
            this.gbxMeny.Visible = false;
            // 
            // lblHighscore
            // 
            this.lblHighscore.AutoSize = true;
            this.lblHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscore.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHighscore.Location = new System.Drawing.Point(24, 153);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(96, 22);
            this.lblHighscore.TabIndex = 5;
            this.lblHighscore.Text = "Highscore:";
            // 
            // tbxHighScore
            // 
            this.tbxHighScore.Location = new System.Drawing.Point(138, 155);
            this.tbxHighScore.Multiline = true;
            this.tbxHighScore.Name = "tbxHighScore";
            this.tbxHighScore.ReadOnly = true;
            this.tbxHighScore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxHighScore.Size = new System.Drawing.Size(89, 72);
            this.tbxHighScore.TabIndex = 4;
            // 
            // lblPoäng
            // 
            this.lblPoäng.AutoSize = true;
            this.lblPoäng.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoäng.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPoäng.Location = new System.Drawing.Point(26, 129);
            this.lblPoäng.Name = "lblPoäng";
            this.lblPoäng.Size = new System.Drawing.Size(67, 22);
            this.lblPoäng.TabIndex = 3;
            this.lblPoäng.Text = "Poäng:";
            // 
            // tbxPoäng
            // 
            this.tbxPoäng.Location = new System.Drawing.Point(138, 129);
            this.tbxPoäng.Name = "tbxPoäng";
            this.tbxPoäng.ReadOnly = true;
            this.tbxPoäng.Size = new System.Drawing.Size(89, 20);
            this.tbxPoäng.TabIndex = 2;
            // 
            // btnNyttSpel
            // 
            this.btnNyttSpel.BackColor = System.Drawing.Color.White;
            this.btnNyttSpel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNyttSpel.ForeColor = System.Drawing.Color.Black;
            this.btnNyttSpel.Location = new System.Drawing.Point(30, 84);
            this.btnNyttSpel.Name = "btnNyttSpel";
            this.btnNyttSpel.Size = new System.Drawing.Size(197, 39);
            this.btnNyttSpel.TabIndex = 1;
            this.btnNyttSpel.Text = "Nytt Spel";
            this.btnNyttSpel.UseVisualStyleBackColor = false;
            this.btnNyttSpel.Click += new System.EventHandler(this.btnNyttSpel_Click);
            this.btnNyttSpel.Enter += new System.EventHandler(this.btnNyttSpel_Enter);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitel.Location = new System.Drawing.Point(26, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(201, 22);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Vill du spela lite Snake?";
            // 
            // SliderSpeed
            // 
            this.SliderSpeed.Location = new System.Drawing.Point(28, 204);
            this.SliderSpeed.Name = "SliderSpeed";
            this.SliderSpeed.Size = new System.Drawing.Size(104, 42);
            this.SliderSpeed.TabIndex = 6;
            this.SliderSpeed.Value = 5;
            this.SliderSpeed.Scroll += new System.EventHandler(this.SliderSpeed_Scroll);
            // 
            // lblHastighet
            // 
            this.lblHastighet.AutoSize = true;
            this.lblHastighet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHastighet.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHastighet.Location = new System.Drawing.Point(26, 179);
            this.lblHastighet.Name = "lblHastighet";
            this.lblHastighet.Size = new System.Drawing.Size(91, 22);
            this.lblHastighet.TabIndex = 7;
            this.lblHastighet.Text = "Hastighet:";
            // 
            // wmp
            // 
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(16, 33);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(237, 45);
            this.wmp.TabIndex = 8;
            this.wmp.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.wmp_ClickEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(298, 272);
            this.Controls.Add(this.gbxMeny);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.gbxMeny.ResumeLayout(false);
            this.gbxMeny.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox gbxMeny;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Button btnNyttSpel;
        private System.Windows.Forms.Label lblPoäng;
        private System.Windows.Forms.TextBox tbxPoäng;
        private System.Windows.Forms.TextBox tbxHighScore;
        private System.Windows.Forms.Label lblHighscore;
        private System.Windows.Forms.TrackBar SliderSpeed;
        private System.Windows.Forms.Label lblHastighet;
        private AxWMPLib.AxWindowsMediaPlayer wmp;
    }
}

