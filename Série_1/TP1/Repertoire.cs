using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1
{
    class Repertoire
    {
        public string Nom { get; set; }
        private List<Fichier> fichiers;

        public Repertoire(string nom)
        {
            Nom = nom;
            fichiers = new List<Fichier>();
        }

        public void Afficher()
        {
            Console.WriteLine($"\n📁 Répertoire : {Nom}");
            if (fichiers.Count == 0)
            {
                Console.WriteLine("  (Aucun fichier dans ce répertoire)");
            }
            else
            {
                foreach (var fichier in fichiers)
                {
                    Console.WriteLine($"  - {fichier}");
                }
            }
        }

        public int Rechercher(string nom)
        {
            return fichiers.FindIndex(f => f.Nom == nom);
        }

        public void Ajouter(Fichier fichier)
        {
            if (fichiers.Count < 30)
            {
                fichiers.Add(fichier);
                Console.WriteLine($"✅ Fichier {fichier.Nom}.{fichier.Extension} ajouté !");
            }
            else
            {
                Console.WriteLine("❌ Impossible d'ajouter plus de 30 fichiers !");
            }
        }

        public void Supprimer(string nom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers.RemoveAt(index);
                Console.WriteLine($"🗑️ Fichier {nom} supprimé !");
            }
            else
            {
                Console.WriteLine($"❌ Fichier {nom} introuvable !");
                Afficher();
            }
        }

        public void Renommer(string ancienNom, string nouveauNom)
        {
            int index = Rechercher(ancienNom);
            if (index != -1)
            {
                fichiers[index].Nom = nouveauNom;
                Console.WriteLine($"✏️ Fichier {ancienNom} renommé en {nouveauNom} !");
            }
            else
            {
                Console.WriteLine($"❌ Fichier {ancienNom} introuvable !");
                Console.WriteLine("📂 Liste des fichiers existants :");
                Afficher();
            }
        }

        public void ModifierTaille(string nom, float nouvelleTaille)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Taille = nouvelleTaille;
                Console.WriteLine($"📏 Taille de {nom} modifiée à {nouvelleTaille} Ko.");
            }
            else
            {
                Console.WriteLine($"❌ Fichier {nom} introuvable !");
            }
        }

        public void RechercherPDF()
        {
            var pdfs = fichiers.FindAll(f => f.Extension == "pdf");
            if (pdfs.Count == 0)
            {
                Console.WriteLine("📄 Aucun fichier PDF trouvé.");
            }
            else
            {
                Console.WriteLine("📄 Fichiers PDF trouvés :");
                foreach (var pdf in pdfs)
                {
                    Console.WriteLine($"  - {pdf}");
                }
            }
        }

        public float GetTaille()
        {
            float totalTaille = 0;
            foreach (var fichier in fichiers)
            {
                totalTaille += fichier.Taille;
            }
            return totalTaille / 1024; // Conversion en MO
        }
    }
}

