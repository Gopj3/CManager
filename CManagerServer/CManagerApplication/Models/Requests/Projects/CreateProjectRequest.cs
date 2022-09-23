using System.ComponentModel.DataAnnotations;

namespace CManagerApplication.Models.Requests.Projects
{
    public class CreateProjectRequest
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}