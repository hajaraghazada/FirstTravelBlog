using Business.Abstract;
using Core.DataRepositories.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager(ICommentDal commentDal) : ICommentService
    {
        private readonly ICommentDal _commentDal= commentDal;
       
        public IResult Add(Comment comment)
        {
            try
            {
                _commentDal.Add(comment);
                return new SuccessResult($"the comment added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the comment...");
            }
           
        }

        public IResult Delete(Comment comment)
        {
            try
            {
                comment.IsActive = false;
                _commentDal.Update(comment);
                return new SuccessResult($"the comment deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the comment...");
            }
            
        }

        public IDataResult<Comment> Get(int id)
        {
           var comment= _commentDal.Get(p => p.Id == id && p.IsActive);
            if (comment != null)
            {
                return new SuccessDataResult<Comment>(comment, "Comment found successfuly! ");
            }
            return new ErrorDataResult<Comment>("Comment not found...");
        }

        public IDataResult<List<Comment>> GetAll()
        {
           var comment= _commentDal.GetAll(p => p.IsActive);
            if (comment.Count > 0)
            {
                return new SuccessDataResult<List<Comment>>(comment, "Comments retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Comment>>("No Comments found...");
        }

        public IResult Update(Comment comment)
        {
            try
            {
                _commentDal.Update(comment);
                return new SuccessResult($"the comment updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the comment...");
            }
           
        }
    }
}
