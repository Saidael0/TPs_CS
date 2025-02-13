using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TP5

{
    class Program
    {
        static string usersFile = "users.json";
        static string accountsFile = "comptes.json";
        static string historyFile = "textTP5.txt";

        static List<CompteBancaire> comptes = new List<CompteBancaire>();
        static Dictionary<string, string> users = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            ChargerUtilisateurs();
            ChargerComptes();

            Console.WriteLine("===== Connexion =====");
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Mot de passe: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(login) && users[login] == password)
            {
                Console.WriteLine("\n✅ Connexion réussie !");
                MenuPrincipal();
            }
            else
            {
                Console.WriteLine("\n❌ Identifiant ou mot de passe incorrect.");
            }
        }

        static void ChargerUtilisateurs()
        {
            if (File.Exists(usersFile))
            {
                string json = File.ReadAllText(usersFile);
                users = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                users["admin"] = "admin123";
                File.WriteAllText(usersFile, JsonConvert.SerializeObject(users));
            }
        }

        static void ChargerComptes()
        {
            if (File.Exists(accountsFile))
            {
                string json = File.ReadAllText(accountsFile);
                comptes = JsonConvert.DeserializeObject<List<CompteBancaire>>(json);
            }
        }

        static void SauvegarderComptes()
        {
            File.WriteAllText(accountsFile, JsonConvert.SerializeObject(comptes));
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n===== MENU PRINCIPAL =====");
                Console.WriteLine("1 - Créer un compte bancaire");
                Console.WriteLine("2 - Opérations sur un compte");
                Console.WriteLine("3 - Afficher tous les comptes");
                Console.WriteLine("4 - Rechercher un compte");
                Console.WriteLine("5 - Supprimer un compte");
                Console.WriteLine("6 - Quitter");
                Console.Write("Votre choix : ");

                switch (Console.ReadLine())
                {
                    case "1": CreerCompte(); break;
                    case "2": OperationsCompte(); break;
                    case "3": AfficherComptes(); break;
                    case "4": RechercherCompte(); break;
                    case "5": SupprimerCompte(); break;
                    case "6": return;
                    default: Console.WriteLine("❌ Choix invalide."); break;
                }
            }
        }

        static void CreerCompte()
        {
            Console.Write("\nNom du titulaire : ");
            string nom = Console.ReadLine();
            Console.Write("Montant initial : ");
            double solde = double.Parse(Console.ReadLine());

            CompteBancaire compte = new CompteBancaire(nom, solde);
            comptes.Add(compte);
            SauvegarderComptes();
            Console.WriteLine($"✅ Compte créé avec succès ! Numéro: {compte.Numero}");
        }

        static void OperationsCompte()
        {
            Console.Write("\nEntrez le numéro du compte : ");
            string num = Console.ReadLine();
            CompteBancaire compte = comptes.Find(c => c.Numero == num);

            if (compte == null)
            {
                Console.WriteLine("❌ Ce compte n'existe pas !");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n===== MENU OPÉRATIONS =====");
                Console.WriteLine("1 - Créditer");
                Console.WriteLine("2 - Débiter");
                Console.WriteLine("3 - Voir l'historique");
                Console.WriteLine("4 - Transférer de l'argent");
                Console.WriteLine("5 - Retour");
                Console.Write("Votre choix : ");

                switch (Console.ReadLine())
                {
                    case "1": compte.Crediter(); SauvegarderComptes(); break;
                    case "2": compte.Debiter(); SauvegarderComptes(); break;
                    case "3": compte.AfficherHistorique(); break;
                    case "4": compte.Transferer(comptes); SauvegarderComptes(); break;
                    case "5": return;
                    default: Console.WriteLine("❌ Choix invalide."); break;
                }
            }
        }

        static void AfficherComptes()
        {
            Console.WriteLine("\n===== LISTE DES COMPTES =====");
            foreach (var compte in comptes)
            {
                Console.WriteLine(compte);
            }
        }

        static void RechercherCompte()
        {
            Console.Write("\nEntrez le numéro du compte : ");
            string num = Console.ReadLine();
            CompteBancaire compte = comptes.Find(c => c.Numero == num);

            if (compte != null)
                Console.WriteLine(compte);
            else
                Console.WriteLine("❌ Ce compte n'existe pas !");
        }

        static void SupprimerCompte()
        {
            Console.Write("\nEntrez le numéro du compte à supprimer : ");
            string num = Console.ReadLine();
            comptes.RemoveAll(c => c.Numero == num);
            SauvegarderComptes();
            Console.WriteLine("✅ Compte supprimé avec succès.");
        }
    }

   
}
