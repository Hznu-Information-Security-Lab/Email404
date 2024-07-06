namespace Email404.db;

public class Achievement
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public string Name { get; set; } = null!;

    /// <summary>
    ///     提交时间
    /// </summary>
    public DateTime SubmitTime { get; set; }
}