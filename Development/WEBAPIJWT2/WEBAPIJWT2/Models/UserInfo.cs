namespace WEBAPIJWT2.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Rol { get; internal set; }
    }
}
