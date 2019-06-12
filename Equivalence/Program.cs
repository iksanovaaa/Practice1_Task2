using System;
using System.Linq;
using System.IO;

namespace Equivalence
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArr = File.ReadAllText("INPUT.TXT").ToArray();
            string[] strArr = { "", "", "", "", "" };
            int j = 0;
            string temp = "";
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i].ToString().Any(char.IsLetter) || charArr[i].ToString() == " ") break;
                if (charArr[i] >= '0' && charArr[i] <= '9' || temp.ToString().Length == 0 && charArr[i] == '-') temp += charArr[i].ToString();                
                else
                {
                    strArr[j] = temp;
                    temp = "";
                    strArr[j + 1] = charArr[i].ToString();
                    if (j <= 2) j += 2;
                    else j++;
                }
            }
            strArr[j] = temp;
            if ((strArr[1] == "*" || strArr[1] == "+" || strArr[1] == "-" || strArr[1] == "/") && strArr[3] == "=" &&
                    Int32.TryParse(strArr[0], out int n) && Int32.TryParse(strArr[2], out int m) && Int32.TryParse(strArr[4], out int l))
            {
                bool okay = false;
                int first = Convert.ToInt32(strArr[0]);
                int second = Convert.ToInt32(strArr[2]);
                int result = Convert.ToInt32(strArr[4]);
                switch (strArr[1])
                {
                    case "*":
                        okay = (first * second == result);
                        break;
                    case "/":
                        okay = (first / second == result);
                        break;
                    case "+":
                        okay = (first + second == result);
                        break;
                    case "-":
                        okay = (first - second == result);
                        break;
                }
                if (okay) File.WriteAllText("OUTPUT.TXT", "YES");
                else File.WriteAllText("OUTPUT.TXT", "NO");
            }
            else File.WriteAllText("OUTPUT.TXT", "ERROR");
        }
    }
}
