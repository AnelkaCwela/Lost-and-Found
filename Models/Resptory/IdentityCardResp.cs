using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class IdentityCardResp: IIdentityCard
    {
        private readonly DBCONTEX context;
        public IdentityCardResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<IdentityCardModel>> TabAsync()
        {
            return await context.IdentityCards.ToListAsync();
        }

        public async Task<IEnumerable<IdentityCardModel>> TabByIdAsync(Guid z)
        {
            return await context.IdentityCards.Where(i => i.IdentyCardId == z).ToListAsync();
        }

        public async Task<IdentityCardModel> GetByIdAsync(Guid BrandId)
        {
            return await context.IdentityCards.FirstOrDefaultAsync(x => x.IdentyCardId == BrandId);
        }
        public async Task<IdentityCardModel> GetBy_Id_Async(Guid BrandId)
        {
            return await context.IdentityCards.FirstOrDefaultAsync(x => x.FoundId == BrandId);
        }
        public async Task<IdentityCardModel> AddAsync(IdentityCardModel _BrandModel)
        {
            var brandModel = await context.IdentityCards.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<IdentityCardModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.IdentityCards.FirstOrDefaultAsync(x => x.IdentyCardId == BrandId);
            if (data != null)
            {
                context.IdentityCards.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<IdentityCardModel> UpdatAsync(IdentityCardModel _BrandModel)
        {
            var Data = await context.IdentityCards.FirstOrDefaultAsync(x => x.IdentyCardId == _BrandModel.IdentyCardId);
            if (Data != null)
            {
                Data.Name = _BrandModel.Name;
                Data.Suname = _BrandModel.Suname;
                Data.FoundId = _BrandModel.FoundId;
                var save = context.IdentityCards.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }

      
    }
}
