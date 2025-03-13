using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MaterielSportHiv.Vue
{
    public partial class Formlisteloc : Form
    {
        public Formlisteloc()
        {
            InitializeComponent();
        }

        private void Formlisteloc_Load(object sender, EventArgs e)
        {
           // Afficher dans le DataGridView les locations effectuées a partir de la table location
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string query = "SELECT l.`locationID`, e.`nom_equipement`, e.`prix_loc`, l.`date_debut_loc`, l.`date_fin_loc` FROM `locations` l " +
                "INNER JOIN `equipement` e ON l.`id_equipement` = e.`id_equipement` " +
                "WHERE l.`User` = 'Lee';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Liaison des données au DataGridView
                            dataGridListeloc.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formloc formloc = new Formloc();
                formloc.Show();
                this.Dispose();
            }
        }

        
    }
}
