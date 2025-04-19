namespace ZombieShooter
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spawner = new System.Windows.Forms.Timer(this.components);
            this.moveZombies = new System.Windows.Forms.Timer(this.components);
            this.moveAmmo = new System.Windows.Forms.Timer(this.components);
            this.ammoPicturebox = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ammoPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ammo:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(708, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(206, 23);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kills:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(615, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Health:";
            // 
            // spawner
            // 
            this.spawner.Interval = 3000;
            this.spawner.Tick += new System.EventHandler(this.spawner_Tick);
            // 
            // moveZombies
            // 
            this.moveZombies.Interval = 200;
            this.moveZombies.Tick += new System.EventHandler(this.moveZombies_Tick);
            // 
            // moveAmmo
            // 
            this.moveAmmo.Tick += new System.EventHandler(this.moveAmmo_Tick);
            // 
            // ammoPicturebox
            // 
            this.ammoPicturebox.Image = global::ZombieShooter.Properties.Resources.ammo_Image;
            this.ammoPicturebox.Location = new System.Drawing.Point(72, 77);
            this.ammoPicturebox.Name = "ammoPicturebox";
            this.ammoPicturebox.Size = new System.Drawing.Size(46, 50);
            this.ammoPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ammoPicturebox.TabIndex = 7;
            this.ammoPicturebox.TabStop = false;
            this.ammoPicturebox.Visible = false;
            // 
            // player
            // 
            this.player.Image = global::ZombieShooter.Properties.Resources.down;
            this.player.Location = new System.Drawing.Point(414, 196);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(62, 82);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(926, 533);
            this.Controls.Add(this.ammoPicturebox);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ammoPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer spawner;
        private System.Windows.Forms.Timer moveZombies;
        private System.Windows.Forms.Timer moveAmmo;
        private System.Windows.Forms.PictureBox ammoPicturebox;
    }
}

