using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class CommentLostResp
    {
        //private readonly DBCONTEX context;
        //public CommentLostResp(DBCONTEX _context)
        //{
        //    context = _context;
        //}
        //public async Task<IEnumerable<CommentLostModel>> TabAsync()
        //{
        //    return await context.Commentx.ToListAsync();
        //}

        //public async Task<CommentLostModel> GetByIdAsync(Guid BrandId)
        //{
        //    return await context.Commentx.FirstOrDefaultAsync(x => x.CommentLostId == BrandId);
        //}

        //public async Task<CommentLostModel> AddAsync(CommentLostModel _BrandModel)
        //{
        //    var brandModel = await context.Commentx.AddAsync(_BrandModel);
        //    await context.SaveChangesAsync();
        //    return brandModel.Entity;
        //}

        //public async Task<CommentLostModel> RemoveAsync(Guid BrandId)
        //{
        //    var data = await context.Commentx.FirstOrDefaultAsync(x => x.CommentLostId == BrandId);
        //    if (data != null)
        //    {
        //        context.Commentx.Remove(data);
        //        await context.SaveChangesAsync();
        //    }
        //    return data;
        //}

        //public async Task<CommentLostModel> UpdatAsync(CommentLostModel _BrandModel)
        //{
        //    var Data = await context.Commentx.FirstOrDefaultAsync(x => x.CommentLostId == _BrandModel.CommentLostId);
        //    if (Data != null)
        //    {
        //        Data.LostDescription = _BrandModel.LostDescription;
        //        Data.PersonId = _BrandModel.PersonId;
        //        Data.LostId = _BrandModel.LostId;
        //        var save = context.Commentx.Attach(Data);
        //        save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        await context.SaveChangesAsync();

        //    }
        //    return _BrandModel;
        //}
    }
}
