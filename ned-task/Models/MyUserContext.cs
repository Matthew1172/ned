/*
 * 
 * This class holds the Database context, which is a List that can have CRUD operations performed on it.
 * Once the operation is finished, we call SaveChanges() method on the list, which will update our DB.
 * 
 */

using Microsoft.EntityFrameworkCore;

namespace ned_task.Models
{
    public class MyUserContext : DbContext
    {
        public MyUserContext()
        {

        }

        public MyUserContext(DbContextOptions<MyUserContext> options)
            : base (options)
        {

        }

        //Configure the model according to our table in the DB.
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

        }

        public DbSet<MyUser> MyUsers { get; set; } = null!;

    }
}
