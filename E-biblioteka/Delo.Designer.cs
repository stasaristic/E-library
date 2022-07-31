
namespace E_biblioteka
{
    partial class Delo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rezervisiBtn = new System.Windows.Forms.Button();
            this.zatvoriBtn = new System.Windows.Forms.Button();
            this.naslov_godinaLbl = new System.Windows.Forms.Label();
            this.vrsta_izdavacLbl = new System.Windows.Forms.Label();
            this.isbnLbl = new System.Windows.Forms.Label();
            this.dostupnaLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.autoriDgv = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoriDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // rezervisiBtn
            // 
            this.rezervisiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezervisiBtn.Location = new System.Drawing.Point(61, 432);
            this.rezervisiBtn.Margin = new System.Windows.Forms.Padding(4);
            this.rezervisiBtn.Name = "rezervisiBtn";
            this.rezervisiBtn.Size = new System.Drawing.Size(141, 57);
            this.rezervisiBtn.TabIndex = 19;
            this.rezervisiBtn.Text = "Rezerviši";
            this.rezervisiBtn.UseVisualStyleBackColor = true;
            this.rezervisiBtn.Click += new System.EventHandler(this.rezervisiBtn_Click);
            // 
            // zatvoriBtn
            // 
            this.zatvoriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zatvoriBtn.Location = new System.Drawing.Point(234, 432);
            this.zatvoriBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zatvoriBtn.Name = "zatvoriBtn";
            this.zatvoriBtn.Size = new System.Drawing.Size(128, 57);
            this.zatvoriBtn.TabIndex = 20;
            this.zatvoriBtn.Text = "Zatvori";
            this.zatvoriBtn.UseVisualStyleBackColor = true;
            this.zatvoriBtn.Click += new System.EventHandler(this.zatvoriBtn_Click);
            // 
            // naslov_godinaLbl
            // 
            this.naslov_godinaLbl.AutoSize = true;
            this.naslov_godinaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naslov_godinaLbl.Location = new System.Drawing.Point(57, 35);
            this.naslov_godinaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.naslov_godinaLbl.Name = "naslov_godinaLbl";
            this.naslov_godinaLbl.Size = new System.Drawing.Size(183, 29);
            this.naslov_godinaLbl.TabIndex = 21;
            this.naslov_godinaLbl.Text = "Naslov (godina)";
            // 
            // vrsta_izdavacLbl
            // 
            this.vrsta_izdavacLbl.AutoSize = true;
            this.vrsta_izdavacLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrsta_izdavacLbl.Location = new System.Drawing.Point(57, 77);
            this.vrsta_izdavacLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vrsta_izdavacLbl.Name = "vrsta_izdavacLbl";
            this.vrsta_izdavacLbl.Size = new System.Drawing.Size(141, 25);
            this.vrsta_izdavacLbl.TabIndex = 22;
            this.vrsta_izdavacLbl.Text = "Vrsta | Izdavac";
            // 
            // isbnLbl
            // 
            this.isbnLbl.AutoSize = true;
            this.isbnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isbnLbl.Location = new System.Drawing.Point(57, 113);
            this.isbnLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isbnLbl.Name = "isbnLbl";
            this.isbnLbl.Size = new System.Drawing.Size(48, 20);
            this.isbnLbl.TabIndex = 25;
            this.isbnLbl.Text = "ISBN";
            // 
            // dostupnaLbl
            // 
            this.dostupnaLbl.AutoSize = true;
            this.dostupnaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dostupnaLbl.Location = new System.Drawing.Point(775, 64);
            this.dostupnaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dostupnaLbl.Name = "dostupnaLbl";
            this.dostupnaLbl.Size = new System.Drawing.Size(55, 29);
            this.dostupnaLbl.TabIndex = 31;
            this.dostupnaLbl.Text = "broj";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(679, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 58);
            this.label2.TabIndex = 32;
            this.label2.Text = "broj dostupnih\r\ndela :";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(575, 135);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(270, 255);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 33;
            this.pictureBox.TabStop = false;
            // 
            // autoriDgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.autoriDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.autoriDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.autoriDgv.BackgroundColor = System.Drawing.Color.White;
            this.autoriDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.autoriDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.autoriDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.autoriDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.autoriDgv.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.autoriDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.autoriDgv.EnableHeadersVisualStyles = false;
            this.autoriDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.autoriDgv.Location = new System.Drawing.Point(43, 163);
            this.autoriDgv.Margin = new System.Windows.Forms.Padding(4);
            this.autoriDgv.Name = "autoriDgv";
            this.autoriDgv.RowHeadersVisible = false;
            this.autoriDgv.RowHeadersWidth = 51;
            this.autoriDgv.RowTemplate.Height = 25;
            this.autoriDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.autoriDgv.Size = new System.Drawing.Size(469, 227);
            this.autoriDgv.TabIndex = 102;
            this.autoriDgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.autoriDgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.autoriDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.autoriDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.autoriDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.autoriDgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.autoriDgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.autoriDgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.autoriDgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.autoriDgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.autoriDgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.autoriDgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.autoriDgv.ThemeStyle.HeaderStyle.Height = 30;
            this.autoriDgv.ThemeStyle.ReadOnly = false;
            this.autoriDgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.autoriDgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.autoriDgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.autoriDgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.autoriDgv.ThemeStyle.RowsStyle.Height = 25;
            this.autoriDgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.autoriDgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Delo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 531);
            this.Controls.Add(this.autoriDgv);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.dostupnaLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.isbnLbl);
            this.Controls.Add(this.vrsta_izdavacLbl);
            this.Controls.Add(this.naslov_godinaLbl);
            this.Controls.Add(this.zatvoriBtn);
            this.Controls.Add(this.rezervisiBtn);
            this.Name = "Delo";
            this.Text = "Delo";
            this.Load += new System.EventHandler(this.Delo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoriDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button rezervisiBtn;
        private System.Windows.Forms.Button zatvoriBtn;
        private System.Windows.Forms.Label naslov_godinaLbl;
        private System.Windows.Forms.Label vrsta_izdavacLbl;
        private System.Windows.Forms.Label isbnLbl;
        private System.Windows.Forms.Label dostupnaLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox;
        private Guna.UI2.WinForms.Guna2DataGridView autoriDgv;
    }
}