using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ApProject.Models
{
    enum Gender
    {
        Female,
        Male,
        None
    }
    enum Type
    {
        Golden,
        Silver,
        Bronze,
        None
    }
    internal class Customer : User
    {

        public string FirstName;
        public string LastName;
        public string PhoneNumebr;
        public MailAddress Mail;
        public string PostAddress;
        public Gender Gender;
        public Type Type;
        public List<Complaint> Complaints = new List<Complaint>();
        public List<Order> Orders = new List<Order>();
        public List<Reserve> Reserves = new List<Reserve>();
        public static List<Customer> Customers = new List<Customer>();

        public Customer(string userName, string password,string firstname,string lastname,string phonenumber,MailAddress mail,string postaddress,Gender gender) :base(userName, password)
        {
            
           FirstName =firstname;
           LastName = lastname;
           PhoneNumebr = phonenumber;
           Mail = mail;
           PostAddress = postaddress;
           Gender = gender;
           Type = Type.None;
           Customers.Add(this);
        }

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z]{3,32}$");
        }
        public static bool ValidateMobile(string mobile)
        {
            if(Regex.IsMatch(mobile, @"^09\d{9}$"))
            {
                foreach(var customer in Customers)
                {
                    if (customer.PhoneNumebr == mobile)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool ValidateUsername(string username)
        {
            if(Regex.IsMatch(username, @"^[a-zA-Z0-9]{3,}$"))
            {
                foreach(var user in User.Users)
                {
                    if(user.UserName == username)
                    {
                        return false;
                    }
                }
                return true;
            }

           return false;
        }
        public static bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z]{3,32}@[a-zA-Z]{3,32}\.[a-zA-Z]{2,3}$"))
            {
                try
                {
                    MailAddress mail = new MailAddress(email);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,32}$");
        }
        public void ChangeEmail(string email)
        {
            MailAddress mail = new MailAddress(email);
            this.Mail=mail;
        }
        public void ChangePostAddress(string postAddress)
        {
            this.PostAddress = postAddress; 
        }
        public void UpgradeToSpecialService(Type serviceType)
        {
            this.Type = serviceType;
        }

        public void AddOrder(List<Food> foods,Restaurant restaurant ,PaymentType paymentType)
        {
            foreach(var food in foods)
            {
                food.Count--;
            }

             Order order = new Order(foods,this,restaurant,paymentType);
             this.Orders.Add(order);
             restaurant.Orders.Add(order);
        }
        public bool CanReserve(Restaurant restaurant)
        {
            restaurant.CheckReserveState();
            if (!restaurant.CanReserve) { return false; }

            if (this.Type == Type.None) { return false; }

            var groupedreserve = this.Reserves.GroupBy(r => r.DateTime.Month);
            int count = 0;
            foreach(var group in groupedreserve)
            {
                if (group.Key == DateTime.Now.Month)
                {
                    foreach(var item in group)
                    {
                        if(item.DateTime.Year == DateTime.Now.Year) { count++; }
                    }
                }
            }
            if(this.Type ==Type.Bronze && count>=2) { return false; }
            if(this.Type==Type.Golden && count>=15)  { return false; }
            if(this.Type==Type.Silver && count>=5)  { return false; }
           
            return true;
        }
        public bool AddReserve(Restaurant restaurant,DateTime dateTime)
        {
            double price = 0;
            int min = (dateTime - DateTime.Now).Minutes;

            if(this.Type== Type.Bronze && 0<min && min<=60) { price = 100; }
            if (this.Type == Type.Golden && 0<min && min<=180) { price = 300; }
            if(this.Type == Type.Silver && 0<min && min<=90) { price = 150; }
            if (price != 0)
            {
                Reserve reserve = new Reserve(this, restaurant, price, dateTime);
                this.Reserves.Add(reserve);
                restaurant.Reserves.Add(reserve);
                return true;    
            }
            return false;

        }
        public void CancelReservation(Reserve reserve )
        {
            reserve.Canceled = true;
            int min = (reserve.DateTime - DateTime.Now).Minutes;
             
            if(reserve.Customer.Type==Type.Silver  && min>=30) { reserve.Price = 45; }
            if (reserve.Customer.Type == Type.Bronze && min >= 30) { reserve.Price = 30; }
            if (reserve.Customer.Type == Type.Golden && min >=15) { reserve.Price = 90 ; }

        }
         public void AddComplaint(string title,string description,Restaurant restaurant)
        {
            Complaint complaint = new Complaint(title, description, this, restaurant);
            this.Complaints.Add(complaint);
            restaurant.Complaints.Add(complaint);
        }

    }
}
