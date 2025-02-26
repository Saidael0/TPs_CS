// See https://aka.ms/new-console-template for more information
using System;

namespace TP2
{
    class Program
    {
        static void Main()
        {
            Repertoire monRepertoire = new Repertoire();

            // Ajouter quelques programmeurs de test
            monRepertoire.AjouterProgrammeur(new Programmeur(1, "REGNIER", "PATRICK", 205));
            monRepertoire.AjouterProgrammeur(new Programmeur(2, "FAVRE", "JEAN-MARIE", 566));

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1️⃣ Ajouter un programmeur");
                Console.WriteLine("2️⃣ Afficher les programmeurs");
                Console.WriteLine("3️⃣ Ajouter une consommation");
                Console.WriteLine("4️⃣ Afficher les consommations");
                Console.WriteLine("5️⃣ Afficher la consommation totale");
                Console.WriteLine("6️⃣ Quitter");
                Console.Write("🔹 Choix : ");

                int choix;
                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("❌ Choix invalide !");
                    continue;
                }

                switch (choix)
                {
                    case 1:
                        Console.Write("ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nom : ");
                        string nom = Console.ReadLine();
                        Console.Write("Prénom : ");
                        string prenom = Console.ReadLine();
                        Console.Write("Bureau : ");
                        int bureau = int.Parse(Console.ReadLine());
                        monRepertoire.AjouterProgrammeur(new Programmeur(id, nom, prenom, bureau));
                        break;

                    case 2:
                        monRepertoire.AfficherProgrammeurs();
                        break;

                    case 3:
                        Console.Write("Numéro de semaine : ");
                        int semaine = int.Parse(Console.ReadLine());
                        Console.Write("ID du programmeur : ");
                        int idProg = int.Parse(Console.ReadLine());
                        Console.Write("Nombre de tasses : ");
                        int nbTasses = int.Parse(Console.ReadLine());
                        monRepertoire.AjouterConsommation(semaine, idProg, nbTasses);
                        break;

                    case 4:
                        monRepertoire.AfficherConsommations();
                        break;

                    case 5:
                        Console.WriteLine($"☕ Consommation totale : {monRepertoire.TotalTasses()} tasses");
                        break;

                    case 6:
                        Console.WriteLine("👋 Au revoir !");
                        return;

                    default:
                        Console.WriteLine("❌ Choix invalide !");
                        break;
                }
            }
        }
    }
}

