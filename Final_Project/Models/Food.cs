using Final_Project.ViewModels.PagesViewModel;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace ApProject.Models
{
    public enum FoodCategory
    {
        MainCourse,
        Appetizer,
        Dessert,
        Beverage,
        Salad,
        Soup,
        SideDish,
        Snack,
        Breakfast,
        None
    }
    public class Food
    {
        public string Name;
        public string Material;
        public double Price;
        public double Rating;
        public int Count;
        public FoodCategory Category;
        public string Image;
        public Resturant Restaurant;
        public List<Rating> Ratings=new List<Rating>();
        public List<Comment> Comments=new List<Comment>();


        public Food(string name,string material,double price,int count,string image, Resturant restaurant, FoodCategory category = FoodCategory.None)
        {
            Name = name;
            Material = material;
            Price = price;
            Count = count;
            Image = image;
            Category = category;
            Restaurant = restaurant;    
        }
        public static bool ValidatePrice(double price)
        {
            if(price <= 0)
            {
                return false;
            }
            return true;
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void ChangeMaterial(string material)
        {
            Material = material;
        }
        public void ChangePrice(double price)
        {
            Price = price;
        }
        public void ChangeCount(int count)
        {
            Count = count;
        }
        public void ChangeCategory(FoodCategory category)
        {
            Category = category;
        }
        public void ChangeImage(string image)
        {
            Image = image;
        }
        public void CalculateFoodAverageRating()
        {
            Rating = Ratings.Count() > 0 ? Ratings.Average(f => f.Value) : 0;
        }
        public void AddComment(Customer customer,string text)
        {
            this.Comments.Add(new Comment(text, DateTime.Now, customer));
        }
        public void DeleteComment(Comment comment)
        {
            this.Comments.Remove(comment);
        }
        public void EditComment(Comment comment,string newtext)
        {
           foreach(var c in this.Comments)
           {
                if (c == comment)
                {
                    c.Edit(newtext);
                }
           }
        }
        public bool AddRate(Customer customer, double rate)
        {
            bool check = true;
            foreach (var r in Ratings)
            {
                if (r.Customer == customer)
                {
                    check = false;
                }
            }
            if (check)
            {
                this.Ratings.Add(new Rating(rate, customer));
                CalculateFoodAverageRating();
            }
            return check;
        }
        public void DeleteRate(Rating rating)
        {
            this.Ratings.Remove(rating);
        }
        public void EditRate(Rating rating,double newRate)
        {
            foreach(var r in Ratings)
            {
                if(r==rating)
                {
                    r.Edit(newRate);
                }
            }
        }



       
    }
}
