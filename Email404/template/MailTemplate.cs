namespace Email404.template;

public static class MailTemplate
{
    public const string MailTitleTemplate = """
                                            <h1>{title}</h1>
                                            <hr/>
                                            """;

    public const string MailContentTemplateDaily = """
                                                    <h2>{userName}</h2>
                                                    <h5>本日签到时长:{time}h</h5>
                                                    <h5>本日总结:{today}</h5>
                                                    <h5>明日计划:{tomorrow}</h5>
                                                    <br>
                                                   """;
}