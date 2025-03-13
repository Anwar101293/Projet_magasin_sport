using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterielSportHiv.Métiers
{
    public class Equipement
    {
        public int Id;
        public string Nom;
        public int QuantiteDisponible;
        public decimal PrixLocation;
        public string CodeTypeEquipement;
        public int IdMarque;

        public Equipement(int id, string nom, int quantiteDisponible, decimal prixLocation, string codeTypeEquipement, int idMarque)
        {
            this.Id = id;
            this.Nom = nom;
            this.QuantiteDisponible = quantiteDisponible;
            this.PrixLocation = prixLocation;
            this.CodeTypeEquipement = codeTypeEquipement;
            this.IdMarque = idMarque;

        }

        public String GetNom()
        {
            return this.Nom;
        }
        
        public int GetQuantiteDisponible()
        {
            return this.QuantiteDisponible;
        }
        public decimal GetPrixLocation()
        {
           return this.PrixLocation;
        }

        public string GetCodeTypeEquipement()
        {
            return this.CodeTypeEquipement;
        }

        public int GetIdMarque()
        {
            return this.IdMarque;
        }

        public int GetId()
        {
            return this.Id;
        }

        



    }
    
    
    
}
