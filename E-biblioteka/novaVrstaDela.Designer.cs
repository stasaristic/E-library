
namespace E_biblioteka
{
    partial class novaVrstaDela
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
            this.zatvoriBtn = new System.Windows.Forms.Button();
            this.dodajBtn = new System.Windows.Forms.Button();
            this.dodajVrstuTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zatvoriBtn
            // 
            this.zatvoriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zatvoriBtn.Location = new System.Drawing.Point(156, 139);
            this.zatvoriBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zatvoriBtn.Name = "zatvoriBtn";
            this.zatvoriBtn.Size = new System.Drawing.Size(114, 33);
            this.zatvoriBtn.TabIndex = 33;
            this.zatvoriBtn.Text = "Zatvori";
            this.zatvoriBtn.UseVisualStyleBackColor = true;
            this.zatvoriBtn.Click += new System.EventHandler(this.zatvoriBtn_Click);
            // 
            // dodajBtn
            // 
            this.dodajBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajBtn.Location = new System.Drawing.Point(27, 138);
            this.dodajBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dodajBtn.Name = "dodajBtn";
            this.dodajBtn.Size = new System.Drawing.Size(102, 34);
            this.dodajBtn.TabIndex = 32;
            this.dodajBtn.Text = "Dodaj";
            this.dodajBtn.UseVisualStyleBackColor = true;
            this.dodajBtn.Click += new System.EventHandler(this.dodajBtn_Click);
            // 
            // dodajVrstuTb
            // 
            this.dodajVrstuTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajVrstuTb.Location = new System.Drawing.Point(27, 49);
            this.dodajVrstuTb.Margin = new System.Windows.Forms.Padding(4);
            this.dodajVrstuTb.Multiline = true;
            this.dodajVrstuTb.Name = "dodajVrstuTb";
            this.dodajVrstuTb.Size = new System.Drawing.Size(243, 55);
            this.dodajVrstuTb.TabIndex = 95;
            // 
            // novaVrstaDela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 207);
            this.Controls.Add(this.dodajVrstuTb);
            this.Controls.Add(this.zatvoriBtn);
            this.Controls.Add(this.dodajBtn);
            this.Name = "novaVrstaDela";
            this.Text = "novaVrstaDela";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button zatvoriBtn;
        private System.Windows.Forms.Button dodajBtn;
        private System.Windows.Forms.TextBox dodajVrstuTb;
    }
}