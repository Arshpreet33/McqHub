namespace Domain
{
  public class Category
  {
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
  }
}