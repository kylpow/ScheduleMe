using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smRoles : ObservableObject
    {
        private int _smRoles_id;
        private string _establishmentID;
        private string _roleName;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

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

        public string RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                if (value != _roleName)
                {
                    _roleName = value;
                    OnPropertyChanged("roleName");
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
