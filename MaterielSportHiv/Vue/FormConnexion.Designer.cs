namespace MaterielSportHiv
{
    partial class FormConnexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
            this.panconn = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnconn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmdp = new System.Windows.Forms.TextBox();
            this.txtconn = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panconn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panconn
            // 
            this.panconn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panconn.Controls.Add(this.pictureBox2);
            this.panconn.Controls.Add(this.btnconn);
            this.panconn.Controls.Add(this.label2);
            this.panconn.Controls.Add(this.label1);
            this.panconn.Controls.Add(this.txtmdp);
            this.panconn.Controls.Add(this.txtconn);
            this.panconn.Location = new System.Drawing.Point(458, 0);
            this.panconn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panconn.Name = "panconn";
            this.panconn.Size = new System.Drawing.Size(864, 548);
            this.panconn.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MaterielSportHiv.Properties.Resources.images;
            this.pictureBox2.Location = new System.Drawing.Point(774, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnconn
            // 
            this.btnconn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnconn.Location = new System.Drawing.Point(86, 428);
            this.btnconn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnconn.Name = "btnconn";
            this.btnconn.Size = new System.Drawing.Size(273, 47);
            this.btnconn.TabIndex = 5;
            this.btnconn.Text = "Connexion";
            this.btnconn.UseVisualStyleBackColor = true;
            this.btnconn.Click += new System.EventHandler(this.btnconn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 50);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de passe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom d\'utilisateur:";
            // 
            // txtmdp
            // 
            this.txtmdp.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmdp.Location = new System.Drawing.Point(86, 343);
            this.txtmdp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmdp.Multiline = true;
            this.txtmdp.Name = "txtmdp";
            this.txtmdp.Size = new System.Drawing.Size(385, 40);
            this.txtmdp.TabIndex = 2;
            // 
            // txtconn
            // 
            this.txtconn.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconn.Location = new System.Drawing.Point(86, 211);
            this.txtconn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtconn.Multiline = true;
            this.txtconn.Name = "txtconn";
            this.txtconn.Size = new System.Drawing.Size(385, 42);
            this.txtconn.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(1315, 550);
            this.Controls.Add(this.panconn);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormConnexion";
            this.Text = "Connexion Compte";
            this.panconn.ResumeLayout(false);
            this.panconn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panconn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtmdp;
        private System.Windows.Forms.TextBox txtconn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnconn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

