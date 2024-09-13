using BorletteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorletteDTO.Enums;
using System.Diagnostics.Metrics;

namespace BorletteRepository.IDAO
{
    public interface IDAOTirage
    {
        public Tirage GetTirageByID(long ID);

        public List<Tirage> GetAllTirageByStatut(StatutTirage Statut);
        public List<Tirage> GetAllTirage();

        public long Save(Tirage tirage, string user);
        
    }
}
