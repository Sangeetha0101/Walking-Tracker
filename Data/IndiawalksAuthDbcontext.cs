using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndiaWalks.Data
{
    public class IndiawalksAuthDbcontext : IdentityDbContext
    {
        public IndiawalksAuthDbcontext(DbContextOptions<IndiawalksAuthDbcontext> options): base(options)     
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerroleId = "25CC86F2-F3DC-4E89-ACE1-9573BEEAB9B7";
            var WriterroleId = "76FD7615-846A-4605-A9B5-7DDA8F4910EA";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerroleId,
                    ConcurrencyStamp = readerroleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = WriterroleId,
                    ConcurrencyStamp = WriterroleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }

    
}
