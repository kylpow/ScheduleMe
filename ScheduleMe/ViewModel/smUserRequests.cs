using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smUserRequests : ObservableObject
    {
        private int _smUser_id;
        private DateTime _requestDate;
        private string _requestReason;
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

        public DateTime RequestsDate
        {
            get
            {
                return _requestDate;
            }
            set
            {
                if (value != _requestDate)
                {
                    _requestDate = value;
                    OnPropertyChanged("requestDate");
                }
            }
        }

        public string RequestReason
        {
            get
            {
                return _requestReason;
            }
            set
            {
                if (value != _requestReason)
                {
                    _requestReason = value;
                    OnPropertyChanged("requestReason");
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
