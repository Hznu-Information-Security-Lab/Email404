using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows;
using Email404.configuration;

namespace Email404.Desktop.Services;

public class ConfigurationService
{
    private const string ConfigFileName = "configuration.json";
    
    public static Configuration LoadConfiguration()
    {
        try
        {
            if (File.Exists(ConfigFileName))
            {
                var json = File.ReadAllText(ConfigFileName);
                return JsonSerializer.Deserialize<Configuration>(json) ?? Configuration.Empty;
            }
        }
        catch (Exception ex)
        {
            // TODO: 添加日志记录
            MessageBox.Show($"加载配置文件失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        return Configuration.Empty;
    }
    
    public static void SaveConfiguration(Configuration configuration)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = JsonSerializer.Serialize(configuration, options);
            File.WriteAllText(ConfigFileName, json);
        }
        catch (Exception ex)
        {
            // TODO: 添加日志记录
            MessageBox.Show($"保存配置文件失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
} 