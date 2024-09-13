using BorletteDTO;
using BorletteDTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.IDAO
{
    public interface IDAOMiseJoueur
    {
        public List<MiseJoueur> GetMiseJoueurByTirage(long idTirage);
        public List<MiseJoueur> GetMiseJoueurByTirageAndUtilisateur(long idTirage, long IdUtilisateur);

        public List<MiseJoueur> GetMiseJoueurByTirageAndUtilisateurAndStatut(long idTirage, long IdUtilisateur,StatutMise stat);

        public List<MiseJoueur> GetMiseJoueurUtilisateur( long IdUtilisateur);

        public MiseJoueur GetMiseJoueurByID(long ID);

        public long Save(MiseJoueur mise, string user);
    }
}
