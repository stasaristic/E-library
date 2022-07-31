
namespace E_biblioteka
{
    partial class Login
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
            this.korisnickoImeTb = new System.Windows.Forms.TextBox();
            this.LozinkaTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.potvrdiBtn = new System.Windows.Forms.Button();
            this.otkaziBtn = new System.Windows.Forms.Button();
            this.prikaziSifruCb = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-biblioteka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Korisničko ime:";
            // 
            // korisnickoImeTb
            // 
            this.korisnickoImeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.korisnickoImeTb.Location = new System.Drawing.Point(227, 210);
            this.korisnickoImeTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.korisnickoImeTb.Name = "korisnickoImeTb";
            this.korisnickoImeTb.Size = new System.Drawing.Size(217, 30);
            this.korisnickoImeTb.TabIndex = 2;
            // 
            // LozinkaTb
            // 
            this.LozinkaTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LozinkaTb.Location = new System.Drawing.Point(227, 276);
            this.LozinkaTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LozinkaTb.Name = "LozinkaTb";
            this.LozinkaTb.PasswordChar = '•';
            this.LozinkaTb.Size = new System.Drawing.Size(217, 30);
            this.LozinkaTb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 276);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lozinka:";
            // 
            // potvrdiBtn
            // 
            this.potvrdiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potvrdiBtn.Location = new System.Drawing.Point(143, 389);
            this.potvrdiBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.potvrdiBtn.Name = "potvrdiBtn";
            this.potvrdiBtn.Size = new System.Drawing.Size(100, 37);
            this.potvrdiBtn.TabIndex = 6;
            this.potvrdiBtn.Text = "Potvrdi";
            this.potvrdiBtn.UseVisualStyleBackColor = true;
            this.potvrdiBtn.Click += new System.EventHandler(this.potvrdiBtn_Click);
            // 
            // otkaziBtn
            // 
            this.otkaziBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otkaziBtn.Location = new System.Drawing.Point(268, 389);
            this.otkaziBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.otkaziBtn.Name = "otkaziBtn";
            this.otkaziBtn.Size = new System.Drawing.Size(100, 37);
            this.otkaziBtn.TabIndex = 7;
            this.otkaziBtn.Text = "Otkaži";
            this.otkaziBtn.UseVisualStyleBackColor = true;
            this.otkaziBtn.Click += new System.EventHandler(this.otkaziBtn_Click);
            // 
            // prikaziSifruCb
            // 
            this.prikaziSifruCb.AutoSize = true;
            this.prikaziSifruCb.Location = new System.Drawing.Point(341, 315);
            this.prikaziSifruCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prikaziSifruCb.Name = "prikaziSifruCb";
            this.prikaziSifruCb.Size = new System.Drawing.Size(103, 21);
            this.prikaziSifruCb.TabIndex = 8;
            this.prikaziSifruCb.Text = "Prikaži šifru";
            this.prikaziSifruCb.UseVisualStyleBackColor = true;
            this.prikaziSifruCb.CheckedChanged += new System.EventHandler(this.prikaziSifruCb_CheckedChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(136, 363);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 24);
            this.label7.TabIndex = 24;
            this.label7.Text = "Nemate nalog? Prijavite se.";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(499, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 39);
            this.label4.TabIndex = 25;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.prikaziSifruCb);
            this.Controls.Add(this.otkaziBtn);
            this.Controls.Add(this.potvrdiBtn);
            this.Controls.Add(this.LozinkaTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.korisnickoImeTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox korisnickoImeTb;
        private System.Windows.Forms.TextBox LozinkaTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button potvrdiBtn;
        private System.Windows.Forms.Button otkaziBtn;
        private System.Windows.Forms.CheckBox prikaziSifruCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}

