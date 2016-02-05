using System.Collections.Generic;

namespace Models.Entities.AppContext
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}