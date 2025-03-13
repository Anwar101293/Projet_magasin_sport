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
using MaterielSportHiv.BD;

namespace MaterielSportHiv
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnconn_Click(object sender, EventArgs e)
        {
            // Generate a code that allows to redirect each user has his window according to his account type
            string query = "SELECT User,Mdp, Typecpt FROM utilisateur WHERE User = @login AND Mdp = @password";
            MySqlCommand cmd = new MySqlCommand(query, Database.Connection);
            cmd.Parameters.AddWithValue("@login", txtconn.Text);
            cmd.Parameters.AddWithValue("@password", txtmdp.Text);
            Database.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                char userType = reader.GetChar("Typecpt");
                if (userType == 'P')
                {
                    Formgestion formgestion = new Formgestion();
                    formgestion.Show();
                    this.Hide();

                    
                }
                else if (userType == 'U')
                {
                    Vue.Formloc formloc = new Vue.Formloc();
                    formloc.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();
            Database.Close();

            
                        
        }

        


    }
}
