using BDeshi.Logging;
using UnityEngine;

namespace bdeshi.logging.Samples
{
    public class TestSubLogger:MonoBehaviour, ISubLoggerMixin<TestLogCategory>
    {
        public TestLogCategory Category => TestLogCategory.Tuesday | TestLogCategory.Sunday;
        public CustomLogger<TestLogCategory> Logger => TestLogger.Instance.Logger;

        public void logTest()
        {
            this.LogError("test");
        }
    }
}