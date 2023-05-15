using ProjetFinale.DataAccessLayer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.DataAccessLayer
{
    internal class DAL
    {
        private AbilityFact _abilityFact = null;
        private CharacterFact _characterFact = null;
        private CharacteristicsFact _characteristicsFact = null;
        private ItemFact _itemFact = null;
        private StatisticsFact _statisticsFact = null;

        public AbilityFact? AbilityFact
        {
            get
            {
                if (_abilityFact == null)
                {
                    _abilityFact = new AbilityFact();
                }
                return _abilityFact;
            }
        }

        public CharacterFact? CharacterFact
        {
            get
            {
                if (_characterFact == null)
                {
                    _characterFact = new CharacterFact();
                }
                return _characterFact;
            }
        }

        public CharacteristicsFact? CharacteristicsFact
        {
            get
            {
                if (_characteristicsFact == null)
                {
                    _characteristicsFact = new CharacteristicsFact();
                }
                return _characteristicsFact;
            }
        }

        public ItemFact? ItemFact
        {
            get
            {
                if (_itemFact == null)
                {
                    _itemFact = new ItemFact();
                }
                return _itemFact;
            }
        }

        public StatisticsFact? StatisticsFact
        {
            get
            {
                if (_statisticsFact == null)
                {
                    _statisticsFact = new StatisticsFact();
                }
                return _statisticsFact;
            }
        }
    }
}
