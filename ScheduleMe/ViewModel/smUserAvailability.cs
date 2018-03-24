using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smUserAvailability : ObservableObject
    {
        private int _smUser_id;
        private DateTime _beginTime;
        private DateTime _endTime;
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

        public DateTime BeginTime
        {
            get
            {
                return _beginTime;
            }
            set
            {
                if (value != _beginTime)
                {
                    _beginTime = value;
                    OnPropertyChanged("beginTime");
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (value != _endTime)
                {
                    _endTime = value;
                    OnPropertyChanged("endTime");
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
