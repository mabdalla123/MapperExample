namespace MapperExample.Models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string DriverNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public int status { get; set; }

    }
}
