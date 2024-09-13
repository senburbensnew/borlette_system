using BorletteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.IDAO
{
    public interface IDAOTypeTransaction
    {
        public List<ParametreReference> getAllTypeTransaction();
    }
}
