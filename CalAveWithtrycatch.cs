using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcAveWithTryCatch
{
    class CalcAveWithTryCatch
    {
        static void Main(string[] args)
        {

            bool moreData = true;
            double average = 0;
            int[] numArray = new int[100]; ;
            int numScores = 0;
            char grade;
            try
            {
                DisplayInfo();
                moreData = GetInput(); 
                while (moreData)
                {
                    numScores = PromptForNums(numArray);
                    average = CalculateAverage(numArray, numScores);
                    grade = GetGrade(average);
                    DisplayResults(numScores, average, grade);
                    moreData = GetInput();
                }

                Console.WriteLine("\n\n\n\n");
            }


            catch (FormatException ex)
            {
                Console.Error.WriteLine(
                    "\n\tError in parameter types.");
                Console.Error.WriteLine(
                    "\n\tException type:\t" + ex.Message + "\n\n\n");
            }

            catch (DivideByZeroException ex)
            {
                Console.Error.WriteLine(
                    "\n\tDenominator within a calculation read as zero.");
                Console.Error.WriteLine(
                    "\n\tException type:\t" + ex.Message + "\n\n\n");
            }

            catch (ArrayTypeMismatchException ex)
            {
                Console.Error.WriteLine(
                    "\n\tWrong type of data in the scores array.");
                Console.Error.WriteLine(
                    "\n\tException type:\t" + ex.Message + "\n\n\n");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Error.WriteLine(
                    "\n\tIndex out of range.");
                Console.Error.WriteLine(
                    "\n\tException type:\t" + ex.Message + "\n\n\n");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(
                    "\n\tValue entered exceeds the range of the\n" +
                    "\tdata type designated to store the input.");
                Console.Error.WriteLine(
                    "\n\tException type:\t" + ex.Message + "\n");
            }
            Console.ReadKey();
        }

        static void DisplayInfo()
        {
            Console.WriteLine(
                "\n***   You can be prompted to input scores 0 - 100.        ***" +
                "\n***   The scores entered will be averaged and a letter    ***" +
                "\n***   grade assigned. The results will then be displayed. ***" +
                "\n***   Enter as many sets of scores as you would like.     ***");
        }

        static bool GetInput()
        {
            char input;
            bool choice;

            Console.Write(
                "\n\nWould you like to enter a set of scores? " +
                "\nPlease enter 'y' for yes or any other letter for no: ");
            input = char.Parse(Console.ReadLine());
             
            switch (input)
            {
                case 'y':
                case 'Y': choice = true;
                    break;
                default: choice = false;
                    break;
            }

            return choice;
        }

        static int PromptForNums(int[] numArray)
        {
            string input;
            int numScores = 0;

            Console.Write("\nPlease enter a score 0 - 100 ." +
                    "\nEnter -99 to STOP entering scores: ");
            input = Console.ReadLine();
            numArray[numScores] = int.Parse(input);

            while (numArray[numScores] != -99)
            {
                numScores++;
                Console.Write("\nPlease enter a score 0 - 100 ." +
                    "\nEnter -99 to STOP entering scores: ");
                input = Console.ReadLine();
                numArray[numScores] = int.Parse(input);
            }


            return numScores;
        }
        public static double CalculateAverage(int[] numArray, int numScores)
        {
            double avg;
            int total = 0;

            for (int i = 0; i < numScores; i++)
            {
                total += numArray[i];
            }
            return (double)total / numScores;
        }

        public static char GetGrade(double average)
        {
            char letter;
            if (average > 89)
            {
                letter = 'A';
            }
            else
                if (average > 79)
                {
                    letter = 'B';
                }
                else
                    if (average > 69)
                    {
                        letter = 'C';
                    }
                    else
                        if (average > 59)
                        {
                            letter = 'D';
                        }
                        else
                        {
                            letter = 'F';
                        }

            return letter;
        }

        static void DisplayResults(int numScores, double average, char grade)
        {
            Console.WriteLine(
                "\n\nThe average of the {0} scores entered is {1}." +
                "\nThe assigned letter grade is '{2}'.\n",
                numScores, average, grade);
        }
    }
}
