using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApProject.Models
{
    internal class Reserve
    {
        public double Price;
        public double Rating;
        public DateTime DateTime;
        public bool Canceled;
        public bool notPresent;
        public Resturant Restaurant;
        public Customer Customer;

        public Reserve (Customer customer,Resturant restaurant,double price,DateTime dateTime)
        {
            this.Customer = customer;
            this.Restaurant = restaurant;
            this.notPresent = false;
            this.Canceled = false;  
            this.DateTime =dateTime;
            this.Price = price;

        }
        public static List<Reserve> FilterByUsername(string username, DateTime start, DateTime end, List<Reserve > reserves)
        {
            return reserves.Where(o => o.Customer.UserName == username && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Reserve> FilterByMobileNumber(string phone, DateTime start, DateTime end, List<Reserve> reserves)
        {
            return reserves.Where(o => o.Customer.PhoneNumebr == phone && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Reserve> FilterByPriceRange(double minPrice, double maxPrice, DateTime start, DateTime end, List<Reserve> reserves)
        {
            return reserves.Where(o => o.Price >= minPrice && o.Price <= maxPrice && o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public static List<Reserve> FilterByType(DateTime start, DateTime end, List<Reserve> reserves)
        {
            return reserves.Where(o => o.DateTime >= start && o.DateTime <= end).ToList();
        }
        public void AddRating(double  rating)
        {
            this.Rating= rating;    
        }
    }
}
