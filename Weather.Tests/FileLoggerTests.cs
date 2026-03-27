using Microsoft.Extensions.Logging;
using Weather.Infrastructure.Logging;
using Xunit;

namespace Weather.Tests
{
    public class FileLoggerTests()
    {
        [Fact]
        public async Task Log_ConcurrentWrites_NoDataLoss()
        {
            var tempFile = Path.GetTempFileName();
            var logger = new FileLogger(tempFile, "Test");
            var messages = Enumerable.Range(0, 100)
                .Select(i => $"Message {i}")
                .ToList();

            // Act: 10 потоков пишут одновременно
            var tasks = messages.Select(msg =>
                Task.Run(() => logger.LogInformation(msg)));

            await Task.WhenAll(tasks);

            // Assert: все сообщения записаны
            var content = await File.ReadAllTextAsync(tempFile);
            foreach (var msg in messages)
            {
                Assert.Contains(msg, content);
            }

            File.Delete(tempFile);
        }
    }
}
