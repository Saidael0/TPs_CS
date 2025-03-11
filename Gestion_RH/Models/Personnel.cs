namespace Gestion_RH.Models
{
    abstract class Personnel : Personne
    {
        public string Bureau { get; set; }
        public double Salaire { get; protected set; }

        protected Personnel(int code, string nom, string prenom, string bureau, double salaire)
            : base(code, nom, prenom)
        {
            Bureau = bureau;
            Salaire = salaire;
        }

        public abstract void Calculer_Salaire();
    }
}
