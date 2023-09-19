using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class ContentManagement
    {
        public int InsertContentPage(tblContentManagement contentManagementData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Check that Is page name which is entered by admin is allready exsit or not

                var Result = (from p in db.tblContentManagements
                              where p.LinkName == contentManagementData.LinkName
                              select p).SingleOrDefault();
                if (Result != null)
                {
                    db.Dispose();
                    retval = 2;
                }

                #endregion
                #region Save new content management Data

                else
                {
                    tblContentManagement _contentManagement = new tblContentManagement
                    {
                        LinkName = contentManagementData.LinkName,
                        LinkOrder = contentManagementData.LinkOrder,
                        LinkStatus = contentManagementData.LinkStatus,
                        LinkContent = contentManagementData.LinkContent
                    };

                    db.tblContentManagements.InsertOnSubmit(_contentManagement);
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

        public List<tblContentManagement> SelectAllPages()
        {
            List<tblContentManagement> ContentPages = new List<tblContentManagement>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This method is used to get all the content pages which is stored in the database

                ContentPages = (from p in db.tblContentManagements
                                orderby p.ID descending
                                select p).ToList<tblContentManagement>();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return ContentPages;
        }

        public Boolean DeleteContentPage(Int32 ContentPageId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete a single page from the data base.

                var query = (from p in db.tblContentManagements
                             where p.ID == ContentPageId
                             select p).Single();
                db.tblContentManagements.DeleteOnSubmit(query);
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

        public tblContentManagement SelectByPageId(Int32 ContentPageId)
        {
            tblContentManagement ContentPage = new tblContentManagement();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used the get a single page data using pageid.

                ContentPage = (from p in db.tblContentManagements
                               where p.ID == ContentPageId
                               select p).Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return ContentPage;
        }

        public Boolean UpdateContentPage(tblContentManagement contentManagementPage)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to update the content page data according to the page id

                tblContentManagement ContentPage = (from p in db.tblContentManagements
                                                    where p.ID == contentManagementPage.ID
                                                    select p).Single();

                ContentPage.LinkContent=contentManagementPage.LinkContent;
                ContentPage.LinkName = ContentPage.LinkName;
                ContentPage.LinkOrder = contentManagementPage.LinkOrder;
                ContentPage.LinkStatus = contentManagementPage.LinkStatus;

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
