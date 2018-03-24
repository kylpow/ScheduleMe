using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smUserShifts : ObservableObject
    {
        private int _smUser_id;
        private int _shift_id;
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

        public int Shift_id
        {
            get
            {
                return _shift_id;
            }
            set
            {
                if (value != _shift_id)
                {
                    _shift_id = value;
                    OnPropertyChanged("shift_id");
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
