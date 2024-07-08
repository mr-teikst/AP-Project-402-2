using Newtonsoft.Json;
using System.IO;
using System;
using System.Net.Mail;


namespace ApProject.Models
{
    public class User
    {
      public string UserName { get; set; }
        public string Password { get; set; }
        public static List<User> Users = new List<User>();
      public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Users.Add(this);
        }

     public static User? Login (string userName, string password)
        {
            foreach (var user in Users)
            {
                if (user.UserName == userName && user.Password==password)
                {
                    return user;
                }
            }
            return null;
        }

    public static bool LoadFromJsonFile()
    {
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new MailAddressConverter());
        try
        {

            if (File.Exists("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\User.txt"))
            {
                string json = File.ReadAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\User.txt");
                User.Users = JsonConvert.DeserializeObject<List<User>>(json);
                if(User.Users == null)
                {
                    User.Users = new List<User>();
                }
            }
            if (File.Exists("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Admin.txt"))
            {
                string json = File.ReadAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Admin.txt");
                Admin.Admins = JsonConvert.DeserializeObject<List<Admin>>(json);
                if(Admin.Admins == null)
                {
                    Admin.Admins= new List<Admin>();
                }
            
            }
            if (File.Exists("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Customer.txt"))
            {
                string json = File.ReadAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Customer.txt");
                Customer.Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                if(Customer.Customers == null)
                {
                    Customer.Customers= new List<Customer>();
                }
            }
            if (File.Exists("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Restaurant.txt"))
            {
                string json = File.ReadAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Restaurant.txt");
                Resturant.Resturants = JsonConvert.DeserializeObject<List<Resturant>>(json);
                if(Resturant.Resturants== null)
                {
                    Resturant.Resturants= new List<Resturant>();
                }
            }
            if (File.Exists("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Complaint.txt"))
            {
                string json = File.ReadAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Complaint.txt");
                Complaint.Complaints = JsonConvert.DeserializeObject<List<Complaint>>(json);
                if(Complaint.Complaints == null)
                {
                    Complaint.Complaints= new List<Complaint>();
                }
            }
            return true;
        }
        catch(Exception ex)
        {
            return false;

        }


    }
    public static bool SaveToJsonFile()
    {

        var settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        settings.Converters.Add(new MailAddressConverter());
        try
        {
            string json1 = JsonConvert.SerializeObject(User.Users, settings);
            File.WriteAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\User.txt", json1);

            string json2 = JsonConvert.SerializeObject(Admin.Admins, settings);
            File.WriteAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Admin.txt", json2);

            string json3 = JsonConvert.SerializeObject(Customer.Customers, settings);
            File.WriteAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Customer.txt", json3);

            string json4 = JsonConvert.SerializeObject(Resturant.Resturants, settings);
            File.WriteAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Restaurant.txt", json4);

            string json5 = JsonConvert.SerializeObject(Complaint.Complaints, settings);
            File.WriteAllText("C:\\Users\\erfan\\OneDrive\\Desktop\\Code\\C# WPF\\git_Final_Project\\Final_Project\\Final_Project\\Models\\Complaint.txt", json5);

            return true;
        }
        catch(Exception ex)
        {
            return false;
        }

        }
     
    }

    public class MailAddressConverter : JsonConverter<MailAddress>
    {
        public override MailAddress? ReadJson(JsonReader reader, System.Type objectType, MailAddress? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var emailAddress = reader.Value as string;
            return emailAddress != null ? new MailAddress(emailAddress) : null;
        }

        public override void WriteJson(JsonWriter writer, MailAddress value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Address);
        }


    }

}
