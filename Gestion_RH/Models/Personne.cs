namespace Gestion_RH.Models
{
    abstract class Personne
    {
        public int Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        protected Personne(int code, string nom, string prenom)
        {
            Code = code;
            Nom = nom;
            Prenom = prenom;
        }
    }
}
