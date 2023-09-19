using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class TopicComments
    {
        public Int32 InsertTopicComment(tblTopicComment TopicCommentData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new Topic Comment in the database

                tblTopicComment _topiccomment = new tblTopicComment
                {
                    CreateedOn = TopicCommentData.CreateedOn,
                    TopicComment = TopicCommentData.TopicComment,
                    TopicId = TopicCommentData.TopicId,
                    UserId = TopicCommentData.UserId
                };

                db.tblTopicComments.InsertOnSubmit(_topiccomment);
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

        public List<SelectAllTopicCommentResult> SelectAllTopicComment()
        {
            List<SelectAllTopicCommentResult> TopicComment = new List<SelectAllTopicCommentResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all Topic Comment list

                TopicComment = db.SelectAllTopicComment().ToList<SelectAllTopicCommentResult>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return TopicComment;
        }

        public Boolean DeleteTopicComment(Int32 TopicCommentId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single Topic Comment from the database

                var query = (from p in db.tblTopicComments
                             where p.ID == TopicCommentId
                             select p).Single();

                db.tblTopicComments.DeleteOnSubmit(query);
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

        public List<SelectAllTopicCommentByIdResult> SelectTopicCommentById(Int32 TopicCommentId)
        {
            List<SelectAllTopicCommentByIdResult> TopicComment = new List<SelectAllTopicCommentByIdResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database

                TopicComment = db.SelectAllTopicCommentById(TopicCommentId).ToList<SelectAllTopicCommentByIdResult>();
                db.Dispose();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return TopicComment;
        }

        public Boolean UpdateTopicComment(tblTopicComment TopicCommentData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the Topic Comment data according to its id

                tblTopicComment TopicComment = (from p in db.tblTopicComments
                                    where p.ID == TopicCommentData.ID
                                    select p).Single();

                TopicComment.TopicComment = TopicCommentData.TopicComment;
                TopicComment.TopicId = TopicCommentData.TopicId;
                TopicComment.UserId = TopicCommentData.UserId;
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
