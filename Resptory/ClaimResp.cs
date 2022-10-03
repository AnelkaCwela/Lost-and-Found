using LostNelsonFound.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class ClaimResp:IClaimModel
    {
        private readonly DBCONTEX context;
        public ClaimResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ClaimModel>> TabAsync()
        {
            return await context.Claims.ToListAsync();
        }

        public async Task<IEnumerable<ClaimModel>> TabByIdAsync(Guid z)
        {
            return await context.Claims.Where(i => i.FoundId == z).ToListAsync();
        }

        public async Task<ClaimModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Claims.FirstOrDefaultAsync(x => x.ClaimId == BrandId);
        }

        public async Task<ClaimModel> AddAsync(ClaimModel _BrandModel)
        {
            var brandModel = await context.Claims.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<ClaimModel> CheckClaimAsync(Guid foundId,Guid personiD)
        {
            return await context.Claims.FirstOrDefaultAsync(x => x.FoundId == foundId);
       
           
        }

        public async Task<ClaimModel> UpdatAsync(ClaimModel _BrandModel)
        {

            var data = await context.Claims.FirstOrDefaultAsync(o => o.FoundId == _BrandModel.FoundId);
           // var Rate = data.FirstOrDefault(d => d.PersunId == _BrandModel.PersunId);
            if (data != null)
            {


                //Data.PersonId = _BrandModel.PersonId;
                data.IsOwner = _BrandModel.IsOwner;
                var save = context.Claims.Attach(data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
