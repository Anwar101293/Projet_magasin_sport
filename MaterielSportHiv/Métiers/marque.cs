using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterielSportHiv.Métiers
{
    public class marque
    {
        public int IdMarque;
        public string NomMarque;

        public marque(int idmarque, string nomMarque)
        {
            this.IdMarque = idmarque;
            this.NomMarque = nomMarque;
        }

        public int GetIdMarque()
        {
            return IdMarque;
        }
        public int SetIdMarque(int idmarque)
        {
            return IdMarque = idmarque;
        }

        public string GetNomMarque()
        {
            return NomMarque;
        }
        public string SetNomMarque(string nomMarque)
        {
            return NomMarque = nomMarque;
        }

    }
}
