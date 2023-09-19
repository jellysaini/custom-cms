using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class News
    {
        public Int32 InsertNews(tblNew NewsData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new news in the database

                tblNew _news = new tblNew
                {
                    NewsDescription = NewsData.NewsDescription,
                    NewsImagePath = NewsData.NewsImagePath,
                    NewsName = NewsData.NewsName,
                    NewsOrder = NewsData.NewsOrder,
                    NewsStatus = NewsData.NewsStatus
                };

                db.tblNews.InsertOnSubmit(_news);
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

        public List<tblNew> SelectAllNews()
        {
            List<tblNew> Newses = new List<tblNew>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all news list

                Newses = (from p in db.tblNews
                          orderby p.ID descending
                          select p).ToList<tblNew>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Newses;
        }

        public List<tblNew> SelectNNews(Int32 NoOfRecord)
        {
            List<tblNew> News = new List<tblNew>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all tblNews list

                News = (from p in db.tblNews
                        where p.NewsStatus == true
                        orderby p.ID descending
                        select p).Take(NoOfRecord).ToList<tblNew>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return News;
        }

        public List<tblNew> SelectAllNewsByTrueStatus()
        {
            List<tblNew> Newses = new List<tblNew>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all news list

                Newses = (from p in db.tblNews
                          where p.NewsStatus == true
                          orderby p.ID descending
                          select p).ToList<tblNew>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Newses;
        }

        public Boolean DeleteNews(Int32 NewsId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single news from the database

                var query = (from p in db.tblNews
                             where p.ID == NewsId
                             select p).Single();

                db.tblNews.DeleteOnSubmit(query);
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

        public tblNew SelectNewsById(Int32 NewsId)
        {
            tblNew News = new tblNew();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                News = (from p in db.tblNews
                        where p.ID == NewsId
                        select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return News;
        }

        public Boolean UpdateNews(tblNew NewsData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the news data according to its id

                tblNew News = (from p in db.tblNews
                               where p.ID == NewsData.ID
                               select p).Single();

                News.NewsDescription = NewsData.NewsDescription;
                News.NewsImagePath = NewsData.NewsImagePath;
                News.NewsName = NewsData.NewsName;
                News.NewsOrder = NewsData.NewsOrder;
                News.NewsStatus = NewsData.NewsStatus;
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
