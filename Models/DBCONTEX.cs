using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LostNelsonFound.Models.DataModel;
namespace LostNelsonFound.Models
{
    public class DBCONTEX : IdentityDbContext<UserPlusModel>
    {
        public DBCONTEX(DbContextOptions<DBCONTEX> options) : base(options)
        { }
        public DbSet<CampusModel> Campus { get; set; }
        public DbSet<ClaimModel> Claims { get; set; }
        public DbSet<IdentityCardModel> IdentityCards { get; set; }
        public DbSet<StudentCardModel> StudentCards { get; set; }
        public DbSet<BankCardModel> BankCards { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }
        //public DbSet<ProfileModel> Profiles { get; set; }
      //  public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FoundModel> Founds { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<StatuseModel> Statuses { get; set; }
        public DbSet<CategoryLostModel> Categoryx { get; set; }
       // public DbSet<CommentLostModel> Commentx { get; set; }
       public DbSet<LostModel> Foundx { get; set; }
     //   public DbSet<ImageLostModel> Imagex { get; set; }
    
        public DbSet<StatuseLostModel> Statusex { get; set; }

    }
}
