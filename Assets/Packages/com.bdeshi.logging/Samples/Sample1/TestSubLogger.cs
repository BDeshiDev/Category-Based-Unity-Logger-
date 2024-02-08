using BDeshi.Logging;
using UnityEngine;

namespace bdeshi.logging.Samples
{
    public class TestSubLogger:MonoBehaviour, ISubLoggerMixin<TestLogCategory>
    {
        public TestLogCategory Category => TestLogCategory.Sunday | TestLogCategory.Monday;
        public CustomLogger<TestLogCategory> Logger => TestLogger.Instance.Logger;

        public void TestSubLog()
        {
            this.LogError("SUBLOG");
        }
    }
}