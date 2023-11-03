using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Configuration
{
    public sealed class CustomConfigurationStore<T> where T : class, ICloneable, new()
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private string _filePath = "customsettings.json";
        private T? _instance;

        public CustomConfigurationStore()
        {
            _jsonSerializerSettings = new JsonSerializerSettings 
            {
                Formatting = Formatting.Indented
            };
        }

        public CustomConfigurationStore<T> SetJsonFilePath(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _instance = null;
            return this;
        }

        public async Task SaveAsync(T instance) 
        {
            var json = JsonConvert.SerializeObject(instance, _jsonSerializerSettings);
            await File.WriteAllTextAsync(_filePath, json);
            _instance = instance;
        }

        public async Task<T> GetAsync()
        {
            if (_instance != null) return _instance;

            if (!File.Exists(_filePath)) throw new FileNotFoundException(_filePath);

            var json = await File.ReadAllTextAsync(_filePath);

            _instance = JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings) ??
                throw new InvalidOperationException($"Cannot deserialize {_filePath}");

            return _instance;
        }
    }
}
