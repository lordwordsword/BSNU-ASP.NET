public class FileLoggerProvider : ILoggerProvider
{
    string path;
    LogLevel minimumLogLevel;

    public FileLoggerProvider(string path, LogLevel minimumLogLevel)
    {
        this.path = path;
        this.minimumLogLevel = minimumLogLevel;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(path, minimumLogLevel);
    }

    public void Dispose() { }
}