namespace CoffeeShop
{
    partial class Percentage
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Percentage));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            MyProgress = new ProgressBar();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            procent = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(216, 41);
            label1.Name = "label1";
            label1.Size = new Size(496, 34);
            label1.TabIndex = 0;
            label1.Text = "Coffee Shop Management System";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(375, 140);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // MyProgress
            // 
            MyProgress.Location = new Point(22, 385);
            MyProgress.Name = "MyProgress";
            MyProgress.Size = new Size(870, 29);
            MyProgress.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(22, 348);
            label2.Name = "label2";
            label2.Size = new Size(126, 28);
            label2.TabIndex = 3;
            label2.Text = "Loading...";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // procent
            // 
            procent.AutoSize = true;
            procent.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            procent.ForeColor = SystemColors.GrayText;
            procent.Location = new Point(154, 348);
            procent.Name = "procent";
            procent.Size = new Size(37, 28);
            procent.TabIndex = 4;
            procent.Text = "%";
            // 
            // Percentage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(920, 426);
            Controls.Add(procent);
            Controls.Add(label2);
            Controls.Add(MyProgress);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Percentage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Percentage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private ProgressBar MyProgress;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label procent;
    }
}