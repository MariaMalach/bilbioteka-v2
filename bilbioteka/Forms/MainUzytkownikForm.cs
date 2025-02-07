﻿using Microsoft.VisualBasic.Logging;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bilbioteka.Forms
{
    public partial class MainUzytkownikForm : Form
    {
        private int userId; // Id zalogowanego użytkownika
        private string userName; // Imię zalogowanego użytkownika
        private string login;
        private string zalogowanyLogin;

        public MainUzytkownikForm(int userId, string imie, string login)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = imie;
            this.login = login;
            label1.Text = userName;
            LoadData();
            LoadDataToDataGridView2();
            Kara(); 
        }

        private void Kara()
        {

            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string karaQuery = "SELECT COUNT(*) FROM HistoriaWypozyczen WHERE LoginUzytkownika = @login AND StatusZwrotu = 'KARA'";
                    SqlCommand karaCommand = new SqlCommand(karaQuery, connection);
                    karaCommand.Parameters.AddWithValue("@login", login);

                    int count = (int)karaCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show(userName + " zalegasz z oddaniem pozycji. Opłać karę aby dalej korzystać z biblioteki!");
                        return;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania danych: " + ex.Message);
            }
        }

        private void LoadDataToDataGridView2()
        {
            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT h.Id, z.Tytul, h.DataWypozyczenia as 'Wypożyczone', h.DataZwrotu  as 'Zwrot' 
                        FROM HistoriaWypozyczen h
                        JOIN zasoby z ON h.ZasobId = z.Id
                        WHERE h.LoginUzytkownika = @login AND h.StatusZwrotu='Nie zwrócono'"; // Filtrowanie po loginie użytkownika

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login); // Przekazujemy login jako parametr

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        dataGridView2.DataSource = null;
                        labelNoActiveLoans.Visible = true;
                    }
                    else
                    {
                        labelNoActiveLoans.Visible = false;
                        dataGridView2.DataSource = dataTable;
                        dataGridView2.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania danych: " + ex.Message);
            }
        }


        private void LoadData()
        {
            try
            {
                string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Tytul, Autor,RokWydania AS 'Rok', Typ, Ocena, Kategoria, Wydawnictwo  FROM zasoby WHERE Ilosc > 0 AND StanZasobu = 'Aktywny'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania danych: " + ex.Message);
            }
        }


        private void SearchData()
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kryterium wyszukiwania.");
                return;
            }

            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            string query = string.Empty;
            string searchValue = textBox1.Text;
            int rokWydania = 0;
            decimal ocena = 0;
            int ilosc = 0;
            // Ustal zapytanie w zależności od wybranego kryterium
            switch (comboBox1.SelectedItem.ToString())
            {
                case "   ":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE StanZasobu = 'Aktywny' ";
                    break;
                case "Tytuł":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Tytul LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                case "Autor":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Autor LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                case "Rok wydania":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE RokWydania LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                case "Numer katalogowy":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE NumerKatalogowy LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                case "Typ produktu":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Typ LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                case "Ocena":
                    // Sprawdzenie, czy searchValue jest liczbą
                    if (!decimal.TryParse(searchValue, out ocena))
                    {
                        MessageBox.Show("Proszę wpisać poprawną ocenę.");
                        return;
                    }
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Ocena = @ocena AND StanZasobu = 'Aktywny'";
                    break;
                case "Ilość":

                    if (!int.TryParse(searchValue, out ilosc))
                    {
                        MessageBox.Show("Proszę wpisać poprawną ilość.");
                        return;
                    }
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Ilosc = @ilosc AND StanZasobu = 'Aktywny'";
                    break;
                case "Kategoria":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Kategoria LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                default:
                    MessageBox.Show("Proszę wybrać kryterium wyszukiwania.");
                    return;

                case "Wydawnictwo":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Wydawnictwo LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;

            }

            // Tworzenie połączenia z bazą
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Dodaj parametr w zależności od wybranego kryterium
                    switch (comboBox1.SelectedItem.ToString())
                    {
                        case "Tytuł":
                        case "Autor":
                        case "Numer katalogowy":
                        case "Typ produktu":
                        case "Wydawnictwo":
                        case "Kategoria":
                            cmd.Parameters.AddWithValue("@searchValue", $"%{searchValue}%");
                            break;
                        case "Rok wydania":
                            cmd.Parameters.AddWithValue("@searchValue", $"%{searchValue}%");
                            break;
                        case "Ocena":
                            cmd.Parameters.AddWithValue("@ocena", ocena);
                            break;
                        case "Ilość":
                            cmd.Parameters.AddWithValue("@ilosc", ilosc);
                            break;
                    }

                    // Wypełnij DataTable i przypisz do DataGridView
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zostałeś pomyślnie wylogowany. Do zobaczenia!");
            this.Close();
        }

        private void buttonHistoriaWypozyczen_Click(object sender, EventArgs e)
        {
            HistoriaWypozycenForm historiaForm = new HistoriaWypozycenForm(login);
            historiaForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView2();
        }

        private void buttonEdytujKonto_Click(object sender, EventArgs e)
        {
            EdycjaUzytkownikaUzytkownik edycjaUzytkownikaUzytkownik = new EdycjaUzytkownikaUzytkownik( login);
            edycjaUzytkownikaUzytkownik.Show();
        }
    }
}
