namespace Survey.Models;

public class SurveyInfo
{
    public class Answer
    {
        public string title;
        public AnswerDetail[] detail;
        public string user;
        public DateTime createTime;
    }

    public class AnswerDetail
    {
        public string question;
        public string userAnswer;
    }
    
    public class SurveyCategoryTotal
    {
        public string title { get; set; }
        public Dictionary<string, int> answer { get; set; } = new();
    }

    public enum SurveyType
    {
        Subjective,
        MultipleChoice
    }
[Serializable]
    public class QuestionData
    {
        public string question;
        public SurveyType type;
        public string[] choiceArr;
    }
}