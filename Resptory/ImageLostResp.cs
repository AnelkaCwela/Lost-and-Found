using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class ImageLostResp
    {
        private readonly DBCONTEX context;
        public ImageLostResp(DBCONTEX _context)
        {
            context = _context;
        }
        //public async Task<IEnumerable<ImageLostModel>> TabAsync()
        //{
        //    return await context.Imagex.ToListAsync();
        //}

        //public async Task<ImageLostModel> GetByIdAsync(Guid BrandId)
        //{
        //    return await context.Imagex.FirstOrDefaultAsync(x => x.ImageLostId == BrandId);
        //}

        //public async Task<ImageLostModel> AddAsync(ImageLostModel _BrandModel)
        //{
        //    var brandModel = await context.Imagex.AddAsync(_BrandModel);
        //    await context.SaveChangesAsync();
        //    return brandModel.Entity;
        //}

        //public async Task<ImageLostModel> RemoveAsync(Guid BrandId)
        //{
        //    var data = await context.Imagex.FirstOrDefaultAsync(x => x.ImageLostId == BrandId);
        //    if (data != null)
        //    {
        //        context.Imagex.Remove(data);
        //        await context.SaveChangesAsync();
        //    }
        //    return data;
        //}

        //public async Task<ImageLostModel> UpdatAsync(ImageLostModel _BrandModel)
        //{
        //    var Data = await context.Imagex.FirstOrDefaultAsync(x => x.ImageLostId == _BrandModel.ImageLostId);
        //    if (Data != null)
        //    {
        //        Data.LostId = _BrandModel.LostId;
        //        Data.ImageLostData = _BrandModel.ImageLostData;

        //        var save = context.Imagex.Attach(Data);
        //        save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        await context.SaveChangesAsync();

        //    }
        //    return _BrandModel;
        //}
    }
}
