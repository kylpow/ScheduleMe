using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMe.Model
{
    class ScheduleMeAccess
    {
        private DataAccess db;

        public ScheduleMeAccess()
        {
            db = new DataAccess();
        }

        ////C.R.U.D METHODS

        #region Select Statements

        public int ValidateUserNamePassword(string userName, string password)
        {
           
            ObservableCollection<smUser> col_Items;
            string sSQL;    //Holds an SQL statement
            int iRet = 0;   //Number of return values
            DataSet ds = new DataSet(); //Holds the return values
            sSQL = "Select * from smUser where username = '" + userName + "' and password = '" + password + "'";
            col_Items = new ObservableCollection<smUser>();
            try
            {
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                return iRet;
                //Creates User object based on the data pulled from the query
                //smUser user = new smUser();

                //user.UserName = ds.Tables[0].Rows[0]["userName"].ToString();
                //user.Password = ds.Tables[0].Rows[0]["password"].ToString();

                //col_Items.Add(user);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return 0;
            //return col_Items;
        }

        public ObservableCollection<smUser> GetUser(string userName)
        {

            ObservableCollection<smUser> col_Items;
            string sSQL;    //Holds an SQL statement
            int iRet = 0;   //Number of return values
            DataSet ds = new DataSet(); //Holds the return values
            sSQL = "Select * from smUser where username = '" + userName + "'";
            col_Items = new ObservableCollection<smUser>();
            try
            {
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //Creates User object based on the data pulled from the query
                smUser user = new smUser();

                user.UserName = ds.Tables[0].Rows[0]["userName"].ToString();
                user.FirstName = ds.Tables[0].Rows[0]["firstName"].ToString();
                user.LastName = ds.Tables[0].Rows[0]["lastName"].ToString();
                user.EmailAddress = ds.Tables[0].Rows[0]["emailAddress"].ToString();
                user.PhoneNumber = ds.Tables[0].Rows[0]["phoneNumber"].ToString();
                user.PhoneNumber2 = ds.Tables[0].Rows[0]["phoneNumber2"].ToString();
                user.Address = ds.Tables[0].Rows[0]["address"].ToString();
                user.Zip = (int)ds.Tables[0].Rows[0]["zip"];
                user.RoleName = ds.Tables[0].Rows[0]["roleName"].ToString();

                col_Items.Add(user);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return col_Items;

        }

        #endregion

        #region Insert Statements

        #endregion

        #region Update Statements

        #endregion

        #region Delete Statements

        #endregion

    }
}
