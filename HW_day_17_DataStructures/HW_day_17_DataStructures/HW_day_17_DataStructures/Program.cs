namespace HW_day_17_DataStructures
{
    internal class Program
    {
        public static bool BalancingBrackets(string input)
        {
            // with dictionary and stack
            var brackets = new Dictionary<char, char>();
            brackets.Add(')', '(');
            brackets.Add('}', '{');
            brackets.Add(']', '[');

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (brackets.ContainsValue(input[i]))
                {
                    stack.Push(input[i]);
                }
                if (brackets.ContainsKey(input[i]))
                {
                    if (stack.Count > 0)
                        if (stack.Peek() == brackets[input[i]])
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }

                    else
                    {
                        return false;
                    }
                }
            }

            if (stack.Count == 0)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(BalancingBrackets("({([])}"));
        }


        // with only dictionary

        //bool result = true;
        //int countOpen = 0;
        //int countClosed = 0;

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (brackets.ContainsKey(input[i]))
        //        {
        //            countOpen++;
        //            for (int j = i + 1; j < input.Length; j++)
        //            {
        //                if (brackets.ContainsValue(input[i]))
        //                {
        //                    countClosed++;
        //                    break;
        //                }
        //            }
        //        }
        //        if (brackets.ContainsValue(input[i]))
        //            result = false;
        //    }
        //    result = (countOpen == countClosed) && result;


        //Console.WriteLine(countOpen);
        //Console.WriteLine(countClosed);
        //return (result);
        //}

    }
}