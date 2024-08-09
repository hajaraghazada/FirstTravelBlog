using Business.Abstract;
using Core.DataRepositories.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FaqManager(IFaqDal faqDal) : IFaqService
    {
        private readonly IFaqDal _faqDal =faqDal;
       
        public IResult Add(Faq faq)
        {
            try
            {
                _faqDal.Add(faq);
                return new SuccessResult($"the faq added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the faq ...");
            }

           
        }

        public IResult Delete(Faq faq)
        {
            try
            {
                faq.IsActive = false;
                _faqDal.Update(faq);
                return new SuccessResult($"the faq  deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the faq...");
            }
           
        }

        public IDataResult<Faq> Get(int id)
        {
           var faq= _faqDal.Get(p => p.Id == id && p.IsActive);
            if (faq != null)
            {
                return new SuccessDataResult<Faq>(faq, "Faq found successfuly! ");
            }
            return new ErrorDataResult<Faq>("Faq not found...");
        }

        public IDataResult<List<Faq>> GetAll()
        {
            var faq= _faqDal.GetAll(p => p.IsActive);
            if (faq.Count > 0)
            {
                return new SuccessDataResult<List<Faq>>(faq, "Faqs retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Faq>>("No Faqs found...");
        }

        public IResult Update(Faq faq)
        {
            try
            {
                _faqDal.Update(faq);
                return new SuccessResult($"the faq update successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the faq...");
            }
           
        }
    }
}
