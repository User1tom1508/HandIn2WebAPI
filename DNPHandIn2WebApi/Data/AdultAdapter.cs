using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;

namespace HandIn1.Data
{
    public class AdultAdapter: IAdultAdapter
    {
        private FileContext _fileContext;
        public IList<Adult> adults; 
        
       public AdultAdapter()
        {
            _fileContext = new FileContext();
            adults = _fileContext.Adults;

        }


        public async Task<IList<Adult>> getAllAdults()
        {
           return new List<Adult>(adults);
        }

        public async Task Delete(Adult adult)
        {
            Adult adultToDelete = adults.First(adultos => adultos.Id == adult.Id);
            adults.Remove(adultToDelete);
           _fileContext.SaveChanges();
        }

        public async Task Add(Adult adult)
        {

            try
            {
                adult.Id = adults.Max(adult => adult.Id);
                adult.Id++;
            }
            catch (IndexOutOfRangeException e)
            {
                adult.Id = 1;
            }
            
            adults.Add(adult);
            _fileContext.SaveChanges();
            
        }

        public async void Modify(Adult adult)
        {
           
        }
    }
}