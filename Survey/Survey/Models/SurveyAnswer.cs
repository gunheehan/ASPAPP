using System;
using System.Collections.Generic;

namespace Survey.Models;

public partial class SurveyAnswer
{
    public int Id { get; set; }

    public string? FormKey { get; set; }

    public string? Title { get; set; }

    public string? UserId { get; set; }

    public string? Answers { get; set; }

    public DateOnly? CreateTime { get; set; }
}
