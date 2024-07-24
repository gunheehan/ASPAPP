using System;
using System.Collections.Generic;

namespace Survey.Models;

public partial class SurveyForm
{
    public string FormKey { get; set; } = null!;

    public string? Title { get; set; }

    public string? Questions { get; set; }

    public DateTime? CreateTime { get; set; }

    public string Constructor { get; set; } = null!;
}
