using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("##Summarize Temps##");

            int Temp;
            int NumberTemps = 0;
            int SumTemps = 0;
            int NumberAbove = 0;
            int NumberBelow = 0;
            int Threshold;
            double Avg;
            string Line;
            string FilePath;
            string Input = "";

            // Prompt user for the name of the data file
            Console.WriteLine("Enter file name");
            FilePath = Console.ReadLine();

            // Check that file path exists
            if (File.Exists(FilePath))
            {
                Console.WriteLine("File found");

                // Prompt the user to provide a temperature reading that will be used as the threshold
                Console.WriteLine("Enter Temp threshold");
                Input = Console.ReadLine();
                Threshold = int.Parse(Input);

                // Open data file
                using (StreamReader sr = File.OpenText(FilePath))
                {
                    Line = sr.ReadLine();

                    while (Line != null)
                    {
                        Temp = int.Parse(Line);

                        // Read each line of the data file and count the number of temperature readings that are above (or equal) and the number below the threshold
                        SumTemps += Temp;
                        NumberTemps += 1;

                        // Sum up the number of readings above and below a certain temperature threshold that is provided via Console input
                        if (Temp >= Threshold) 
                        {
                            NumberAbove += 1;
                        }
                        else
                        {
                            NumberBelow += 1;
                        }

                        Line = sr.ReadLine();
                    }
                }
                // Calculate the average temperature in the dataset
                Avg = SumTemps / NumberTemps;

                // Print the results to the Console window
                Console.WriteLine("Tempratures above =" + NumberAbove);
                Console.WriteLine("Tempratures below =" + NumberBelow);
                Console.WriteLine("Average temprature =" + Avg);

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString());
                    sw.WriteLine("Tempratures above =" + NumberAbove);
                    sw.WriteLine("Tempratures below =" + NumberBelow);
                    sw.WriteLine("Average temprature =" + Avg);
                }
            }
            else
                Console.WriteLine("File not found");
        }
    }
}
// Requirements:
// Prompt user for the name of the data file 
// Check that file path exists
// Sum up the number of readings above and below a certain temperature threshold that is provided via Console input
// Prompt the user to provide a temperature reading that will be used as the threshold
// Open the data file
// Read each line of the data file and count the number of temperature readings that are above (or equal) and the number below the threshold
// Calculate the average temperature in the dataset
// Print the results to the Console window
