﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bilbioteka.Forms //C:\Users\48514\Desktop\Raport.txt
{
    public partial class MainAdminstratorForm : Form
    {
        private Raport raport;
        public MainAdminstratorForm(string imie)
        {
            InitializeComponent();
            label1.Text = imie;
        string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
        string sciezkaPliku = @"C:\Users\48514\Desktop\Raport.txt";

        raport = new Raport(sciezkaPliku, connectionString);
    }




        private void buttonDodajPracownika_Click(object sender, EventArgs e)
        {
            DodajPracownikaForm dodajPracownikaForm = new DodajPracownikaForm();
            dodajPracownikaForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zostałeś pomyślnie wylogowany. Do zobaczenia!");
            this.Close();
        }

        private void buttonDodajProdukt_Click(object sender, EventArgs e)
        {
            DodajNwoyProduktAdminForm dodajNwoyProduktAdminForm = new DodajNwoyProduktAdminForm();
            dodajNwoyProduktAdminForm.Show();

        }

        private void buttonEdycjaZbioru_Click(object sender, EventArgs e)
        {
            EdycjaProduktowAdminForm edycjaProduktowAdminForm = new EdycjaProduktowAdminForm();
            edycjaProduktowAdminForm.Show();

        }

        private void buttonGenerujRaport_Click(object sender, EventArgs e)
        {
            try
            {
                // Wywołanie metody generującej raport
                raport.GenerujRaport();

                // Wyświetlenie komunikatu o sukcesie
                MessageBox.Show("Raport został pomyślnie wygenerowany i zapisany na dysku C:\\.",
                                "Sukces",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message,
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
    
}
