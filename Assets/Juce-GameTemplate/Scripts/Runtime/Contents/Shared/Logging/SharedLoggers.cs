using Juce.Core.Logging;
using Juce.CoreUnity.Logging;

namespace Template.Contents.Shared.Logging
{
    public static class SharedLoggers
    {
        public static ILogger BootstrapLogger { get; }
        public static ILogger MetaLogger { get; }
        public static ILogger StageLogger { get; }

        static SharedLoggers()
        {
            BootstrapLogger = CreateLogger("Bootstrap");
            MetaLogger = CreateLogger("Meta");
            StageLogger = CreateLogger("Stage");
        }

        private static ILogger CreateLogger(string owner)
        {
            if (UnityEngine.Application.isEditor || UnityEngine.Debug.isDebugBuild)
            {
                return new Logger(new OwnedUnityLoggerOutput(new LoggerOwner(owner)));
            }

            return NopLogger.Instance;
        }
    }
}
