using Domain;
using Newtonsoft.Json.Linq;
using Persistence.JSONStrings.Entertainment;

namespace Persistence
{
  public class LoadJsonData
  {
    private static string[] programming = { "Bash", "CMS", "Code", "DevOps", "Docker", "Linux", "SQL" };
    private static string[] entertainment =
      { "Anime", "BoardGames", "Books", "Cartoons", "Comics", "Films", "Music", "Television", "Theatre", "VideoGames" };
    private static string[] science = { "ComputerScience", "Gadgets", "GeneralScience", "Mathematics" };
    private static string[] miscellaneous =
      { "Animals", "Art", "Celebrities", "GeneralKnowledge", "Geography", "History", "Mythology",
        "Politics", "Sports", "Vehicles" };

    public static async Task<List<Topic>> GetTopics(string category)
    {
      var topics = new List<Topic>();

      foreach (var item in entertainment)
      {
        Topic topic = new Topic
        {
          Title = item,
          IsActive = true,
          Questions = new List<Question>()
        };

        var objects = JArray.Parse(EntertainmentJson.Anime); // parse as array 

        foreach (JObject question in objects)
        {
          if ((string)question["type"] == "multiple")
          {
            var newQuestion = new Question
            {
              Title = (string)question["question"],
              CorrectAnswer = 1,
              IsMultipleAnswers = false
            };

            switch ((string)question["difficulty"])
            {
              case "easy":
                newQuestion.Level = (int)QuestionDifficulty.Easy;
                break;
              case "medium":
                newQuestion.Level = (int)QuestionDifficulty.Medium;
                break;
              case "hard":
                newQuestion.Level = (int)QuestionDifficulty.Hard;
                break;
            }

            newQuestion.Answers = new List<Answer>();
            newQuestion.Answers.Add(new Answer { Number = 1, Title = (string)question["correct_answer"] });
            int index = 2;
            foreach (string answer in question["incorrect_answers"])
            {
              newQuestion.Answers.Add(new Answer { Number = index++, Title = answer });
            }
            topic.Questions.Add(newQuestion);
          }
        }

        topics.Add(topic);
      }

      return topics;
    }

    public static async Task<List<Topic>> GetProgrammingTopic(string category)
    {
      var topics = new List<Topic>();

      foreach (var topic in programming)
      {
        var json = System.IO.File.ReadAllText(@"/Persistence/JSONFiles/" + category + @"/" + topic + ".json");
        var objects = JArray.Parse(json); // parse as array  
        foreach (JObject root in objects)
        {
          foreach (KeyValuePair<String, JToken> app in root)
          {
            var appName = app.Key;
            var description = (String)app.Value["Description"];
            var value = (String)app.Value["Value"];

            Console.WriteLine(appName);
            Console.WriteLine(description);
            Console.WriteLine(value);
            Console.WriteLine("\n");
          }
        }
      }

      return topics;
    }

  }
}