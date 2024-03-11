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
        public SerializableCategoryLogger<TestLogCategory> Logger = new SerializableCategoryLogger<TestLogCategory>(
            TestLogCategory.Sunday |
            TestLogCategory.Monday |
            TestLogCategory.Tuesday
            );
        public LogPriority testLogPriority;
        public TestLogCategory testLogCategory;

        public static TestLogger Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Logger.DefaultContext = this;
        }

        [ContextMenu("log test")]
        public void logTest()
        {
            Logger.LogError(testLogCategory, "TEST", testLogPriority);
        }
    }
}