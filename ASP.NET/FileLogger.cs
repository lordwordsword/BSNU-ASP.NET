public class FileLogger : ILogger, IDisposable
{
    string filePath;
    LogLevel minimumLogLevel;
    static object _lock = new object();

    public FileLogger(string path, LogLevel minimumLogLevel)
    {
        filePath = path;
        this.minimumLogLevel = minimumLogLevel;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return this;
    }

    public void Dispose() { }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= minimumLogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        lock (_lock)
        {
            File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
        }
    }
}