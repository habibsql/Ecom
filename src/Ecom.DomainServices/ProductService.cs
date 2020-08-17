using Ecom.Commands;
using Ecom.Domain.Entities;
using Ecom.Framework;
using Ecom.Repositories;
using System.Threading.Tasks;

namespace Ecom.DomainServices
{
    public class ProductService : IProductService
    {
        private readonly IDiscountStratigyProvider discountStratigyProvider;
        private readonly IProductRepository productRepository;
        private readonly ICheckoutRepository checkoutRepository;
        private readonly IHttpContextProvider httpContextProvider;

        public ProductService(IDiscountStratigyProvider discountStratigyProvider, IProductRepository productRepository, 
            ICheckoutRepository checkoutRepository, IHttpContextProvider httpContextProvider)
        {
            this.discountStratigyProvider = discountStratigyProvider;
            this.productRepository = productRepository;
            this.checkoutRepository = checkoutRepository;
            this.httpContextProvider = httpContextProvider;
        }

        public Task Checkout(CheckoutCommand command)
        {
            IDiscountStratigy discountStratigy = discountStratigyProvider.CreateDiscountStratigy(command.CouponCode, command.GetTotalPrice());

            Checkout entity = Mapper.MapCheckoutEntity(command, discountStratigy.Discount());

            LoggedInContext loggedInContext = httpContextProvider.GetLoggedinContext();

            entity.CheckeoutBy = Mapper.MapUser(loggedInContext);

            checkoutRepository.Save(entity);

            return Task.CompletedTask;
        }

    }
}
