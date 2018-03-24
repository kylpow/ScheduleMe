using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smEstablishmentRoles : ObservableObject
    {
        private int _smEstablishment_id;
        private int _smRoles_id;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

        public int SMEstablishment_id
        {
            get
            {
                return _smEstablishment_id;
            }
            set
            {
                if (value != _smEstablishment_id)
                {
                    _smEstablishment_id = value;
                    OnPropertyChanged("smEstablishment_id");
                }
            }
        }

        public int SMRoles_id
        {
            get
            {
                return _smRoles_id;
            }
            set
            {
                if (value != _smRoles_id)
                {
                    _smRoles_id = value;
                    OnPropertyChanged("smRoles_id");
                }
            }
        }

        public DateTime LastChangedOn
        {
            get
            {
                return _lastChangedOn;
            }
            set
            {
                if (value != _lastChangedOn)
                {
                    _lastChangedOn = value;
                    OnPropertyChanged("lastChangedOn");
                }
            }
        }

        public string LastChangedBy
        {
            get
            {
                return _lastChangedBy;
            }
            set
            {
                if (value != _lastChangedBy)
                {
                    _lastChangedBy = value;
                    OnPropertyChanged("lastChangedBy");
                }
            }
        }
    }
}
