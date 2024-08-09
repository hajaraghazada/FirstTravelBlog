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
    public class TravelActivityManager(ITravelActivityDal activityDal) : ITravelActivityService
    {
        private readonly ITravelActivityDal _activityDal=activityDal;
        
        public IResult Add(TravelActivity activity)
        {
            try
            {
                _activityDal.Add(activity);
                return new SuccessResult($"the activity added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the activity...");
            }

           
        }

        public IResult Delete(TravelActivity activity)
        {
            try
            {
                activity.IsActive = false;
                _activityDal.Update(activity);
                return new SuccessResult($"the activity deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the activity...");
            }

            
        }

        public IDataResult<TravelActivity> Get(int id)
        {
           var activity=_activityDal.Get(p => p.Id == id && p.IsActive);
            if (activity != null)
            {
                return new SuccessDataResult<TravelActivity>(activity, "Activity found successfuly! ");
            }
            return new ErrorDataResult<TravelActivity>("Activity not found...");
        }

        public IDataResult<List<TravelActivity>> GetAll()
        {
           var activity= _activityDal.GetAll(p => p.IsActive);
            if (activity.Count > 0)
            {
                return new SuccessDataResult<List<TravelActivity>>(activity, "Activities retrieved successfuly! ");
            }
            return new ErrorDataResult<List<TravelActivity>>("No Activities found...");
        }

        public IResult Update(TravelActivity activity)
        {
            try
            {
                _activityDal.Update(activity);
                return new SuccessResult($"the activity updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the activity...");
            }
            
        }
    }
}
