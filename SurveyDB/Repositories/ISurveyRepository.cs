using SurveyDB.Entities;

namespace SurveyDB.Repositories;

public interface ISurveyRepository
{
    SurveyForm GetForm(int id);
    void CreateForm(SurveyForm formData);
    void DeleteForm(int id);

    IEnumerable<SurveyAnswer> GetAnswers(string title);
    void AddAnswer(SurveyAnswer answer);
    void DeleteAnswer(string title, int id);
}