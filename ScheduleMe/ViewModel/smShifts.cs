using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    public class smShifts : ObservableObject
    {
        private int _smShift_id;
        private DateTime _shiftBegin;
        private DateTime _shiftEnd;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

        public int SMShift_id
        {
            get
            {
                return _smShift_id;
            }
            set
            {
                if (value != _smShift_id)
                {
                    _smShift_id = value;
                    OnPropertyChanged("smShift_id");
                }
            }
        }

        public DateTime ShiftBegin
        {
            get
            {
                return _shiftBegin;
            }
            set
            {
                if (value != _shiftBegin)
                {
                    _shiftBegin = value;
                    OnPropertyChanged("shiftBegin");
                }
            }
        }

        public DateTime ShiftEnd
        {
            get
            {
                return _shiftEnd;
            }
            set
            {
                if (value != _shiftEnd)
                {
                    _shiftEnd = value;
                    OnPropertyChanged("shiftBegin");
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
