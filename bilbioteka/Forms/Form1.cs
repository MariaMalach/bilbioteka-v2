using bilbioteka.Forms;
using System.Data.SqlClient;
using System.Data;

namespace bilbioteka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonZaloguj_Click(object sender, EventArgs e)
        {
            LogowanieForm logowanieForm = new LogowanieForm();
            logowanieForm.Show();
            //this.Close();

        }
        private void buttonRejstruj_Click(object sender, EventArgs e)
        {
            RejestracjaForm rejestracjaForm = new RejestracjaForm();
            rejestracjaForm.Show();
            //this.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }
        private void LoadData()
        {
            // Pobieranie connection string z klasy PolaczenieBazyDanych
            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();

            // Zapytanie SQL, kt�re wybiera dane z tabeli 'zasoby'
            string query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE StanZasobu = 'Aktywny'";

            // Tworzenie obiektu SqlConnection z connection string
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Otw�rz po��czenie
                    conn.Open();

                    // Utw�rz obiekt SqlDataAdapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

                    // Utw�rz DataTable, do kt�rej za�adujemy dane
                    DataTable dataTable = new DataTable();

                    // Za�aduj dane z SQL do DataTable
                    dataAdapter.Fill(dataTable);

                    // Ustaw DataGridView1 jako �r�d�o danych dla DataTable
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Obs�uga b��d�w
                    MessageBox.Show("Wyst�pi� b��d: " + ex.Message);
                }
            }
        }
        private void SearchData()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Prosz� wybra� kryterium wyszukiwania.");
                return;
            }

            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            string query = string.Empty;
            string searchValue = textBox1.Text;
            int rokWydania = 0;
            decimal ocena = 0;
            int ilosc = 0;
            // Ustal zapytanie w zale�no�ci od wybranego kryterium
            switch (comboBox1.SelectedItem.ToString())
            {
                case "   ":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE StanZasobu = 'Aktywny' ";
                    break;
                case "Tytu�":
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
                    // Sprawdzenie, czy searchValue jest liczb�
                    if (!decimal.TryParse(searchValue, out ocena))
                    {
                        MessageBox.Show("Prosz� wpisa� poprawn� ocen�.");
                        return;
                    }
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Ocena = @ocena AND StanZasobu = 'Aktywny'";
                    break;
                case "Ilo��":

                    if (!int.TryParse(searchValue, out ilosc))
                    {
                        MessageBox.Show("Prosz� wpisa� poprawn� ilo��.");
                        return;
                    }
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Ilosc = @ilosc AND StanZasobu = 'Aktywny'";
                    break;
                case "Kategoria":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Kategoria LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;
                default:
                    MessageBox.Show("Prosz� wybra� kryterium wyszukiwania.");
                    return;

                case "Wydawnictwo":
                    query = "SELECT Tytul, Autor, Typ, Ocena, RokWydania, Kategoria, Wydawnictwo FROM zasoby WHERE Wydawnictwo LIKE @searchValue AND StanZasobu = 'Aktywny'";
                    break;

            }

            // Tworzenie po��czenia z baz�
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Dodaj parametr w zale�no�ci od wybranego kryterium
                    switch (comboBox1.SelectedItem.ToString())
                    {
                        case "Tytu�":
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
                        case "Ilo��":
                            cmd.Parameters.AddWithValue("@ilosc", ilosc);
                            break;
                    }

                    // Wype�nij DataTable i przypisz do DataGridView
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst�pi� b��d: " + ex.Message);
                }
            }
        }



        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void buttonUlubiency_Click(object sender, EventArgs e)
        {
            UlubiencyUzytkownikow ulubiencyUzytkownikow = new UlubiencyUzytkownikow();
            ulubiencyUzytkownikow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UlubiiencyMiesiaca ulubiiencyMiesiaca = new UlubiiencyMiesiaca();
            ulubiiencyMiesiaca.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Regulamin regulamin = new Regulamin();
            regulamin.Show();
        }
    }
}