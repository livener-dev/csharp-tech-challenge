using csharp_tech_challenge.Classes;
using csharp_tech_challenge.Controllers;
using Microsoft.Extensions.Configuration;

namespace APITests
{
    [TestClass]
    public sealed class Tests
    {
        /* Tests */

        /* Log directory setting not set */
        /* File doesn't exist */
        /* File is empty */
        /* File has unknown event type */
        /* File has bad date */
        /* Stream ID is missing in event entry */

        /* There are more tests that could be written, for example, if the log file is locked, but these are just to give you an idea of approach */

        [TestMethod]
        public void LogDirectoryIsNotSet()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            IConfigurationRoot configuration = builder.Build();

            try
            {
                LogFile logFile = new LogFile(APIController.LOG_FILENAME, configuration);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Setting not set in appsettings: PathToLogs");
            }
        }

        

        [TestMethod]
        public void FileDoesNotExist()
        {
            IConfiguration configuration = CreateValidConfiguration();

            try
            {
                LogFile logFile = new LogFile("filedoesnotexist.txt", configuration);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Log file does not exist");
            }
        }

        [TestMethod]
        public void FileIsEmpty()
        {
            IConfiguration configuration = CreateValidConfiguration();

            LogFile logFile = new LogFile("empty.log", configuration);
            var logEntries = logFile.Parse();
            Assert.IsTrue(logEntries.Count == 0);
        }

        [TestMethod]
        public void FileHasUnknownEventType()
        {
            IConfiguration configuration = CreateValidConfiguration();

            LogFile logFile = new LogFile("invalideventtype.log", configuration);
            var logEntries = logFile.Parse();

            Assert.IsTrue(logEntries.Count == 999); // 1 invalid log entry which would be skipped
        }

        [TestMethod]
        public void FileHasInvalidDateEntry()
        {
            IConfiguration configuration = CreateValidConfiguration();

            LogFile logFile = new LogFile("invaliddate.log", configuration);
            var logEntries = logFile.Parse();

            Assert.IsTrue(logEntries.Count == 999); // 1 invalid log entry which would be skipped
        }

        [TestMethod]
        public void FileHasMissingStreamId()
        {
            IConfiguration configuration = CreateValidConfiguration();

            LogFile logFile = new LogFile("missingstreamid.log", configuration);
            var logEntries = logFile.Parse();

            Assert.IsTrue(logEntries.Count == 999); // 1 invalid log entry which would be skipped
        }

        private IConfiguration CreateValidConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            return builder.Build();
        }

    }
}
