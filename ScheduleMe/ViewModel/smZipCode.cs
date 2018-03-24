using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smZipCode : ObservableObject
    {
        private int _zip;
        private string _city;
        private string _state;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

        public int Zip
        {
            get
            {
                return _zip;
            }
            set
            {
                if (value != _zip)
                {
                    _zip = value;
                    OnPropertyChanged("zip");
                }
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("city");
                }
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    OnPropertyChanged("state");
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
