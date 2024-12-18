﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bilbioteka.Forms
{
    public partial class KaraPracownik2 : Form
    {
        public KaraPracownik2()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        private void LoadData()
        {
            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            string query = "SELECT IloscDniKary AS 'Długość kary', KwotaKary AS 'Kwota [zł]', Login, Tytul, Typ, StatusKary FROM kary ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Wystąpił błąd w bazie danych: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
        }


        private string selectedLogin = string.Empty;
        private string selectedTytul = string.Empty;
        private string selectedTyp = string.Empty;
        private int selectedKwotaKary = 0;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Upewnij się, że kliknięto wiersz, a nie nagłówek
            {
                // Pobierz zaznaczony wiersz
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Pobierz wartości z odpowiednich kolumn
                selectedLogin = selectedRow.Cells["Login"]?.Value?.ToString() ?? string.Empty;
                selectedTytul = selectedRow.Cells["Tytul"]?.Value?.ToString() ?? string.Empty;
                selectedTyp = selectedRow.Cells["Typ"]?.Value?.ToString() ?? string.Empty;
                int selectedKwotaKary = selectedRow.Cells["Kwota [zł]"]?.Value != null
                ? Convert.ToInt32(selectedRow.Cells["Kwota [zł]"].Value) : 0;

                // Wstaw wartości do odpowiednich pól tekstowych
                textBox1.Text = selectedLogin;
                textBoxTytul.Text = selectedTytul;
                textBoxTyp.Text = selectedTyp;
                textBoxKwota.Text = selectedKwotaKary.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string tytul = textBoxTytul.Text;
            string kwota = textBoxKwota.Text;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Proszę wpisać login użytkownika.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tytul))
            {
                MessageBox.Show("Proszę wpisać tytuł zasobu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(kwota))
            {
                MessageBox.Show("Proszę wpisać kwotę kary.");
                return;
            }

            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Sprawdź, czy istnieje rekord dla podanego loginu i tytułu
                    string selectQuery = "SELECT Login, Tytul, KwotaKary FROM kary WHERE Login = @login AND Tytul = @tytul";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@login", login);
                    selectCommand.Parameters.AddWithValue("@tytul", tytul);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Nie znaleziono takiego użytkownika lub tytułu w bazie danych.");
                            return;
                        }

                        // Sprawdzenie poprawności kwoty
                        int kwotaZBazy = reader.GetInt32(reader.GetOrdinal("KwotaKary"));
                        if (kwotaZBazy.ToString() != kwota)
                        {
                            MessageBox.Show("Podana kwota kary jest niezgodna.");
                            return;
                        }
                    }

                    string updateQuery = @"
        UPDATE kary
        SET StatusKary = 'Zwrócono'
        FROM kary
        INNER JOIN HistoriaWypozyczen ON kary.Login = HistoriaWypozyczen.LoginUzytkownika
            AND kary.Tytul = HistoriaWypozyczen.TytulPozycji
        WHERE kary.Login = @login AND HistoriaWypozyczen.TytulPozycji = @tytul;
        
        UPDATE HistoriaWypozyczen
        SET StatusZwrotu = 'Zwrócono'
        WHERE LoginUzytkownika = @login AND TytulPozycji = @tytul;";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@login", login);
                    updateCommand.Parameters.AddWithValue("@tytul", tytul);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status został pomyślnie zaktualizowany.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się zaktualizować statusu.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Wystąpił błąd w bazie danych: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }


        private void buttonZalogujRej_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string tytul = textBoxTytul.Text;
            string kwota = textBoxKwota.Text;
            string typ = textBoxTyp.Text;
            

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Proszę wpisać login użytkownika.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tytul))
            {
                MessageBox.Show("Proszę wpisać tytuł zasobu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(kwota))
            {
                MessageBox.Show("Proszę wpisać kwotę kary.");
                return;
            }

            //połaczenie 2
            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Sprawdź, czy istnieje rekord dla podanego loginu i tytułu
                    string selectQuery = "SELECT Login, Tytul, KwotaKary FROM kary WHERE Login = @login AND Tytul = @tytul";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@login", login);
                    selectCommand.Parameters.AddWithValue("@tytul", tytul);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Nie znaleziono takiego użytkownika lub tytułu w bazie danych.");
                            return;
                        }
                    }


                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Wystąpił błąd w bazie danych: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }//koniec
             //połączenie 1
            
           

            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Sprawdź, czy istnieje rekord dla podanego loginu i tytułu
                    string selectQuery = "SELECT COUNT(*) FROM kary WHERE Login = @login AND Tytul = @tytul";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@login", login);
                    selectCommand.Parameters.AddWithValue("@tytul", tytul);

                    int recordCount = (int)selectCommand.ExecuteScalar();
                    if (recordCount == 0)
                    {
                        MessageBox.Show("Nie znaleziono takiego użytkownika lub tytułu w bazie danych.");
                        return;
                    }

                    // Pobierz cenę z tabeli Cennik
                    string selectPriceQuery = "SELECT CenaZaNowe FROM Cennik WHERE Produkt = @typ";
                    SqlCommand selectPriceCommand = new SqlCommand(selectPriceQuery, connection);
                    selectPriceCommand.Parameters.AddWithValue("@typ", typ);

                    object cenaObj = selectPriceCommand.ExecuteScalar();
                    if (cenaObj == null)
                    {
                        MessageBox.Show("Nie znaleziono ceny dla podanego typu produktu w tabeli Cennik.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int cenaZBazy = Convert.ToInt32(cenaObj);
                    if (!int.TryParse(kwota, out int cenaWprowadzona) || cenaWprowadzona != cenaZBazy)
                    {
                        MessageBox.Show("Cena musi być zgodna z cennikiem. Patrz kolumnę CenaZaNowe!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    string updateQuery = @"
        UPDATE kary
        SET StatusKary = 'Zwrócono'
        FROM kary
        INNER JOIN HistoriaWypozyczen ON kary.Login = HistoriaWypozyczen.LoginUzytkownika
            AND kary.Tytul = HistoriaWypozyczen.TytulPozycji
        WHERE kary.Login = @login AND HistoriaWypozyczen.TytulPozycji = @tytul;
        
        UPDATE HistoriaWypozyczen
        SET StatusZwrotu = 'Zwrócono'
        WHERE LoginUzytkownika = @login AND TytulPozycji = @tytul;";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@login", login);
                    updateCommand.Parameters.AddWithValue("@tytul", tytul);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status został pomyślnie zaktualizowany.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się zaktualizować statusu.");
                    }

                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Wystąpił błąd w bazie danych: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            //koniec

            
        }
    }
}
