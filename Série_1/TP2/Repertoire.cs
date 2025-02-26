using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;

namespace TP2
{
    class Repertoire
    {
        private List<Programmeur> programmeurs = new List<Programmeur>();
        private List<(int Semaine, int ProgrammeurId, int NbTasses)> consommations = new List<(int, int, int)>();

        public void AjouterProgrammeur(Programmeur p)
        {
            programmeurs.Add(p);
        }

        public void AfficherProgrammeurs()
        {
            Console.WriteLine("\n📋 Liste des Programmeurs :");
            foreach (var p in programmeurs)
            {
                Console.WriteLine(p);
            }
        }

        public void AjouterConsommation(int semaine, int idProgrammeur, int nbTasses)
        {
            if (programmeurs.Any(p => p.Id == idProgrammeur))
            {
                consommations.Add((semaine, idProgrammeur, nbTasses));
                Console.WriteLine("✅ Consommation ajoutée !");
            }
            else
            {
                Console.WriteLine("❌ Programmeur introuvable !");
            }
        }

        public void AfficherConsommations()
        {
            Console.WriteLine("\n☕ Consommation de café :");
            foreach (var c in consommations)
            {
                Console.WriteLine($"Semaine {c.Semaine} - Programmeur {c.ProgrammeurId} : {c.NbTasses} tasses");
            }
        }

        public int TotalTasses()
        {
            return consommations.Sum(c => c.NbTasses);
        }
    }
}
