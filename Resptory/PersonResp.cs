using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class PersonResp: IPersonModel
    {
        private readonly DBCONTEX context;
        public PersonResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<PersonModel>> TabAsync()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<PersonModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Persons.FirstOrDefaultAsync(x => x.PersonId == BrandId);
        }
        public async Task<PersonModel> GetByEmailAsync(string PersonUserName)
        {
            return await context.Persons.FirstOrDefaultAsync(x => x.UserName == PersonUserName);
        }
        public async Task<PersonModel> AddAsync(PersonModel _BrandModel)
        {
            var brandModel = await context.Persons.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<PersonModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Persons.FirstOrDefaultAsync(x => x.PersonId == BrandId);
            if (data != null)
            {
                context.Persons.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<PersonModel> UpdatAsync(PersonModel _BrandModel)
        {
            var Data = await context.Persons.FirstOrDefaultAsync(x => x.PersonId == _BrandModel.PersonId);
            if (Data != null)
            {
                Data.UserName = _BrandModel.UserName;
             

                var save = context.Persons.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }

       
    }
}

