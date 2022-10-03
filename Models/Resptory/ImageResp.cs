using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class ImageResp: IImageModel
    {
        private readonly DBCONTEX context;
        public ImageResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ImageModel>> TabAsync()
        {
            return await context.Images.ToListAsync();
        }

        public async Task<ImageModel> GetByIdAsync(Guid BrandId)
        {
            return await context.Images.FirstOrDefaultAsync(x => x.FoundId == BrandId);
        }

        public async Task<ImageModel> AddAsync(ImageModel _BrandModel)
        {
            var brandModel = await context.Images.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<ImageModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.Images.FirstOrDefaultAsync(x => x.FoundId == BrandId);
            if (data != null)
            {
                context.Images.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<ImageModel> UpdatAsync(ImageModel _BrandModel)
        {
            var Data = await context.Images.FirstOrDefaultAsync(x => x.FoundId == _BrandModel.FoundId);
            if (Data != null)
            {
                Data.FoundId = _BrandModel.FoundId;
                Data.ImageData = _BrandModel.ImageData;
               
                var save = context.Images.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
