using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Models.SingServices;
using UserServices;

namespace SuportFromMusics.Data
{
    public class SuportContext : DbContext
    {
        public SuportContext(DbContextOptions<SuportContext> options) : base(options)
        {

        }
        public DbSet<User> user { get; set; }

        public DbSet<Singer> singer { get; set; }

        public DbSet<SingDetail> singDetail { get; set; }

        public DbSet<SingType> singType { get; set; }

        public DbSet<MusicText> MusicTexts { get; set; }

        public DbSet<SongVersies> SongVersies { get; set; }

        public DbSet<FollowSinger> FollowSingers { get; set; }

        public DbSet<SuportForm> SuportForm { get; set; }

        public DbSet<SuportedUsers> SuportedUsers { get; set; }

        public DbSet<SingLike> SingLike { get;set; }

        public DbSet<SaveSing> SaveSing { get; set; }

        public DbSet<Coment> Coment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Singer>().HasKey(k => new { k.Id });
            modelBuilder.Entity<SongVersies>().HasKey(k => new { k.Id });
            modelBuilder.Entity<SuportedUsers>().HasKey(k => new { k.UserId, k.SuportFormId });
            modelBuilder.Entity<SaveSing>().HasKey(k => new { k.SingDetailId, k.UserId });
            modelBuilder.Entity<Coment>().HasKey(k => new { k.Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
