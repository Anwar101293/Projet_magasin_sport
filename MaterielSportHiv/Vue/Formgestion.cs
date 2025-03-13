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
using MySql.Data;
using System.Management;
using System.Reflection.Emit;
using System.Data.SqlClient;


namespace MaterielSportHiv
{
    public partial class Formgestion : Form
    {
        public Formgestion()
        {
            InitializeComponent();
        }
        
        

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FormConnexion formlogin = new FormConnexion();
                formlogin.Show();
                this.Dispose();
            }
            
        }

        private void btnajout_Click(object sender, EventArgs e)
        {
            string nomEquipement = txtequip.Text;
            int quantite;
            decimal prixLocation;

            // Vérifier si les champs quantité et prix sont des nombres valides
            if (!int.TryParse(txtqt.Text, out quantite) || !decimal.TryParse(txtpr.Text, out prixLocation))
            {
                MessageBox.Show("La quantité et le prix de location doivent être des nombres valides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string typeEquipement = comboBtype.SelectedItem?.ToString();
            string marque = comboBmarque.SelectedItem?.ToString();

            // Vérifier que tous les champs ont été saisis
            if (string.IsNullOrEmpty(nomEquipement) || quantite <= 0 || prixLocation <= 0 || string.IsNullOrEmpty(typeEquipement) || string.IsNullOrEmpty(marque))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer les ID du type d'équipement et de la marque
            string idTypeEquipement = GetIdTypeEquipement(typeEquipement);
            int idMarque = GetIdMarque(marque);

            // Insérer le nouvel équipement dans la base de données
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string sql = "INSERT INTO equipement (nom_equipement, qte_dispo, prix_loc, CODETYPEQUIP, id_marque) VALUES (@nomEquipement, @quantite, @prixLocation, @idTypeEquipement, @idMarque)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nomEquipement", nomEquipement);
                    command.Parameters.AddWithValue("@quantite", quantite);
                    command.Parameters.AddWithValue("@prixLocation", prixLocation);
                    command.Parameters.AddWithValue("@idTypeEquipement", idTypeEquipement);
                    command.Parameters.AddWithValue("@idMarque", idMarque);

                    command.ExecuteNonQuery();
                }
            }

            // Actualiser le DataGridView
            ActualiserDataGridView();

            // Afficher un message de confirmation
            MessageBox.Show("L'équipement a été ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);


            
        }

        private void Formgestion_Load(object sender, EventArgs e)
        {
            {
                ActualiserDataGridView();
            }


            // Remplissage des liste déroulantes

            MySqlConnection conn1 = new MySqlConnection("server=localhost;database=projet2;uid=root;password=;");
            conn1.Open();

            // Récupérer les types d'équipement
            MySqlCommand cmd1 = new MySqlCommand("SELECT NOMTYPEEQUIP FROM type_equip", conn1);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                // Ajouter le nom du type d'équipement à la ComboBox
                comboBtype.Items.Add(reader.GetString("NOMTYPEEQUIP"));
            }
            reader.Close();

            // Récupérer les marques
            MySqlCommand cmd2 = new MySqlCommand("SELECT nom_marque FROM marque", conn1);
            MySqlDataReader reader1 = cmd2.ExecuteReader();
            while (reader1.Read())
            {
                // Ajouter le nom de la marque à la ComboBox
                comboBmarque.Items.Add(reader1.GetString("nom_marque"));
            }
            reader1.Close();

            conn1.Close();


        }

        private void ActualiserDataGridView()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=projet2;uid=root;password=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT e.nom_equipement, e.qte_dispo, e.prix_loc, t.NOMTYPEEQUIP, m.nom_marque " +
               "FROM equipement e " +
               "INNER JOIN type_equip t ON e.CODETYPEQUIP = t.CODETYPEQUIP " +
               "INNER JOIN marque m ON e.id_marque = m.id_marque", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridListe.DataSource = dt;
            conn.Close();

            dataGridListe.Columns[0].HeaderText = "Nom de l'équipement";
            dataGridListe.Columns[1].HeaderText = "Quantité disponible";
            dataGridListe.Columns[2].HeaderText = "Prix location";
            dataGridListe.Columns[3].HeaderText = "Type équipement";
            dataGridListe.Columns[4].HeaderText = "Marque";

            dataGridListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridListe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridListe.AutoResizeColumns();
            dataGridListe.AutoResizeRows();





        }

        private string GetIdTypeEquipement(string typeEquipement)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string sql = "SELECT CODETYPEQUIP FROM type_equip WHERE NOMTYPEEQUIP = @typeEquipement";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@typeEquipement", typeEquipement);
                    object result = command.ExecuteScalar();

                    // Vérifier si le résultat n'est pas null avant de le convertir en string
                    if (result != null)
                    {
                        return result.ToString(); // Convertir le résultat en string
                    }
                    else
                    {
                        // Gérer le cas où aucun ID n'est trouvé
                        // Par exemple, vous pouvez lever une exception ou renvoyer une valeur par défaut
                        throw new InvalidOperationException("Aucun ID trouvé pour le type d'équipement spécifié.");
                    }
                }
            }
        }

        // Fonction pour récupérer l'ID de la marque
        private int GetIdMarque(string marque)
        {
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string sql = "SELECT id_marque FROM marque WHERE nom_marque = @marque";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@marque", marque);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée

            if (dataGridListe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer les valeurs de la ligne sélectionnée
            string nomEquipement = txtequip.Text;
            int quantite;
            decimal prixLocation;

            // Vérifier si les champs quantité et prix sont des nombres valides
            if (!int.TryParse(txtqt.Text, out quantite) || !decimal.TryParse(txtpr.Text, out prixLocation))
            {
                MessageBox.Show("La quantité et le prix de location doivent être des nombres valides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string typeEquipement = comboBtype.SelectedItem?.ToString();
            string marque = comboBmarque.SelectedItem?.ToString();

            // Vérifier que tous les champs ont été saisis
            if (string.IsNullOrEmpty(nomEquipement) || quantite <= 0 || prixLocation <= 0 || string.IsNullOrEmpty(typeEquipement) || string.IsNullOrEmpty(marque))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer les ID du type d'équipement et de la marque
            string idTypeEquipement = GetIdTypeEquipement(typeEquipement);
            int idMarque = GetIdMarque(marque);

            // Récupérer l'ID de l'équipement à modifier
            string nomEquipementAModifier = dataGridListe.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string sql = "UPDATE equipement SET nom_equipement = @nomEquipement, qte_dispo = @quantite, prix_loc = @prixLocation, CODETYPEQUIP = @idTypeEquipement, id_marque = @idMarque WHERE nom_equipement = @nomEquipementAModifier";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nomEquipement", nomEquipement);
                    command.Parameters.AddWithValue("@quantite", quantite);
                    command.Parameters.AddWithValue("@prixLocation", prixLocation);
                    command.Parameters.AddWithValue("@idTypeEquipement", idTypeEquipement);
                    command.Parameters.AddWithValue("@idMarque", idMarque);
                    command.Parameters.AddWithValue("@nomEquipementAModifier", nomEquipementAModifier);

                    command.ExecuteNonQuery();
                }
            }

            // Actualiser le DataGridView
            ActualiserDataGridView();

            // Afficher un message de confirmation
            MessageBox.Show("L'équipement a été modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée
            if (dataGridListe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer le nom de l'équipement à supprimer
            string nomEquipement = dataGridListe.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "server=localhost;database=projet2;uid=root;password=;";
            string sql = "DELETE FROM equipement WHERE nom_equipement = @nomEquipement";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nomEquipement", nomEquipement);
                    command.ExecuteNonQuery();
                }
            }

            // Actualiser le DataGridView
            ActualiserDataGridView();

            // Afficher un message de confirmation
            MessageBox.Show("L'équipement a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
