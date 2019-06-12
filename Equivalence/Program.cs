using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace Equivalence
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalStr = new StringBuilder();
            string str = File.ReadAllText("INPUT.TXT");
            var tmp = Regex.Matches(str, @"\A(-?[0-9]+)[\+\*\/-](-?[0-9]+=-?[0-9]+).?\Z");
            foreach (var v in tmp)
                finalStr.Append(v);
            if (finalStr.Length > 0)
            {
                char[] charArr = finalStr.ToString().ToArray();
                string[] strArr = { "", "", "", "", "" };
                int j = 0;
                string temp = "";
                for (int i = 0; i < charArr.Length; i++)
                {
                    if (charArr[i].ToString() == "\r" && i == charArr.Length-1) break;
                    if (charArr[i].ToString() == "\r" && i != charArr.Length - 1)
                    {
                        temp = "";
                        break;
                    }
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
                            okay = ((double)first / (double)second == result);
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
            else File.WriteAllText("OUTPUT.TXT", "ERROR");
        }
    }
}
