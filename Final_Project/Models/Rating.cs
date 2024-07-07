namespace ApProject.Models
{
    public class Rating
    {
        public double Value;
        public Customer Customer;

        public Rating (double value, Customer customer)
        {
            Value = value;
            Customer = customer;
        }
        public void Edit(double newValue)
        {
            Value = newValue;
        }
    }
}
