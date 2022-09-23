using System;
using System.ComponentModel.DataAnnotations;

namespace CManagerApplication.Models.Requests.Projects
{
    public class AssignUserRequest
    {
        [Required] public Guid UserId { get; set; }

        [Required] public string ProjectRole { get; set; }
    }
}