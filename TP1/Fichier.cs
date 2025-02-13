using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1
{
    class Fichier
    {
        public string Nom { get; set; }
        public string Extension { get; set; }
        public float Taille { get; set; } // Taille en Ko

        public Fichier(string nom, string extension, float taille)
        {
            Nom = nom;
            Extension = extension;
            Taille = taille;
        }

        public override string ToString()
        {
            return $"{Nom}.{Extension} - {Taille} Ko";
        }
    }
}
