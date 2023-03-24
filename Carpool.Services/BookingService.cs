﻿using System;
using System.Data;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;

        public BookingService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post   
        public async Task<List<OfferTransaction>> ReadBookingDetails(BookingRequest model)
        {
            try
            {
                BookingTransaction bookingTransaction = new()
                {
                    BookerId=model.BookerId,
                    From=model.From,
                    To=model.To,
                    Time=model.Time,
                    Date = model.Date,
                    SeatsRequired =model.SeatsRequired,
                    BookedTime=model.BookedTime
                };

                await dbContext.BookingTransactions.AddAsync(bookingTransaction);
                await dbContext.SaveChangesAsync();

                List<OfferTransaction> matches=dbContext.OfferTransactions.Where(n =>

                (n.From == bookingTransaction.From) &&
                (n.To == bookingTransaction.To)&&
                (n.Time == bookingTransaction.Time)&&
                (n.Date == bookingTransaction.Date)


                ).ToList<OfferTransaction>();

                return matches;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

