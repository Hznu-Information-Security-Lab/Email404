namespace Email404.db;

public class Course
{
    public int CourseId { get; set; }

    /// <summary>
    ///     用户
    /// </summary>
    public string UserId { get; set; } = null!;

    public string? CourseFirst { get; set; }

    public string? CourseSecond { get; set; }

    public string? CourseThird { get; set; }

    public string? CourseFourth { get; set; }

    public string? CourseFifth { get; set; }

    public string? CourseSixth { get; set; }

    public string? CourseSeventh { get; set; }

    public string? CourseEighth { get; set; }

    public string? CourseNinth { get; set; }

    public string? CourseTenth { get; set; }

    public string? CourseEleventh { get; set; }

    public string? CourseTwelfth { get; set; }

    /// <summary>
    ///     学年/学期
    /// </summary>
    public string Date { get; set; } = null!;

    /// <summary>
    ///     星期
    /// </summary>
    public int? Week { get; set; }

    public virtual User User { get; set; } = null!;
}