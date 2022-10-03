using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class StatuseLostResp : IStatuseLostModel
    {
        private readonly DBCONTEX context;
        public StatuseLostResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<StatuseLostModel>> TabAsync()
        {
            return await context.Statusex.ToListAsync();
        }

        public async Task<StatuseLostModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Statusex.FirstOrDefaultAsync(x => x.StatuseLostId == BrandId);
        }

        public async Task<StatuseLostModel> AddAsync(StatuseLostModel _BrandModel)
        {
            var brandModel = await context.Statusex.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<StatuseLostModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Statusex.FirstOrDefaultAsync(x => x.StatuseLostId == BrandId);
            if (data != null)
            {
                context.Statusex.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<StatuseLostModel> UpdatAsync(StatuseLostModel _BrandModel)
        {
            var Data = await context.Statusex.FirstOrDefaultAsync(x => x.StatuseLostId == _BrandModel.StatuseLostId);
            if (Data != null)
            {
                Data.LostStatuse = _BrandModel.LostStatuse;


                var save = context.Statusex.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}

