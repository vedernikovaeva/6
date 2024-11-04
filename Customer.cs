using System;
namespace ШП_ЛБ6
{
	public class Customer
	{
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer(int customerId, string name, string phone, string email, string address)
        {
            CustomerId = customerId;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }

        public List<string> ViewProducts(List<Product> products)
        {
            List<string> productDetails = new List<string>();
            foreach (var product in products)
            {
                productDetails.Add(product.GetProductDetails());
            }
            return productDetails;
        }

        public Order CreateOrder(ShoppingCart shoppingCart)
        {
            return shoppingCart.Checkout(Address);
        }
    }
}
