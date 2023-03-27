namespace Domain
{
  public class Question
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string? Explanation { get; set; }
    public int Level { get; set; }
    public bool IsMultipleAnswers { get; set; }
    public Topic Topic { get; set; }
    public int CorrectAnswer { get; set; }
    public ICollection<Answer> Answers { get; set; }
  }
}