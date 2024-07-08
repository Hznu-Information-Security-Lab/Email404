using Microsoft.EntityFrameworkCore;

namespace Email404.db;

public partial class ManageSystemContext : DbContext
{
    public ManageSystemContext(
        string serverIp = "192.168.5.11",
        string user = "pub_root",
        string passsword = "123456",
        string dataBaseName = "manage_system")
    {
        ServerIp = serverIp;
        User = user;
        Passsword = passsword;
        DataBaseName = dataBaseName;
    }

    public ManageSystemContext(DbContextOptions<ManageSystemContext> options,
        string serverIp = "192.168.5.11",
        string user = "pub_root",
        string passsword = "123456",
        string dataBaseName = "manage_system"
    )
        : base(options)
    {
        ServerIp = serverIp;
        User = user;
        Passsword = passsword;
        DataBaseName = dataBaseName;
    }

    private string ServerIp { get; }
    private string User { get; }
    private string Passsword { get; }
    private string DataBaseName { get; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Coursetime> Coursetimes { get; set; }

    public virtual DbSet<ExistUser> ExistUsers { get; set; }

    public virtual DbSet<Grouptime> Grouptimes { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Recordtime> Recordtimes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Thegroup> Thegroups { get; set; }

    public virtual DbSet<Totaltime> Totaltimes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLeave> UserLeaves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.5.11;user=pub_root;password=123456;database=manage_system",
            ServerVersion.Parse("5.7.19-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("achievement");

            entity.Property(e => e.Id)
                .HasColumnType("int(255)")
                .HasColumnName("id");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.SubmitTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("提交时间")
                .HasColumnType("timestamp")
                .HasColumnName("submit_time");
        });

        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.PrizeId).HasName("PRIMARY");

            entity.ToTable("award");

