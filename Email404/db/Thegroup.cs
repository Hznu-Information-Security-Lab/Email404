namespace Email404.db;

public class Thegroup
{
    /// <summary>
    ///     组名
    /// </summary>
    public string GroupName { get; set; } = null!;

    /// <summary>
    ///     组长名字
    /// </summary>
    public string? GroupLeader { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}