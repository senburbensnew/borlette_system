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
    public class DAOUtilisateur : IDAOUtilisateur
    {

        private string _ConnectionString;
        public string ConnectionString { get => _ConnectionString; set => _ConnectionString = value; }
        public DAOUtilisateur(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        } 

        List<Utilisateur> IDAOUtilisateur.getAllUtilisateur()
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                List<Utilisateur> lst = (from u in db.TblUtilisateurs  
                                        join p in db.TblProfessions on u.IdProfession equals p.Id

                                        select new Utilisateur(u.CodeUtilisateur, u.DateNaissance,
                                            u.Email, u.Id, u.Password, u.Nif, u.Nom, u.Prenom, u.Sexe, (StatutUtilisateur)u.IdStatut, 
                                            (ProfilUtilisateur)u.IdProfil, new ParametreReference(u.IdProfession, p.Libelle))
                                    ).ToList();
                return lst;
            }
        }

        Utilisateur IDAOUtilisateur.getUtilisateurById(long ID)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                Utilisateur? util = (from u in db.TblUtilisateurs
                                         join p in db.TblProfessions on u.IdProfession equals p.Id
                                         where u.Id == ID
                                         select new Utilisateur(u.CodeUtilisateur, u.DateNaissance, 
                                             u.Email, u.Id, u.Password, u.Nif, u.Nom, u.Prenom, u.Sexe, (StatutUtilisateur)u.IdStatut,
                                             (ProfilUtilisateur)u.IdProfil, new ParametreReference(u.IdProfession, p.Libelle))
                                    ).FirstOrDefault();
                return util;
            }
        }

        Utilisateur IDAOUtilisateur.getUtilisateurByCode(string Code)
        {
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                Utilisateur? util = (from u in db.TblUtilisateurs
                                     join p in db.TblProfessions on u.IdProfession equals p.Id
                                     where u.CodeUtilisateur == Code
                                     select new Utilisateur(u.CodeUtilisateur, u.DateNaissance, 
                                         u.Email, u.Id, u.Password, u.Nif, u.Nom, u.Prenom, u.Sexe, (StatutUtilisateur)u.IdStatut,
                                         (ProfilUtilisateur)u.IdProfil, new ParametreReference(u.IdProfession, p.Libelle))
                                    ).FirstOrDefault();
                return util;
            }
        }

        long IDAOUtilisateur.Save(Utilisateur util, string user)
        {
            long result = 0;
            using (BorletteContext db = new BorletteContext(this.ConnectionString))
            {
                //Validate by using Agency name, email, and url

                TblUtilisateur? efcUtilisateur = (from c in db.TblUtilisateurs
                                                where c.Id == util.Id
                                                select c).FirstOrDefault();

                if (efcUtilisateur is null)
                {
                    efcUtilisateur = new TblUtilisateur();

                    efcUtilisateur.IdStatut =(short) util.IdStatut; 
                    efcUtilisateur.IdProfession = util.IDProfession; 
                    efcUtilisateur.IdProfil = (short)util.Profil; 
                    efcUtilisateur.CodeUtilisateur = util.CodeUtilisateur;
                    efcUtilisateur.DateNaissance = util.DateNaissance;
                    efcUtilisateur.Email = util.Email;
                    efcUtilisateur.Nif = util.Nif;
                    efcUtilisateur.Nom = util.Nom;
                    efcUtilisateur.Prenom = util.Prenom;
                    efcUtilisateur.Sexe = util.Sexe;

                    efcUtilisateur.Password =util.MotDePasse;  
                     efcUtilisateur.DateCreated = DateTime.Now;
                    efcUtilisateur.CreatedBy = user;

                    db.TblUtilisateurs.Add(efcUtilisateur);
                    result = db.SaveChanges();

                    util.Id = efcUtilisateur.Id;
                }
                else
                {
                    //Mise a jour dans certaine condition
                    efcUtilisateur.IdStatut = (short)util.IdStatut;
                    efcUtilisateur.IdProfession = util.IDProfession;
                    efcUtilisateur.IdProfil = (short)util.Profil;
                    efcUtilisateur.CodeUtilisateur = util.CodeUtilisateur;
                    efcUtilisateur.DateNaissance = util.DateNaissance;
                    efcUtilisateur.Email = util.Email;
                    efcUtilisateur.Nif = util.Nif;
                    efcUtilisateur.Nom = util.Nom;
                    efcUtilisateur.Prenom = util.Prenom;
                    efcUtilisateur.Sexe = util.Sexe;

                    efcUtilisateur.Password = util.MotDePasse;
                    efcUtilisateur.DateModif = DateTime.Now;
                    efcUtilisateur.ModifBy = user;

                    result = db.SaveChanges();
                }

                return result;
            }
        }
    }
    }

