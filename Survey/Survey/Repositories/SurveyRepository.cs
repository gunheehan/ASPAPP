using Microsoft.EntityFrameworkCore;
using Survey.Models;

namespace Survey.Repositories;

public class SurveyRepository : ISurveyRepository
{
    private readonly SurveyDbContext dbContext;
    
    public SurveyRepository(SurveyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<SurveyForm>> GetForms()
    {
        var forms = await dbContext.SurveyForms.ToArrayAsync();
        return forms;
    }

    public async Task<SurveyForm?> GetForm(string formKey)
    {
        return await dbContext.SurveyForms
            .Where(a => a.FormKey == formKey)
            .SingleOrDefaultAsync();
    }

    public void CreateForm(SurveyForm formData)
    {
        formData.FormKey = GenerateRandomKey(8);
        dbContext.SurveyForms.Add(formData);
        dbContext.SaveChanges();
    }

    public void DeleteForm(int id)
    { }

    public async Task<IEnumerable<SurveyAnswer>> GetAnswers(string formKey)
    {
        var answers = await dbContext.SurveyAnswers
            .Where(a => a.FormKey == formKey)
            .OrderBy(a => a.UserId)
            .ToListAsync();
        return answers;
    }

    public void AddAnswer(SurveyAnswer answer)
    { }

    public void DeleteAnswer(string title, int id)
    { }
    
    private readonly Random _random = new Random();

    public string GenerateRandomKey(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}