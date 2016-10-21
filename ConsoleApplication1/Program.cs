using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        private static string inputfile = @"C:\test\source.txt"; // source file name and path
        private static string outputfile = @"C:\test\" + Path.GetFileNameWithoutExtension(inputfile) + "graded.txt"; // output file name and path 

        private class score
        {
            public string FirstName { get; set; }
            public string LasttName { get; set; }
            public string Score { get; set; }


        }

        static void Main()
        {
            try

            {
                List<score> inputtextstring = getinputfilestring();
                List<score> orderedScores = sortextfilenew(inputtextstring);
                createoutputfile(orderedScores);
                Console.WriteLine("Finished: created " + outputfile);

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
        private static List<score> getinputfilestring()
        {
           //This function reads data from the input text file. 
           //its validates the blank line
           //Assumtion is taht the source file contains  first name , last name and score in same order and seperated by comma .`           1`
            StreamReader sr = new StreamReader(inputfile);
            String line = null;
            List<score> lstscore= new List<score>();
            while ((line = sr.ReadLine()) != null)
            {
           
                if (line.Trim() != ""  ) // validate intput file 
                {
                    string[] strLine = line.Split(',');
                    score objscore = new score();
                    objscore.LasttName = strLine[0];
                    objscore.FirstName = strLine[1];
                    objscore.Score = strLine[2];
                  
                    lstscore.Add(objscore);
                }
            }
            return lstscore;
           
        }


        private static List<score> sortextfilenew(List<score> scores)
        {
            //This function Orders the names by their score. 
            //If scores are the same, order by their last name followed by first name 

            var orderedScores = scores.OrderByDescending(x => int.Parse(x.Score)) // order by score first
               .ThenBy(x => (x.LasttName)) // order by last name
                 .ThenBy(x => (x.FirstName)//order by first name
                ).ToList();

            return orderedScores;
        }
       
        private static void createoutputfile(List<score> orderedScores)
        {  // create or overwrite an output text file 
          
            FileStream fs1 = new FileStream(outputfile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);

            foreach (score score in orderedScores)
            { // Wrtie to output file
                string writeoutputline = (score.FirstName + "," + score.LasttName + "," + score.Score);
                writer.WriteLine(writeoutputline);

            }
            writer.Close();
        }
       
    }
   
}
