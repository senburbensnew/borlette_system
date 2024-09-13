using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteDTO.Enums
{
    public enum StatutTirage
    {
        Ferme =1,
        Ouvert= 2,
        Annule = 3
    }

    public enum SensTransaction
    {
        Credit= 1,
        Debit= 2
    }
    public enum ProfilUtilisateur
    {
        Joueur= 1,
        Manager= 2
    }
    public enum StatutMise {
        Annuler= 1,
        EnCours= 2,
        Valider= 3
    }

    public enum StatutUtilisateur
    {
        Actif=1,
        Inactif
    }

}
