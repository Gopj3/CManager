using System.ComponentModel.DataAnnotations;

namespace CManagerApplication.Models.Requests.Companies
{
    public class CreateCompanyRequest
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}

