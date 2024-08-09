using Business.Abstract;
using Core.DataRepositories.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TravelReviewManager(ITravelReviewDal reviewDal) : ITravelReviwService
    {
        private readonly ITravelReviewDal _reviewDal=reviewDal;
       
        public IResult Add(TravelReview review)
        {
            try
            {
                _reviewDal.Add(review);
                return new SuccessResult($"the review added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the review...");
            }
           
        }

        public IResult Delete(TravelReview review)
        {
            try
            {
                //_reviewDal.Delete(review);
                review.IsActive = false;
                _reviewDal.Update(review);
                return new SuccessResult($"the review deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the review...");
            }
           
        }

        public IDataResult<TravelReview> Get(int id)
        {
           var review= _reviewDal.Get(p => p.Id == id && p.IsActive);
            if (review != null)
            {
                return new SuccessDataResult<TravelReview>(review, "Review found successfuly! ");
            }
            return new ErrorDataResult<TravelReview>("Review not found...");
        }

        public IDataResult<List<TravelReview>> GetAll()
        {
        var review= _reviewDal.GetAll(p => p.IsActive);
            if (review.Count > 0)
            {
                return new SuccessDataResult<List<TravelReview>>(review, "Reviews retrieved successfuly! ");
            }
            return new ErrorDataResult<List<TravelReview>>("No Reviews found...");
        }

        public IResult Update(TravelReview review)
        {
            try
            {
                _reviewDal.Update(review);
                return new SuccessResult($"the review updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the review...");
            }
           
        }
    }
}
