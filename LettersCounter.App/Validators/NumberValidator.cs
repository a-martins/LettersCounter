using LettersCounter.App.Validators.Interfaces;

namespace LettersCounter.App.Validators
{
    public class NumberValidator : INumberValidator
    {
        public bool isValid(int number)
        {
            return Between(number, 0, 100);
        }

        private bool Between(int num, int lower, int upper)
        {
            return lower <= num && num <= upper;
        }
    }
}