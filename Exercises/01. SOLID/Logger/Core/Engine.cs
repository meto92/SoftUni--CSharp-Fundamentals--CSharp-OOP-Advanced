using System.Collections.Generic;

public class Engine
{
    private ILogger logger;
    private IOutputWriter outputWriter;
    private LoggerController loggerController;

    public Engine(ILogger logger, IInputReader inputReader, IOutputWriter outputWriter)
    {
        this.logger = logger;
        this.outputWriter = outputWriter;
        this.loggerController = new LoggerController(inputReader, outputWriter);
    }

    public void Run()
    {
        this.logger.AddAppenders(loggerController.ReadAppenders());
        
        List<Report> reports = loggerController.ReadReports();

        loggerController.ProcessReports(logger, reports);
        loggerController.ReportAppendersStatistics(logger.Appenders);
    }
}