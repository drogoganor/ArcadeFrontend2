using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArcadeFrontend2.Data
{
	public class ConfigurationService
	{
		private static readonly Configuration sampleConfiguration = new Configuration
		{
			Systems = new System[]
			{
				new System
				{
					Path = "mame/mame64.exe",
					Games = new Game[]
                    {
						new Game
                        {
							Name = "1941",
							RomName = "1941.zip",
						}
                    }
                }
            }
		};

        public void WriteSampleConfiguration()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(sampleConfiguration, options);
            var fullPath = Path.Combine(AppContext.BaseDirectory, "config.json");

            try
            {
                using (var streamWriter = new StreamWriter(fullPath))
                {
                    streamWriter.Write(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't write sample configuration file.", ex);
                throw;
            }
        }

        //public Task<Configuration[]> GetForecastAsync(DateTime startDate)
        //{
        //	return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Configuration
        //	{
        //		Date = startDate.AddDays(index),
        //		TemperatureC = Random.Shared.Next(-20, 55),
        //		Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //	}).ToArray());
        //}
    }
}
