namespace Email404.db;

public class UserLeave
{
    /// <summary>
    ///     请假记录编号
    /// </summary>
    public int LeaveId { get; set; }

    /// <summary>
    ///     请假成员
    /// </summary>
    public string LeaveUser { get; set; } = null!;

    /// <summary>
    ///     提交时间
    /// </summary>
    public DateTime SubmitTime { get; set; }

    /// <summary>
    ///     请假开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    ///     请假结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    ///     0-不批准，1-批准，2-待审核
    /// </summary>
    public int? LeaveAllowed { get; set; }

    /// <summary>
    ///     请假原因
    /// </summary>
    public string Reason { get; set; } = null!;

    /// <summary>
    ///     拒绝原因
    /// </summary>
    public string? Remarks { get; set; }

    public virtual User LeaveUserNavigation { get; set; } = null!;
}