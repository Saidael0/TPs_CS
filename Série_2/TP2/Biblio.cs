using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP2
{
    class Biblio
    {
        private List<Document> documents = new List<Document>();

        public void AjouterDocument(Document doc)
        {
            documents.Add(doc);
        }

        public int NombreDeLivres()
        {
            return documents.OfType<Livre>().Count();
        }

        public void AfficherDictionnaires()
        {
            Console.WriteLine("\n Liste des dictionnaires :");
            foreach (var doc in documents.OfType<Dictionnaire>())
                Console.WriteLine(doc.Description());
        }

        public void TousLesAuteurs()
        {
            Console.WriteLine("\n Liste des auteurs et numéros :");
            foreach (var doc in documents)
            {
                if (doc is Livre livre)
                    Console.WriteLine($" {doc.Numero} - {doc.Titre} | Auteur : {livre.Auteur}");
                else
                    Console.WriteLine($" {doc.Numero} - {doc.Titre} | Pas d'auteur");
            }
        }

        public void ToutesLesDescriptions()
        {
            Console.WriteLine("\n Descriptions des documents :");
            foreach (var doc in documents)
                Console.WriteLine(doc.Description());
        }
    }
}

