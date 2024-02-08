using System;
using BDeshi.Logging;
using UnityEngine;

namespace bdeshi.logging.Samples
{
    [Flags]
    public enum TestLogCategory
    {
        Sunday = 1 << 0, 
        Monday = 1 << 1,
        Tuesday = 1 << 2,
    }
    public class TestLogger:MonoBehaviour
    {
        public CustomLogger<TestLogCategory> Logger = new CustomLogger<TestLogCategory>(
            TestLogCategory.Sunday |
            TestLogCategory.Monday |
            TestLogCategory.Tuesday
            );
        public LogPriority testLogPriority;
        public TestLogCategory testLogCategory;

        private void Awake()
        {
            Logger.DefaultContext = this;
        }

        [ContextMenu("log test")]
        public void logTest()
        {
            Logger.Log(testLogCategory, "TEST", testLogPriority);
        }
    }
}