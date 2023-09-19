using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class ContactDetail
    {
        public Int32 InsertContactDetail(tblContactDetail ContactDetailData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new contact details in the database

                tblContactDetail _contactdetail = new tblContactDetail
                {
                    Address = ContactDetailData.Address,
                    City = ContactDetailData.City,
                    Email = ContactDetailData.Email,
                    Mobile = ContactDetailData.Mobile,
                    OfficeLocation = ContactDetailData.OfficeLocation,
                    State = ContactDetailData.State,
                    Telephone = ContactDetailData.Telephone
                };

                db.tblContactDetails.InsertOnSubmit(_contactdetail);
                db.SubmitChanges();
                db.Dispose();
                retval = 1;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = 0;
            }
            return retval;
        }

        public List<tblContactDetail> SelectAllContactDetail()
        {
            List<tblContactDetail> ConatctDetails = new List<tblContactDetail>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all contact details list

                ConatctDetails = (from p in db.tblContactDetails
                                  orderby p.ID ascending
                                  select p).ToList<tblContactDetail>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return ConatctDetails;
        }

        public Boolean DeleteContactDetail(Int32 ContactId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single contact details from the database

                var query = (from p in db.tblContactDetails
                             where p.ID == ContactId
                             select p).Single();

                db.tblContactDetails.DeleteOnSubmit(query);
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

        public tblContactDetail SelectContactDetailById(Int32 ContactId)
        {
            tblContactDetail ContactDetail = new tblContactDetail();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database

                ContactDetail = (from p in db.tblContactDetails
                                 where p.ID == ContactId
                                 select p).Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return ContactDetail;
        }

        public Boolean UpdateContactDetail(tblContactDetail ContactDetailData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the contact details data according to its id

                tblContactDetail ContactDetail = (from p in db.tblContactDetails
                                                  where p.ID == ContactDetailData.ID
                                    select p).Single();

                ContactDetail.Address = ContactDetailData.Address;
                ContactDetail.City = ContactDetailData.City;
                ContactDetail.Email = ContactDetailData.Email;
                ContactDetail.Mobile = ContactDetailData.Mobile;
                ContactDetail.OfficeLocation = ContactDetailData.OfficeLocation;
                ContactDetail.State = ContactDetailData.State;
                ContactDetail.Telephone = ContactDetailData.Telephone;
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
