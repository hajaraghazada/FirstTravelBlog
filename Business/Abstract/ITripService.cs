using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface ITripService
    {
        IResult Add(Trip trip);
        IResult Update(Trip trip);
        IResult Delete(Trip trip);
        IDataResult<Trip> Get(int id);
        IDataResult<List<Trip>> GetAll();
    }
}
