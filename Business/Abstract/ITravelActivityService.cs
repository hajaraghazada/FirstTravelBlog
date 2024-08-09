using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ITravelActivityService
    {
        IResult Add(TravelActivity activity);
        IResult Update(TravelActivity activity);
        IResult Delete(TravelActivity activity);
        IDataResult<TravelActivity> Get(int id);
        IDataResult<List<TravelActivity>> GetAll();
    }
}
