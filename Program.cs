using System;
using System.Collections.Generic;
using System.Linq;

namespace ШП_ЛБ6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Крем для обличчя", "Зволожуючий крем для обличчя", 990.99, true),
                new Product(2, "Сироватка", "Відновлююча сироватка для обличчя", 1549.99 , true),
                new Product(3, "Спрей-міст для обличчя", "Освіжаючий спрей-міст для обличчя", 880.89, true)
            };

            Customer customer = new Customer(1, "Інна", "+123456789", "inna@gmail.com", "123 Вулиця");
            ShoppingCart shoppingCart = new ShoppingCart();
            Admin admin = new Admin(1, "admin@gmail.com");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nГоловне меню");
                Console.WriteLine("1. Переглянути товари");
                Console.WriteLine("2. Додати товар до кошика");
                Console.WriteLine("3. Переглянути кошик");
                Console.WriteLine("4. Оформити замовлення");
                Console.WriteLine("5. Адмін: Додати новий товар");
                Console.WriteLine("6. Адмін: Оновити інформацію про товар");
                Console.WriteLine("0. Вийти");
                Console.Write("Виберіть опцію: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ViewProducts(products);
                        break;
                    case "2":
                        AddProductToCart(products, shoppingCart);
                        break;
                    case "3":
                        ViewCart(shoppingCart);
                        break;
                    case "4":
                        Checkout(customer, shoppingCart);
                        break;
                    case "5":
                        AdminAddProduct(products, admin);
                        break;
                    case "6":
                        AdminUpdateProduct(products, admin);
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Завершення роботи програми...");
                        break;
                    default:
                        Console.WriteLine("Неправильна опція. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ViewProducts(List<Product> products)
        {
            Console.WriteLine("\nДоступні товари:");
            foreach (var product in products)
            {
                Console.WriteLine(product.GetProductDetails());
            }
        }

        static void AddProductToCart(List<Product> products, ShoppingCart shoppingCart)
        {
            Console.Write("\nВведіть ID товару для додавання до кошика: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = products.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.Availability)
            {
                Console.Write("Введіть кількість: ");
                int quantity = int.Parse(Console.ReadLine());
                shoppingCart.AddToCart(product, quantity);
            }
            else
            {
                Console.WriteLine("Товар не знайдено або він недоступний.");
            }
        }

        static void ViewCart(ShoppingCart shoppingCart)
        {
            Console.WriteLine("\nТовари у кошику:");
            foreach (var item in shoppingCart.ViewDetails())
            {
                Console.WriteLine(item);
            }
        }

        static void Checkout(Customer customer, ShoppingCart shoppingCart)
        {
            Order order = customer.CreateOrder(shoppingCart);
            Console.WriteLine($"\nЗамовлення створено. Сума: ${order.OrderTotal}, Статус: {order.GetOrderStatus()}");
            order.ConfirmOrder("електронну пошту");
            Console.WriteLine($"{order.GetOrderStatus()}");
        }

        static void AdminAddProduct(List<Product> products, Admin admin)
        {
            Console.Write("\nВведіть назву товару: ");
            string title = Console.ReadLine();
            Console.Write("Введіть опис: ");
            string description = Console.ReadLine();
            Console.Write("Введіть ціну: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Чи є в наявності (true/false): ");
            bool availability = bool.Parse(Console.ReadLine());

            Product newProduct = new Product(products.Count + 1, title, description, price, availability);
            admin.AddProduct(products, newProduct);
            Console.WriteLine($"Товар {title} успішно додано.");
        }

        static void AdminUpdateProduct(List<Product> products, Admin admin)
        {
            Console.Write("\nВведіть ID товару для оновлення: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                Console.Write("Введіть нову назву (залиште пустим, щоб залишити без змін): ");
                string title = Console.ReadLine();
                Console.Write("Введіть новий опис (залиште пустим, щоб залишити без змін): ");
                string description = Console.ReadLine();
                Console.Write("Введіть нову ціну (залиште пустим, щоб залишити без змін): ");
                string priceInput = Console.ReadLine();
                Console.Write("Чи є в наявності (true/false) або залиште пустим, щоб залишити без змін): ");
                string availabilityInput = Console.ReadLine();

                double? newPrice = string.IsNullOrEmpty(priceInput) ? (double?)null : double.Parse(priceInput);
                bool? newAvailability = string.IsNullOrEmpty(availabilityInput) ? (bool?)null : bool.Parse(availabilityInput);

                admin.UpdateProduct(product, string.IsNullOrEmpty(title) ? null : title,
                    string.IsNullOrEmpty(description) ? null : description,
                    newPrice, newAvailability);

                Console.WriteLine("Товар успішно оновлено.");
            }
            else
            {
                Console.WriteLine("Товар не знайдено.");
            }
        }
    }
}
