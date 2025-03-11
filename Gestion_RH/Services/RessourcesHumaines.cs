using System;
using System.Linq;
using System.Collections.Generic;
using Gestion_RH.Interfaces;
using Gestion_RH.Models;

namespace Gestion_RH.Services
{
    class RessourcesHumaines : IRessourcesHumaines
    {
        private List<Personnel> GRH = new List<Personnel>();

        public void AjouterPersonnel(Personnel p)
        {
            GRH.Add(p);
        }

        public void Afficher_Enseignants()
        {
            var enseignants = GRH.OfType<Enseignant>();
            foreach (var e in enseignants)
                Console.WriteLine($"{e.Nom} {e.Prenom} - Grade: {e.Grade}");
        }

        public int Rechercher_Ens(int code)
        {
            var ens = GRH.OfType<Enseignant>().FirstOrDefault(e => e.Code == code);
            return ens != null ? GRH.IndexOf(ens) : -1;
        }
    }
}
