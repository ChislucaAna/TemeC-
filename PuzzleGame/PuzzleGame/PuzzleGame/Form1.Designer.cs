namespace PuzzleGame
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
            this.fullImage = new System.Windows.Forms.PictureBox();
            this.pictureBox01 = new System.Windows.Forms.PictureBox();
            this.pictureBox00 = new System.Windows.Forms.PictureBox();
            this.pictureBox02 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.secunde = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fullImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            this.SuspendLayout();
            // 
            // fullImage
            // 
            this.fullImage.Image = global::PuzzleGame.Properties.Resources.puzzle1;
            this.fullImage.Location = new System.Drawing.Point(479, 12);
            this.fullImage.Name = "fullImage";
            this.fullImage.Size = new System.Drawing.Size(300, 300);
            this.fullImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fullImage.TabIndex = 0;
            this.fullImage.TabStop = false;
            this.fullImage.Tag = "fullI";
            // 
            // pictureBox01
            // 
            this.pictureBox01.Location = new System.Drawing.Point(151, 67);
            this.pictureBox01.Name = "pictureBox01";
            this.pictureBox01.Size = new System.Drawing.Size(100, 100);
            this.pictureBox01.TabIndex = 1;
            this.pictureBox01.TabStop = false;
            this.pictureBox01.Tag = "piece";
            this.pictureBox01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox00
            // 
            this.pictureBox00.Location = new System.Drawing.Point(47, 67);
            this.pictureBox00.Name = "pictureBox00";
            this.pictureBox00.Size = new System.Drawing.Size(100, 100);
            this.pictureBox00.TabIndex = 1;
            this.pictureBox00.TabStop = false;
            this.pictureBox00.Tag = "piece";
            this.pictureBox00.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox02
            // 
            this.pictureBox02.Location = new System.Drawing.Point(257, 67);
            this.pictureBox02.Name = "pictureBox02";
            this.pictureBox02.Size = new System.Drawing.Size(100, 100);
            this.pictureBox02.TabIndex = 1;
            this.pictureBox02.TabStop = false;
            this.pictureBox02.Tag = "piece";
            this.pictureBox02.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(47, 173);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(100, 100);
            this.pictureBox10.TabIndex = 1;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "piece";
            this.pictureBox10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Location = new System.Drawing.Point(153, 173);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(100, 100);
            this.pictureBox11.TabIndex = 1;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Tag = "piece";
            this.pictureBox11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Location = new System.Drawing.Point(257, 173);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(100, 100);
            this.pictureBox12.TabIndex = 1;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "piece";
            this.pictureBox12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox20
            // 
            this.pictureBox20.Location = new System.Drawing.Point(47, 279);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(100, 100);
            this.pictureBox20.TabIndex = 1;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Tag = "piece";
            this.pictureBox20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox21
            // 
            this.pictureBox21.Location = new System.Drawing.Point(153, 279);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(100, 100);
            this.pictureBox21.TabIndex = 1;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Tag = "piece";
            this.pictureBox21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // pictureBox22
            // 
            this.pictureBox22.Location = new System.Drawing.Point(257, 279);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(100, 100);
            this.pictureBox22.TabIndex = 1;
            this.pictureBox22.TabStop = false;
            this.pictureBox22.Tag = "piece";
            this.pictureBox22.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox22_MouseDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(443, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Shuffle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(565, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 54);
            this.button2.TabIndex = 3;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(687, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "Quit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // secunde
            // 
            this.secunde.Interval = 1000;
            this.secunde.Tick += new System.EventHandler(this.secunde_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(575, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox02);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox00);
            this.Controls.Add(this.pictureBox01);
            this.Controls.Add(this.fullImage);
            this.Name = "Form1";
            this.Text = "PuzzleGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fullImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fullImage;
        private System.Windows.Forms.PictureBox pictureBox01;
        private System.Windows.Forms.PictureBox pictureBox00;
        private System.Windows.Forms.PictureBox pictureBox02;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer secunde;
        private System.Windows.Forms.Label label1;
    }
}

