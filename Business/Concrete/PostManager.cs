using Business.Abstract;
using Core.DataRepositories.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager(IPostDal postDal) : IPostService
    {
        private readonly IPostDal _postDal=postDal;
     
        public IResult Add(Post post)
        {
            try
            {
                _postDal.Add(post);
                return new SuccessResult($"the post added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the post...");
            }
           
        }

        public IResult Delete(Post post)
        {
            try
            {
                post.IsActive = false;
                _postDal.Update(post);
                return new SuccessResult($"the post deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the post...");
            }
            
        }

        public IDataResult<Post> Get(int id)
        {
           var post= _postDal.Get(p => p.Id == id && p.IsActive);
            if (post != null)
            {
                return new SuccessDataResult<Post>(post, "Post found successfuly! ");
            }
            return new ErrorDataResult<Post>("Post not found...");
        }

        public IDataResult<List<Post>> GetAll()
        {
           var post= _postDal.GetAll(p => p.IsActive);
            if (post.Count > 0)
            {
                return new SuccessDataResult<List<Post>>(post, "Posts retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Post>>("No Posts found...");
        }

       

        public IResult Update(Post post)
        {
            try
            {
                _postDal.Update(post);
                return new SuccessResult($"the post updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the post...");
            }
           
        }
    }
}
