using System.Text;

public class ChallengeA
{
	private static Random random = new Random();
	
	static void Main()
	{
		string rootFolder = Environment.CurrentDirectory;
		// Navigate up 4 levels
		if(!string.IsNullOrEmpty(rootFolder))
		{
			for (int i = 0; i < 4; i++)
			{
				rootFolder = Directory.GetParent(rootFolder).FullName;
			}
		}
		
		string filePath = Path.Combine(rootFolder, "RandomObjects.txt");
		// 1KB = 1024 bytes (in binary)
		long maxFileSize = 10 * 1024 * 1024;
		long currentFileSize = 0;

		using (StreamWriter streamWriter = new StreamWriter(filePath))
		{
			while (currentFileSize < maxFileSize)
			{

				string randomAlphabeticalString = GenerateAlphabeticalString(10);
				string randomRealNumber = GenerateRealNumber();
				string randomInteger = GenerateInteger();
				string randomAlphanumeric = GenerateAlphanumeric(20);

				string content = $"{randomAlphabeticalString},{randomRealNumber},{randomInteger},{randomAlphanumeric},";
				streamWriter.Write(content);
				currentFileSize += Encoding.UTF8.GetByteCount(content);
			}

			Console.WriteLine("The file 'RandomObjects.txt' has been generated with a size of 10MB.");
		}
	}

	private static string GetAlphabets()
	{
		string alphabets = string.Empty;

		// Uppercase letters
		for (int u = 'A'; u <= 'Z'; u++)
		{
			alphabets = alphabets + ((char)u);
		}

		// Lowercase letters
		alphabets += alphabets.ToLower();
		return alphabets;
	}

	private static string GetNumbers()
	{
		string numbers = string.Empty;
		for (int n = 0; n <= 9; n++)
		{
			numbers += n.ToString();
		}
		return numbers;
	}

	private static string GenerateAlphabeticalString(int length)
	{
		string alphabets = GetAlphabets();
		string randomAlphabeticalString = string.Empty;
		for (int i = 0; i < length; i++)
		{
			randomAlphabeticalString += alphabets[random.Next(alphabets.Length)];
		}
		return randomAlphabeticalString;
	}

	private static string GenerateRealNumber()
	{
		return random.NextDouble().ToString();
	}

	private static string GenerateInteger()
	{
		return random.NextInt64(0, 9999).ToString();
	}

	private static string GenerateAlphanumeric(int length)
	{
		string alphaNumerics = GetAlphabets() + GetNumbers();
		string randomAlphaNumeric = string.Empty;
		for (int i = 0; i < length; i++)
		{
			randomAlphaNumeric += alphaNumerics[random.Next(alphaNumerics.Length)];
		}

		int numberOfSpacesBefore = random.Next(0, 9);
		int numberOfSpacesAfter = 10 - numberOfSpacesBefore;
		return new string(' ', numberOfSpacesBefore) + randomAlphaNumeric + new string(' ', numberOfSpacesAfter);
	}
}
