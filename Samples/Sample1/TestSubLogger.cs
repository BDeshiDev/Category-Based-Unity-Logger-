using BDeshi.Logging;
using UnityEngine;

namespace bdeshi.logging.Samples
{
    public class TestSubLogger:MonoBehaviour, ISubCategoryLoggerMixin<TestLogCategory>
    {
        public TestLogCategory Category => TestLogCategory.Tuesday | TestLogCategory.Sunday;
        public ICategoryLogger<TestLogCategory> Logger => TestLogger.Instance.Logger;

        public void logTest()
        {
            this.LogError("test");
        }
    }
}