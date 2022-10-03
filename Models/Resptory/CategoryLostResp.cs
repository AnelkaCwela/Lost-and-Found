using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class CategoryLostResp: ICategoryLostModel
    {
        private readonly DBCONTEX context;
        public CategoryLostResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CategoryLostModel>> TabAsync()
        {
            return await context.Categoryx.ToListAsync();
        }
        public async Task<IEnumerable<CategoryLostModel>> TabByIdAsync(Guid z)
        {
            return await context.Categoryx.Where(p=>p.CategoryLostId==z).ToListAsync();
        }


        public async Task<CategoryLostModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Categoryx.FirstOrDefaultAsync(x => x.CategoryLostId == BrandId);
        }

        public async Task<CategoryLostModel> AddAsync(CategoryLostModel _BrandModel)
        {
            var brandModel = await context.Categoryx.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<CategoryLostModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Categoryx.FirstOrDefaultAsync(x => x.CategoryLostId == BrandId);
            if (data != null)
            {
                context.Categoryx.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CategoryLostModel> UpdatAsync(CategoryLostModel _BrandModel)
        {
            var Data = await context.Categoryx.FirstOrDefaultAsync(x => x.CategoryLostId == _BrandModel.CategoryLostId);
            if (Data != null)
            {
                Data.CategoryLostName = _BrandModel.CategoryLostName;
              

                var save = context.Categoryx.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
              
            }
            return _BrandModel;
        }
    }
}
