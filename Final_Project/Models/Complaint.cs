namespace ApProject.Models
{
    public class Complaint
    {
        public string Title;
        public string Description;
        public string Answer;
        public Customer Customer;
        public Resturant Restaurant;
        public bool Status;
        public static List<Complaint> Complaints = new List<Complaint>();

         public Complaint(string title,string description,Customer customer,Resturant restaurant)
        {
            Title = title;
            Description = description;
            Customer = customer;
            Restaurant = restaurant;
            Status = false;

            Complaints.Add(this);

        }

        public void RespondAndMarkAsReviewed(string answer)
        {
            this.Answer= answer;
            this.Status = true;
        }
        public static List<Complaint> SearchByUsername( string username)
        {
            return Complaints.Where(c => c.Customer.UserName == username).ToList();
        }
        public static List<Complaint> SearchByTitle( string title)
        {
            return Complaints.Where(c => c.Title == title).ToList();
        }
        public static List<Complaint> SearchByComplainantName( string FirstName,string LastName)
        {
            return Complaints.Where(c => c.Customer.FirstName==FirstName && c.Customer.LastName==LastName).ToList();
        }
        public static List<Complaint> SearchByRestaurantName( string restaurantName)
        {
            return Complaints.Where(c => c.Restaurant.Name == restaurantName).ToList();
        }

        public static List<Complaint> SearchByStatus( bool status)
        {
            return Complaints.Where(c => c.Status == status).ToList();
        }


    }
}
