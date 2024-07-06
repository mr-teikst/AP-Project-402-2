using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ApProject.Models
{
    public enum PaymentType
    {
        Cash,
        Online
    }
    internal class Order
    {
        public double Rating;
        public double Price;
        public DateTime DateTime;
        public Restaurant Restaurant;
        public Customer Customer;
        public Comment Comment;
        public PaymentType PaymentType;
        public List<Food> Foods=new List<Food>();

        public Order(List<Food> foods,Customer customer,Restaurant restaurant,PaymentType paymentType)
        {
            this.Foods = foods;
            this.Customer = customer;
            this.Restaurant = restaurant;
            this.PaymentType = paymentType;
            this.DateTime = DateTime.Now;
            this.Price=foods.Sum(x => x.Price);
        }

       public static List<Order> FilterByUsername(string username,DateTime start, DateTime end,List<Order> orders)
        {
            return orders.Where(o => o.Customer.UserName == username && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Order> FilterByMobileNumber(string phone, DateTime start, DateTime end, List<Order> orders)
        {
            return orders.Where(o => o.Customer.PhoneNumebr==phone && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Order> FilterByFood(Food food, DateTime start, DateTime end, List<Order> orders)
        {
            return orders.Where(o => o.Foods.Contains(food) && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static  List<Order> FilterByPriceRange(double minPrice, double maxPrice, DateTime start, DateTime end, List<Order> orders)
        {
            return orders.Where(o => o.Price >= minPrice && o.Price <= maxPrice && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Order> FilterByType(DateTime start, DateTime end, List<Order> orders)
        {
            return orders.Where(o=> o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public void AddRating(double  rating)
        {
           this.Rating=rating;
        }
        public void AddComment(string text)
        {
           this.Comment =new Comment (text,DateTime.Now,this.Customer);
        }

    }
}
