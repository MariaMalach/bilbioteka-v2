namespace bilbioteka.Forms
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
            dataGridView2 = new DataGridView();
            textBox4 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new Font("Book Antiqua", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(21, 379);
            button2.Name = "button2";
            button2.Size = new Size(160, 81);
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
            dataGridView1.Location = new Point(426, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(858, 526);
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
            textBoxKwota.Location = new Point(206, 260);
            textBoxKwota.Name = "textBoxKwota";
            textBoxKwota.Size = new Size(187, 38);
            textBoxKwota.TabIndex = 185;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(15, 263);
            label10.Name = "label10";
            label10.Size = new Size(167, 35);
            label10.TabIndex = 184;
            label10.Text = "Kwota kary:";
            // 
            // textBoxTytul
            // 
            textBoxTytul.Anchor = AnchorStyles.None;
            textBoxTytul.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTytul.Location = new Point(206, 205);
            textBoxTytul.Name = "textBoxTytul";
            textBoxTytul.Size = new Size(187, 38);
            textBoxTytul.TabIndex = 183;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(93, 205);
            label7.Name = "label7";
            label7.Size = new Size(89, 35);
            label7.TabIndex = 182;
            label7.Text = "Tytuł:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Book Antiqua", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(138, 23);
            label6.Name = "label6";
            label6.Size = new Size(1049, 54);
            label6.TabIndex = 181;
            label6.Text = "Użytkownicy, którzy zalegają ze zwrtotem produktu";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(206, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 38);
            textBox1.TabIndex = 191;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(88, 147);
            label1.Name = "label1";
            label1.Size = new Size(94, 35);
            label1.TabIndex = 190;
            label1.Text = "Login:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Book Antiqua", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(206, 380);
            button1.Name = "button1";
            button1.Size = new Size(214, 81);
            button1.TabIndex = 192;
            button1.Text = "Przyjmij opłatę za nowy produkt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxTyp
            // 
            textBoxTyp.Anchor = AnchorStyles.None;
            textBoxTyp.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTyp.Location = new Point(206, 319);
            textBoxTyp.Name = "textBoxTyp";
            textBoxTyp.Size = new Size(187, 38);
            textBoxTyp.TabIndex = 194;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(110, 322);
            label2.Name = "label2";
            label2.Size = new Size(72, 35);
            label2.TabIndex = 193;
            label2.Text = "Typ:";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(21, 477);
            dataGridView2.Margin = new Padding(2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(399, 187);
            dataGridView2.TabIndex = 195;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.None;
            textBox4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(206, 97);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(187, 38);
            textBox4.TabIndex = 196;
            textBox4.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Book Antiqua", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(131, 101);
            label3.Name = "label3";
            label3.Size = new Size(53, 35);
            label3.TabIndex = 197;
            label3.Text = "ID:";
            // 
            // KaraPracownik2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.stan_czytelnictwa_w_polsce1;
            ClientSize = new Size(1296, 690);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(dataGridView2);
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
            Text = "Przyjmowanie opłat";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private DataGridView dataGridView2;
        private TextBox textBox4;
        private Label label3;
    }
}