using System;
namespace ШП_ЛБ6
{
	public class Product
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }

        public Product(int id, string title, string description, double price, bool availability)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Availability = availability;
        }

        public string GetProductDetails()
        {
            return $"ID: {Id}, Назва: {Title}, Опис: {Description}, Ціна: {Price}, Наявність: {Availability}";
        }

        public void UpdateProduct(string title = null, string description = null, double? price = null, bool? availability = null)
        {
            if (title != null) Title = title;
            if (description != null) Description = description;
            if (price.HasValue) Price = price.Value;
            if (availability.HasValue) Availability = availability.Value;
        }
    }
}

