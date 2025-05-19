using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Transactions;
using System.Xml.Serialization;

namespace Dictionaries
{
    public class Add_Dictionary
    {
        private string GetDictionaryPath(string nameDictionary)
        {
            string dictionariesFolder = "Словари";
            Directory.CreateDirectory(dictionariesFolder);
            return Path.Combine(dictionariesFolder, nameDictionary);
        }
        
        public void CreateNewDictionary(string nameDictionary)
        {
            string dictionaryPath = GetDictionaryPath(nameDictionary);

            if (!File.Exists(nameDictionary))
            {
                using (File.Create(dictionaryPath)) { }
                Console.WriteLine($"File {nameDictionary} created");
            }
            else
            {
                Console.WriteLine("File already exists");
            }
        }

        public void AddWordInDictionary(string nameDictionary, int countWords)
        {
            string word, translateWord, yesNo;

            string dictionaryPath = GetDictionaryPath(nameDictionary);

            if (!File.Exists(dictionaryPath))
            {
                Console.WriteLine("Dictionary file doesn't exist. Creating it first.");
                CreateNewDictionary(dictionaryPath);
            }

            for (int i = 0; i < countWords; i++)
            {
                Console.Write("Please enter a word: ");
                word = Console.ReadLine();

                Console.WriteLine("Does the word support multiple translations?");
                Console.Write("Please enter yes or no: ");
                yesNo = Console.ReadLine();

                if (yesNo == "yes")
                {
                    List<string> translations = new List<string>();
                    Console.WriteLine("Enter translations (type 'stop' to finish):");

                    while (true)
                    {
                        Console.Write("Translation: ");
                        string translation = Console.ReadLine();

                        if (translation == "stop")
                            break;

                        translations.Add(translation);
                    }

                    string result = $"{word}-{string.Join(",", translations)}{Environment.NewLine}";
                    File.AppendAllText(dictionaryPath, result);
                }
                else
                {
                    Console.Write("Please enter the translation of the word: ");
                    translateWord = Console.ReadLine();

                    string result = $"{word}-{translateWord}{Environment.NewLine}";
                    File.AppendAllText(dictionaryPath, result);

                }
            }
        }

        public void Replace(string nameDictionary, string wordToReplace)
        {
            string dictionaryPath = GetDictionaryPath(nameDictionary);

            if (!File.Exists(dictionaryPath))
            {
                Console.WriteLine("Dictionary file doesn't exist. Creating it first.");
                CreateNewDictionary(dictionaryPath);
            }
            List<string> allWords = File.ReadAllLines(dictionaryPath).ToList();

            
            for (int i = 0; i < allWords.Count; i++)
            {
                string[] parts = allWords[i].Split('-');

                if (parts.Length >= 1 && parts[0].Equals(wordToReplace))
                {
                    Console.WriteLine("Word is find");

                    Console.Write("Enter new word: ");
                    string newWord = Console.ReadLine();
                    parts[0] = newWord;

                    Console.WriteLine("Does the word support multiple translations?");
                    Console.Write("Please enter yes or no: ");
                    string yesNo = Console.ReadLine();

                    if (yesNo == "yes")
                    {
                        List<string> newTranslations = new List<string>();
                        Console.WriteLine("Enter translations (type 'stop' to finish):");

                        while (true)
                        {
                            Console.Write("Translation: ");
                            string translation = Console.ReadLine();

                            if (translation == "stop")
                                break;

                            newTranslations.Add(translation);
                        }

                        allWords[i] = $"{newWord}-{string.Join(",", newTranslations)}";
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter the translation of the word: ");
                        string newTranslateWord = Console.ReadLine();

                        allWords[i] = $"{newWord}-{string.Join(",", newTranslateWord)}";

                    }
                    File.WriteAllLines(dictionaryPath, allWords);
                    Console.WriteLine("Dictionary updated");
                    return;

                }

            }

            
        }

        public void DeleteTranslate(string nameDictionary, string wordToDelete)
        {
            string dictionaryPath = GetDictionaryPath(nameDictionary);

            if (!File.Exists(dictionaryPath))
            {
                Console.WriteLine("Dictionary file doesn't exist. Creating it first.");
                CreateNewDictionary(dictionaryPath);
            }
            List<string> allWords = File.ReadAllLines(dictionaryPath).ToList();
            
            for (int i = 0; i < allWords.Count; i++)
            {
                string[] parts = allWords[i].Split('-', 2);

                if (parts.Length >= 1 && parts[0].Equals(wordToDelete))
                {
                    Console.WriteLine("Do you want to delete " +
                        "a word and its translations, or just one translation?");
                    Console.Write("all/just one: ");
                    string answer = Console.ReadLine();
                
                    if (answer == "all")
                    {
                        allWords.RemoveAt(i);
                        File.WriteAllLines(dictionaryPath, allWords);
                        Console.WriteLine("The word has been deleted");
                        break;
                    }
                    else if (answer == "just one")
                    {
                        string[] translations = parts[1].Split(',');
                        if (translations.Length <= 1)
                        {
                            Console.WriteLine("Cannot remove the last translation.");
                            return;
                        }
                        Console.Write("Enter number of translation to remove: ");
                        int number = Convert.ToInt32(Console.ReadLine());

                        if (number > 0 && number <= translations.Length)
                        {
                            var update = translations.Where((translation, index) => index != number - 1)
                                .Select(translation => translation);
                            parts[1] = string.Join(",", update);

                            allWords[i] = $"{parts[0]}-{parts[1]}";
                            File.WriteAllLines(dictionaryPath, allWords);
                            Console.WriteLine("The transfer was deleted");
                            break;
                        }
                    }
                }
                
            }
        }

        public void SearchTranslate(string nameDictionary, string word)
        {
            string dictionaryPath = GetDictionaryPath(nameDictionary);

            if (!File.Exists(dictionaryPath))
            {
                Console.WriteLine("Dictionary file doesn't exist. Creating it first.");
                CreateNewDictionary(dictionaryPath);
            }
            List<string> allWords = File.ReadAllLines(dictionaryPath).ToList();

            
            for (int i = 0; i < allWords.Count; i++)
            {
                string[] parts = allWords[i].Split('-');

                if (parts.Length >= 1 && parts[0].Equals(word))
                {
                    string resultLine = $"Your word: {parts[0]} - translate {parts[1]}";
                    Console.WriteLine(resultLine);
                    Console.WriteLine("");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        string resultPath = GetDictionaryPath("result.txt");
                        File.AppendAllText(resultPath, resultLine + Environment.NewLine);
                        Console.WriteLine($"Your translation was saved in {resultPath}");
                       
                    }
                   break;
                    
                }
                
            }
           
        }

        public void PrintAllFile()
        {
            string dirName = "F:\\C#\\Dictionaries\\Dictionaries\\bin\\Debug\\net8.0\\Словари";
            string[] files = Directory.GetFiles(dirName);

            Console.WriteLine("Files in Словари folder:");
            foreach (string file in files) 
            {
                Console.WriteLine(file);
            }


        }
    }
}
