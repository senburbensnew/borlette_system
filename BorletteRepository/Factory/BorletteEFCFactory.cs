using BorletteRepository.DAOEFC.DAO;
using BorletteRepository.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.Factory
{
    public class BorletteEFCFactory : IDAOFactory
    {
        #region Field/Propriete
            private string _ConnectionString;

            public string ConnectionString
            {
                get => _ConnectionString; set => _ConnectionString = value;
            }
        #endregion
       

        #region Constructeur
            public BorletteEFCFactory(String conn)
            {
                _ConnectionString = conn;
            }

            public BorletteEFCFactory()
            {
                _ConnectionString = "";
            }
        #endregion

         
        #region Instanciation
            IDAOMiseJoueur IDAOFactory.CreateInstanceDAOMiseJoueur()
            {
                return new DAOMiseJoueur(_ConnectionString);
            }

            IDAOProfession IDAOFactory.CreateInstanceDAOProfession()
            {
                return new DAOProfession(_ConnectionString);
            }

            IDAOTirage IDAOFactory.CreateInstanceDAOTirage()
            {
                return new DAOTirage(_ConnectionString);
            }

            IDAOTransaction IDAOFactory.CreateInstanceDAOTransaction()
            {
                throw new NotImplementedException();
            }

            IDAOUtilisateur IDAOFactory.CreateInstanceDAOUtilisateur()
            {
                return new DAOUtilisateur(_ConnectionString);
            }
        #endregion

       
    }

}
