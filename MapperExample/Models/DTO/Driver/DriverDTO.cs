namespace MapperExample.Models.DTO.Driver
{
    public class DriverDTO
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string DriverNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public int status { get; set; }


    }
}
