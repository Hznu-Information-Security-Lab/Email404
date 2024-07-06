namespace Email404.db;

public class Record
{
    /// <summary>
    ///     记录编号
    /// </summary>
    public int RecordId { get; set; }

    /// <summary>
    ///     签到时间
    /// </summary>
    public DateTime RecordStart { get; set; }

    /// <summary>
    ///     签退时间
    /// </summary>
    public DateTime? RecordEnd { get; set; }

    /// <summary>
    ///     签到成员id
    /// </summary>
    public string RecordUser { get; set; } = null!;

    public virtual User RecordUserNavigation { get; set; } = null!;
}