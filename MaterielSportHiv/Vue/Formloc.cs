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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaterielSportHiv.Vue
{
    public partial class Formloc : Form
    {
        public Formloc()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FormConnexion formlogin = new FormConnexion();
                formlogin.Show();
                this.Dispose();
            }
        }

        private void Formloc_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;"; 
            string query = "SELECT nom_equipement, nom_marque, prix_loc, qte_dispo,disponible FROM equipement " +
                "INNER JOIN marque  ON equipement.id_marque = marque.id_marque";

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
                            dataGridLoc.DataSource = dataTable;
                        }

                        // Renommer les colonnes du DataGridView
                        dataGridLoc.Columns["nom_equipement"].HeaderText = "Nom de l'équipement";
                        dataGridLoc.Columns["nom_marque"].HeaderText = "Marque";
                        dataGridLoc.Columns["prix_loc"].HeaderText = "Prix de location/jour (en €)";
                        dataGridLoc.Columns["qte_dispo"].HeaderText = "Quantité";
                        dataGridLoc.Columns["disponible"].HeaderText = "Disponibilité";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite lors du chargement des données : " + ex.Message);
                    }
                }
            }

            MySqlConnection conn1 = new MySqlConnection("server=localhost;database=projet2;uid=root;password=;");
            conn1.Open();

            // Récupérer les types d'équipement
            MySqlCommand cmd1 = new MySqlCommand("SELECT id_equipement FROM equipement", conn1);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                // ajouter les id des équipements dans la combobox
                comboBid.Items.Add(reader["id_equipement"].ToString());


            }
            reader.Close();
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string query = "INSERT INTO locations (locationID, USER, id_equipement, date_debut_loc, date_fin_loc) VALUES (@id_location, @User, @id_equipement, @date_debut_loc, @date_fin_loc)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        int userId = GetUserId(txtuser.Text);
                        int equipementID = GetEquipementId(comboBid.SelectedItem.ToString());

                        command.Parameters.AddWithValue("@id_location", txtloc.Text);
                        command.Parameters.AddWithValue("@id_equipement", equipementID);
                        command.Parameters.AddWithValue("@User", userId); // Utilisez l'ID de l'utilisateur connecté
                        command.Parameters.AddWithValue("@date_debut_loc", dateTimedeb.Value.Date);
                        command.Parameters.AddWithValue("@date_fin_loc", dateTimefin.Value.Date);

                        command.ExecuteNonQuery();
                        MessageBox.Show("L'équipement a bien été loué !", "Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la location : " + ex.Message);
                    }
                }
            }



        }

        private int GetEquipementId(string equipement)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string select = "SELECT id_equipement FROM equipement WHERE nom_equipement = @nom_equipement";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(select, connection))
                {
                    command.Parameters.AddWithValue("@nom_equipement", equipement);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Équipement non trouvé");
                    }
                }
            }
        }

        // Méthode pour récupérer l'ID de l'utilisateur en fonction de son nom d'utilisateur
        private int GetUserId(string username)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string query = "SELECT USER FROM utilisateur WHERE USER = @username";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Utilisateur non trouvé");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ouvrir la fenetre du résultat de la location
            Formlisteloc formlocresult = new Formlisteloc();
            formlocresult.Show();


        }
    }
}
