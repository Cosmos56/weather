using Microsoft.Extensions.Logging;
using System.Text;

namespace Weather.Infrastructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _path;
        private readonly string _category;
        private static readonly SemaphoreSlim _lock = new(1, 1);

        public FileLogger(string path, string category)
        {
            _path = path;
            _category = category;
        }

        public bool IsEnabled(LogLevel level) => level >= LogLevel.Information;
        public IDisposable? BeginScope<TState>(TState state) => null;

        public void Log<TState>(LogLevel level, EventId id, TState state,
            Exception? ex, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(level)) return;

            var message = $"{DateTime.Now:O} [{level}] {_category}: {formatter(state, ex)}";
            if (ex != null) message += $"\n{ex}";

            _lock.Wait();
            try
            {
                WriteLogAsync(_path, message + "\n");
            }
            finally
            {
                _lock.Release();
            }
        }

        public static void WriteLogAsync(string filePath, string content)
        {
            try
            {
                // 🔹 Создать директорию
                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // 🔹 Записать файл
               File.AppendAllText(filePath, content);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Директория не найдена: {ex.Message}");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода/вывода: {ex.Message}");
                throw;
            }
        }
    }

}
