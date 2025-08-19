using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TasksList
    {
        [Required]
        [Display(Name = "Task")]
        public string? Task { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string? Status { get; set; }
    }
}