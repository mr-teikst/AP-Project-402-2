namespace ApProject.Models
{
    public class Comment
    {
        public string Text;
        public string Answer;
        public bool Edited;
        public DateTime DateTime;
        public Customer Customer;

        public Comment(string text, DateTime dateTime, Customer customer)
        {
            Text = text;
            Edited =false;
            DateTime = dateTime;
            Customer = customer;
        }

        public void Respond(string answer)
        {
            Answer = answer;
        }
        public void Edit(string newtext)
        {
            Edited = true;
            Text = newtext;
        }
    }
}
