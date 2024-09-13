using BorletteDTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteDTO
{
    public class Utilisateur
    {
        #region Field
            private string _CodeUtilisateur;
            private DateOnly _DateNaissance;
            private string _Email;
            private long _Id;
            private string _MotDePasse;
            private string _Nif;
            private string _Nom;
            private string _Prenom;
            private string _sexe;

            private StatutUtilisateur _Statut;
            private ProfilUtilisateur _Profil;

            private long _IDProfession;
            private ParametreReference _Profession;
        #endregion
        
        #region Constructeur
         public Utilisateur(string codeUtilisateur, DateOnly dateNaissance, string email, long id, string motDePasse, string nif,
                                string nom, string prenom, string sexe, StatutUtilisateur statut, ProfilUtilisateur profil,  ParametreReference profession)
        {
            _CodeUtilisateur = codeUtilisateur;
            _DateNaissance = dateNaissance;
            _Email = email;
            _Id = id;
            _MotDePasse = motDePasse;
            _Nif = nif;
            _Nom = nom;
            _Prenom = prenom;
            _sexe = sexe;
            _Statut = statut;
            _Profil = profil;
            _IDProfession = (profession == null)? 0: profession.Id;
            _Profession = profession;
        }
        #endregion

        #region Propriete
        public string CodeUtilisateur { get => _CodeUtilisateur; set => _CodeUtilisateur = value; }
            public DateOnly DateNaissance { get => _DateNaissance; set => _DateNaissance = value; }
            public string Email { get => _Email; set => _Email = value; }
            public long Id { get => _Id; set => _Id = value; }
            public string MotDePasse { get => _MotDePasse; set => _MotDePasse = value; }
            public string Nif { get => _Nif; set => _Nif = value; }
            public string Nom { get => _Nom; set => _Nom = value; }
            public string Prenom { get => _Prenom; set => _Prenom = value; }
            public string Sexe { get => _sexe; set => _sexe = value; }
            public StatutUtilisateur IdStatut { get => _Statut; set => _Statut = value; }
            public ProfilUtilisateur Profil { get => _Profil; set => _Profil = value; }
            public long IDProfession { get => _IDProfession; set => _IDProfession = value; }
            public ParametreReference Profession { get => _Profession; set => _Profession = value; }
        #endregion
    }
}
