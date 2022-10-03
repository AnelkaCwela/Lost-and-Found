using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class CategoryResp : ICategoryModel
    {
        private readonly DBCONTEX context;
        public CategoryResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CategoryModel>> TabAsync()
        {
            return await context.Categorys.ToListAsync();
        }

        public async Task<IEnumerable<CategoryModel>> TabByIdAsync(Guid z)
        {
            return await context.Categorys.Where(i=>i.CategoryId==z).ToListAsync();
        }

        public async Task<CategoryModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Categorys.FirstOrDefaultAsync(x => x.CategoryId == BrandId);
        }

        public async Task<CategoryModel> AddAsync(CategoryModel _BrandModel)
        {
            var brandModel = await context.Categorys.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<CategoryModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Categorys.FirstOrDefaultAsync(x => x.CategoryId == BrandId);
            if (data != null)
            {
                context.Categorys.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CategoryModel> UpdatAsync(CategoryModel _BrandModel)
        {
            var Data = await context.Categorys.FirstOrDefaultAsync(x => x.CategoryId == _BrandModel.CategoryId);
            if (Data != null)
            {
                Data.CategoryName = _BrandModel.CategoryName;
              
                  var save = context.Categorys.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
              
            }
            return _BrandModel;
        }
    }
}
