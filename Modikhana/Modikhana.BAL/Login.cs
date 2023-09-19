using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Login
    {
        public object UserLogin(String UserName, String Password)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            var Result = (from p in db.tblUsers
                          where p.LoginName == UserName && p.UserPassword == Password && p.UserStatus == true
                          select p).SingleOrDefault();
            db.Dispose();
            return Result;
        }

        public List<tblUser> UserAuthentication(String UserName, String Password)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            List<tblUser> SelectedUser = new List<tblUser>();
            SelectedUser = (from p in db.tblUsers
                            where p.LoginName == UserName && p.UserPassword == Password && p.UserStatus == true
                            select p).ToList<tblUser>();
            db.Dispose();
            return SelectedUser;
        }

        public Boolean ChangePassword(String LoginName, String OldPassword, String NewPassword)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This method is Change the Current password of  the user.

                tblUser Users = (from p in db.tblUsers
                                 where p.LoginName == LoginName && p.UserPassword == OldPassword
                                 select p).Single();
                Users.UserPassword = NewPassword;
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

        public tblUser GetMailByLoginName(String LoginName)
        {
            tblUser user = new tblUser();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get the Email Address of the user by his LoginName
                user = (from p in db.tblUsers
                        where p.LoginName == LoginName
                        select p).Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return user;
        }

        public int AlreadyExist(String LoginName)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                var Result = (from p in db.tblUsers
                              where p.LoginName == LoginName
                              select p).SingleOrDefault();

                if (Result != null)
                {
                    db.Dispose();
                    return 2;
                }
                else
                {
                    db.Dispose();
                    return 0;
                }


            }
            catch (Exception)
            {
                return 1;
            }

        }
    }
}
