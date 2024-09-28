namespace Philharmonic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? passwordHash { get; set; }
        public int lives { get; set; }
    }
}
