using System;

namespace Gestion_RH.Models
{
    class Etudiant : Personne
    {
        public string Niveau { get; set; }
        public double Moyenne { get; set; }

        public Etudiant(int code, string nom, string prenom, string niveau, double moyenne)
            : base(code, nom, prenom)
        {
            Niveau = niveau;
            Moyenne = moyenne;
        }

        public void Afficher_etd()
        {
            Console.WriteLine($" {Nom} {Prenom} | Niveau: {Niveau} | Moyenne: {Moyenne}");
        }
    }
}
