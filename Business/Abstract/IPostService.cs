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
    public interface IPostService
    {
        IResult Add (Post post);
        IResult Update (Post post);
        IResult Delete (Post post);
        IDataResult<Post> Get(int  id);
        IDataResult<List<Post>> GetAll();
        

    }
}
