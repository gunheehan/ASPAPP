using SurveyDB.Entities;

namespace SurveyDB.Repositories;

public class SurveyRepository : ISurveyRepository
{
    public SurveyForm GetForm(int id)
    {
        return null;
    }

    public void CreateForm(SurveyForm formData)
    { }

    public void DeleteForm(int id)
    { }

    public IEnumerable<SurveyAnswer> GetAnswers(string title)
    {
        return null;
    }

    public void AddAnswer(SurveyAnswer answer)
    { }

    public void DeleteAnswer(string title, int id)
    { }
}