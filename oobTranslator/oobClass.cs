using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oobTranslator
{
    class oobClass
    {
        /// <summary>
        /// Returns an oobified string
        /// </summary>
        /// <param name="input">Un-oobified input</param>
        /// <returns>An oobified string</returns>
        public string oobifyString(string input)
        {
            StringBuilder output = new StringBuilder();
            string vowels = "aeiou";
            foreach (char c in input)
            {
                bool isUpper = Char.IsUpper(c);
                char myC = Char.ToLower(c);

                bool isOob = false;

                foreach(char x in vowels)
                {
                    if (myC == x)
                    {
                        isOob = true;
                    }
                }
                if (isOob)
                {
                    if (isUpper)
                    {
                        output.Append(new char[] { 'O' });
                    } else
                    {
                        output.Append(new char[] { 'o' });
                    }
                    output.Append(new char[] { 'o', 'b' });
                } else
                {
                    output.Append(c);
                }

            }
            return output.ToString(); 
        }
    }
}
