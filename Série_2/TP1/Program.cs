using System;

namespace TP1
{
    class Program
    {
        static void Main()
        {
            GestionEmployes gestion = new GestionEmployes();
            gestion.AjouterEmploye(new Employee("Ali", 12000, "Développeur", new DateTime(2020, 5, 1)));
            gestion.AjouterEmploye(new Employee("Fatima", 15000, "Manager", new DateTime(2018, 3, 15)));

            Directeur directeur = Directeur.GetInstance();
            directeur.SetGestionEmployes(gestion);

            gestion.AfficherEmployes();
            directeur.AfficherInformationsEntreprise();
        }
    }
}
