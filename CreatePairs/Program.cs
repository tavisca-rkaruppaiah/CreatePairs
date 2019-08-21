using System;
using System.Collections.Generic;

namespace CreatePairs
{
    
    class CreatePairs
    {
        public int MaximalSum(int[] data)
        {
            int sum = 0, _index = 0, _sizeOfArray = data.Length, resultNegative = 0, resultPositive=0;
            Array.Sort(data);
            
            List<int> _positiveNumbers = new List<int>();
            List<int> _negativeNumbers = new List<int>();
            if (_sizeOfArray == 0)
                Console.WriteLine("Enter valid Input");
            else if(_sizeOfArray == 1)
            {
                return data[0];
            }
            else
            {
                for (int i = 0; i < _sizeOfArray; i++)
                {
                    if (IsNegativeNumber(data[i]) || data[i] == 0)
                        _negativeNumbers.Add(data[i]);
                    else
                        _positiveNumbers.Add(data[i]);
                }

                _index = _positiveNumbers.Count - 1;
                _positiveNumbers.Sort();
                _positiveNumbers.Reverse();
                resultPositive= PerformPairInList(_positiveNumbers, 'p');
                _negativeNumbers.Sort();
               resultNegative = PerformPairInList(_negativeNumbers,'n');
            }
            if(resultPositive == 0)
            {
                if (IsNegativeNumber(sum))
                    return sum * -1;
            }
           
            return sum=resultPositive + resultNegative;
        }

        public bool IsNegativeNumber(int number)
        {
            return number < 0;
        }

       

        public int PerformPairInList(List<int> numbers, char signature)
        {
            int _product = 0, _index = numbers.Count, k = 0 ;
            
            for(int j=0; j<_index; j=j+2)
            {
               try
                {
                    if(signature == 'p')
                    {
                        if (numbers[j + 1] != 1 && numbers[j] !=1)
                        {
                            _product += numbers[j + 1] * numbers[j];
                        }
                        else
                        {
                            _product += numbers[j + 1] + numbers[j];
                        }
                    }
                    else
                    {
                        _product += numbers[j + 1] * numbers[j];
                    }
                }
                catch(Exception e)
                {
                    _product += numbers[j];
                }

               
            }

            
            return _product;
        }

       

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CreatePairs createPairs = new CreatePairs();
            do
            {
                int[] data = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(createPairs.MaximalSum(data));
                input = Console.ReadLine();
            } while (input != "*");
        }
        #endregion
    }
}
