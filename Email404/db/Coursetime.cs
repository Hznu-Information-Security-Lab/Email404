namespace Email404.db;

public class Coursetime
{
    public string Date { get; set; } = null!;

    public TimeOnly? FirstStart { get; set; }

    public TimeOnly? SecondStart { get; set; }

    public TimeOnly? ThirdStart { get; set; }

    public TimeOnly? FourthStart { get; set; }

    public TimeOnly? FifthStart { get; set; }

    public TimeOnly? SixthStart { get; set; }

    public TimeOnly? SeventhStart { get; set; }

    public TimeOnly? EighthStart { get; set; }

    public TimeOnly? NinthStart { get; set; }

    public TimeOnly? TenthStart { get; set; }

    public TimeOnly? EleventhStart { get; set; }

    public TimeOnly? TwelfthStart { get; set; }

    public string? Duration { get; set; }
}