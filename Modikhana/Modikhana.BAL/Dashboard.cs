using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Dashboard
    {
        public DashboardTotalResult SelectDashboardTotal()
        {
            DashboardTotalResult DashboardTotal = new DashboardTotalResult();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will return selected Discussion Topic. used SP

                DashboardTotal = db.DashboardTotal().Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return DashboardTotal;
        }

    }
}
