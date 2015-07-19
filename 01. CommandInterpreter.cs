using System;
using System.Linq;

class CommandInterpreter
{
    static void Main()
    {
        string[] userInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        while (command[0] != "end")
        {
            try
            {
                ExecuteCommand(userInput, command);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        string output = string.Format("[{0}]", string.Join(", ", userInput));
        Console.WriteLine(output);
    }

    private static void ExecuteCommand(string[] userInput, string[] command)
    {
        switch (command[0])
        {
            case "reverse":
                ReverseArray(userInput, command[2], command[4]);
                break;
            case "sort":
                SortArray(userInput, command[2], command[4]);
                break;
            case "rollLeft":
                RollArrayLeft(userInput, command[1]);
                break;
            case "rollRight":
                RollArrayRight(userInput, command[1]);
                break;
            default:
                throw new ArgumentException();
        }
    }

    private static void RollArrayRight(string[] userInput, string countTimes)
    {
        int shifts = int.Parse(countTimes);
        if (shifts >= 0)
        {
            int offset = shifts % userInput.Length;
            if (offset > 0)
            {
                var temp = new string[offset];
                Array.Copy(userInput, userInput.Length - offset, temp, 0, offset);
                Array.Copy(userInput, 0, userInput, offset, userInput.Length - offset);
                Array.Copy(temp, 0, userInput, 0, temp.Length);
            }
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private static void RollArrayLeft(string[] userInput, string countTimes)
    {
        int shifts = int.Parse(countTimes);
        if (shifts >= 0)
        {
            int offset = shifts % userInput.Length;
            if (offset > 0)
            {
                var temp = new string[offset];
                Array.Copy(userInput, temp, offset);
                Array.Copy(userInput, offset, userInput, 0, userInput.Length - offset);
                Array.Copy(temp, 0, userInput, userInput.Length - offset, temp.Length);
            }
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private static void SortArray(string[] userInput, string start, string count)
    {
        int startIndex = int.Parse(start);
        int positionsCount = int.Parse(count);
        if (startIndex != userInput.Length)
        {
            Array.Sort(userInput, startIndex, positionsCount);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private static void ReverseArray(string[] userInput, string start, string count)
    {
        int startIndex = int.Parse(start);
        int positionsCount = int.Parse(count);
        if (startIndex != userInput.Length)
        {
            Array.Reverse(userInput, startIndex, positionsCount);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}