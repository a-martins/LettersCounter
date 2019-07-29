using LettersCounter.App.Services.Interfaces;
using LettersCounter.Domain.Enums;
using System;

namespace LettersCounter.App.Services
{
    public class NumberConverter : INumberConverter
    {
        public string GetWord(int number)
        {
            var digits = number.ToString();
            var word = string.Empty;

            switch (digits.Length)
            {
                case 1:
                    word = Enum.GetName(typeof(UnitsEnum), number);
                    break;

                case 2:
                    if (number >= 11 && number <= 19)
                        word = Enum.GetName(typeof(IrregularDozensEnum), number);
                    else
                    {
                        var numbersArray = digits.ToCharArray();
                        if (numbersArray[1] == '0')
                            word = Enum.GetName(typeof(DozensEnum), number);
                        else
                        {
                            var dozen = int.Parse($"{numbersArray[0].ToString()}0");

                            word = $"{Enum.GetName(typeof(DozensEnum), dozen)} e " +
                                $"{Enum.GetName(typeof(UnitsEnum), int.Parse(numbersArray[1].ToString()))}";
                        }
                    }
                    break;

                case 3:
                    word = Enum.GetName(typeof(HundredsEnum), number);
                    break;
            }

            return word;
        }
    }
}