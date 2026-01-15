using Atrium.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(h => h.Description)
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("room_types");

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(r => r.BasePrice)
                    .HasColumnName("base_price")
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                entity.Property(r => r.Size)
                    .HasColumnType("decimal(10, 1)")
                    .IsRequired();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.RoomTypeId)
                    .HasColumnName("room_type_id")
                    .IsRequired();

                entity.Property(r => r.HotelId)
                    .HasColumnName("hotel_id")
                    .IsRequired();

                entity.Property(r => r.RoomNumber)
                    .HasColumnName("room_number")
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(r => r.Status)
                    .HasDefaultValue("available");

                entity.Property(r => r.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.Property(r => r.MaxGuests)
                    .HasColumnName("max_guests");


                entity.HasIndex(r => r.RoomTypeId);
                entity.HasIndex(r => r.HotelId);

            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(s => s.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Price)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.Property(s => s.IsAvailable)
                    .HasColumnName("is_available")
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.FirstName)
                    .HasColumnName("first_name")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(g => g.LastName)
                    .HasColumnName("last_name")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(g => g.Email)
                    .HasMaxLength(50);

                entity.Property(g => g.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(g => g.PassportNumber)
                    .HasColumnName("passport_number")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(g => g.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .IsRequired();

                entity.Property(g => g.Address)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasIndex(r => r.Id);

                entity.Property(r => r.GuestId)
                    .HasColumnName("guest_id")
                    .IsRequired();

                entity.Property(r => r.RoomId)
                    .HasColumnName("room_id")
                    .IsRequired();

                entity.Property(r => r.CheckInDate)
                    .HasColumnName("check_in_date")
                    .IsRequired();

                entity.Property(r => r.CheckOutDate)
                    .HasColumnName("check_out_date")
                    .IsRequired();

                entity.Property(r => r.AdultsCount)
                    .HasColumnName("adults_count")
                    .IsRequired();

                entity.Property(r => r.ChildrenCount)
                    .HasColumnName("children_count")
                    .IsRequired();

                entity.Property(r => r.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.Property(r => r.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasIndex(r => r.GuestId);
                entity.HasIndex(r => r.RoomId); 
            });
        }
    }
}
