namespace HotelWebApiResource.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=HotelContext1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<BookingInfo> BookingInfoes { get; set; }
        public virtual DbSet<VdistinctRoomNo> VdistinctRoomNoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Guest)
                .HasForeignKey(e => e.GuestNo);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Bookings1)
                .WithRequired(e => e.Guest1)
                .HasForeignKey(e => e.GuestNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.HotelNo);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Rooms1)
                .WithRequired(e => e.Hotel1)
                .HasForeignKey(e => e.HotelNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => new { e.RoomNo, e.HotelNo });

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bookings1)
                .WithRequired(e => e.Room1)
                .HasForeignKey(e => new { e.RoomNo, e.HotelNo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.RoomType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.GuestName)
                .IsUnicode(false);
        }
    }
}
