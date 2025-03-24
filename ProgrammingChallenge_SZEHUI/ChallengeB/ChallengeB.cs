public class ChallengeB
{
	private enum Type { None, AlphabeticalString, RealNumber, Integer, Alphanumeric }

	public static void Main()
	{
		// Challenge B
		string inputFile = Path.Combine(GetDirectory(), "RandomObjects.txt");
		string outputFile = Path.Combine(GetDirectory(), "OutputFile.txt");

		// Challenge C
		//string inputFile = "/app/RandomObjects.txt";
		//string outputFile = "/app/OutputFile.txt";

		if (File.Exists(inputFile))
		{
			var streamReader = new StreamReader(inputFile);
			string content = content = streamReader.ReadToEnd();

			// Print to console
			string[] randomObjects = content.Split(',');

			foreach (string rObject in randomObjects)
			{
				Type type = GetRandomObjectType(rObject);
				Console.WriteLine(DisplayRandomObject(type, rObject.Replace(" ", "")));
			}
			
			// Write to output file
			var streamWriter = new StreamWriter(outputFile);
			streamWriter.Write(content);
			streamWriter.Close();
		}
		else
		{
			Console.WriteLine("RandomObjects.txt not found");
		}
	}

	private static string GetDirectory()
	{
		string rootFolder = Environment.CurrentDirectory;
		// Navigate up 4 levels
		if (!string.IsNullOrEmpty(rootFolder))
		{
			for (int i = 0; i < 4; i++)
			{
				rootFolder = Directory.GetParent(rootFolder).FullName;
			}
		}
		return rootFolder;
	}

	private static Type GetRandomObjectType(string content)
	{
		if (int.TryParse(content, out int number))
		{
			return Type.Integer;
		}
		else if (decimal.TryParse(content, out decimal realNumber))
		{
			return Type.RealNumber;
		}
		else if (content.Any(char.IsLetter) && !content.Any(char.IsDigit))
		{
			return Type.AlphabeticalString;
		}
		else if (content.Any(char.IsLetter) && content.Any(char.IsDigit))
		{
			return Type.Alphanumeric;
		}
		return default(Type);
	}

	private static string DisplayRandomObject(Type type, string content)
	{
		switch (type)
		{
			case Type.AlphabeticalString:
				return $"Type : Alphabetical String  \n{content}";
			case Type.RealNumber:
				return $"Type : Real Number \n{content}";
			case Type.Integer:
				return $"Type : Integer \n{content}";
			case Type.Alphanumeric:
				return $"Type : Alphanumeric \n{content}";
			default:
				return string.Empty;
		}
	}
}
