namespace SurveyDB.Entities;

public class SurveyForm
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Dictionary<string, object> detail { get; set; }
    public DateTime Date { get; set; }
}