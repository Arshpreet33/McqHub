namespace Domain
{
  public class Topic
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public Category Category { get; set; }
    public ICollection<Question> Questions { get; set; }
  }
}