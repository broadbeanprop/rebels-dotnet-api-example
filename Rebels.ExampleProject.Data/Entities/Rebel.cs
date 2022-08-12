using System.ComponentModel.DataAnnotations;

namespace Rebels.ExampleProject.Data.Entities;

public class Rebel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the name of the Rebel.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
}