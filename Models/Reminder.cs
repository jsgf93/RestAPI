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
            this.Name = "Default Reminder";
            this.IsDone = true;
        }
        public Reminder(string Name ="Default Name", bool IsDone = false)
        {
            this.Name = Name;
            this.IsDone = IsDone;
        }


    }
}