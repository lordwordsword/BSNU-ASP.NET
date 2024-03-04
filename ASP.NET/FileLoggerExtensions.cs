public static class FileLoggerExtensions
{
    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath, LogLevel minimumLogLevel = LogLevel.Trace)
    {
        builder.AddProvider(new FileLoggerProvider(filePath, minimumLogLevel));
        return builder;
    }
}
