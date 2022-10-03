using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class CommentResp
    {
        //private readonly DBCONTEX context;
        //public CommentResp(DBCONTEX _context)
        //{
        //    context = _context;
        //}
        //public async Task<IEnumerable<CommentModel>> TabAsync()
        //{
        //    return await context.Comments.ToListAsync();
        //}

        //public async Task<CommentModel> GetByIdAsync(Guid BrandId)
        //{
        //    return await context.Comments.FirstOrDefaultAsync(x => x.CommentId == BrandId);
        //}

        //public async Task<CommentModel> AddAsync(CommentModel _BrandModel)
        //{
        //    var brandModel = await context.Comments.AddAsync(_BrandModel);
        //    await context.SaveChangesAsync();
        //    return brandModel.Entity;
        //}

        //public async Task<CommentModel> RemoveAsync(Guid BrandId)
        //{
        //    var data = await context.Comments.FirstOrDefaultAsync(x => x.CommentId == BrandId);
        //    if (data != null)
        //    {
        //        context.Comments.Remove(data);
        //        await context.SaveChangesAsync();
        //    }
        //    return data;
        //}

        //public async Task<CommentModel> UpdatAsync(CommentModel _BrandModel)
        //{
        //    var Data = await context.Comments.FirstOrDefaultAsync(x => x.CommentId == _BrandModel.CommentId);
        //    if (Data != null)
        //    {
        //        Data.Description = _BrandModel.Description;
        //        Data.PersonId = _BrandModel.PersonId;
        //        Data.FoundId = _BrandModel.FoundId;
        //        var save = context.Comments.Attach(Data);
        //        save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        await context.SaveChangesAsync();

        //    }
        //    return _BrandModel;
        //}
    }
}
