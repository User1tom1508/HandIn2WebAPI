using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPHandIn2WebApi.Model;
using DNPHandIn2WebApi.Persistance;
using FileData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models;

namespace HandIn1.Data
{
    public class AdultAdapter: IAdultAdapter
    {
        private readonly CustomDbContext _dbContext;
        
       public AdultAdapter(CustomDbContext dbContext)
       {
           _dbContext = dbContext;
       }


        public async Task<IList<Adult>> getAllAdults()
        {
            return _dbContext.Adults.Include(adult => adult.Job).ToList();
        }

        public async Task Delete(Adult adult)
        {
            Adult adultToDelete = _dbContext.Adults.Include(adult1 =>adult1.Job).First(adultos => adultos.Id == adult.Id);
            _dbContext.Adults.Remove(adultToDelete);
            _dbContext.Jobs.Remove(adultToDelete.Job);
           await _dbContext.SaveChangesAsync();
        }

        public async Task Add(Adult adult)
        {
            await _dbContext.Adults.AddAsync(adult);
            await _dbContext.Jobs.AddAsync(adult.Job);
            await _dbContext.SaveChangesAsync();
        }

        public async void Modify(Adult adult)
        {
           
        }
    }
}