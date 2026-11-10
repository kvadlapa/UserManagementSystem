using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementSystem.Models
{
    public class User
    {
        // [Key] represents Primary key
        // Guid type represents Global Unique Identifier
        // get; set; represents property with getter and setter
        // Default value is assigned using Guid.NewGuid() method
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // [Required] indicates that the property is mandatory
        // [MaxLength] sets the maximum length for string properties
        // Sort of validation attributes, also called Data Annotations
        // Default value is assigned to avoid null reference issues(string.Empty)
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        // NotMapped indicates that this property is not mapped to a database column
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;


        // Store hashed password only
        // In real applications, consider using secure password storage mechanisms
        // such as hashing with salt
        // PasswordHash property to store the hashed password
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Touch method to update the UpdatedAt timestamp
        public void Touch() => UpdatedAt = DateTime.UtcNow;
    }
}