using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.AppContext
{
    public class UserLogin
    {
        [Key]
        [Column(Order = 2)]
        public virtual string LoginProvider { get; set; }

        [Key]
        [Column(Order = 3)]
        public virtual string ProviderKey { get; set; }

        [Key]
        [Column(Order = 1)]
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}