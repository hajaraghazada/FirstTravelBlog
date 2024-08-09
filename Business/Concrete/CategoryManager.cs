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
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categeoryDal = categoryDal;

        public IResult Add(Category category)
        {
            try
            {
                _categeoryDal.Add(category);
                return new SuccessResult($"the category added successfully! ");
            }
            catch 
            {
                return new ErrorResult($"An error occurred while adding the category...");
            }
            
        }

        public IResult Delete(Category category)
        {
            try
            {
                category.IsActive = false;
                _categeoryDal.Update(category);
                //_categeoryDal.Delete(category);
                return new SuccessResult($"the category deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the category...");
            }
           
        }

        public IDataResult<Category> Get(int id)
        {
            var category= _categeoryDal.Get(p => p.Id == id && p.IsActive); 
            if (category != null)
            {
                return new SuccessDataResult<Category>(category,"Category found successfuly! ");
            }
            return new ErrorDataResult<Category>(category, "Category not found...");
        }

        public IDataResult<List<Category>> GetAll()
        {
          var category= _categeoryDal.GetAll(p => p.IsActive);
            if (category.Count > 0)
            {
                return new SuccessDataResult<List<Category>>(category, "Categories retrieved successfuly! ");
            }
            return new ErrorDataResult<List<Category>>("No Categories found...");

        }

        public IResult Update(Category category)
        {
            try
            {
                _categeoryDal.Update(category);
                return new SuccessResult($"the category updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the category...");
            }
        }
    }
}
