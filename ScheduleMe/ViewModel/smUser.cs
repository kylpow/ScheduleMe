using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    public class smUser : ObservableObject
    {

       

        private int _smUser_id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _emailAddress;
        private string _phoneNumber;
        private string _phoneNumber2;
        private string _address;
        private bool _deleted; //bool?
        private int _zip;
        private string _roleName;
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

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("firstName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("lastName");
                }
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    OnPropertyChanged("userName");
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("password");
                }
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value != _emailAddress)
                {
                    _emailAddress = value;
                    OnPropertyChanged("emailAddress");
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("phoneNumber");
                }
            }
        }

        public string PhoneNumber2
        {
            get
            {
                return _phoneNumber2;
            }
            set
            {
                if (value != _phoneNumber2)
                {
                    _phoneNumber2 = value;
                    OnPropertyChanged("phoneNumber2");
                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("address");
                }
            }
        }

        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                if (value != _deleted)
                {
                    _deleted = value;
                    OnPropertyChanged("deleted");
                }
            }
        }

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
