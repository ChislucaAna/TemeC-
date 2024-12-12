namespace RGB_Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            trackBar1 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(12, 226);
            label1.Name = "label1";
            label1.Size = new Size(48, 30);
            label1.TabIndex = 0;
            label1.Text = "Red";
            // 
            // numericUpDown1
            // 
            numericUpDown1.ForeColor = Color.Red;
            numericUpDown1.Location = new Point(99, 233);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(181, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += generate_rgb;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(99, 333);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(181, 45);
            trackBar1.TabIndex = 2;
            trackBar1.ValueChanged += generate_rgb;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(12, 334);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 3;
            label2.Text = "Opacity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(12, 364);
            label3.Name = "label3";
            label3.Size = new Size(24, 30);
            label3.TabIndex = 4;
            label3.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(51, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.ForeColor = Color.FromArgb(0, 192, 0);
            numericUpDown2.Location = new Point(99, 268);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(181, 23);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.ValueChanged += generate_rgb;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.ForeColor = Color.FromArgb(0, 192, 0);
            label4.Location = new Point(12, 261);
            label4.Name = "label4";
            label4.Size = new Size(68, 30);
            label4.TabIndex = 6;
            label4.Text = "Green";
            // 
            // numericUpDown3
            // 
            numericUpDown3.ForeColor = Color.Blue;
            numericUpDown3.Location = new Point(99, 304);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(181, 23);
            numericUpDown3.TabIndex = 9;
            numericUpDown3.ValueChanged += generate_rgb;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(12, 303);
            label5.Name = "label5";
            label5.Size = new Size(53, 30);
            label5.TabIndex = 8;
            label5.Text = "Blue";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 432);
            Controls.Add(numericUpDown3);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(trackBar1);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDown1;
        private TrackBar trackBar1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Label label5;
    }
}
