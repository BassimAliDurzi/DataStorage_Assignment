using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Dtos;


public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; } = null!;

    public int StatusId { get; set; }
    public virtual StatusTypeEntity Status { get; set; } = null!;

    public int UserID { get; set; }
    public virtual UserEntity User { get; set; } = null!;

    public int ProductID { get; set; }
    public virtual ProductEntity Product { get; set; } = null!;
}



