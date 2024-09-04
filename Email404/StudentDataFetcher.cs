using Email404.db;
using Microsoft.EntityFrameworkCore;

namespace Email404;

public static class StudentDataFetcher
{
    public static IQueryable<UserRecordData> GetStudentReportByDuration(this ManageSystemContext context,
        DateTime startTime, DateTime endTime)

    {
        var reports =
            from reportUser in context.Reports
            where reportUser.SubTime > startTime && reportUser.SubTime < endTime
            select reportUser;

        var existUserName = from existUser in context.ExistUsers select existUser.UserId;
        
        var userRecordDuration =
            from record in context.Records
            join user in context.Users on record.RecordUser equals user.UserId
            where EF.Functions.DateDiffHour(record.RecordStart,record.RecordEnd) <= 8 &&
                  existUserName.Any(name => name == record.RecordUser)
                  && record.RecordStart > startTime && record.RecordEnd < endTime
            group new { record, user } by record.RecordUser
            into groups
            select new
            {
                key = groups.Key,
                id = groups.First().record.RecordUser,
                Name = groups.First().user.UserName,
                time = groups.Sum(x =>EF.Functions.DateDiffSecond(x.record.RecordStart,x.record.RecordEnd))
            };
        
        var result =
            from user in context.Users
            join report in reports on user.UserName equals report.User into reportUsers
            from reportUser in reportUsers.DefaultIfEmpty()
            join recordTime in userRecordDuration on user.UserId equals recordTime.id into recordTimeUser
            from time in recordTimeUser.DefaultIfEmpty()
            where !context.UserLeaves.Any(ul => ul.LeaveUser == user.UserId &&
                                                ul.StartTime <= startTime &&
                                                ul.EndTime >= endTime &&
                                                (ul.LeaveAllowed == 1 || ul.LeaveAllowed == 2))
            group new { user, reportUser, time } by user.UserName
            into grouped
            select new UserRecordData(
                grouped.Key,
                grouped.FirstOrDefault().user.UserGroup,
                grouped.FirstOrDefault().reportUser.ContSummary,
                grouped.FirstOrDefault().reportUser.ContPlan,
                grouped.FirstOrDefault().reportUser.SubTime,
                grouped.FirstOrDefault().time.time
            );

        return result;
    }


    public static IQueryable<UserRecordData> GetStudentReportToday(this ManageSystemContext context)
    {
        return context.GetStudentReportByDuration(DateTime.Today, DateTime.Today.AddDays(1));
    }
    
    public static IQueryable<UserRecordData> GetStudentReportThisWeek(this ManageSystemContext context)
    {
        return context.GetStudentReportByDuration(
            DateTime.Today - TimeSpan.FromDays(DateTime.Today.DayOfWeek - DayOfWeek.Sunday), DateTime.Today);
    }


    public static void Test()
    {
        Console.WriteLine(DateTime.Today);
        var context = new ManageSystemContext();
        var result = context.GetStudentReportThisWeek();
        foreach (var valueTuple in result) Console.WriteLine(valueTuple);
    }
}