using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smEstablishment : ObservableObject
    {
        private int _smEstablishment_id;
        private string _establishmentID;
        private string _establishmentName;
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

        public string EstablishmentID
        {
            get
            {
                return _establishmentID;
            }
            set
            {
                if (value != _establishmentID)
                {
                    _establishmentID = value;
                    OnPropertyChanged("establishmentID");
                }
            }
        }

        public string EstablishmentName
        {
            get
            {
                return _establishmentName;
            }
            set
            {
                if (value != _establishmentName)
                {
                    _establishmentName = value;
                    OnPropertyChanged("establishmentName");
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
