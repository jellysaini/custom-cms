using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Banner
    {
        public Int32 InsertBanner(tblBanner BannerData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new banner in the database

                tblBanner _banner = new tblBanner
                {
                    BannerDescription = BannerData.BannerDescription,
                    BannerImagePath = BannerData.BannerImagePath,
                    BannerName = BannerData.BannerName,
                    BannerOrder = BannerData.BannerOrder,
                    BannerStatus = BannerData.BannerStatus
                };

                db.tblBanners.InsertOnSubmit(_banner);
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

        public List<tblBanner> SelectAllBanner()
        {
            List<tblBanner> Banners = new List<tblBanner>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all banner list

                Banners = (from p in db.tblBanners
                           orderby p.ID descending
                           select p).ToList<tblBanner>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Banners;
        }

        public List<tblBanner> SelectAllBannerByTrueStatus()
        {
            List<tblBanner> Banners = new List<tblBanner>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all banner list

                Banners = (from p in db.tblBanners
                           where p.BannerStatus==true
                           orderby p.ID descending
                           select p).ToList<tblBanner>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Banners;
        }

        public Boolean DeleteBanner(Int32 BannerId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single banner from the database

                var query = (from p in db.tblBanners
                             where p.ID == BannerId
                             select p).Single();

                db.tblBanners.DeleteOnSubmit(query);
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

        public tblBanner SelectBannerById(Int32 BannerId)
        {
            tblBanner Banner = new tblBanner();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                Banner = (from p in db.tblBanners
                          where p.ID == BannerId
                          select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return Banner;
        }

        public Boolean UpdateBanner(tblBanner BannerData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the banner data according to its id

                tblBanner Banner = (from p in db.tblBanners
                                    where p.ID == BannerData.ID
                                    select p).Single();

                Banner.BannerDescription = BannerData.BannerDescription;
                Banner.BannerImagePath = BannerData.BannerImagePath;
                Banner.BannerName = BannerData.BannerName;
                Banner.BannerOrder = BannerData.BannerOrder;
                Banner.BannerStatus = BannerData.BannerStatus;
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
