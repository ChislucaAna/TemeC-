namespace EggCatcher
{
    partial class EggCatcher
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
            this.basket = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.basket)).BeginInit();
            this.SuspendLayout();
            // 
            // basket
            // 
            this.basket.Image = global::EggCatcher.Properties.Resources.basket;
            this.basket.Location = new System.Drawing.Point(225, 424);
            this.basket.Name = "basket";
            this.basket.Size = new System.Drawing.Size(75, 50);
            this.basket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.basket.TabIndex = 0;
            this.basket.TabStop = false;
            this.basket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.basket_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.eggmovement);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.eggspawner);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // EggCatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.basket);
            this.Name = "EggCatcher";
            this.Text = "EggCathcer";
            this.Load += new System.EventHandler(this.EggCatcher_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EggCatcher_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EggCatcher_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.basket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox basket;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
    }
}

