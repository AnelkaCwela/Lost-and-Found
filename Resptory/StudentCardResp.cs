using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound.Models.Resptory
{
    public class StudentCardResp: IStudentCard
    {
        private readonly DBCONTEX context;
        public StudentCardResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<StudentCardModel>> TabAsync()
        {
            return await context.StudentCards.ToListAsync();
        }

        public async Task<IEnumerable<StudentCardModel>> TabByIdAsync(Guid z)
        {
            return await context.StudentCards.Where(i => i.StudentId == z).ToListAsync();
        }

        public async Task<StudentCardModel> GetByIdAsync(Guid BrandId)
        {
            return await context.StudentCards.FirstOrDefaultAsync(x => x.StudentId == BrandId);
        }
        public async Task<StudentCardModel> GetBy_Id_Async(Guid BrandId)
        {
            return await context.StudentCards.FirstOrDefaultAsync(x => x.FoundId == BrandId);
        }
        public async Task<StudentCardModel> AddAsync(StudentCardModel _BrandModel)
        {
            var brandModel = await context.StudentCards.AddAsync(_BrandModel);
            await context.SaveChangesAsync();
            return brandModel.Entity;
        }

        public async Task<StudentCardModel> RemoveAsync(Guid BrandId)
        {
            var data = await context.StudentCards.FirstOrDefaultAsync(x => x.StudentId == BrandId);
            if (data != null)
            {
                context.StudentCards.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<StudentCardModel> UpdatAsync(StudentCardModel _BrandModel)
        {
            var Data = await context.StudentCards.FirstOrDefaultAsync(x => x.StudentId == _BrandModel.StudentId);
            if (Data != null)
            {
                Data.Suname = _BrandModel.Suname;
                Data.StudentNo = _BrandModel.StudentNo;
                Data.iniatials = _BrandModel.iniatials;
                var save = context.StudentCards.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return _BrandModel;
        }
    }
}
