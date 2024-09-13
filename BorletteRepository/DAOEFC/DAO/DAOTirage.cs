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
    public class DAOTirage:IDAOTirage
    {

        private string _ConnectionString;
        public string ConnectionString { get => _ConnectionString; set => _ConnectionString = value; }
        public DAOTirage(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        List<Tirage> IDAOTirage.GetAllTirage()
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<Tirage> lst = (from t in db.TblTirages

                                    select new Tirage( t.Id,(StatutTirage)t.IdStatutTirage,t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                            t.CoefficientDeuxiemeNumeroGagnant,t.CoefficientDeuxiemeNumeroGagnant ,
                                                            t.CoefficientTroisiemeNumeroGagnant , t.TroisiemeNumeroGagnant,t.DateCreation )
                                    ).ToList();
                return lst;
            }
        }

        List<Tirage> IDAOTirage.GetAllTirageByStatut(StatutTirage statut)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<Tirage> lst = (from t in db.TblTirages
                                    where t.IdStatutTirage == (short)statut
                                    select new Tirage( t.Id,(StatutTirage)t.IdStatutTirage,t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                            t.CoefficientDeuxiemeNumeroGagnant,t.CoefficientDeuxiemeNumeroGagnant ,
                                                            t.CoefficientTroisiemeNumeroGagnant , t.TroisiemeNumeroGagnant,t.DateCreation )
                                    ).ToList();
                return lst;
            } 
        }

        Tirage IDAOTirage.GetTirageByID(long ID)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                Tirage? tir = (from t in db.TblTirages
                                    where t.Id == ID
                                    select new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                            t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant,
                                                            t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation)
                                    ).FirstOrDefault();
                return tir;
            }
        }

        long IDAOTirage.Save(Tirage tirage, string user)
        {
            long result = 0;
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                //Validate by using Agency name, email, and url

                TblTirage? efcTirage = (from c in db.TblTirages
                                        where c.Id == tirage.Id
                                                    select c).FirstOrDefault();

                if (efcTirage is null)
                {
                    
                        efcTirage = new TblTirage();

                        efcTirage.IdStatutTirage = (short)tirage.Id_Statut;
                        efcTirage.CoefficientPremierNumeroGagnant = tirage.CoefficientPremierNumero;
                        efcTirage.PremierNumeroGagnant = tirage.PremierNumero;

                        efcTirage.CoefficientDeuxiemeNumeroGagnant = tirage.CoefficientDeuxiemeNumero;
                        efcTirage.SecondNumeroGagnant = tirage.DeuxiemeNumero;

                        efcTirage.CoefficientTroisiemeNumeroGagnant = tirage.CoefficientTroisiemeNumero;
                        efcTirage.TroisiemeNumeroGagnant = tirage.TroisiemeNumero;

                        efcTirage.DateCreation = DateTime.Now;
                        efcTirage.CreatedBy = user;

                        db.TblTirages.Add(efcTirage);
                        result = db.SaveChanges();

                        tirage.Id = efcTirage.Id;
                }
                else
                {
                    //Mise a jour dans certaine condition
                    efcTirage.IdStatutTirage = (short)tirage.Id_Statut;
                    efcTirage.CoefficientPremierNumeroGagnant = tirage.CoefficientPremierNumero;
                    efcTirage.PremierNumeroGagnant = tirage.PremierNumero;

                    efcTirage.CoefficientDeuxiemeNumeroGagnant = tirage.CoefficientDeuxiemeNumero;
                    efcTirage.SecondNumeroGagnant = tirage.DeuxiemeNumero;

                    efcTirage.CoefficientTroisiemeNumeroGagnant = tirage.CoefficientTroisiemeNumero;
                    efcTirage.TroisiemeNumeroGagnant = tirage.TroisiemeNumero;

                    efcTirage.DateModif = DateTime.Now;
                    efcTirage.ModifBy = user;

                     
                    result = db.SaveChanges(); 
                }
                 
                return result;
               
            }
        }
    }
}
