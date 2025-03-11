using Gestion_RH.Models;

namespace Gestion_RH.Interfaces
{
    interface IRessourcesHumaines
    {
        void Afficher_Enseignants();
        int Rechercher_Ens(int code);
    }

}
