using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Event
    {
        public Boolean InsertEvent(tblEvent EventData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will save new event in the database

                tblEvent _event = new tblEvent
                {
                    EventDescription = EventData.EventDescription,
                    EventEndDate = EventData.EventEndDate,
                    EventName = EventData.EventName,
                    EventStartDate = EventData.EventStartDate,
                    EventStatus = EventData.EventStatus
                };
                db.tblEvents.InsertOnSubmit(_event);
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

        public List<tblEvent> SelectAllEvent()
        {
            List<tblEvent> EventData = new List<tblEvent>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select all the 

                EventData = (from p in db.tblEvents
                             orderby p.ID descending
                             select p).ToList<tblEvent>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return EventData;
        }

        public List<tblEvent> SelectNEvent(Int32 NoOfRecord)
        {
            List<tblEvent> EventData = new List<tblEvent>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select all the

                EventData = (from p in db.tblEvents
                             orderby p.ID descending
                             select p).Take(NoOfRecord).ToList<tblEvent>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return EventData;
        }

        public List<tblEvent> SelectAllEventByTrueStatus()
        {
            List<tblEvent> EventData = new List<tblEvent>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select all the

                EventData = (from p in db.tblEvents
                             where p.EventStatus==true
                             orderby p.ID descending
                             select p).ToList<tblEvent>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return EventData;
        }

        public Boolean DeleteEvent(Int32 EventId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete event.

                var query = (from p in db.tblEvents
                             where p.ID == EventId
                             select p).Single();
                db.tblEvents.DeleteOnSubmit(query);
                db.SubmitChanges();
                db.Dispose();
                return true;

                #endregion
            }
            catch (Exception)
            {
                return false;
            }
        }

        public tblEvent SelectEventById(Int32 EventId)
        {
            tblEvent Event = new tblEvent();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext(); 
            try
            {
                #region This code will select only single record from the database

                Event = (from p in db.tblEvents
                         where p.ID == EventId
                         select p).Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return Event;
        }

        public Boolean UpdateEvent(tblEvent EventData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to update the event data in database.

                tblEvent Event = (from p in db.tblEvents
                                  where p.ID == EventData.ID
                                  select p).Single();

                Event.EventDescription = EventData.EventDescription;
                Event.EventEndDate = EventData.EventEndDate;
                Event.EventName = EventData.EventName;
                Event.EventStartDate = EventData.EventStartDate;
                Event.EventStatus = EventData.EventStatus;

                db.SubmitChanges();
                db.Dispose();
                retval = true;

                #endregion
            }
            catch (Exception)
            {
                retval = false;
                db.Dispose();
            }
            return retval;
        }
    }
}
