using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Programmeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Bureau { get; set; }

        public Programmeur(int id, string nom, string prenom, int bureau)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Bureau = bureau;
        }

        public override string ToString()
        {
            return $"{Id} - {Nom} {Prenom} (Bureau: {Bureau})";
        }
    }
}

