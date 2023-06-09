﻿using System.Data;
using AutoMapper;
using Carpool.Data;
using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public BookingService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        //Post   
        public async Task<BookingModel> AddBookingDetails(BookingRequest model)
        {
            try
            {
                Booking booking = new()
                {
                    BookerId = model.BookerId,
                    From = model.From,
                    To = model.To,
                    Time = model.Time,
                    Date = model.Date,
                    SeatsRequired = model.SeatsRequired,
                    BookedTime = model.BookedTime
                };

                await dbContext.Bookings.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<BookingModel>(booking);
            }
            
            catch (Exception ex)
            {
                throw;
            }



        }

        
    }
}

