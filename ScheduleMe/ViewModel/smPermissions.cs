using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class smPermissions : ObservableObject
    {
        private int _smPermissions_id;
        private bool _updatePersonalInfo;
        private bool _updateAvailability;
        private bool _makeRequests;
        private bool _writeNewSchedule;
        private bool _addEmployee;
        private bool _deleteEmployee;
        private bool _addNewShiftType;
        private bool _addShiftToExistingSchedule;
        private bool _deleteShiftFromSchedule;
        private bool _modifyEmployeePermissions;
        private DateTime _lastChangedOn;
        private string _lastChangedBy;

        public int SMPermissions_id
        {
            get
            {
                return _smPermissions_id;
            }
            set
            {
                if (value != _smPermissions_id)
                {
                    _smPermissions_id = value;
                    OnPropertyChanged("smPermissions_id");
                }
            }
        }

        public bool UpdatePersonalInfo
        {
            get
            {
                return _updatePersonalInfo;
            }
            set
            {
                if (value != _updatePersonalInfo)
                {
                    _updatePersonalInfo = value;
                    OnPropertyChanged("updatePersonalInfo");
                }
            }
        }

        public bool UpdateAvailability
        {
            get
            {
                return _updateAvailability;
            }
            set
            {
                if (value != _updateAvailability)
                {
                    _updateAvailability = value;
                    OnPropertyChanged("updateAvailability");
                }
            }
        }

        public bool MakeRequests
        {
            get
            {
                return _makeRequests;
            }
            set
            {
                if (value != _makeRequests)
                {
                    _makeRequests = value;
                    OnPropertyChanged("makeRequests");
                }
            }
        }

        public bool WriteNewSchedule
        {
            get
            {
                return _writeNewSchedule;
            }
            set
            {
                if (value != _writeNewSchedule)
                {
                    _writeNewSchedule = value;
                    OnPropertyChanged("writeNewSchedule");
                }
            }
        }

        public bool AddEmployee
        {
            get
            {
                return _addEmployee;
            }
            set
            {
                if (value != _addEmployee)
                {
                    _addEmployee = value;
                    OnPropertyChanged("addEmployee");
                }
            }
        }

        public bool DeleteEmployee
        {
            get
            {
                return _deleteEmployee;
            }
            set
            {
                if (value != _deleteEmployee)
                {
                    _deleteEmployee = value;
                    OnPropertyChanged("deleteEmployee");
                }
            }
        }

        public bool AddNewShiftType
        {
            get
            {
                return _addNewShiftType;
            }
            set
            {
                if (value != _addNewShiftType)
                {
                    _addNewShiftType = value;
                    OnPropertyChanged("addNewShiftType");
                }
            }
        }

        public bool AddShiftToExistingSchedule
        {
            get
            {
                return _addShiftToExistingSchedule;
            }
            set
            {
                if (value != _addShiftToExistingSchedule)
                {
                    _addShiftToExistingSchedule = value;
                    OnPropertyChanged("addShiftToExistingSchedule");
                }
            }
        }

        public bool DeleteShiftFromSchedule
        {
            get
            {
                return _deleteShiftFromSchedule;
            }
            set
            {
                if (value != _deleteShiftFromSchedule)
                {
                    _deleteShiftFromSchedule = value;
                    OnPropertyChanged("deleteShiftFromSchedule");
                }
            }
        }

        public bool ModifyEmployeePermissions
        {
            get
            {
                return _modifyEmployeePermissions;
            }
            set
            {
                if (value != _modifyEmployeePermissions)
                {
                    _modifyEmployeePermissions = value;
                    OnPropertyChanged("modifyEmployeePermissions");
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
