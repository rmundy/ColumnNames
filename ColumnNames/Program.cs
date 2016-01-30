namespace ColumnNames
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public sealed class Program
    {
        public static void Main(String[] args)
        {
            using (var reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (null == line)
                    {
                    }
                    else
                    {
                        var count = Convert.ToInt64(line);
                        var upperBound = 26;
                        Int32 answerCounter;

                        var twoDimensionalArray = new String[26, 26];
                        var threeDimensionalArray = new String[26, 26, 26];

                        while (upperBound < count)
                        {
                            upperBound *= 26;
                        }

                        if (upperBound == 26)
                        {
                            var arr = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
                            Console.WriteLine(arr[count-1]);
                        }

                        if (upperBound == 26 * 26)
                        {
                            var outerCounter = 0;
                            var innerCounter = 0;
                            answerCounter = 26;
                            for (var letter = 'A'; letter <= 'Z'; letter++)
                            {
                                for (var letter2 = 'A'; letter2 <= 'Z'; letter2++)
                                {
                                    answerCounter++;
                                    twoDimensionalArray[outerCounter,innerCounter] = 
                                        new StringBuilder().Append(letter).Append(letter2).ToString();
                                    
                                    if (answerCounter == count)
                                    {
                                        Console.WriteLine(twoDimensionalArray[outerCounter, innerCounter]);
                                    }

                                    innerCounter++;
                                }

                                outerCounter++;
                                innerCounter = 0;
                            }
                        }
                        else if (upperBound == 26*26*26)
                        {
                            var outerCounter = 0;
                            var middleCounter = 0;
                            var innerCounter = 0;
                            answerCounter = 26*26+26;
                            for (var letter = 'A'; letter <= 'Z'; letter++)
                            {
                                for (var letter2 = 'A'; letter2 <= 'Z'; letter2++)
                                {
                                    for (var letter3 = 'A'; letter3 <= 'Z'; letter3++)
                                    {
                                        answerCounter++;
                                        threeDimensionalArray[outerCounter, middleCounter,innerCounter] =
                                            new StringBuilder().Append(letter).Append(letter2).Append(letter3).ToString();

                                        if (answerCounter == count)
                                        {
                                            Console.WriteLine(threeDimensionalArray[outerCounter, middleCounter, innerCounter]);
                                        }

                                        innerCounter++;
                                    }

                                    middleCounter++;
                                    innerCounter = 0;
                                }

                               
                                outerCounter++;
                                middleCounter = 0;
                            }
                        }
                    }
                }
            } 
        }
    }
}
