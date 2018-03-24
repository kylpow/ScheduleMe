using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smUserEstablishment : ObservableObject
    {
        private int _smUser_id;
        private int _establishment_id;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

        public int SMUser_id
        {
            get
            {
                return _smUser_id;
            }
            set
            {
                if (value != _smUser_id)
                {
                    _smUser_id = value;
                    OnPropertyChanged("smUser_id");
                }
            }
        }

        public int Establishment_id
        {
            get
            {
                return _establishment_id;
            }
            set
            {
                if (value != _establishment_id)
                {
                    _establishment_id = value;
                    OnPropertyChanged("establishment_id");
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
