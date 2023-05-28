using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Domain
{
    public class Customer
    {
        [Key]
        public long Codigo { get; set; }
    }
}