namespace Email404;

public record UserRecordData(string UserName,string? UserGroup,string? ContSummary,string? ContPlan, DateTime? SubTime, decimal? Time)

{
    public string UserName { get; set; } = UserName;
    public string? ContSummary { get; set; } = ContSummary;
    public string? UserGroup { get; set; } = UserGroup;
    public string? ContPlan { get; set; } = ContPlan;
    public DateTime? SubTime { get; set; } = SubTime;
    public decimal? Time { get; set; } = Time;

    public decimal? Hours => Time / 3600;
    
}