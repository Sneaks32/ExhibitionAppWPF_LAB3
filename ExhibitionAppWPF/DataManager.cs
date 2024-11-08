
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ExhibitionAppWPF
{
	public static class DataManager
	{
		private static string filePath = "exhibits.json";

		public static List<Floor> LoadData()
		{
			if (File.Exists(filePath))
			{
				string json = File.ReadAllText(filePath);
				return JsonConvert.DeserializeObject<List<Floor>>(json);
			}
			return new List<Floor>();
		}

		public static void SaveData(List<Floor> floors)
		{
			string json = JsonConvert.SerializeObject(floors, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}
	}

}
