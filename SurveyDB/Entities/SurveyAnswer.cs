namespace SurveyDB.Entities;

public class SurveyAnswer
{
    public int Id { get; set; }
    public int RootId { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }
    public Dictionary<string, object> Answer { get; set; }
    public DateTime Date { get; set; }
}