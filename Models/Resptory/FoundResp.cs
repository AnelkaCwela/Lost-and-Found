using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class FoundResp: IFoundModel
    {
        private readonly DBCONTEX context;
        public FoundResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<FoundModel>> TabAsync()
        {
            return await context.Founds.ToListAsync();
        }
        public async Task<IEnumerable<FoundModel>> GetByUserAsync(Guid BrandId, Guid person)
        {
            return await context.Founds.Where(x => x.StatuseId == BrandId).Where(p => p.PersonId == person).ToListAsync();
          // return Data.Where(p => p.PersonId == person);
        }
        //public async Task<IEnumerable<FoundModel>> GetByActiveAsync(Guid BrandId, Guid person)
        //{
        //    var Data = await context.Founds.Where(x => x.StatuseId == BrandId).ToListAsync();
        //    return Data.Where(p => p.PersonId == person);
        //}
        public async Task<IEnumerable<FoundModel>> GetByActiveAsync(Guid BrandId)
        {
           return await context.Founds.Where(x => x.StatuseId == BrandId).ToListAsync();
        
        }
        public async Task<IEnumerable<FoundModel>> GetByMyIdAsync(Guid BrandId)
        {
            return await context.Founds.Where(x => x.PersonId == BrandId).ToListAsync();
        }
        public async Task<FoundModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Founds.FirstOrDefaultAsync(x => x.FoundId == BrandId);
        }

        public async Task<FoundModel> AddAsync(FoundModel _BrandModel)
        {
            var brandModel = await context.Founds.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<FoundModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Founds.FirstOrDefaultAsync(x => x.FoundId == BrandId);
            if (data != null)
            {
                context.Founds.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

       
        public async Task<FoundModel> RemoveAsync(FoundModel _BrandModel)
        {
            var Data = await context.Founds.FirstOrDefaultAsync(x => x.FoundId == _BrandModel.FoundId);
            if (Data != null)
            {
                Data.StatuseId = _BrandModel.StatuseId;
                
                var save = context.Founds.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
        public async Task<FoundModel> UpdatAsync(FoundModel _BrandModel)
        {
            var Data = await context.Founds.FirstOrDefaultAsync(x => x.FoundId == _BrandModel.FoundId);
            if (Data != null)
            {
                Data.Description = _BrandModel.Description;
                Data.PersonId = _BrandModel.PersonId;
                Data.FoundId = _BrandModel.FoundId;
                Data.CategoryId = _BrandModel.CategoryId;
                Data.DateFound = _BrandModel.DateFound;
                Data.DatePosted = _BrandModel.DatePosted;
                //Data.
                var save = context.Founds.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
