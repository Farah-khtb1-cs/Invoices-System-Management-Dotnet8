using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace home7.Models
{
    public class InvoiceBinding
    {
        public int Id { get; set; } = 0;
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        public string Service { get; set; } = "";

        [Range(1,9999999, ErrorMessage = "Unit price must be between 1 and 9999999")]
        public decimal UnitPrice { get; set; }
        [Range(1,99)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Client name is required")]
        public string ClientName { get; set; } = "";
        [Required,EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

    }
}
