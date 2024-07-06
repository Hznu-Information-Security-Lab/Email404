namespace Email404.db;

public class Totaltime
{
    /// <summary>
    ///     签到成员id
    /// </summary>
    public string RecordUser { get; set; } = null!;

    /// <summary>
    ///     成员姓名
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    ///     所属小组
    /// </summary>
    public string UserGroup { get; set; } = null!;

    public decimal? Time { get; set; }
}