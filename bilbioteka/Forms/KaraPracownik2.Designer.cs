﻿namespace bilbioteka.Forms
{
    partial class KaraPracownik2
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
            button2 = new Button();
            dataGridView1 = new DataGridView();
            buttonZalogujRej = new Button();
            textBoxKwota = new TextBox();
            label10 = new Label();
            textBoxTytul = new TextBox();
            label7 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            textBoxTyp = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(98, 380);
            button2.Name = "button2";
            button2.Size = new Size(223, 81);
            button2.TabIndex = 189;
            button2.Text = "Przyjmij karę";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(442, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(732, 430);
            dataGridView1.TabIndex = 188;
            // 
            // buttonZalogujRej
            // 
            buttonZalogujRej.Font = new Font("Book Antiqua", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonZalogujRej.Location = new Point(12, 12);
            buttonZalogujRej.Name = "buttonZalogujRej";
            buttonZalogujRej.Size = new Size(88, 69);
            buttonZalogujRej.TabIndex = 187;
            buttonZalogujRej.Text = " ⬅";
            buttonZalogujRej.UseVisualStyleBackColor = true;
            buttonZalogujRej.Click += buttonZalogujRej_Click_1;
            // 
            // textBoxKwota
            // 
            textBoxKwota.Anchor = AnchorStyles.None;
            textBoxKwota.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxKwota.Location = new Point(194, 260);
            textBoxKwota.Name = "textBoxKwota";
            textBoxKwota.Size = new Size(187, 38);
            textBoxKwota.TabIndex = 185;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(3, 263);
            label10.Name = "label10";
            label10.Size = new Size(167, 35);
            label10.TabIndex = 184;
            label10.Text = "Kwota kary:";
            // 
            // textBoxTytul
            // 
            textBoxTytul.Anchor = AnchorStyles.None;
            textBoxTytul.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTytul.Location = new Point(194, 205);
            textBoxTytul.Name = "textBoxTytul";
            textBoxTytul.Size = new Size(187, 38);
            textBoxTytul.TabIndex = 183;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(81, 205);
            label7.Name = "label7";
            label7.Size = new Size(89, 35);
            label7.TabIndex = 182;
            label7.Text = "Tytuł:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Book Antiqua", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(123, 23);
            label6.Name = "label6";
            label6.Size = new Size(1132, 58);
            label6.TabIndex = 181;
            label6.Text = "Użytkownicy, którzy zalegają ze zwrtotem produktu";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(194, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 38);
            textBox1.TabIndex = 191;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(76, 147);
            label1.Name = "label1";
            label1.Size = new Size(94, 35);
            label1.TabIndex = 190;
            label1.Text = "Login:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Book Antiqua", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(98, 496);
            button1.Name = "button1";
            button1.Size = new Size(223, 81);
            button1.TabIndex = 192;
            button1.Text = "Przyjmij opłatę za nowy produkt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxTyp
            // 
            textBoxTyp.Anchor = AnchorStyles.None;
            textBoxTyp.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTyp.Location = new Point(194, 319);
            textBoxTyp.Name = "textBoxTyp";
            textBoxTyp.Size = new Size(187, 38);
            textBoxTyp.TabIndex = 194;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(98, 322);
            label2.Name = "label2";
            label2.Size = new Size(72, 35);
            label2.TabIndex = 193;
            label2.Text = "Typ:";
            // 
            // KaraPracownik2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.stan_czytelnictwa_w_polsce1;
            ClientSize = new Size(1267, 690);
            Controls.Add(textBoxTyp);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(buttonZalogujRej);
            Controls.Add(textBoxKwota);
            Controls.Add(label10);
            Controls.Add(textBoxTytul);
            Controls.Add(label7);
            Controls.Add(label6);
            Name = "KaraPracownik2";
            Text = "KaraPracownik2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private DataGridView dataGridView1;
        private Button buttonZalogujRej;
        private TextBox textBoxKwota;
        private Label label10;
        private TextBox textBoxTytul;
        private Label label7;
        private Label label6;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private TextBox textBoxTyp;
        private Label label2;
    }
}