using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_DAL.Entities
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10), MinLength(10)]
        public string WalletNo { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

     
        public virtual Customer Customer { get; set; }
    }

}
