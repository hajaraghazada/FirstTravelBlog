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
    public interface IFaqService
    {
        IResult Add(Faq faq);
        IResult Update(Faq faq);
        IResult Delete(Faq faq);
        IDataResult<Faq> Get(int id);
        IDataResult<List<Faq>> GetAll();
    }
}
