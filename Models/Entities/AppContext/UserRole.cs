namespace Models.Entities.AppContext
{
    public class UserRole
    {
        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}