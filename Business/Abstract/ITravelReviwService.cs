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
    public interface ITravelReviwService
    {
        IResult Add(TravelReview review);
        IResult Update(TravelReview review);
        IResult Delete(TravelReview review);
        IDataResult<TravelReview> Get(int id);
        IDataResult<List<TravelReview>> GetAll();
    }
}
