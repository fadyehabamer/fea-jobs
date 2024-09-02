using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        // ------
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Category name cannot be more than 100 characters.")]
        [Required(ErrorMessage = "Please enter category name")]
        public string Name { get; set; }
        // ------
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The description cannot be more than 256 characters.")]
        public string? Description { get; set; }
        // ------
        [Required]
        public string Slug { get; set; }
        // ------
        public bool? Disable { get; set; }
        // ------
        // Navigation properties

        // 1 Category has many JobPosts
        public ICollection<Skill>? Skills { get; set; }
        // ------

        // 1 Category has many Titles
        public ICollection<Title>? Titles { get; set; }
        // ------

        // 1 Category has many Provinces
        public ICollection<Province>? Provinces { get; set; }
        // ------

        // 1 Category has many AppUsers
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}