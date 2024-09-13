using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteDTO
{    public class ParametreReference
    {
        #region Attribut
            private long _Id;
            private string _Name;
        #endregion

        #region Constructeur
            public ParametreReference(long id, string name)
            {
                _Id = id;
                _Name = name;
            }
        #endregion

        #region Propriete
            public long Id { get => _Id; set => _Id = value; }
            public string Name { get => _Name; set => _Name = value; }
        #endregion

        public void Valider()
        {
            if (_Name is null || _Name.Length == 0) throw new Exception("Le libellé est obligatoire");
        }
       
    }
}
