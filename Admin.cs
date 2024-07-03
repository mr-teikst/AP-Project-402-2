namespace ApProject.Models
{

    internal class Admin :User
    {
        public static List<Admin> Admins = new List<Admin>();

        public Admin(string userName, string password) : base(userName, password)
        {
            Admins.Add(this);
        }
    }
}
