using Ecom.Commands;
using Ecom.Domain.Entities;
using Ecom.Framework;
using System;

namespace Ecom.DomainServices
{
    public static class Mapper
    {
        public static Checkout MapCheckoutEntity(CheckoutCommand command, long discount)
        {
            var checkoutEntity = new Checkout
            {
                CheckeoutOn = DateTime.UtcNow,
                CouponCode = command.CouponCode.ToString(),
                TotalAmount = command.GetTotalPrice(),
                Discount = discount
            };

            foreach (CheckoutItem item in command.CheckoutItems)
            {
                checkoutEntity.CheckoutProducts.Add(new CheckoutProduct
                {
                    ProductId = item.ProductId,
                    Description = item.Description,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }

            return checkoutEntity;
        }

        public static User MapUser(LoggedInContext loggedInContext)
        {
           return  new User
            {
                Id = loggedInContext.UserId,
                Name = loggedInContext.UserName,
                Email = loggedInContext.UserEmail,
                Role = new UserRole() { RoleName = loggedInContext.UserRole }
            };
        }
    }
}
