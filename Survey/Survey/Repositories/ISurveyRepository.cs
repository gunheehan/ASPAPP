using Survey.Models;

namespace Survey.Repositories;

public interface ISurveyRepository
{
    Task<IEnumerable<SurveyForm>> GetForms();
    Task<SurveyForm?> GetForm(string formKey);
    void CreateForm(SurveyForm formData);
    void UpdateForm(SurveyForm updateData);
    void DeleteForm(int id);

    Task<IEnumerable<SurveyAnswer>> GetAnswers(string formKey);
    void AddAnswer(SurveyAnswer answer);
    void DeleteAnswer(string title, int id);
}