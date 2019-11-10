using System.Collections.Generic;

public class LoggerController
{
    private const string AppenderParamsSeparator = " ";
    private const string ReportParamsSeparator = "|";
    private const string EndCommand = "END";
    private const string ReportStatisticsHeader = "Logger info";

    private IInputReader inputReader;
    private IOutputWriter outputWriter;
    private AppenderFactory appenderFactory;
    private LayoutFactory layoutFactory;
    private ReportFactory reportFactory;

    public LoggerController(IInputReader inputReader, IOutputWriter outputWriter)
    {
        this.inputReader = inputReader;
        this.outputWriter = outputWriter;
        this.appenderFactory = new AppenderFactory();
        this.layoutFactory = new LayoutFactory();
        this.reportFactory = new ReportFactory();
    }

    public IAppender[] ReadAppenders()
    {
        int appendersCount = int.Parse(this.inputReader.ReadLine());

        IAppender[] appenders = new IAppender[appendersCount];

        for (int i = 0; i < appendersCount; i++)
        {
            string[] appenderParams = this.inputReader
                .ReadLine()
                .Split(AppenderParamsSeparator);

            IAppender appender = this.appenderFactory.CreateAppender(
                appenderParams,
                this.layoutFactory);

            appenders[i] = appender;
        }

        return appenders;
    }

    public List<Report> ReadReports()
    {
        List<Report> reports = new List<Report>();

        string input = null;

        while ((input = this.inputReader.ReadLine()) != EndCommand)
        {
            string[] reportParams = input.Split(ReportParamsSeparator);

            string reportType = reportParams[0];
            string dateAndTime = reportParams[1];
            string message = reportParams[2];

            Report report = this.reportFactory.CreateReport(
                reportType,
                dateAndTime,
                message);

            reports.Add(report);
        }

        return reports;
    }

    public void ProcessReports(ILogger logger, IList<Report> reports)
    {
        foreach (Report report in reports)
        {
            switch (report.ReportLevel)
            {
                case ReportLevel.Info:
                    logger.Info(report.DateAndTime, report.Message);
                    break;
                case ReportLevel.Warning:
                    logger.Warn(report.DateAndTime, report.Message);
                    break;
                case ReportLevel.Error:
                    logger.Error(report.DateAndTime, report.Message);
                    break;
                case ReportLevel.Critical:
                    logger.Critical(report.DateAndTime, report.Message);
                    break;
                case ReportLevel.Fatal:
                    logger.Fatal(report.DateAndTime, report.Message);
                    break;
            }
        }
    }

    public void ReportAppendersStatistics(IList<IAppender> appenders)
    {
        this.outputWriter.WriteLine(ReportStatisticsHeader);
        
        foreach (IAppender appender in appenders)
        {
            this.outputWriter.WriteLine(appender.ToString());
        }
    }
}