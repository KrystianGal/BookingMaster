using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookingMaster.Application.Common.Interfaces;
using BookingMaster.Domain.Entities;
using BookingMaster.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace BookingMaster.Infrastructure.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
      
        public void Update(Booking entity)
        {
            _db.Bookings.Update(entity);
        }
    }
}
