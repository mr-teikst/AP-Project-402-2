using Newtonsoft.Json;
using System.IO;
﻿
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

    try
    {

        if (File.Exists("C:\\c#\\ApProject\\User.txt"))
        {
            string json = File.ReadAllText("C:\\c#\\ApProject\\User.txt");
            User.Users = JsonConvert.DeserializeObject<List<User>>(json);
            if(User.Users == null)
            {
                User.Users = new List<User>();
            }
        }
        if (File.Exists("C:\\c#\\ApProject\\Admin.txt"))
        {
            string json = File.ReadAllText("C:\\c#\\ApProject\\Admin.txt");
            Admin.Admins = JsonConvert.DeserializeObject<List<Admin>>(json);
            if(Admin.Admins == null)
            {
                Admin.Admins= new List<Admin>();
            }
            
        }
        if (File.Exists("C:\\c#\\ApProject\\Customer.txt"))
        {
            string json = File.ReadAllText("C:\\c#\\ApProject\\Customer.txt");
            Customer.Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            if(Customer.Customers == null)
            {
                Customer.Customers= new List<Customer>();
            }
        }
        if (File.Exists("C:\\c#\\ApProject\\Restaurant.txt"))
        {
            string json = File.ReadAllText("C:\\c#\\ApProject\\Restaurant.txt");
            Resturant.Resturants = JsonConvert.DeserializeObject<List<Resturant>>(json);
            if(Resturant.Resturants== null)
            {
                Resturant.Resturants= new List<Resturant>();
            }
        }
        if (File.Exists("C:\\c#\\ApProject\\Complaint.txt"))
        {
            string json = File.ReadAllText("C:\\c#\\ApProject\\Complaint.txt");
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
    try
    {
        string json1 = JsonConvert.SerializeObject(User.Users);
        File.WriteAllText("C:\\c#\\ApProject\\User.txt", json1);

        string json2 = JsonConvert.SerializeObject(Admin.Admins);
        File.WriteAllText("C:\\c#\\ApProject\\Admin.txt", json2);

        string json3 = JsonConvert.SerializeObject(Customer.Customers);
        File.WriteAllText("C:\\c#\\ApProject\\Customer.txt", json3);

        string json4 = JsonConvert.SerializeObject(Resturant.Resturants);
        File.WriteAllText("C:\\c#\\ApProject\\Restaurant.txt", json4);

        string json5 = JsonConvert.SerializeObject(Complaint.Complaints);
        File.WriteAllText("C:\\c#\\ApProject\\Complaint.txt", json5);

        return true;
    }
    catch(Exception ex)
    {
        return false;
    }

}
     
    }
}
