using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class BankCardResp: IBankCard
    {
        private readonly DBCONTEX context;
        public BankCardResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<BankCardModel>> TabAsync()
        {
            return await context.BankCards.ToListAsync();
        }

        public async Task<IEnumerable<BankCardModel>> TabByIdAsync(Guid z)
        {
            return await context.BankCards.Where(i => i.BankCardId == z).ToListAsync();
        }

        public async Task<BankCardModel> GetByIdAsync(Guid BrandId)
        {
            return await context.BankCards.FirstOrDefaultAsync(x => x.BankCardId == BrandId);
        }
        public async Task<BankCardModel> GetBy_Id_Async(Guid BrandId)
        {
            return await context.BankCards.FirstOrDefaultAsync(x => x.FoundId == BrandId);
        }
        public async Task<BankCardModel> AddAsync(BankCardModel _BrandModel)
        {
            var brandModel = await context.BankCards.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<BankCardModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.BankCards.FirstOrDefaultAsync(x => x.BankCardId == BrandId);
            if (data != null)
            {
                context.BankCards.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<BankCardModel> UpdatAsync(BankCardModel _BrandModel)
        {
            var Data = await context.BankCards.FirstOrDefaultAsync(x => x.BankCardId == _BrandModel.BankCardId);
            if (Data != null)
            {
                Data.Surname = _BrandModel.Surname;
                Data.iniatials = _BrandModel.iniatials;
                Data.FoundId = _BrandModel.FoundId;
                var save = context.BankCards.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
