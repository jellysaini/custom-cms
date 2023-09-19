using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Users
    {
        public int InsertUser(tblUser userData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to check Is User Login Name allready exist.if user allready exist then it retrun 2.

                var Result = (from p in db.tblUsers
                              where p.LoginName == userData.LoginName
                              select p).SingleOrDefault();

                if (Result != null)
                {
                    db.Dispose();
                    retval = 2;
                }

                #endregion
                #region Save user data.It return 1 if user data save successfully.

                else
                {

                    tblUser _user = new tblUser
                    {
                        CityName = userData.CityName,
                        CountryName = userData.CountryName,
                        EmailAddress = userData.EmailAddress,
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        LoginName = userData.LoginName,
                        Mobile = userData.Mobile,
                        Phone = userData.Phone,
                        StateName = userData.StateName,
                        UserAddress = userData.UserAddress,
                        UserPassword = userData.UserPassword,
                        UserRole = userData.UserRole,
                        UserStatus = userData.UserStatus
                    };
                    db.tblUsers.InsertOnSubmit(_user);
                    db.SubmitChanges();

                    db.Dispose();
                    retval = 1;
                }

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = 0;
            }
            return retval;

        }

        public List<tblUser> SelectAllUser()
        {
            List<tblUser> Users = new List<tblUser>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all user data. It return the list of all user

                Users = (from p in db.tblUsers
                         orderby p.ID descending
                         select p).ToList<tblUser>();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return Users;
        }

        public Boolean DeleteUser(Int32 Userid)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete a single user. It return true if user deleted successfully and return false if user is not deleted successfully.

                var query = (from p in db.tblUsers
                             where p.ID == Userid
                             select p).Single();
                db.tblUsers.DeleteOnSubmit(query);
                db.SubmitChanges();
                db.Dispose();
                return true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                return false;
            }
        }

        public tblUser SelectUserById(Int32 UserId)
        {
            tblUser Users = new tblUser();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {

                #region This is code is used to select the data of a single user. It return the object of the tblUser which hold the all information of the user

                Users = (from p in db.tblUsers
                         where p.ID == UserId
                         select p).Single();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return Users;
        }

        public Boolean UpdateUser(tblUser userData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This method is Update the user information of the user according to user id

                tblUser Users = (from p in db.tblUsers
                                 where p.ID == userData.ID
                                 select p).Single();

                Users.CityName = userData.CityName;
                Users.CountryName = userData.CountryName;
                Users.EmailAddress = userData.EmailAddress;
                Users.FirstName = userData.FirstName;
                Users.LastName = userData.LastName;
                Users.LoginName = userData.LoginName;
                Users.Mobile = userData.Mobile;
                Users.Phone = userData.Phone;
                Users.StateName = userData.StateName;
                Users.UserAddress = userData.UserAddress;
                Users.UserPassword = userData.UserPassword;
                Users.UserStatus = userData.UserStatus;

                db.SubmitChanges();
                db.Dispose();
                retval = true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = false;
            }
            return retval;
        }

        public Boolean UpdateMemberUser(tblUser userData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This method is Update the user information of the user according to user id

                tblUser Users = (from p in db.tblUsers
                                 where p.ID == userData.ID
                                 select p).Single();
                Users.CityName = userData.CityName;
                Users.CountryName = userData.CountryName;
                Users.EmailAddress = userData.EmailAddress;
                Users.FirstName = userData.FirstName;
                Users.LastName = userData.LastName;
                Users.Mobile = userData.Mobile;
                Users.Phone = userData.Phone;
                Users.StateName = userData.StateName;
                Users.UserAddress = userData.UserAddress;

                db.SubmitChanges();
                db.Dispose();
                retval = true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = false;
            }
            return retval;
        }

    }
}
