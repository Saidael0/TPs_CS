using System;

namespace TP2
{
    class Program
    {
        static void Main()
        {
            Biblio maBiblio = new Biblio();

            maBiblio.AjouterDocument(new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 150));
            maBiblio.AjouterDocument(new Livre("Les Misérables", "Victor Hugo", 1200));
            maBiblio.AjouterDocument(new Dictionnaire("Larousse Français", "Français", 50000));

            maBiblio.ToutesLesDescriptions();
            maBiblio.AfficherDictionnaires();
            maBiblio.TousLesAuteurs();
            Console.WriteLine($" Nombre de livres : {maBiblio.NombreDeLivres()}");
        }
    }
}
