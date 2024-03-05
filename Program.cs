using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, char[]> inputDictionary = new Dictionary<string, char[]>
        {
            {"1", new char[] {'A', 'd'}},
            {"2", new char[] {'C', 'B'}}
        };

        string result = GenerateCombinations(inputDictionary);
        Console.WriteLine("Результат:");
        Console.WriteLine(result);

        File.WriteAllText("result.json", result);
        Console.WriteLine("Результат збережено у файл result.json");
    }

    static string GenerateCombinations(Dictionary<string, char[]> inputDictionary)
    {
        List<string> combinations = new List<string>();
        GenerateCombinationsHelper(inputDictionary, 0, "", combinations);

        return string.Join(" ", combinations);
    }

    static void GenerateCombinationsHelper(Dictionary<string, char[]> inputDictionary, int index, string currentCombination, List<string> combinations)
    {
        if (index == inputDictionary.Count)
        {
            combinations.Add(currentCombination);
            return;
        }

        var key = inputDictionary.Keys.ToArray()[index];
        foreach (char letter in inputDictionary[key])
        {
            GenerateCombinationsHelper(inputDictionary, index + 1, currentCombination + letter, combinations);
        }
    }
}





