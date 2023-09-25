using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List
{
    public class ToDoFile
    {
        public string FilePath;
        public ToDoFile(string filePath) {
            try
            {
                FilePath = filePath;
                if (!File.Exists(filePath))
                {
                    StreamWriter writer = new StreamWriter(filePath, false);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered on text file creation : {0}", ex.Message);
                Console.ReadKey();
            }

        }
        public void MainMenu()
        {
            
            bool programFinished = false;
            while(!programFinished)
            {
                ReadTextFile();
                Console.WriteLine("""
                Please enter the number of your choice:
                1. Add a line.
                2. Remove a line.
                3. Exit
                """);
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        WriteToDoLine();
                        break;
                    case "2":
                        DeleteToDoLine();
                        break;
                    case "3":
                        programFinished = true;
                        break;
                    default:
                        Console.Clear();
                        continue;
                }
            }

        }
        public void ReadTextFile()
        {
            try
            {
                string filePath = FilePath;
                Console.WriteLine("Here is your to-do list:\n");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int lineNumber = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("{0}. {1}", lineNumber, line);
                        lineNumber++;
                    }
                }
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered on reading text file: {0}", ex.Message);
                Console.ReadKey();
            }

        }
        public void WriteToDoLine()
        {
            try
            {
                Console.Clear();
                ReadTextFile();
                string filePath = FilePath;
                Console.WriteLine("Please enter the line that you want to add.");
                string newLine = Console.ReadLine();
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(newLine);
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered on writing to text file: {0}", ex.Message);
                Console.ReadKey();
            }
        }

        public void DeleteToDoLine()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    ReadTextFile();
                    var todoLinesList = new List<string>();
                    string filePath = FilePath;

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            todoLinesList.Add(line);
                        }
                    }

                    Console.WriteLine("Please type the line number you want to remove.");
                    var removeNumber = Console.ReadLine();
                    var parseSuccess = int.TryParse(removeNumber, out int removeInt);
                    var intExist = todoLinesList.Count >= removeInt ? true : false;

                    if (parseSuccess && intExist)
                    {

                        removeInt--;
                        todoLinesList.RemoveAt(removeInt);

                        using (StreamWriter writer = new StreamWriter(filePath, false))
                        {
                            foreach (var element in todoLinesList) { writer.WriteLine(element); }
                        }
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNumber does not exist. Press enter to try again.");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered on deleting line: {0}", ex.Message);
                Console.ReadKey();
            }
        }
    }
}
