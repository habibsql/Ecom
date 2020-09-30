using Ecom.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly IMongoDbService mongoDbService;

        public CheckoutRepository(IMongoDbService mongoDbService)
        {
            this.mongoDbService = mongoDbService;
        }

        public async Task Save(Checkout checkout)
        {
            IMongoCollection<Checkout> checkoutCollection = mongoDbService.GetCollection<Checkout>(null, "Checkouts");

            await checkoutCollection.InsertOneAsync(checkout);
        }
    }
}
