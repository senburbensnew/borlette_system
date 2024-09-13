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
    public class DAOMiseJoueur:IDAOMiseJoueur
    {

        private string _ConnectionString;
        public string ConnectionString { get => _ConnectionString; set => _ConnectionString = value; }
        public DAOMiseJoueur(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        List<MiseJoueur> IDAOMiseJoueur.GetMiseJoueurByTirage(long idTirage)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<MiseJoueur> lst = (from m in db.TblMiseJoueurs
                                        join t in db.TblTirages on m.IdTirage equals t.Id
                                        join u in db.TblUtilisateurs on m.IdUtilisateur equals u.Id
                                        into utTemp from ut in utTemp.DefaultIfEmpty()
                                        join p in db.TblProfessions on ut.IdProfession equals p.Id
                                        where m.IdTirage == idTirage
                                        select new MiseJoueur(m.Id, (StatutMise)m.IdStatutMise,
                                                                new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                                    t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation),
                                                                ut == null? null: new Utilisateur( ut.CodeUtilisateur,ut.DateNaissance ,ut.Email,ut.Id,ut.Password,ut.Nif,ut.Nom,ut.Prenom , ut.Sexe,(StatutUtilisateur)ut.IdStatut ,(ProfilUtilisateur)ut.IdProfil , new ParametreReference(ut.IdProfession,p.Libelle)),
                                                                (int)m.MisePremierNumeroGagnant, (int)m.MiseDeuxiemeNumeroGagnant,
                                                                (int)m.MiseTroisiemeNumeroGagnant, (int)t.PremierNumeroGagnant, (int)m.DeuxiemeNumeroGagnant,
                                                                (int)t.TroisiemeNumeroGagnant)
                                    ).ToList();
                return lst;
            }
        }

        List<MiseJoueur> IDAOMiseJoueur.GetMiseJoueurByTirageAndUtilisateur(long idTirage, long IdUtilisateur)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<MiseJoueur> lst = (from m in db.TblMiseJoueurs
                                        join t in db.TblTirages on m.IdTirage equals t.Id
                                        join u in db.TblUtilisateurs on m.IdUtilisateur equals u.Id
                                        into utTemp
                                        from ut in utTemp.DefaultIfEmpty()
                                        join p in db.TblProfessions on ut.IdProfession equals p.Id
                                        where m.IdTirage == idTirage && m.IdUtilisateur == IdUtilisateur
                                        select new MiseJoueur(m.Id, (StatutMise)m.IdStatutMise,
                                                                new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                                    t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation),
                                                                ut == null ? null : new Utilisateur(ut.CodeUtilisateur, ut.DateNaissance, ut.Email, ut.Id, ut.Password, ut.Nif, ut.Nom, ut.Prenom, ut.Sexe, (StatutUtilisateur)ut.IdStatut, (ProfilUtilisateur)ut.IdProfil, new ParametreReference(ut.IdProfession, p.Libelle)),
                                                                (int)m.MisePremierNumeroGagnant, (int)m.MiseDeuxiemeNumeroGagnant,
                                                                (int)m.MiseTroisiemeNumeroGagnant, (int)t.PremierNumeroGagnant, (int)m.DeuxiemeNumeroGagnant,
                                                                (int)t.TroisiemeNumeroGagnant)
                                    ).ToList();
                return lst;
            }
        }

        List<MiseJoueur> IDAOMiseJoueur.GetMiseJoueurByTirageAndUtilisateurAndStatut(long idTirage, long IdUtilisateur, StatutMise stat)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<MiseJoueur> lst = (from m in db.TblMiseJoueurs
                                        join t in db.TblTirages on m.IdTirage equals t.Id
                                        join u in db.TblUtilisateurs on m.IdUtilisateur equals u.Id
                                        into utTemp
                                        from ut in utTemp.DefaultIfEmpty()
                                        join p in db.TblProfessions on ut.IdProfession equals p.Id
                                        where m.IdTirage == idTirage && m.IdUtilisateur == IdUtilisateur && m.IdStatutMise == (short)stat
                                        select new MiseJoueur(m.Id, (StatutMise)m.IdStatutMise,
                                                                new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                                    t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation),
                                                                ut == null ? null : new Utilisateur(ut.CodeUtilisateur, ut.DateNaissance, ut.Email, ut.Id, ut.Password, ut.Nif, ut.Nom, ut.Prenom, ut.Sexe, (StatutUtilisateur)ut.IdStatut, (ProfilUtilisateur)ut.IdProfil, new ParametreReference(ut.IdProfession, p.Libelle)),
                                                                (int)m.MisePremierNumeroGagnant, (int)m.MiseDeuxiemeNumeroGagnant,
                                                                (int)m.MiseTroisiemeNumeroGagnant, (int)t.PremierNumeroGagnant, (int)m.DeuxiemeNumeroGagnant,
                                                                (int)t.TroisiemeNumeroGagnant)
                                    ).ToList();
                return lst;
            }
        }

        List<MiseJoueur> IDAOMiseJoueur.GetMiseJoueurUtilisateur(long IdUtilisateur)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<MiseJoueur> lst = (from m in db.TblMiseJoueurs
                                        join t in db.TblTirages on m.IdTirage equals t.Id
                                        join u in db.TblUtilisateurs on m.IdUtilisateur equals u.Id
                                        into utTemp
                                        from ut in utTemp.DefaultIfEmpty()
                                        join p in db.TblProfessions on ut.IdProfession equals p.Id
                                        where m.IdUtilisateur == IdUtilisateur
                                        select new MiseJoueur(m.Id, (StatutMise)m.IdStatutMise,
                                                                new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                                    t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation),
                                                                ut == null ? null : new Utilisateur(ut.CodeUtilisateur, ut.DateNaissance, ut.Email, ut.Id, ut.Password, ut.Nif, ut.Nom, ut.Prenom, ut.Sexe, (StatutUtilisateur)ut.IdStatut, (ProfilUtilisateur)ut.IdProfil, new ParametreReference(ut.IdProfession, p.Libelle)),
                                                                (int)m.MisePremierNumeroGagnant, (int)m.MiseDeuxiemeNumeroGagnant,
                                                                (int)m.MiseTroisiemeNumeroGagnant, (int)t.PremierNumeroGagnant, (int)m.DeuxiemeNumeroGagnant,
                                                                (int)t.TroisiemeNumeroGagnant)
                                    ).ToList();
                return lst;
            }
        }

        MiseJoueur IDAOMiseJoueur.GetMiseJoueurByID(long ID)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                MiseJoueur? mise = (from m in db.TblMiseJoueurs
                                        join t in db.TblTirages on m.IdTirage equals t.Id
                                        join u in db.TblUtilisateurs on m.IdUtilisateur equals u.Id
                                        into utTemp
                                        from ut in utTemp.DefaultIfEmpty()
                                        join p in db.TblProfessions on ut.IdProfession equals p.Id
                                        where m.Id == ID
                                        select new MiseJoueur(m.Id, (StatutMise)m.IdStatutMise,
                                                                new Tirage(t.Id, (StatutTirage)t.IdStatutTirage, t.CoefficientPremierNumeroGagnant, t.PremierNumeroGagnant,
                                                                    t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientDeuxiemeNumeroGagnant, t.CoefficientTroisiemeNumeroGagnant, t.TroisiemeNumeroGagnant, t.DateCreation),
                                                                ut == null ? null : new Utilisateur(ut.CodeUtilisateur,ut.DateNaissance, ut.Email, ut.Id, ut.Password, ut.Nif, ut.Nom, ut.Prenom, ut.Sexe, (StatutUtilisateur)ut.IdStatut, (ProfilUtilisateur)ut.IdProfil, new ParametreReference(ut.IdProfession, p.Libelle)),
                                                                (int)m.MisePremierNumeroGagnant, (int)m.MiseDeuxiemeNumeroGagnant,
                                                                (int)m.MiseTroisiemeNumeroGagnant, (int)t.PremierNumeroGagnant, (int)m.DeuxiemeNumeroGagnant,
                                                                (int)t.TroisiemeNumeroGagnant)
                                    ).FirstOrDefault();
                return mise;
            }
        }

        long IDAOMiseJoueur.Save(MiseJoueur mise, string user)
        {
            long result = 0;
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                //Validate by using Agency name, email, and url

                TblMiseJoueur? efcMiseJoueur = (from c in db.TblMiseJoueurs
                                                where c.Id == mise.Id
                                                select c).FirstOrDefault();

                if (efcMiseJoueur is null)
                {

                    efcMiseJoueur = new TblMiseJoueur();

                    efcMiseJoueur.IdStatutMise = (short)mise.Statut;
                    efcMiseJoueur.IdUtilisateur = mise.IdUtilissateur;
                    efcMiseJoueur.IdTirage = mise.IdTirage;
                    

                    efcMiseJoueur.MisePremierNumeroGagnant = mise.MisePremierNumero;
                    efcMiseJoueur.PremierNumeroGagnant = mise.PremierNumero;

                    efcMiseJoueur.MiseDeuxiemeNumeroGagnant = mise.DeuxiemeNumero;
                    efcMiseJoueur.DeuxiemeNumeroGagnant = mise.DeuxiemeNumero;

                    efcMiseJoueur.MiseTroisiemeNumeroGagnant = mise.MiseTroisiemeNumero;
                    efcMiseJoueur.TroisiemeNumeroGagnant = mise.TroisiemeNumero;

                    efcMiseJoueur.DateCreated = DateTime.Now;
                    //efcMiseJoueur.Cr = user;

                    db.TblMiseJoueurs.Add(efcMiseJoueur);
                    result = db.SaveChanges();

                    mise.Id = efcMiseJoueur.Id;
                }
                else
                {
                    //Mise a jour dans certaine condition
                    efcMiseJoueur.IdStatutMise = (short)mise.Statut;
                    efcMiseJoueur.IdUtilisateur = mise.IdUtilissateur;
                    efcMiseJoueur.IdTirage = mise.IdTirage;


                    efcMiseJoueur.MisePremierNumeroGagnant = mise.MisePremierNumero;
                    efcMiseJoueur.PremierNumeroGagnant = mise.PremierNumero;

                    efcMiseJoueur.MiseDeuxiemeNumeroGagnant = mise.DeuxiemeNumero;
                    efcMiseJoueur.DeuxiemeNumeroGagnant = mise.DeuxiemeNumero;

                    efcMiseJoueur.MiseTroisiemeNumeroGagnant = mise.MiseTroisiemeNumero;
                    efcMiseJoueur.TroisiemeNumeroGagnant = mise.TroisiemeNumero;

                    //Mise a jour du numero Gagnant
                    efcMiseJoueur.MontantGagne = mise.MontantGagne; 

                    result = db.SaveChanges();
                }

                return result;

            }
        }
    }
}
