
using SurveyDB.Models;

namespace SurveyDB.Repositories;

public interface ISurveyRepository
{
    SurveyForm GetForm(int id);
    void CreateForm(SurveyForm formData);
    void DeleteForm(int id);

    Task<IEnumerable<SurveyAnswer>> GetAnswers(string formKey);
    void AddAnswer(SurveyAnswer answer);
    void DeleteAnswer(string title, int id);
}