﻿using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bilbioteka.Forms
{
    public partial class DodajPracownikaForm : Form
    {
        private string imie;
        public DodajPracownikaForm()
        {
            InitializeComponent();
            
        }

        private void buttonZalogujRej_Click(object sender, EventArgs e)
        {
            MainAdminstratorForm mainAdminstratorForm = new MainAdminstratorForm(imie);
            mainAdminstratorForm.Show();
            this.Hide();
        }

        private void buttonDodajPracownika_Click(object sender, EventArgs e)
        {
            // Pobierz dane z pól tekstowych
            string imie = textBoxImie.Text.Trim();
            string nazwisko = textBoxNazwisko.Text.Trim();
            string login = textBoxLogin.Text.Trim();
            string haslo = textBoxHaslo.Text.Trim();
            string kodPocztowy = textBoxKodPocztowy.Text.Trim();
            string ulica = textBoxUlica.Text.Trim();
            string nrPosesji = textBoxNrPosesji.Text.Trim();
            string nrLokalu = textBoxNrLokalu.Text.Trim();
            string pesel = textBoxPesel.Text.Trim();
            DateTime dataUrodzenia = dateTimePicker1.Value;
            string email = textBoxEmail.Text.Trim();
            string numerTelefonu = textBoxNrTelefonu.Text.Trim();

            // Walidacja danych
            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo) ||
                string.IsNullOrWhiteSpace(kodPocztowy) || string.IsNullOrWhiteSpace(ulica) ||
                string.IsNullOrWhiteSpace(nrPosesji) || string.IsNullOrWhiteSpace(pesel) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(numerTelefonu))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (login.Length < 5 || login.Length > 30)
            {
                MessageBox.Show("Login pracownika musi mieć od 5 do 30 znaków!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (haslo.Length < 5 || !Regex.IsMatch(haslo, @"\d"))
            {
                MessageBox.Show("Hasło pracownika musi mieć minimum 5 znaków i przynajmniej jedną cyfrę!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(kodPocztowy, @"^\d{2}-\d{3}$") || kodPocztowy.CompareTo("90-001") < 0 || kodPocztowy.CompareTo("94-413") > 0)
            {
                MessageBox.Show("Kod pocztowy pracownika musi być z terenu Łodzi czyli od 90-001 do 94-413!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kodPocztowy.Length < 1 || !Regex.IsMatch(nrLokalu, @"\d"))
            {
                MessageBox.Show("Numer lokalu musi zawierać cyfry!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nrPosesji.Length < 1 || !Regex.IsMatch(nrPosesji, @"\d"))
            {
                MessageBox.Show("Numer posesji musi zawierać cyfry!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pesel.Length != 11 || !long.TryParse(pesel, out _))
            {
                MessageBox.Show("Pesel pracownika musi mieć 11 cyfr!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email pracownika musi zawierać znak '@' oraz '.'!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numerTelefonu.Length != 9 || !long.TryParse(numerTelefonu, out _))
            {
                MessageBox.Show("Numer telefonu pracownika musi mieć 9 cyfr!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Now.Year - dataUrodzenia.Year < 16)
            {
                MessageBox.Show("Pracownik musi mieć cob najmniej 16 lat!", "Bład rejstracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


                // Sprawdzenie unikalności loginu
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkLoginQuery = "SELECT COUNT(1) FROM uzytkownicy WHERE Login = @Login";
                using (SqlCommand command = new SqlCommand(checkLoginQuery, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    int exists = (int)command.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Login już istnieje!", "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Dodaj nowego użytkownika
                string insertQuery = @"
            INSERT INTO uzytkownicy 
            (IdOsoby,Imie, Nazwisko, NumerTelefonu, Login, Haslo, KodPocztowy, Ulica, NrPosesji, NrLokalu, Pesel, DataUrodzenia, Email) 
            VALUES 
            (2, @Imie, @Nazwisko, @NumerTelefonu, @Login, @Haslo, @KodPocztowy, @Ulica, @NrPosesji, @NrLokalu, @Pesel, @DataUrodzenia, 
            @Email);";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Imie", imie);
                    command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@NumerTelefonu", numerTelefonu);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Haslo", haslo); 
                    command.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
                    command.Parameters.AddWithValue("@Ulica", ulica);
                    command.Parameters.AddWithValue("@NrPosesji", nrPosesji);
                    command.Parameters.AddWithValue("@NrLokalu", string.IsNullOrEmpty(nrLokalu) ? (object)DBNull.Value : nrLokalu);
                    command.Parameters.AddWithValue("@Pesel", pesel);
                    command.Parameters.AddWithValue("@DataUrodzenia", dataUrodzenia);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(" Pracownik został dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            
            
        }
    }
}

        
    

