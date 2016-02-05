using System;
using System.Collections.Generic;

namespace Models.Entities.AppContext
{
    public class User
    {
        public virtual int AccessFailedCount { get; set; }

        public virtual ICollection<UserClaim> Claims { get; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual int Id { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual DateTime? LockoutEndDateUtc { get; set; }

        public virtual ICollection<UserLogin> Logins { get; }

        public virtual string PasswordHash { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual ICollection<Role> Roles { get; }

        public virtual string SecurityStamp { get; set; }

        public virtual bool TwoFactorEnabled { get; set; }

        public virtual string UserName { get; set; }
    }
}