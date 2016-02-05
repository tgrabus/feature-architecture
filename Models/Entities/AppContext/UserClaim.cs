namespace Models.Entities.AppContext
{
    public class UserClaim
    {
        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }

        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}