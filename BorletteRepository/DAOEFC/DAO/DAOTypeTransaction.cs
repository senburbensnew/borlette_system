using BorletteDTO;
using BorletteDTO.Enums;
using BorletteRepository.DAOEFC.EFC;
using BorletteRepository.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.DAOEFC.DAO
{
    public class DAOTypeTransaction:IDAOTypeTransaction
    {

        private string _ConnectionString;
        public string ConnectionString { get => _ConnectionString; set => _ConnectionString = value; }
        public DAOTypeTransaction(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        List<ParametreReference> IDAOTypeTransaction.getAllTypeTransaction()
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<ParametreReference> lst = (from t in db.TblProfessions

                                    select new ParametreReference(t.Id, t.Libelle)
                                    ).ToList();
                return lst;
            } 
        }
    }
}
