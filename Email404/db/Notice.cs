namespace Email404.db;

public class Notice
{
    /// <summary>
    ///     通知编号
    /// </summary>
    public int NoticeId { get; set; }

    /// <summary>
    ///     会议时间
    /// </summary>
    public string? MeetingTime { get; set; }

    /// <summary>
    ///     提交时间
    /// </summary>
    public DateTime SubTime { get; set; }

    /// <summary>
    ///     注意事项
    /// </summary>
    public string? Cont { get; set; }

    /// <summary>
    ///     通知成员
    /// </summary>
    public string Member { get; set; } = null!;

    /// <summary>
    ///     会议地点
    /// </summary>
    public string? MeetingPlace { get; set; }

    /// <summary>
    ///     0-会议通知，1-请假通知
    /// </summary>
    public bool NoticeType { get; set; }
}