using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class DiscussionTopic
    {
        public Boolean InsertDiscussionTopic(tblDiscussionTopic DiscussionTopicData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will save new Discussion Topic

                tblDiscussionTopic _discussionTopic = new tblDiscussionTopic
                {
                    CreatedBy = DiscussionTopicData.CreatedBy,
                    CreateedOn = DiscussionTopicData.CreateedOn,
                    TopicDescription = DiscussionTopicData.TopicDescription,
                    TopicName = DiscussionTopicData.TopicName,
                    TopicStatus = DiscussionTopicData.TopicStatus
                };

                db.tblDiscussionTopics.InsertOnSubmit(_discussionTopic);
                db.SubmitChanges();
                db.Dispose();
                retval=true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval=false;
            }
            return retval;
        }

        public List<SelectAllDiscussionTopicResult> SelectAllDiscussionTopic()
        {
            List<SelectAllDiscussionTopicResult> DiscussionTopis = new List<SelectAllDiscussionTopicResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get all the Discussion Topic from the database. Use SP

                DiscussionTopis = db.SelectAllDiscussionTopic().ToList<SelectAllDiscussionTopicResult>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return DiscussionTopis;
        }

        public List<SelectAllDiscussionTopicResult> SelectNDiscussionTopic(Int32 NoOfRecord)
        {
            List<SelectAllDiscussionTopicResult> DiscussionTopis = new List<SelectAllDiscussionTopicResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get all the Discussion Topic from the database. Use SP

                DiscussionTopis = db.SelectAllDiscussionTopic().Take(NoOfRecord).ToList<SelectAllDiscussionTopicResult>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return DiscussionTopis;
        }

        public List<SelectAllDiscussionTopicByCreatedByResult> SelectAllDiscussionTopicByCreatedId(Int32 CreatedId)
        {
            List<SelectAllDiscussionTopicByCreatedByResult> DiscussionTopis = new List<SelectAllDiscussionTopicByCreatedByResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get all the Discussion Topic from the database by the created id. Use SP

                DiscussionTopis = db.SelectAllDiscussionTopicByCreatedBy(CreatedId).ToList<SelectAllDiscussionTopicByCreatedByResult>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return DiscussionTopis;
        }

        public Boolean DeleteDiscussionTopic(Int32 DiscussionTopicId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the discussion topic from database

                var query = (from p in db.tblDiscussionTopics
                             where p.ID == DiscussionTopicId
                             select p).Single();
                db.tblDiscussionTopics.DeleteOnSubmit(query);
                db.SubmitChanges();

                //This is used becase delete all the comment on this post.
                var deleteComment = (from p in db.tblTopicComments
                                     where p.TopicId == DiscussionTopicId
                                     select p);
                db.tblTopicComments.DeleteAllOnSubmit(deleteComment);
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

        public SelectDiscusstionTopicByIdResult SelectDiscussionTopicById(Int32 DiscussionTopicId)
        {
            SelectDiscusstionTopicByIdResult DiscussionTopic = new SelectDiscusstionTopicByIdResult();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will return selected Discussion Topic. used SP

                DiscussionTopic =db.SelectDiscusstionTopicById(DiscussionTopicId).Single();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();   
            }
            return DiscussionTopic;
        }

        public Boolean UpdateDiscussionTopic(tblDiscussionTopic DiscussionTopicData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will update the Discussion Topic

                tblDiscussionTopic DiscussionTopic = (from p in db.tblDiscussionTopics
                                                      where p.ID == DiscussionTopicData.ID
                                                      select p).Single();

                DiscussionTopic.TopicDescription = DiscussionTopicData.TopicDescription;
                DiscussionTopic.TopicName = DiscussionTopicData.TopicName;
                DiscussionTopic.TopicStatus = DiscussionTopicData.TopicStatus;

                db.SubmitChanges();
                db.Dispose();
                retval = true;

                #endregion
            }
            catch (Exception)
            {
                retval = false;
            }
            return retval;
        }
    }
}
