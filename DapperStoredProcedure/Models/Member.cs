namespace DapperStoredProcedure.Models
{
    public class Member
    {
        public int Id { get; set; } = new Random().Next();
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
