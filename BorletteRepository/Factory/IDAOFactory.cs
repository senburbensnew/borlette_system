using BorletteRepository.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.Factory
{
    public interface IDAOFactory
    {
        public IDAOTirage CreateInstanceDAOTirage();

        public IDAOMiseJoueur CreateInstanceDAOMiseJoueur();

        public IDAOProfession CreateInstanceDAOProfession();

        public IDAOTransaction CreateInstanceDAOTransaction();

        public IDAOUtilisateur CreateInstanceDAOUtilisateur();
    }
}
