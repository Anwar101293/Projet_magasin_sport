namespace MaterielSportHiv.Vue
{
    partial class Formlisteloc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridListeloc = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListeloc)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridListeloc
            // 
            this.dataGridListeloc.AllowUserToAddRows = false;
            this.dataGridListeloc.AllowUserToDeleteRows = false;
            this.dataGridListeloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListeloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListeloc.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridListeloc.Location = new System.Drawing.Point(0, 0);
            this.dataGridListeloc.Name = "dataGridListeloc";
            this.dataGridListeloc.ReadOnly = true;
            this.dataGridListeloc.RowHeadersWidth = 51;
            this.dataGridListeloc.RowTemplate.Height = 24;
            this.dataGridListeloc.Size = new System.Drawing.Size(998, 420);
            this.dataGridListeloc.TabIndex = 0;
            
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(412, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Retour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Formlisteloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 478);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridListeloc);
            this.Name = "Formlisteloc";
            this.Text = "Formlisteloc";
            this.Load += new System.EventHandler(this.Formlisteloc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListeloc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListeloc;
        private System.Windows.Forms.Button button1;
    }
}