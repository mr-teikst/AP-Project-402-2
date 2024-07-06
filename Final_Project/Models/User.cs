
namespace ApProject.Models
{
    internal class User
    {
      public string UserName;
      public string Password;
      public static List<User> Users = new List<User>();
      public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Users.Add(this);
        }

     public static bool Login (string userName, string password)
        {
            foreach (var user in Users)
            {
                if (user.UserName == userName && user.Password==password)
                {
                    return true;
                }
            }
            return false;
        }
     
    }
}
