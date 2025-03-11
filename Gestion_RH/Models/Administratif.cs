namespace Gestion_RH.Models
{
    class Administratif : Personnel
    {
        public Administratif(int code, string nom, string prenom, string bureau, double salaire)
            : base(code, nom, prenom, bureau, salaire) { }

        public override void Calculer_Salaire() { }
    }
}