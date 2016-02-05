using System.Collections.Generic;

namespace Models.Entities.AppContext
{
    public class Role
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; }
    }
}