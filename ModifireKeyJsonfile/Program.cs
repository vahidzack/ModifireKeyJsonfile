using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using ModifireKeyJsonfile.Models;

namespace ModifireKeyJsonfile
{
    class Program
    {
        static void Main()
        {
            #region TakeJSonFile
            string jsonFilePath = "C:\\Users\\parviz\\source\\repos\\ModifireKeyJsonfile\\modifiers.json";
            Console.WriteLine($"JSON File Path: {jsonFilePath}");

            List<ModifierInfo> modifierInfos;

            using (StreamReader reader = new StreamReader(jsonFilePath))
            {
                string json = reader.ReadToEnd();
                modifierInfos = JsonConvert.DeserializeObject<List<ModifierInfo>>(json);
            }
            #endregion
            #region GetKeyForSearchAndShowInfoWithRandomColor
            Random random = new Random();

            while (true)
            {
                Console.Write("Enter the modifier key to search (or type 'exit' to quit): ");
                string userInput = Console.ReadLine();

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break; // Exit the loop if the user types 'exit'
                }

                bool found = false;

                foreach (var modifierInfo in modifierInfos)
                {
                    if (modifierInfo.Name.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        // Generate random console text color
                        ConsoleColor randomColor = (ConsoleColor)random.Next(1, 16);

                        Console.ForegroundColor = randomColor; // Set the text color
                        Console.WriteLine($"Modifier Name: {modifierInfo.Name}");

                        Console.ForegroundColor = randomColor;
                        Console.WriteLine($"Description: {modifierInfo.Description}");

                        Console.ResetColor(); // Reset the text color to the default
                        Console.WriteLine(); // Add an empty line for separation

                        found = true;
                        break; // Exit the loop once the key is found
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Modifier key '{userInput}' not found.");
                }


            }
            #endregion
        }
    }
}