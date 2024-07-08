using Email404.db;
using Microsoft.EntityFrameworkCore;

namespace Email404;

public static class StudentDataFetcher
{
    public static IQueryable<UserRecordData> GetStudentReportByDuration(this ManageSystemContext context,
        DateTime startTime, DateTime endTime)

    {
        var reports = from reportUser in context.Reports
            where reportUser.SubTime > startTime && reportUser.SubTime < endTime
            select reportUser;
        
        var result = from user in context.Users
            join report in reports on user.UserName equals report.User into reportUsers
            from reportUser in reportUsers.DefaultIfEmpty()
            join recordtime in context.Recordtimes on user.UserId equals recordtime.RecordUser into 
                recordTimeUser
            from time in recordTimeUser.DefaultIfEmpty()
            where !context.UserLeaves.Any(ul => ul.LeaveUser == user.UserId &&
                                                ul.StartTime <= startTime &&
                                                ul.EndTime >= endTime &&
                                                (ul.LeaveAllowed == 1 || ul.LeaveAllowed == 2))
            group new {user,reportUser,time} by user.UserName into grouped
            select new UserRecordData(
                grouped.Key,
                grouped.FirstOrDefault().user.UserGroup,
                grouped.FirstOrDefault().reportUser.ContSummary,
                grouped.FirstOrDefault().reportUser.ContPlan,
                grouped.FirstOrDefault().reportUser.SubTime,
                grouped.FirstOrDefault().time.Time
            );
        Console.WriteLine(result.Distinct().ToQueryString());
        return result.Distinct();
    }

    public static IQueryable<UserRecordData> GetStudentReportToday(this ManageSystemContext context) =>
       context.GetStudentReportByDuration(DateTime.Now-TimeSpan.FromDays(1), DateTime.Now);

    public static void Test()
    {

        var result
            = new ManageSystemContext().GetStudentReportToday();
        
        foreach (var valueTuple in result) Console.WriteLine(valueTuple);
    }
}