using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TP2
{
    abstract class Document
    {
        private static int compteur = 1;
        public int Numero { get; private set; }
        public string Titre { get; set; }

        public Document(string titre)
        {
            Numero = compteur++;
            Titre = titre;
        }

        public abstract string Description();
    }
}

