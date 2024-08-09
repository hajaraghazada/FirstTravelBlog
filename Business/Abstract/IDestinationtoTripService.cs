using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDestinationtoTripService
    {
        IResult Add(DestinationtoTrip destinationtoTrip);
        IResult Update(DestinationtoTrip destinationtoTrip);
        IResult Delete(DestinationtoTrip destinationtoTrip);
        IDataResult<DestinationtoTrip> Get(DestinationtoTrip destinationtoTrip);

        IDataResult<List<DestinationtoTrip>> GetAll();
        IDataResult<List<DestinationtoTrip>> GetForDestination(int destinationId);
        IDataResult<List<DestinationtoTrip>> GetForTrip(int tripId);

    }
}
