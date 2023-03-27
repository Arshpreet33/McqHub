namespace Domain
{
  public class Answer
  {
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public Question Question { get; set; }
  }
}