            entity.Property(e => e.PrizeId)
                .HasComment("编号")
                .HasColumnType("int(255)")
                .HasColumnName("prize_id");
            entity.Property(e => e.AwardRank)
                .HasMaxLength(255)
                .HasComment("获奖等级")
                .HasColumnName("award_rank");
            entity.Property(e => e.AwardTime)
                .HasComment("获奖日期")
                .HasColumnType("datetime")
                .HasColumnName("award_time");
            entity.Property(e => e.CompetitionName)
                .HasMaxLength(255)
                .HasComment("竞赛名称")
                .HasColumnName("competition_name");
            entity.Property(e => e.IsDel)
                .HasDefaultValueSql("'0'")
                .HasComment("是否删除 0-否；1-是")
                .HasColumnType("tinyint(1) unsigned zerofill")
                .HasColumnName("is_del");
            entity.Property(e => e.Member)
                .HasMaxLength(255)
                .HasComment("参赛队员")
                .HasColumnName("member");
            entity.Property(e => e.SubTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("上传时间")
                .HasColumnType("timestamp")
                .HasColumnName("sub_time");
            entity.Property(e => e.SubUser)
                .HasMaxLength(255)
                .HasComment("上传用户")
                .HasColumnName("sub_user");
            entity.Property(e => e.Tutor)
                .HasMaxLength(255)
                .HasComment("指导老师")
                .HasColumnName("tutor");
            entity.Property(e => e.WorksName)
                .HasMaxLength(255)
                .HasComment("作品名称")
                .HasColumnName("works_name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.Date, "date");

            entity.HasIndex(e => e.UserId, "id");

            entity.Property(e => e.CourseId)
                .HasColumnType("int(255)")
                .HasColumnName("course_id");
            entity.Property(e => e.CourseEighth)
                .HasMaxLength(20)
                .HasColumnName("course_eighth");
            entity.Property(e => e.CourseEleventh)
                .HasMaxLength(20)
                .HasColumnName("course_eleventh");
            entity.Property(e => e.CourseFifth)
                .HasMaxLength(20)
                .HasColumnName("course_fifth");
            entity.Property(e => e.CourseFirst)
                .HasMaxLength(20)
                .HasColumnName("course_first");
            entity.Property(e => e.CourseFourth)
                .HasMaxLength(20)
                .HasColumnName("course_fourth");
            entity.Property(e => e.CourseNinth)
                .HasMaxLength(20)
                .HasColumnName("course_ninth");
            entity.Property(e => e.CourseSecond)
                .HasMaxLength(20)
                .HasColumnName("course_second");
            entity.Property(e => e.CourseSeventh)
                .HasMaxLength(20)
                .HasColumnName("course_seventh");
            entity.Property(e => e.CourseSixth)
                .HasMaxLength(20)
                .HasColumnName("course_sixth");
            entity.Property(e => e.CourseTenth)
                .HasMaxLength(20)
                .HasColumnName("course_tenth");
            entity.Property(e => e.CourseThird)
                .HasMaxLength(20)
                .HasColumnName("course_third");
            entity.Property(e => e.CourseTwelfth)
                .HasMaxLength(20)
                .HasColumnName("course_twelfth");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasComment("学年/学期")
                .HasColumnName("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("用户")
                .HasColumnName("user_id");
            entity.Property(e => e.Week)
                .HasComment("星期")
                .HasColumnType("int(10)")
                .HasColumnName("week");

            entity.HasOne(d => d.User).WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id");
        });

        modelBuilder.Entity<Coursetime>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PRIMARY");

            entity.ToTable("coursetime");

            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .HasColumnName("duration");
            entity.Property(e => e.EighthStart)
                .HasColumnType("time")
                .HasColumnName("eighth_start");
            entity.Property(e => e.EleventhStart)
                .HasColumnType("time")
                .HasColumnName("eleventh_start");
            entity.Property(e => e.FifthStart)
                .HasColumnType("time")
                .HasColumnName("fifth_start");
            entity.Property(e => e.FirstStart)
                .HasColumnType("time")
                .HasColumnName("first_start");
            entity.Property(e => e.FourthStart)
                .HasColumnType("time")
                .HasColumnName("fourth_start");
            entity.Property(e => e.NinthStart)
                .HasColumnType("time")
                .HasColumnName("ninth_start");
            entity.Property(e => e.SecondStart)
                .HasColumnType("time")
                .HasColumnName("second_start");
            entity.Property(e => e.SeventhStart)
                .HasColumnType("time")
                .HasColumnName("seventh_start");
            entity.Property(e => e.SixthStart)
                .HasColumnType("time")
                .HasColumnName("sixth_start");
            entity.Property(e => e.TenthStart)
                .HasColumnType("time")
                .HasColumnName("tenth_start");
            entity.Property(e => e.ThirdStart)
                .HasColumnType("time")
                .HasColumnName("third_start");
            entity.Property(e => e.TwelfthStart)
                .HasColumnType("time")
                .HasColumnName("twelfth_start");
        });

        modelBuilder.Entity<ExistUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("exist_users");

            entity.Property(e => e.IsAdmin)
                .HasComment("1-管理员，0-用户")
                .HasColumnName("is_admin");
            entity.Property(e => e.UserClass)
                .HasMaxLength(255)
                .HasComment("班级")
                .HasColumnName("user_class");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(45)
                .HasComment("邮箱")
                .HasColumnName("user_email");
            entity.Property(e => e.UserGrade)
                .HasMaxLength(45)
                .HasComment("所属年级")
                .HasColumnName("user_grade");
            entity.Property(e => e.UserGroup)
                .HasMaxLength(45)
                .HasComment("所属小组")
                .HasColumnName("user_group");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("成员账号")
                .HasColumnName("user_id");
            entity.Property(e => e.UserIsusing)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1-使用，0-不使用")
                .HasColumnName("user_isusing");
            entity.Property(e => e.UserName)
                .HasMaxLength(8)
                .HasComment("成员姓名")
                .HasColumnName("user_name");
            entity.Property(e => e.UserNum)
                .HasMaxLength(25)
                .HasComment("学号")
                .HasColumnName("user_num");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(45)
                .HasComment("电话")
                .HasColumnName("user_phone");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(45)
                .HasComment("密码")
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserSex)
                .HasComment("0-男，1-女")
                .HasColumnName("user_sex");
        });

        modelBuilder.Entity<Grouptime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("grouptime");

            entity.Property(e => e.Time)
                .HasPrecision(46, 4)
                .HasColumnName("time");
            entity.Property(e => e.UserGroup)
                .HasMaxLength(45)
                .HasComment("所属小组")
                .HasColumnName("user_group");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.NoticeId).HasName("PRIMARY");

            entity.ToTable("notice");

            entity.Property(e => e.NoticeId)
                .HasComment("通知编号")
                .HasColumnType("int(255)")
                .HasColumnName("notice_id");
            entity.Property(e => e.Cont)
                .HasComment("注意事项")
                .HasColumnType("text")
                .HasColumnName("cont");
            entity.Property(e => e.MeetingPlace)
                .HasMaxLength(255)
                .HasComment("会议地点")
                .HasColumnName("meeting_place");
            entity.Property(e => e.MeetingTime)
                .HasMaxLength(255)
                .HasComment("会议时间")
                .HasColumnName("meeting_time");
            entity.Property(e => e.Member)
                .HasMaxLength(50)
                .HasComment("通知成员")
                .HasColumnName("member");
            entity.Property(e => e.NoticeType)
                .HasComment("0-会议通知，1-请假通知")
                .HasColumnName("notice_type");
            entity.Property(e => e.SubTime)
                .HasComment("提交时间")
                .HasColumnType("datetime")
                .HasColumnName("sub_time");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PRIMARY");

            entity.ToTable("record");

            entity.HasIndex(e => e.RecordUser, "recode_user");

            entity.Property(e => e.RecordId)
                .HasComment("记录编号")
                .HasColumnType("int(255)")
                .HasColumnName("record_id");
            entity.Property(e => e.RecordEnd)
                .HasComment("签退时间")
                .HasColumnType("timestamp")
                .HasColumnName("record_end");
            entity.Property(e => e.RecordStart)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("签到时间")
                .HasColumnType("timestamp")
                .HasColumnName("record_start");
            entity.Property(e => e.RecordUser)
                .HasMaxLength(20)
                .HasComment("签到成员id")
                .HasColumnName("record_user");

            entity.HasOne(d => d.RecordUserNavigation).WithMany(p => p.Records)
                .HasForeignKey(d => d.RecordUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recode_user");
        });

        modelBuilder.Entity<Recordtime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("recordtime");

            entity.Property(e => e.RecordUser)
                .HasMaxLength(20)
                .HasComment("签到成员id")
                .HasColumnName("record_user");
            entity.Property(e => e.Time)
                .HasPrecision(42)
                .HasColumnName("time");
            entity.Property(e => e.UserName)
                .HasMaxLength(8)
                .HasComment("成员姓名")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PRIMARY");

            entity.ToTable("report");

            entity.HasIndex(e => e.User, "user");

            entity.Property(e => e.ReportId)
                .HasColumnType("int(255)")
                .HasColumnName("report_id");
            entity.Property(e => e.Achievement)
                .HasMaxLength(255)
                .HasColumnName("achievement");
            entity.Property(e => e.ContPlan)
                .HasColumnType("text")
                .HasColumnName("cont_plan");
            entity.Property(e => e.ContSummary)
                .HasColumnType("text")
                .HasColumnName("cont_summary");
            entity.Property(e => e.SubTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("sub_time");
            entity.Property(e => e.User)
                .HasMaxLength(20)
                .HasColumnName("user");
        });

        modelBuilder.Entity<Thegroup>(entity =>
        {
            entity.HasKey(e => e.GroupName).HasName("PRIMARY");

            entity.ToTable("thegroup");

            entity.Property(e => e.GroupName)
                .HasComment("组名")
                .HasColumnName("group_name");
            entity.Property(e => e.GroupLeader)
                .HasMaxLength(20)
                .HasComment("组长名字")
                .HasColumnName("group_leader");
        });

        modelBuilder.Entity<Totaltime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("totaltime");

            entity.Property(e => e.RecordUser)
                .HasMaxLength(20)
                .HasComment("签到成员id")
                .HasColumnName("record_user");
            entity.Property(e => e.Time)
                .HasPrecision(10, 1)
                .HasColumnName("time");
            entity.Property(e => e.UserGroup)
                .HasMaxLength(45)
                .HasComment("所属小组")
                .HasColumnName("user_group");
            entity.Property(e => e.UserName)
                .HasMaxLength(8)
                .HasComment("成员姓名")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserGroup, "group");

            entity.HasIndex(e => e.UserName, "user_name");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("成员账号")
                .HasColumnName("user_id");
            entity.Property(e => e.IsAdmin)
                .HasComment("1-管理员，0-用户")
                .HasColumnName("is_admin");
            entity.Property(e => e.UserClass)
                .HasMaxLength(255)
                .HasComment("班级")
                .HasColumnName("user_class");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(45)
                .HasComment("邮箱")
                .HasColumnName("user_email");
            entity.Property(e => e.UserGrade)
                .HasMaxLength(45)
                .HasComment("所属年级")
                .HasColumnName("user_grade");
            entity.Property(e => e.UserGroup)
                .HasMaxLength(45)
                .HasComment("所属小组")
                .HasColumnName("user_group");
            entity.Property(e => e.UserIsusing)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1-使用，0-不使用")
                .HasColumnName("user_isusing");
            entity.Property(e => e.UserName)
                .HasMaxLength(8)
                .HasComment("成员姓名")
                .HasColumnName("user_name");
            entity.Property(e => e.UserNum)
                .HasMaxLength(25)
                .HasComment("学号")
                .HasColumnName("user_num");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(45)
                .HasComment("电话")
                .HasColumnName("user_phone");
            entity.Property(e => e.UserPwd)
                .HasMaxLength(45)
                .HasComment("密码")
                .HasColumnName("user_pwd");
            entity.Property(e => e.UserSex)
                .HasComment("0-男，1-女")
                .HasColumnName("user_sex");

            entity.HasOne(d => d.UserGroupNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("theGroup");
        });

        modelBuilder.Entity<UserLeave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PRIMARY");

            entity.ToTable("user_leave");

            entity.HasIndex(e => e.LeaveUser, "user_id");

            entity.Property(e => e.LeaveId)
                .HasComment("请假记录编号")
                .HasColumnType("int(255)")
                .HasColumnName("leave_id");
            entity.Property(e => e.EndTime)
                .HasComment("请假结束时间")
                .HasColumnType("timestamp")
                .HasColumnName("end_time");
            entity.Property(e => e.LeaveAllowed)
                .IsRequired()
                .HasDefaultValueSql("'2'")
                .HasComment("0-不批准，1-批准，2-待审核")
                .HasColumnName("leave_allowed");
            entity.Property(e => e.LeaveUser)
                .HasMaxLength(20)
                .HasComment("请假成员")
                .HasColumnName("leave_user");
            entity.Property(e => e.Reason)
                .HasComment("请假原因")
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.Remarks)
                .HasComment("拒绝原因")
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.StartTime)
                .HasComment("请假开始时间")
                .HasColumnType("timestamp")
                .HasColumnName("start_time");
            entity.Property(e => e.SubmitTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("提交时间")
                .HasColumnType("timestamp")
                .HasColumnName("submit_time");

            entity.HasOne(d => d.LeaveUserNavigation).WithMany(p => p.UserLeaves)
                .HasForeignKey(d => d.LeaveUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}