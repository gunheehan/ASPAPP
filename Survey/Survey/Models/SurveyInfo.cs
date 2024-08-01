namespace Survey.Models;

public class SurveyInfo
{
    public class Answer
    {
        public string title;
        public AnswerDetail detail;
        public string user;
        public DateTime createTime;
    }

    public class AnswerDetail
    {
        public string[] userAnswer;
    }
    
    public class SurveyCategoryTotal
    {
        public string title { get; set; }
        public Dictionary<string, int> answer { get; set; } = new();
    }
}