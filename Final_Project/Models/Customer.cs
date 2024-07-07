using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace ApProject.Models
{
    public enum Gender
    {
        Female,
        Male,
        None
    }
    public enum Type
    {
        Golden,
        Silver,
        Bronze,
        None
    }
    public class Customer : User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumebr { get; set; }
        public MailAddress Mail { get; set; }
        public string PostAddress { get; set; }
        public Gender Gender { get; set; }
        public Type Type { get; set; }
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
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
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
        public static string GenerateAndSendVerificationCode(string email)
        {
            try
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string verificationCode = new string(Enumerable.Repeat(chars, 6)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                string sender = "ap2817830@gmail.com";
                string pass = "lctjvchiqeichbyc";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sender, pass),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(sender, "System");
                mailMessage.To.Add(email);
                mailMessage.Subject = "**Verification Code**";
                mailMessage.Body = "\n\nYour verification code is  : " + verificationCode;


                smtpClient.Send(mailMessage);
                return verificationCode;
            }

            catch (Exception ex)
            {
                return "-1";
            }
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

        public Order AddOrder(List<Food> foods,Resturant restaurant ,PaymentType paymentType)
        {
            foreach(var food in foods)
            {
                food.Count--;
            }

             Order order = new Order(foods,this,restaurant,paymentType);
             this.Orders.Add(order);
            restaurant.Orders.Add(order);
            return order;
        }

        public static bool SendOrderConfirmationEmail(string email, Order order)
        {
            List<Food> foods = order.Foods;
            try
            {
                string sender = "ap2817830@gmail.com";
                string pass = "lctjvchiqeichbyc";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sender, pass),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(sender, foods[0].Restaurant.Name);
                mailMessage.To.Add(email);
                mailMessage.Subject = "**Order Payment**";

                StringBuilder body = new StringBuilder();
                body.AppendLine("\n\nOrders\n");
                foreach (Food food in foods)
                {
                    body.AppendLine("Name : " + food.Name + "   Price : " + food.Price);
                }
                body.AppendLine();
                body.Append("Total price : " + foods.Sum(f => f.Price));
                body.AppendLine("\n\n");
                body.AppendLine("Your order has been successfully paid and registered.\nThanks for your purchase.");
                mailMessage.Body = body.ToString();

                smtpClient.Send(mailMessage);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool CanReserve(Resturant restaurant)
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
        public bool AddReserve(Resturant restaurant,DateTime dateTime)
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
         public void AddComplaint(string title,string description,Resturant restaurant)
        {
            Complaint complaint = new Complaint(title, description, this, restaurant);
            this.Complaints.Add(complaint);
            restaurant.Complaints.Add(complaint);
        }

    }
}
