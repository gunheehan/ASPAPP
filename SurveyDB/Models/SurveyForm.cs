using System;
using System.Collections.Generic;

namespace SurveyDB.Models;

public partial class SurveyForm
{
    public string FormKey { get; set; } = null!;

    public string? Title { get; set; }

    public string? Questions { get; set; }

    public DateOnly? CreateTime { get; set; }
}
