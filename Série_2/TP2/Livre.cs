using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Livre : Document
    {
        public string Auteur { get; set; }
        public int NbPages { get; set; }

        public Livre(string titre, string auteur, int nbPages) : base(titre)
        {
            Auteur = auteur;
            NbPages = nbPages;
        }

        public override string Description()
        {
            return $" [Livre] {Titre} | Auteur: {Auteur} | Pages: {NbPages}";
        }
    }

}
