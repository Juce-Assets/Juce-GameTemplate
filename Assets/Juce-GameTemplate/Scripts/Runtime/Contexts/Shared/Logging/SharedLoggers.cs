using Juce.Core.Logging;
using Juce.CoreUnity;
using Juce.CoreUnity.Logging;

namespace Template.Contexts.Shared.Logging
{
    public static class SharedLoggers
    {
        public static ILogger BootstrapLogger { get; }
        public static ILogger DebugLogger { get; }
        public static ILogger LoadingScreenLogger { get; }
        public static ILogger ServicesLogger { get; }
        public static ILogger MetaLogger { get; }
        public static ILogger StageLogger { get; }

        static SharedLoggers()
        {
            BootstrapLogger = CreateLogger("Bootstrap");
            DebugLogger = CreateLogger("Debug");
            LoadingScreenLogger = CreateLogger("LoadingScreen");
            ServicesLogger = CreateLogger("Services");
            MetaLogger = CreateLogger("Meta");
            StageLogger = CreateLogger("Stage");
        }

        private static ILogger CreateLogger(string owner)
        {
            if (JuceAppliaction.IsDebug)
            {
                return new Logger(new OwnedUnityLoggerOutput(new LoggerOwner(owner)));
            }

            return NopLogger.Instance;
        }
    }
}
