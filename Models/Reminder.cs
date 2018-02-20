namespace RestAPI.Models
{
    public class Reminder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }

        //Constructors
        public Reminder()
        {
        }
        public Reminder(string NewName ="Default Name", bool NewIsDone = false)
        {
            this.Name = NewName;
            this.IsDone = NewIsDone;
        }


    }
}