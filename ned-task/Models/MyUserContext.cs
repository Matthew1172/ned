using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ned_task.Models
{
    public partial class MyUserContext : DbContext
    {
        public MyUserContext()
        {

        }

        public MyUserContext(DbContextOptions<MyUserContext> options)
            : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyUser>(entity =>
            {
                entity.ToTable("MyUsers");

                entity.Property(e => e.fname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                
                entity.Property(e => e.lname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<MyUser> MyUsers { get; set; } = null!;

    }
}
