using System;
using Gestion_RH.Models;
using Gestion_RH.Services;



namespace Gestion_RH
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("🚀 Initialisation du système de gestion des ressources humaines...");

            // 📌 Création de la gestion des ressources humaines
            RessourcesHumaines grh = new RessourcesHumaines();

            // 📌 Création et ajout du Directeur (Singleton)
            Directeur directeur = Directeur.GetInstance(1, "BENJELLOUN", "Mohamed", "Bureau D1", 20000, 5000);
            directeur.Calculer_Salaire();
            grh.AjouterPersonnel(directeur);
            Console.WriteLine($"👔 Directeur : {directeur.Nom} {directeur.Prenom} - Salaire : {directeur.Salaire} Dhs");

            // 📌 Création et ajout d'enseignants
            Enseignant ens1 = new Enseignant(2, "OUALI", "Sara", "Bureau E1", 15000, "PA", 10);
            Enseignant ens2 = new Enseignant(3, "EL BOUKILI", "Youssef", "Bureau E2", 15000, "PH", 15);

            ens1.Calculer_Salaire();
            ens2.Calculer_Salaire();

            grh.AjouterPersonnel(ens1);
            grh.AjouterPersonnel(ens2);

            // 📌 Ajout de groupes à l'enseignant
            ens1.Ajouter_groupe("Groupe A");
            ens1.Ajouter_groupe("Groupe B");

            // 📌 Ajout d'étudiants
            Etudiant etd1 = new Etudiant(101, "Amine", "Tazi", "Génie Informatique", 14.5);
            Etudiant etd2 = new Etudiant(102, "Hajar", "Bensalem", "Génie Electrique", 13.0);
            Etudiant etd3 = new Etudiant(103, "Omar", "Fassi", "Génie Informatique", 15.0);

            ens1.Ajouter_etudiant("Groupe A", etd1);
            ens1.Ajouter_etudiant("Groupe A", etd2);
            ens1.Ajouter_etudiant("Groupe B", etd3);

            // 📌 Affichage des enseignants
            Console.WriteLine("\n📚 Liste des enseignants :");
            grh.Afficher_Enseignants();

            // 📌 Affichage des groupes et étudiants d’un enseignant
            Console.WriteLine($"\n🧑‍🏫 {ens1.Nom} {ens1.Prenom} enseigne aux groupes suivants :");
            foreach (var groupe in new string[] { "Groupe A", "Groupe B" })
            {
                Console.WriteLine($"📌 {groupe}:");
                foreach (var etudiant in ens1[groupe])
                    etudiant.Afficher_etd();
            }

            // 📌 Recherche d'un enseignant
            int index = grh.Rechercher_Ens(2);
            Console.WriteLine(index != -1 ? $"\n✅ Enseignant trouvé à l'index {index}" : "\n❌ Enseignant introuvable");

            // 📌 Affichage des salaires
            Console.WriteLine($"\n💰 Salaire du directeur : {directeur.Salaire} Dhs");
            Console.WriteLine($"💰 Salaire de {ens1.Nom} : {ens1.Salaire} Dhs");
            Console.WriteLine($"💰 Salaire de {ens2.Nom} : {ens2.Salaire} Dhs");

            Console.WriteLine("\n✅ Programme terminé avec succès !");
        }
    }
}

