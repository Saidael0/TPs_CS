using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class GestionEmployes
    {
        
            private List<Employee> employes = new List<Employee>();

            public void AjouterEmploye(Employee employe)
            {
                employes.Add(employe);
            }

            public void SupprimerEmploye(string nom)
            {
                employes.RemoveAll(e => e.Nom == nom);
            }

            public double CalculerSalaireTotal()
            {
                return employes.Sum(e => e.Salaire);
            }

            public double CalculerSalaireMoyen()
            {
                return employes.Count > 0 ? employes.Average(e => e.Salaire) : 0;
            }

            public void AfficherEmployes()
            {
                Console.WriteLine("\n Liste des employés :");
                foreach (var employe in employes)
                    Console.WriteLine(employe);
            }
        }
    }