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
    public class TripManager(ITripDal tripDal) : ITripService
    {
        private readonly ITripDal _tripDal=tripDal;
        
        public IResult Add(Trip trip)
        {
            try
            {
                _tripDal.Add(trip);
                return new SuccessResult($"the trip added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the trip...");
            }

        
        }

        public IResult Delete(Trip trip)
        {
            try
            {
                trip.IsActive = false;
                _tripDal.Update(trip);
                return new SuccessResult($"the trip deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the trip...");
            }
           
        }

        public IDataResult<Trip> Get(int id)
        {
            var trip= _tripDal.Get(p => p.Id == id && p.IsActive);
            if (trip != null)
            {
                return new SuccessDataResult<Trip>(trip, "Trip found successfuly! ");
            }
            return new ErrorDataResult<Trip>("Trip not found...");
        }

        public IDataResult<List<Trip>> GetAll()
        {
         var trip= _tripDal.GetAll(p => p.IsActive);
            if (trip.Count > 0)
            {
                return new SuccessDataResult<List<Trip>>(trip, "Trips retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Trip>>("No Trips found...");
        }

        public IResult Update(Trip trip)
        {
            try
            {
                _tripDal.Update(trip);
                return new SuccessResult($"the trip updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the trip...");
            }
           
        }
    }
}
