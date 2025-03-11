using System;
using System.Collections.Generic;
namespace Gestion_RH.Models
{
    class Enseignant : Personnel
    {
        public string Grade { get; set; }
        public int VolumeHoraire { get; set; }
        private Dictionary<string, List<Etudiant>> groupes;

        public Enseignant(int code, string nom, string prenom, string bureau, double salaire, string grade, int volume)
            : base(code, nom, prenom, bureau, salaire)
        {
            Grade = grade;
            VolumeHoraire = volume;
            groupes = new Dictionary<string, List<Etudiant>>();
        }

        public void Ajouter_groupe(string nomGroupe)
        {
            if (!groupes.ContainsKey(nomGroupe))
                groupes[nomGroupe] = new List<Etudiant>();
        }

        public void Ajouter_etudiant(string nomGroupe, Etudiant etudiant)
        {
            if (groupes.ContainsKey(nomGroupe))
                groupes[nomGroupe].Add(etudiant);
        }

        public List<Etudiant> this[string nomGroupe] => groupes.ContainsKey(nomGroupe) ? groupes[nomGroupe] : new List<Etudiant>();


        public override void Calculer_Salaire()
        {
            double taux = Grade switch
            {
                "PA" => 300,
                "PH" => 350,
                "PES" => 400,
                _ => 0
            };

            Salaire += VolumeHoraire * taux;
        }
    }
}