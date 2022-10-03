using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class CampusResp: ICampus
    {
        private readonly DBCONTEX context;
        public CampusResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CampusModel>> TabAsync()
        {
            return await context.Campus.ToListAsync();
        }

        public async Task<IEnumerable<CampusModel>> TabByIdAsync(Guid z)
        {
            return await context.Campus.Where(i => i.CampusId == z).ToListAsync();
        }

        public async Task<CampusModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Campus.FirstOrDefaultAsync(x => x.CampusId == BrandId);
        }

        public async Task<CampusModel> AddAsync(CampusModel _BrandModel)
        {
            var brandModel = await context.Campus.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<CampusModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Campus.FirstOrDefaultAsync(x => x.CampusId == BrandId);
            if (data != null)
            {
                context.Campus.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CampusModel> UpdatAsync(CampusModel _BrandModel)
        {
            var Data = await context.Campus.FirstOrDefaultAsync(x => x.CampusId == _BrandModel.CampusId);
            if (Data != null)
            {
                Data.Campus = _BrandModel.Campus;        
                var save = context.Campus.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
