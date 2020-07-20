namespace MusicPlayer
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
            this.combatButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox_Volume = new System.Windows.Forms.TextBox();
            this.textBox_nowPlaying = new System.Windows.Forms.TextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.button_Prev = new System.Windows.Forms.Button();
            this.button_Pause = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // combatButton
            // 
            this.combatButton.Location = new System.Drawing.Point(13, 13);
            this.combatButton.Name = "combatButton";
            this.combatButton.Size = new System.Drawing.Size(75, 23);
            this.combatButton.TabIndex = 0;
            this.combatButton.Text = "Combat";
            this.combatButton.UseVisualStyleBackColor = true;
            this.combatButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(13, 393);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox_Volume
            // 
            this.textBox_Volume.Location = new System.Drawing.Point(13, 367);
            this.textBox_Volume.Name = "textBox_Volume";
            this.textBox_Volume.Size = new System.Drawing.Size(100, 20);
            this.textBox_Volume.TabIndex = 2;
            // 
            // textBox_nowPlaying
            // 
            this.textBox_nowPlaying.Location = new System.Drawing.Point(120, 366);
            this.textBox_nowPlaying.Name = "textBox_nowPlaying";
            this.textBox_nowPlaying.Size = new System.Drawing.Size(273, 20);
            this.textBox_nowPlaying.TabIndex = 3;
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(13, 341);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(100, 20);
            this.textBox_Status.TabIndex = 4;
            // 
            // button_Prev
            // 
            this.button_Prev.Location = new System.Drawing.Point(13, 312);
            this.button_Prev.Name = "button_Prev";
            this.button_Prev.Size = new System.Drawing.Size(75, 23);
            this.button_Prev.TabIndex = 5;
            this.button_Prev.Text = "Previous";
            this.button_Prev.UseVisualStyleBackColor = true;
            this.button_Prev.Click += new System.EventHandler(this.button_Prev_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.Location = new System.Drawing.Point(94, 312);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(75, 23);
            this.button_Pause.TabIndex = 5;
            this.button_Pause.Text = "Pause";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(175, 312);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(75, 23);
            this.button_Next.TabIndex = 5;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(120, 393);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(273, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.button_Pause);
            this.Controls.Add(this.button_Prev);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.textBox_nowPlaying);
            this.Controls.Add(this.textBox_Volume);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.combatButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button combatButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox_Volume;
        private System.Windows.Forms.TextBox textBox_nowPlaying;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Button button_Prev;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

