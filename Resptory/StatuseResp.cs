using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class StatuseResp : IStatuseModel
    {
        private readonly DBCONTEX context;
        public StatuseResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<StatuseModel>> TabAsync()
        {
            return await context.Statuses.ToListAsync();
        }

        public async Task<StatuseModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Statuses.FirstOrDefaultAsync(x => x.StatuseId == BrandId);
        }

        public async Task<StatuseModel> AddAsync(StatuseModel _BrandModel)
        {
            var brandModel = await context.Statuses.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<StatuseModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Statuses.FirstOrDefaultAsync(x => x.StatuseId == BrandId);
            if (data != null)
            {
                context.Statuses.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<StatuseModel> UpdatAsync(StatuseModel _BrandModel)
        {
            var Data = await context.Statuses.FirstOrDefaultAsync(x => x.StatuseId == _BrandModel.StatuseId);
            if (Data != null)
            {
                Data.Statuse = _BrandModel.Statuse;


                var save = context.Statuses.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}

