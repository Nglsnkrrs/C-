using System;

namespace Module_3
{
    public class Task2
    {

        public bool Palindrome(int num)
        {
            string numStr = num.ToString();
            string reversedStr = new string(numStr.Reverse().ToArray());

            if (numStr == reversedStr)
            {
                return true;
            }
            else { return false; }
        }
    }
}
