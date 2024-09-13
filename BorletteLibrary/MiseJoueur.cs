using BorletteDTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteDTO
{
    public class MiseJoueur
    {
        private long _Id;
        private StatutMise _Statut;

        private Tirage _Tirage;
        private long _IdTirage;

        private long _IdUtilissateur;
        private Utilisateur? _Utilisateur;

        private int _MisePremierNumero; //Montant parié en HTG
        private int _MiseDeuxiemeNumero;//Montant parié en HTG
        private int _MiseTroisiemeNumero;//Montant parié en HTG

        private int _PremierNumero;
        private int _DeuxiemeNumero;
        private int _TroisiemeNumero;

        private decimal _MontantGagne;
       


        #region Constructeur

        public MiseJoueur(long id, 
            StatutMise statut,
            Tirage tirage,
            Utilisateur? user, 
            int misePremierNumero, 
            int miseDeuxiemeNumero, 
            int miseTroisiemeNumero,
            int premierNumero, 
            int deuxiemeNumero, 
            int troisiemeNumero )
        {
            _Id = id;
            _IdUtilissateur = (user == null) ? 0 : user.Id;
            _Utilisateur = user;

            _IdTirage = (tirage == null) ? 0 : tirage.Id;
            _Tirage = tirage;
            _Statut = statut;
            
            _MisePremierNumero = misePremierNumero;
            _MiseDeuxiemeNumero = miseDeuxiemeNumero;
            _MiseTroisiemeNumero = miseTroisiemeNumero;
            _PremierNumero = premierNumero;
            _DeuxiemeNumero = deuxiemeNumero;
            _TroisiemeNumero = troisiemeNumero;
            //_MontantGagne = montantGagne;
        }
        //public MiseJoueur(long id, StatutMise statut, Tirage tirage, Utilisateur user, int misePremierNumero, int miseDeuxiemeNumero, int miseTroisiemeNumero, int premierNumero, int deuxiemeNumero, int troisiemeNumero, decimal montantGagne) : base(id, statut, tirage, user, misePremierNumero, miseDeuxiemeNumero, miseTroisiemeNumero, premierNumero, deuxiemeNumero, troisiemeNumero)
        //{
        //    _MontantGagne = montantGagne;
        //}
        #endregion

        #region Propriete
        public long Id { get => _Id; set => _Id = value; }
            public int MisePremierNumero { get => _MisePremierNumero; set => _MisePremierNumero = value; }
            public int MiseDeuxiemeNumero { get => _MiseDeuxiemeNumero; set => _MiseDeuxiemeNumero = value; }
            public int MiseTroisiemeNumero { get => _MiseTroisiemeNumero; set => _MiseTroisiemeNumero = value; }
            public int PremierNumero { get => _PremierNumero; set => _PremierNumero = value; }
            public int DeuxiemeNumero { get => _DeuxiemeNumero; set => _DeuxiemeNumero = value; }
            public int TroisiemeNumero { get => _TroisiemeNumero; set => _TroisiemeNumero = value; }
            public decimal MontantGagne { get => _MontantGagne; set => _MontantGagne = value; }
            public StatutMise Statut { get => _Statut; set => _Statut = value; }
            public String LibelleStatut
            {
                get
                {
                    if (_Statut == StatutMise.EnCours) { return "En cours"; }
                    if (_Statut == StatutMise.Annuler) { return "Annulé"; }
                    if (_Statut == StatutMise.Valider) { return "Validé"; }
                    else return "N/A";
                }
            }
            public Tirage Tirage { get => _Tirage; set => _Tirage = value; }
            public long IdTirage { get => _IdTirage; set => _IdTirage = value; }
            public Utilisateur? Utilisateur { get => _Utilisateur; set => _Utilisateur = value; }
            public long IdUtilissateur { get => _IdUtilissateur; set => _IdUtilissateur = value; }
        #endregion


    }
}
