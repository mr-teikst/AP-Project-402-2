namespace ApProject.Models
{
    public class Comment
    {
        public string Text {  get; set; }
        public string Answer { get; set; }
        public bool Edited { get; set; }
        public DateTime DateTime { get; set; }
        public Customer Customer { get; set; }

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
