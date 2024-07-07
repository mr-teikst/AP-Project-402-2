using CsvHelper;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ApProject.Models
{
    public class Resturant : User
    {
        public string Name;
        public string City;
        public string Address;
        public double Rating;
        public bool CanReserve;
        public List<Complaint > Complaints=new List<Complaint>();
        public List<Food> Foods=new List<Food>();
        public List<Order> Orders=new List<Order>();
        public List<Reserve> Reserves = new List<Reserve>();
        public static List<Resturant > Resturants = new List<Resturant>();
        public static Resturant r1 = new Resturant("res1", "pass1", "res1", "tehran", "tehran markaz");
        public static Resturant r2 = new Resturant("res2", "pass2", "res2", "tehran", "tehran markaz");
        public Resturant(string userName, string password,string name,string city,string address) : base(userName, password)
        {
            Name = name;
            City = city;
            Address = address;
            CanReserve = false;
            Resturants.Add(this);
        }
        
        public static bool ValidateUsername(string username)
        {
            if (Regex.IsMatch(username, @"^[a-zA-Z0-9]{3,}$"))
            {
                foreach (var user in User.Users)
                {
                    if (user.UserName == username)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }
       public static string GenerateRandomPassword()
        {
            Random random = new Random();
            string password = "";

            for (int i = 0; i < 8; i++)
            {
                int randomNumber = random.Next(0, 10);
                password += randomNumber.ToString();
            }

            return password; 
        }
        public bool ChangePassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,32}$"))
            {
                this.Password = password;
                return true;
            }
            return false;
        }
        public static List<Resturant> SearchByCity( string city)
        {
            return Resturants.Where(r => r.City == city).ToList();
        }
        public static List<Resturant> SearchByCity(string city, List<Resturant> Resturants)
        {
            return Resturants.Where(r => r.City == city).ToList();
        }

        public  static List<Resturant> SearchByRestaurantName( string restaurantName)
        {
            return Resturants.Where(r => r.Name == restaurantName).ToList();
        }
        public static List<Resturant> SearchByRestaurantName(string restaurantName, List<Resturant> Resturants)
        {
            return Resturants.Where(r => r.Name == restaurantName).ToList();
        }

        public static List<Resturant> SearchByMinimumRating( double minimumRating)
        {
            foreach (var r in Resturants)
            {
                r.CalculateRestaurantAverageRating();
            }

            return Resturants.Where(r => r.Rating >= minimumRating).ToList();
        }
        public static List<Resturant> SearchByMinimumRating(double minimumRating, List<Resturant> Resturants)
        {
            foreach (var r in Resturants)
            {
                r.CalculateRestaurantAverageRating();
            }

            return Resturants.Where(r => r.Rating >= minimumRating).ToList();
        }

        public static List<Resturant> SearchByStatusComplaints(bool status)
        {
            return Resturants.Where(r => r.Complaints.Any(c => c.Status == status)).ToList();
        }

        public static List<Resturant> SearchByDine_in(bool status)
        {
            foreach(var r in Resturants)
            {
                r.CheckReserveState();
            }

            return Resturants.Where(r=>r.CanReserve== status).ToList();
        }
        public static List<Resturant> SearchByDine_in(bool status, List<Resturant> Resturants)
        {
            foreach (var r in Resturants)
            {
                r.CheckReserveState();
            }

            return Resturants.Where(r => r.CanReserve == status).ToList();
        }
        public void AddFood(string name,string material,double price,string image,int count,FoodCategory category = FoodCategory.None)
        {
            Food food = new Food(name,material,price,count,image, this, category);
            this.Foods.Add(food);
        }
        public void RemoveFood(Food food)
        {
            this.Foods.Remove(food);
        }
        public void UpdateFoodName(Food food,string name)
        {
            food.ChangeName(name);
        }
        public void UpdateFoodMaterial(Food food, string material)
        {
            food.ChangeMaterial(material);
        }
        public void UpdateFoodPrice(Food food, double price)
        {
            food.ChangePrice(price);
        }
        public void UpdateFoodImage(Food food, string image)
        {
            food.ChangeImage(image);
        }
        public void UpdateFoodCategory(Food food, FoodCategory category )
        {
            food.ChangeCategory(category);
        }
        public void UpdateFoodCount(Food food, int count)
        {
            food.ChangeCount(count);
        }
        public void ReplyToComment(Comment comment ,string answer)
        {
            comment.Respond(answer);

        }
        
        public void CheckReserveState()
        {
            double OrderRate = this.Orders.Average(o => o.Rating);
            double ReserveRate=this.Reserves.Average(o => o.Rating);
            double Rate = (OrderRate + ReserveRate) / 2;
            if(Rate >= 4.5)
            {
                CanReserve = true;  
            }
            else
            {
                CanReserve = false;
            }
        }
        public void ChangeReserveState()
        {
            CanReserve=false;
        }

       public static void CreateCSVfile(List<Order> orders,List<Reserve> reserves)
        {
            double totalSales=orders.Sum(o=>o.Price)+reserves.Sum(r=>r.Price);
            double onlinePaymentPercentage =(orders.Where(o=>o.PaymentType==PaymentType.Online).Count()/orders.Count)*100;
            int totalOrdersCount=orders.Count();
            int totalReservesCount=reserves.Count();    
            int cancelledReservationsCount=reserves.Where(r=>r.Canceled==true).Count();
            int notPresentReservationsCount=reserves.Where(r=>r.notPresent==true).Count();  
            double totalCancellationPenaltyIncome=reserves.Where(r=>r.Price==30 ||  r.Price==45 ||  r.Price==90).Sum(o=>o.Price);

            string fileName = "filtered_restaurant_report";
            string csvFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName + ".csv");

            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                csv.WriteField("TotalSales");
                csv.WriteField("OnlinePaymentPercentage");
                csv.WriteField("TotalOrdersCount");
                csv.WriteField("TotalReservesCount");
                csv.WriteField("notPresentReservationsCount");
                csv.WriteField("CancelledReservationsCount");
                csv.WriteField("TotalCancellationPenaltyIncome");
                csv.NextRecord();
                csv.WriteRecord(totalSales);
                csv.WriteRecord(onlinePaymentPercentage);
                csv.WriteRecord(totalOrdersCount);
                csv.WriteRecord(totalReservesCount);
                csv.WriteRecord(notPresentReservationsCount);
                csv.WriteRecord(cancelledReservationsCount);
                csv.WriteRecord(totalCancellationPenaltyIncome);
                csv.NextRecord();

            }
        }
        public void CalculateRestaurantAverageRating()
        {
            foreach(var f in Foods)
            {
                f.CalculateFoodAverageRating(); 
            }
            double foodsrate = Foods.Average(f => f.Rating);
            double orderrate = Orders.Average(o => o.Rating);
            double reserverate=Reserves.Average(o => o.Rating);
            this.Rating = (foodsrate + orderrate + reserverate) / 3;
        }




    }
}
