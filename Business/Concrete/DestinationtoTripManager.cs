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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DestinationtoTripManager (IDestinationtoTripDal dtDal) : IDestinationtoTripService
    {
        private readonly IDestinationtoTripDal _dtDal=dtDal;

        public IResult Add(DestinationtoTrip destinationtoTrip)
        {
            try
            {
                _dtDal.Add(destinationtoTrip);
                return new SuccessResult($"the category added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the category...");
            }
            
        }

        public IResult Delete(DestinationtoTrip destinationtoTrip)
        {

            try
            {
                destinationtoTrip.IsActive = false;
                _dtDal.Update(destinationtoTrip);
                return new SuccessResult($"the category deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the category...");
            }
           
        }

        public IDataResult<DestinationtoTrip> Get(DestinationtoTrip destinationtoTrip)
        {
            try
            {
                var results = _dtDal.Get(dt => dt.DestinationId == destinationtoTrip.DestinationId && dt.TripId == destinationtoTrip.TripId && dt.IsActive);
                if (results != null)
                {
                    return new SuccessDataResult<DestinationtoTrip>(results, "Category retrieved successfully");
                }
                return new ErrorDataResult<DestinationtoTrip>("Category not found.");
            }
            catch
            {
                return new ErrorDataResult<DestinationtoTrip>("An error occurred while retrieving the category...");
            }
        }
           

        public  IDataResult<List<DestinationtoTrip>> GetAll()
        {
            try
            {
                var result = _dtDal.GetAll(dt => dt.IsActive);
                if (result.Count> 0)
                {
                    return new SuccessDataResult<List<DestinationtoTrip>>(result,"Categories retrieved successfully.");
                }
                return new ErrorDataResult<List<DestinationtoTrip>>("No Categories found.");
            }
            catch
            {
                return new ErrorDataResult<List<DestinationtoTrip>>("An error occurred while retrieving categories");
            }
           
        }

        public IDataResult<List<DestinationtoTrip>> GetForDestination(int destinationId)
        {
            try
            {
               var results= _dtDal.GetAll(dt => dt.DestinationId == destinationId && dt.IsActive);
                if (results.Count > 0)
                {
                    return new SuccessDataResult<List<DestinationtoTrip>>(results, "Categories retrieved successfully.");
                }
                return new ErrorDataResult<List<DestinationtoTrip>>("No Categories found.");

            }
            catch
            {
                return new ErrorDataResult<List<DestinationtoTrip>>("An error occurred while retrieving categories");
            }
            
        }

        public IDataResult<List<DestinationtoTrip>> GetForTrip(int tripId)
        {
            try
            {
                var results = _dtDal.GetAll(dt => dt.TripId == tripId && dt.IsActive);
                if (results.Count > 0)
                {
                    return new SuccessDataResult<List<DestinationtoTrip>>(results, "Categories retrieved successfully.");
                }
                return new ErrorDataResult<List<DestinationtoTrip>>("No Categories found.");
            }
            catch
            {
                return new ErrorDataResult<List<DestinationtoTrip>>("An error occurred while retrieving categories");
            }
            
        }

        public IResult Update(DestinationtoTrip destinationtoTrip)
        {
            try
            {
                _dtDal.Update(destinationtoTrip);
                return new SuccessResult($"the category update successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the category...");
            }
           
        }
    }
}
