using System;
using TP1;

class Program
{
    static void Main()
    {
        Repertoire monRepertoire = new Repertoire("MesDocuments");

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1 - Ajouter un fichier");
            Console.WriteLine("2 - Afficher le répertoire");
            Console.WriteLine("3 - Rechercher un fichier");
            Console.WriteLine("4 - Supprimer un fichier");
            Console.WriteLine("5 - Renommer un fichier");
            Console.WriteLine("6 - Modifier la taille d'un fichier");
            Console.WriteLine("7 - Rechercher les fichiers PDF");
            Console.WriteLine("8 - Afficher la taille totale du répertoire (MO)");
            Console.WriteLine("9 - Quitter");
            Console.Write("Votre choix : ");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int choix) || choix < 1 || choix > 9)
            {
                Console.WriteLine("❌ Choix invalide !");
                continue;
            }

            try
            {
                switch (choix)
                {
                    case 1:
                        Console.Write("Nom du fichier : ");
                        string nom = Console.ReadLine();
                        Console.Write("Extension du fichier : ");
                        string extension = Console.ReadLine();
                        Console.Write("Taille du fichier (Ko) : ");

                        if (!float.TryParse(Console.ReadLine(), out float taille) || taille < 0)
                        {
                            Console.WriteLine("❌ Taille invalide !");
                            break;
                        }

                        monRepertoire.Ajouter(new Fichier(nom, extension, taille));
                        break;

                    case 2:
                        monRepertoire.Afficher();
                        break;

                    case 3:
                        Console.Write("Nom du fichier à rechercher : ");
                        string nomRech = Console.ReadLine();
                        int index = monRepertoire.Rechercher(nomRech);
                        Console.WriteLine(index != -1 ? $"✅ Fichier {nomRech} trouvé." : "❌ Fichier introuvable.");
                        break;

                    case 4:
                        monRepertoire.Afficher();
                        Console.Write("Nom du fichier à supprimer : ");
                        string nomSupp = Console.ReadLine();
                        monRepertoire.Supprimer(nomSupp);
                        break;

                    case 5:
                        monRepertoire.Afficher();
                        Console.Write("Nom du fichier à renommer : ");
                        string ancienNom = Console.ReadLine();

                        if (monRepertoire.Rechercher(ancienNom) == -1)
                        {
                            Console.WriteLine($"❌ Fichier '{ancienNom}' introuvable !");
                            break;
                        }

                        Console.Write("Nouveau nom : ");
                        string nouveauNom = Console.ReadLine();
                        monRepertoire.Renommer(ancienNom, nouveauNom);
                        break;

                    case 6:
                        Console.Write("Nom du fichier à modifier : ");
                        string nomModif = Console.ReadLine();
                        Console.Write("Nouvelle taille (Ko) : ");

                        if (!float.TryParse(Console.ReadLine(), out float nouvelleTaille) || nouvelleTaille < 0)
                        {
                            Console.WriteLine("❌ Taille invalide !");
                            break;
                        }

                        monRepertoire.ModifierTaille(nomModif, nouvelleTaille);
                        break;

                    case 7:
                        monRepertoire.RechercherPDF();
                        break;

                    case 8:
                        Console.WriteLine($"📂 Taille totale du répertoire : {monRepertoire.GetTaille()} Mo");
                        break;

                    case 9:
                        Console.WriteLine("👋 Au revoir !");
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Erreur : {ex.Message}");
            }
        }
    }
}
