using BorletteDTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BorletteDTO
{
    public class Tirage
    {

        #region Attribut
        private long _id;

        private Enums.StatutTirage _Id_Statut;

        private short _CoefficientPremierNumero;
        private int _PremierNumero;

        private short _CoefficientDeuxiemeNumero;
        private int _DeuxiemeNumero;

        private short _CoefficientTroisiemeNumero;
        private int _TroisiemeNumero;

        private DateTime _CreeLe;



        #endregion

        #region Proprietes
            public long Id { get => _id; set => _id = value; }
            public StatutTirage Id_Statut { get => _Id_Statut; set => _Id_Statut = value; }
            public String LibelleStatut {
                get {
                    if (_Id_Statut == StatutTirage.Ouvert) { return "Ouvert"; }
                    if (_Id_Statut == StatutTirage.Ferme) { return "Ferme"; }
                    else return "N/A";
                } 
            }
             
            public short CoefficientPremierNumero { get => _CoefficientPremierNumero; set => _CoefficientPremierNumero = value; }
            public int PremierNumero { get => _PremierNumero; set => _PremierNumero = value; }
            public short CoefficientDeuxiemeNumero { get => _CoefficientDeuxiemeNumero; set => _CoefficientDeuxiemeNumero = value; }
            public int DeuxiemeNumero { get => _DeuxiemeNumero; set => _DeuxiemeNumero = value; }
            public short CoefficientTroisiemeNumero { get => _CoefficientTroisiemeNumero; set => _CoefficientTroisiemeNumero = value; }
            public int TroisiemeNumero { get => _TroisiemeNumero; set => _TroisiemeNumero = value; }
            public DateTime CreeLe { get => _CreeLe; set => _CreeLe = value; }

            public List<MiseJoueur> Mises
            {
                get => default;
                set
                {
                }
            }
        #endregion

        #region Constructeur
        public Tirage(long id, Enums.StatutTirage statut, short coefficientPremierNumero, int premierNumero, short coefficientDeuxiemeNumero, int deuxiemeNumero, short coefficientTroisiemeNumero, int troisiemeNumero, DateTime creeLe)
            {
                _id = id;
                _Id_Statut = statut; 
                _CoefficientPremierNumero = coefficientPremierNumero;
                _PremierNumero = premierNumero;
                _CoefficientDeuxiemeNumero = coefficientDeuxiemeNumero;
                _DeuxiemeNumero = deuxiemeNumero;
                _CoefficientTroisiemeNumero = coefficientTroisiemeNumero;
                _TroisiemeNumero = troisiemeNumero;
                _CreeLe = creeLe;
            }
        #endregion

        #region Validation
        //Add exception for saving
        public void Validate()
        {
            if (_Id_Statut == 0)
            {
                throw new Exception( "Statut est obligatoire");
            } 
            if ((_CoefficientPremierNumero == 0) || (_CoefficientDeuxiemeNumero == 0) || (_CoefficientTroisiemeNumero == 0))
            {
                throw new Exception( "Les coéfficients doivent être superieurs à zero ");
            }
            if ((_PremierNumero == 0) || (_DeuxiemeNumero == 0) || (_TroisiemeNumero == 0))
            {
                throw new Exception("Tous les trois Numéro gagants doivent être supérieurs à zéro ");
            }
        }
        /*
         Permet de générer les nombres al130atoire pour le tirage : premier, deuxieme, troisieme Numero
         */
        private void InitialiserTirageNumber()
        {
            var valueRandom = new Random();
            _PremierNumero = valueRandom.Next(0, 100);
            _CoefficientPremierNumero = 10;

            _DeuxiemeNumero = valueRandom.Next(0, 100);
            _CoefficientDeuxiemeNumero = 6;

            _TroisiemeNumero = valueRandom.Next(0, 100);
            _CoefficientTroisiemeNumero = 3;

            _Id_Statut = Enums.StatutTirage.Ouvert;

            _CreeLe = DateTime.Now;
        }

        #endregion

        #region Autre Methode
            public Boolean Annuler(string user)
            {
                bool result = false;

                //Implementation
                return result;
            }
            public Boolean Lancer(  string user)
            {

                bool result = true;
                InitialiserTirageNumber();

                //Implementation
                return result;
            }
            public Boolean Cloture(string user)
            {
                bool result = false;

                //Implementation
                return result;
            }
        #endregion

    }
}
