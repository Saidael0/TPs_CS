using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TP5
{
    class CompteBancaire
    {
        private static string historyFile = "historique.txt"; // 📌 Ajout de la variable globale

        public string Numero { get; private set; }
        public string Titulaire { get; private set; }
        public double Solde { get; private set; }
        private List<string> historique;

        public CompteBancaire(string titulaire, double solde)
        {
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Titulaire = titulaire;
            Solde = solde;
            historique = new List<string>();
            Enregistrer("Création du compte");
        }

        public void Crediter()
        {
            Console.Write("Montant à créditer : ");
            double montant = double.Parse(Console.ReadLine());
            Solde += montant;
            Enregistrer($"Crédit de {montant} Dhs");
            Console.WriteLine("✅ Montant crédité avec succès !");
        }

        public void Debiter()
        {
            Console.Write("Montant à débiter : ");
            double montant = double.Parse(Console.ReadLine());
            if (montant > Solde)
                Console.WriteLine("❌ Fonds insuffisants !");
            else
            {
                Solde -= montant;
                Enregistrer($"Débit de {montant} Dhs");
                Console.WriteLine("✅ Montant débité avec succès !");
            }
        }

        public void Transferer(List<CompteBancaire> comptes)
        {
            Console.Write("Numéro du compte destinataire : ");
            string num = Console.ReadLine();
            CompteBancaire destinataire = comptes.Find(c => c.Numero == num);

            if (destinataire == null)
            {
                Console.WriteLine("❌ Ce compte n'existe pas !");
                return;
            }

            Console.Write("Montant à transférer : ");
            double montant = double.Parse(Console.ReadLine());

            if (montant > Solde)
                Console.WriteLine("❌ Fonds insuffisants !");
            else
            {
                Debiter();
                destinataire.Crediter();
                Console.WriteLine("✅ Transfert effectué avec succès !");
            }
        }

        public void AfficherHistorique()
        {
            Console.WriteLine("\nHistorique :");
            historique.ForEach(Console.WriteLine);
        }

        private void Enregistrer(string operation)
        {
            string log = $"{DateTime.Now}: {operation} | Solde: {Solde} Dhs";
            historique.Add(log);
            File.AppendAllText(historyFile, log + Environment.NewLine); // 📌 Correction ici
        }

        public override string ToString() => $"Compte {Numero} | {Titulaire} | Solde: {Solde} Dhs";
    }
}
