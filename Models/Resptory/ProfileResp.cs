using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace LostNelsonFound.Models.Resptory
{
    public class ProfileResp 
    {
        private readonly DBCONTEX context;
        //public ProfileResp(DBCONTEX _context)
        //{
        //    context = _context;
        //}
        //public async Task<IEnumerable<ProfileModel>> TabAsync()
        //{
        //    return await context.Profiles.ToListAsync();
        //}

        //public async Task<ProfileModel> GetByIdAsync(Guid BrandId)
        //{
        //    return await context.Profiles.FirstOrDefaultAsync(x => x.ProfileModelId == BrandId);
        //}

        //public async Task<ProfileModel> AddAsync(ProfileModel _BrandModel)
        //{
        //    var brandModel = await context.Profiles.AddAsync(_BrandModel);
        //    await context.SaveChangesAsync();
        //    return brandModel.Entity;
        //}

        //public async Task<ProfileModel> RemoveAsync(Guid BrandId)
        //{
        //    var data = await context.Profiles.FirstOrDefaultAsync(x => x.ProfileModelId == BrandId);
        //    if (data != null)
        //    {
        //        context.Profiles.Remove(data);
        //        await context.SaveChangesAsync();
        //    }
        //    return data;
        //}

        //public async Task<ProfileModel> UpdatAsync(ProfileModel _BrandModel)
        //{
        //    var Data = await context.Profiles.FirstOrDefaultAsync(x => x.ProfileModelId == _BrandModel.ProfileModelId);
        //    if (Data != null)
        //    {
        //        Data.ProfileData = _BrandModel.ProfileData;
               
               
        //        var save = context.Profiles.Attach(Data);
        //        save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        await context.SaveChangesAsync();

        //    }
        //    return _BrandModel;
        //}
    }
}
