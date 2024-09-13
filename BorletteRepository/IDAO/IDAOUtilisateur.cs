using BorletteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.IDAO
{
    public interface IDAOUtilisateur
    {
        public List<Utilisateur> getAllUtilisateur();
        public Utilisateur getUtilisateurById(long ID);
        public Utilisateur getUtilisateurByCode(string Code);
        public long Save(Utilisateur util, string user);

    }
}
