namespace Email404.db;

public class User
{
    /// <summary>
    ///     成员账号
    /// </summary>
    public string UserId { get; set; } = null!;

    /// <summary>
    ///     密码
    /// </summary>
    public string UserPwd { get; set; } = null!;

    /// <summary>
    ///     成员姓名
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    ///     0-男，1-女
    /// </summary>
    public bool UserSex { get; set; }

    /// <summary>
    ///     电话
    /// </summary>
    public string? UserPhone { get; set; }

    /// <summary>
    ///     所属年级
    /// </summary>
    public string UserGrade { get; set; } = null!;

    /// <summary>
    ///     邮箱
    /// </summary>
    public string? UserEmail { get; set; }

    /// <summary>
    ///     所属小组
    /// </summary>
    public string UserGroup { get; set; } = null!;

    /// <summary>
    ///     1-管理员，0-用户
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    ///     1-使用，0-不使用
    /// </summary>
    public bool? UserIsusing { get; set; }

    /// <summary>
    ///     学号
    /// </summary>
    public string UserNum { get; set; } = null!;

    /// <summary>
    ///     班级
    /// </summary>
    public string UserClass { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual Thegroup UserGroupNavigation { get; set; } = null!;

    public virtual ICollection<UserLeave> UserLeaves { get; set; } = new List<UserLeave>();
}