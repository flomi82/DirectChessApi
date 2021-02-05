using DirectChessApi.Enums;
using System;
using System.Text;

namespace DirectChessApi.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random random;

        public RandomService()
        {
            random = new Random(DateTime.Now.Second);
        }

        public string GetRandomGameKey()
        {
            return GetRandomKey(4);
        }

        public string GetRandomPlayerKey()
        {
            return GetRandomKey(4);
        }

        /// <summary>
        /// Returns a random color (White or Black)
        /// </summary>
        /// <returns></returns>
        public Color GetRandomColor()
        {
            return (Color)random.Next(1, 2);
        }

        /// <summary>
        /// Returns a random key consisting of digits and letters
        /// </summary>
        /// <param name="length">length of the generated key</param>
        /// <returns></returns>
        private string GetRandomKey(int length)
        {
            var key = new StringBuilder();
            for (int i=0; i<length; i++)
            {
                if (GetRandomBool())
                {
                    key.Append(GetRandomDigit());
                }
                else
                {
                    key.Append(GetRandomLetter());
                }
            }
            return key.ToString();
        }

        /// <summary>
        /// Returns a random boolean (true or false)
        /// </summary>
        /// <returns></returns>
        private bool GetRandomBool()
        {
            return random.Next(0, 1) == 0;
        }

        /// <summary>
        /// Returns a random number from 0 to 9
        /// </summary>
        /// <returns></returns>
        private int GetRandomDigit()
        {
            return random.Next(0, 9);
        }

        /// <summary>
        /// Returns a random letter from a to z
        /// </summary>
        /// <returns></returns>
        private char GetRandomLetter()
        {
            return (char)random.Next('a', 'z');
        }
    }
}
