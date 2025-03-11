using System;
namespace Gestion_RH.Models
{
    class Directeur : Personnel
    {
        private static Directeur instance;
        public double PrimeDeplacement { get; set; }

        private Directeur(int code, string nom, string prenom, string bureau, double salaire, double prime)
            : base(code, nom, prenom, bureau, salaire)
        {
            PrimeDeplacement = prime;
        }

        public static Directeur GetInstance(int code, string nom, string prenom, string bureau, double salaire, double prime)
        {
            if (instance == null)
                instance = new Directeur(code, nom, prenom, bureau, salaire, prime);
            else
                Console.WriteLine("❌ Un directeur existe déjà !");

            return instance;
        }

        public override void Calculer_Salaire()
        {
            Salaire += PrimeDeplacement;
        }
    }
}