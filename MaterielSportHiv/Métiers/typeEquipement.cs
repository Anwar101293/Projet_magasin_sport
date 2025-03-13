using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterielSportHiv.Métiers
{
    public class typeEquipement
    {
        public string CodeTypeEquipement;
        public string NomTypeEquipement;

        public typeEquipement(string codeTypeEquipement, string nomTypeEquipement)
        {
            this.CodeTypeEquipement = codeTypeEquipement;
            this.NomTypeEquipement = nomTypeEquipement;
        }

        public string GetNomTypeEquipement()
        {
            return NomTypeEquipement;
        }

        public string SetNomTypeEquipement(string nomTypeEquipement)
        {
            return NomTypeEquipement = nomTypeEquipement;
        }

        public string GetCodeTypeEquipement()
        {
            return CodeTypeEquipement;
        }

        public string SetCodeTypeEquipement(string codeTypeEquipement)
        {
            return CodeTypeEquipement = codeTypeEquipement;
        }


    }

}
