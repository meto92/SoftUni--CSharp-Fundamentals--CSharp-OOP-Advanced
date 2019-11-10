using System;
using System.Linq;
using System.Reflection;

public class AppenderFactory
{
    private const string AppenderSuffix = nameof(Appender);
    private const string UnknownAppenderExceptionMessage = "Unknown appender type";

    public IAppender CreateAppender(string[] appenderParams, LayoutFactory layoutFactory)
    {
        string type = appenderParams[0];
        string layoutType = appenderParams[1];

        ILayout layout = layoutFactory.CreateLayout(layoutType);

        Type appenderType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass &&
                t.Name.EndsWith(AppenderSuffix) &&
                t.Name == type);

        if (layoutType == null)
        {
            throw new ArgumentNullException(
                nameof(appenderType),
                UnknownAppenderExceptionMessage);
        }

        IAppender appender = Activator.CreateInstance(appenderType, layout) as IAppender;

        if (appenderParams.Length == 3)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(appenderParams[2], true);

            appender.ReportLevel = reportLevel;
        }

        return appender;
    }
}