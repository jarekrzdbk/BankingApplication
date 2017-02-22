using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Entities
{
    public class Transaction 
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [MaxLength(100)]
        public string UserFrom { get; set; }

        [Index]
        [MaxLength(100)]
        public string UserTo { get; set; }

        public DateTime DateTime { get; set; }

        public double Amount { get; set; }

        public string Message { get; set; }
    }
}
