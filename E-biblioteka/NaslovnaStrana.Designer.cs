
namespace E_biblioteka
{
    partial class NaslovnaStrana
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.promeniBtn = new System.Windows.Forms.Button();
            this.zatvoriBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(39, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(409, 387);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // promeniBtn
            // 
            this.promeniBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promeniBtn.Location = new System.Drawing.Point(39, 432);
            this.promeniBtn.Margin = new System.Windows.Forms.Padding(4);
            this.promeniBtn.Name = "promeniBtn";
            this.promeniBtn.Size = new System.Drawing.Size(141, 57);
            this.promeniBtn.TabIndex = 35;
            this.promeniBtn.Text = "Promeni";
            this.promeniBtn.UseVisualStyleBackColor = true;
            this.promeniBtn.Click += new System.EventHandler(this.promeniBtn_Click);
            // 
            // zatvoriBtn
            // 
            this.zatvoriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zatvoriBtn.Location = new System.Drawing.Point(307, 432);
            this.zatvoriBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zatvoriBtn.Name = "zatvoriBtn";
            this.zatvoriBtn.Size = new System.Drawing.Size(141, 57);
            this.zatvoriBtn.TabIndex = 36;
            this.zatvoriBtn.Text = "Zatvori";
            this.zatvoriBtn.UseVisualStyleBackColor = true;
            this.zatvoriBtn.Click += new System.EventHandler(this.zatvoriBtn_Click);
            // 
            // NaslovnaStrana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 516);
            this.Controls.Add(this.zatvoriBtn);
            this.Controls.Add(this.promeniBtn);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NaslovnaStrana";
            this.Text = "NaslovnaStrana";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button promeniBtn;
        private System.Windows.Forms.Button zatvoriBtn;
    }
}