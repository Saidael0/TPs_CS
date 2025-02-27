using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Directeur
    {
        private static Directeur instance;
        private GestionEmployes gestionEmployes;

        private Directeur() { }

        public static Directeur GetInstance()
        {
            if (instance == null)
                instance = new Directeur();
            return instance;
        }

        public void SetGestionEmployes(GestionEmployes gestion)
        {
            gestionEmployes = gestion;
        }

        public void AfficherInformationsEntreprise()
        {
            if (gestionEmployes != null)
            {
                Console.WriteLine($"\n Salaire total : {gestionEmployes.CalculerSalaireTotal()} Dhs");
                Console.WriteLine($" Salaire moyen : {gestionEmployes.CalculerSalaireMoyen()} Dhs");
            }
            else
            {
                Console.WriteLine(" Aucune gestion des employés associée !");
            }
        }
    }
}
