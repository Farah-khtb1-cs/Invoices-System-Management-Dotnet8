using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace home7.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public string Number { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }


        public string Service { get; set; } = "";
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


        public string ClientName { get; set;} = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";


    }
}
