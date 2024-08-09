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
    public class DestinationManager(IDestinationDal destinationDal) : IDestinationService
    {
        private readonly IDestinationDal _destinationDal=destinationDal;

        public IResult Add(Destination destination)
        {
            try
            {
                _destinationDal.Add(destination);
                return new SuccessResult($"the destination added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the destination...");
            }
            
        }

        public IResult Delete(Destination destination)
        {
            try
            {
                destination.IsActive = false;
                _destinationDal.Update(destination);
                return new SuccessResult($"the destination deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the destination...");
            }
           
        }

        public IDataResult<Destination> Get(int id)
        {
           var destination= _destinationDal.Get(p => p.Id == id && p.IsActive);
            if (destination != null)
            {
                return new SuccessDataResult<Destination>(destination, "Destination found successfuly! ");
            }
            return new ErrorDataResult<Destination>("Destination not found...");
        }

        public IDataResult<List<Destination>> GetAll()
        {
          var destination=_destinationDal.GetAll(p => p.IsActive);
            if (destination.Count > 0)
            {
                return new SuccessDataResult<List<Destination>>(destination, "Destinations retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Destination>>("No Destinations found...");
        }

       
        public IResult Update(Destination destination)
        {
            try
            {
                _destinationDal.Update(destination);
                return new SuccessResult($"the destination updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the destination...");
            }
            
        }
    }
}
