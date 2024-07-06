namespace Email404.db;

public class Award
{
    /// <summary>
    ///     竞赛名称
    /// </summary>
    public string? CompetitionName { get; set; }

    /// <summary>
    ///     作品名称
    /// </summary>
    public string? WorksName { get; set; }

    /// <summary>
    ///     参赛队员
    /// </summary>
    public string? Member { get; set; }

    /// <summary>
    ///     获奖等级
    /// </summary>
    public string? AwardRank { get; set; }

    /// <summary>
    ///     指导老师
    /// </summary>
    public string? Tutor { get; set; }

    /// <summary>
    ///     获奖日期
    /// </summary>
    public DateTime? AwardTime { get; set; }

    /// <summary>
    ///     上传用户
    /// </summary>
    public string? SubUser { get; set; }

    /// <summary>
    ///     上传时间
    /// </summary>
    public DateTime? SubTime { get; set; }

    /// <summary>
    ///     是否删除 0-否；1-是
    /// </summary>
    public byte? IsDel { get; set; }

    /// <summary>
    ///     编号
    /// </summary>
    public int PrizeId { get; set; }
}