
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
     
    }
}
