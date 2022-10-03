using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class LostResp:ILostModel
    {
        private readonly DBCONTEX context;
        public LostResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<LostModel>> TabAsync()
        {
            return await context.Foundx.ToListAsync();
        }
        public async Task<IEnumerable<LostModel>> GetByUserAsync(Guid BrandId,Guid person)
        {

           return await context.Foundx.Where(x => x.PersonId == person).Where(s => s.StatuseLostId == BrandId).ToListAsync();
       
        }
        public async Task<LostModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Foundx.FirstOrDefaultAsync(x => x.LostId == BrandId);
        }
        public async Task<IEnumerable<LostModel>> GetByActiveAsync(Guid BrandId)
        {

            return await context.Foundx.Where(x => x.StatuseLostId == BrandId).ToListAsync();
        }
        public async Task<IEnumerable<LostModel>> GetByMyIdAsync(Guid BrandId)
        {
            
            return await context.Foundx.Where(x => x.PersonId == BrandId).ToListAsync();
        }
        public async Task<LostModel> AddAsync(LostModel _BrandModel)
        {
            var brandModel = await context.Foundx.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<LostModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Foundx.FirstOrDefaultAsync(x => x.LostId == BrandId);
            if (data != null)
            {
                context.Foundx.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }
   
        public async Task<LostModel> RemoveAsync(LostModel _BrandModel)
        {
            var Data = await context.Foundx.FirstOrDefaultAsync(x => x.LostId == _BrandModel.LostId);
            if (Data != null)
            {
                Data.StatuseLostId = _BrandModel.StatuseLostId;
              
                var save = context.Foundx.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
        public async Task<LostModel> UpdatAsync(LostModel _BrandModel)
        {
            var Data = await context.Foundx.FirstOrDefaultAsync(x => x.LostId == _BrandModel.LostId);
            if (Data != null)
            {
                Data.LostDescription = _BrandModel.LostDescription;
                Data.PersonId = _BrandModel.PersonId;
                Data.LostId = _BrandModel.LostId;
                var save = context.Foundx.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }

        //public async Task<LostModel> GetByCountLikesAsync(int BrandId)
        //{
        //    await context.Foundx.
        //}
        //public async Task<IEnumerable<LostModel>> GetByMyIdAsync(int BrandId)
        //{

        //    return await context.Foundx.Where(x => x.PersonId == BrandId).ToListAsync();
        //}
    }
}
