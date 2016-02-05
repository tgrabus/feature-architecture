using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.AppContext
{
    public class Address
    {
        [Key]
        [Column(Order = 1)]
        public virtual int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public virtual int OccupantId { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual string HouseNumber { get; set; }

        public virtual string FlatNumber { get; set; }

        public virtual Person Occupant { get; set; }
    }
}