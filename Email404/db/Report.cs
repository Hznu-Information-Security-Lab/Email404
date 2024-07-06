namespace Email404.db;

public class Report
{
    public int ReportId { get; set; }

    public string User { get; set; } = null!;

    public string ContSummary { get; set; } = null!;

    public DateTime SubTime { get; set; }

    public string? ContPlan { get; set; }

    public string? Achievement { get; set; }
}