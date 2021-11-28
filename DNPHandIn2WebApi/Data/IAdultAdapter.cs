using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNPHandIn2WebApi.Model;
using Models;

namespace HandIn1.Data
{
    public interface IAdultAdapter
    {
        Task<IList<Adult>> getAllAdults();
        public Task Delete(Adult adult);
        public Task Add(Adult adult);
        public void Modify(Adult adult);

        
    }
}