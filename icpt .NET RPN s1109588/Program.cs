// See https://aka.ms/new-console-template for more information

using icpt_.NET_RPN_s1109588;

Console.WriteLine("Hello, World!");

string[] fruits = { "Apple", "Banana", "Cherry" };
List<string> linesList = new List<string>(fruits);


LogItem[] logItems = new LogItem[]{
    new LogItem { Index = 0, Action = "Add", TextAfter = "Apple" },
    new LogItem { Index = 1, Action = "Add", TextAfter = "Banana" },
    new LogItem { Index = 2, Action = "Add", TextAfter = "Blueberry" },
    // new LogItem { Index = 2, Action = "Edit", TextAfter = "Cherry", TextBefore = "Blueberry"},
};
List<LogItem> logItemList = new List<LogItem>(logItems);


LogItem[] logRedoItems = new LogItem[]{
    new LogItem { Index = 2, Action = "Edit", TextAfter = "Blueberry", TextBefore = "Cherry"},
};
List<LogItem> logRedoItemsList = new List<LogItem>(logRedoItems);

// string input = "/EDIT 0 Citrus";
string input = "/REDO";

if (input.StartsWith("/EXIT"))
{
    Console.WriteLine("Starts with /EXIT");
}
else if (input.StartsWith("/UNDO"))
{
    Console.WriteLine("Starts with /UNDO");
    if (logItemList.Count > 0)
    {
        LogItem lastLogItem = logItemList[logItemList.Count - 1];
        string action = lastLogItem.Action;
        if (action == "Add")
        {
            logRedoItemsList.Add(new LogItem { 
                Index = lastLogItem.Index, 
                Action = action, 
                TextAfter = lastLogItem.TextAfter
            });
        } else if (action == "Edit")
        {
            linesList[lastLogItem.Index] = lastLogItem.TextBefore;
            logRedoItemsList.Add(new LogItem { 
                Index = lastLogItem.Index, 
                Action = action, 
                TextAfter = lastLogItem.TextBefore, 
                TextBefore = lastLogItem.TextAfter 
            });
            
        }
        logItemList.RemoveAt(logItemList.Count - 1);

    }
}
else if (input.StartsWith("/REDO"))
{
    Console.WriteLine("Starts with /REDO");
    if (logRedoItemsList.Count > 0)
    {
        LogItem lastLogItem = logRedoItemsList[logRedoItemsList.Count - 1];
        string action = lastLogItem.Action;
        if (action == "Edit")
        {
            Console.WriteLine($"Redo edit line: {lastLogItem.Index} to {lastLogItem.TextBefore}");

            linesList[lastLogItem.Index] = lastLogItem.TextBefore;
            logItemList.Add(new LogItem
            {
                Index = lastLogItem.Index, 
                TextAfter = lastLogItem.TextBefore,
                TextBefore = lastLogItem.TextAfter
            });
        } else if (action == "Add")
        {
            Console.WriteLine($"Redo add line: {lastLogItem.TextAfter}");
            linesList.Add(lastLogItem.TextAfter);
            logItemList.Add(new LogItem
            {
                Index = lastLogItem.Index, 
                TextAfter = lastLogItem.TextAfter
            });
        }
        logRedoItemsList.RemoveAt(logRedoItemsList.Count - 1);
    }
}
else if (input.StartsWith("/EDIT"))
{
    Console.WriteLine("Starts with /EDIT");
    
    
    string[] parts = input.Split(' ');

    if (parts.Length > 2)
    {
        
        // Remove the first character of part 0
        parts[0] = parts[0].Substring(1);

        string secondPart = parts[1];
        
        if (!int.TryParse(secondPart, out int number))
        {
            Console.WriteLine("Index 1 is not a number.");
        }
        
        Console.WriteLine($"Index 1 is a number: {number}");

        if (number < fruits.Length)
        {
            Console.WriteLine($"Index {number} exists and contains: {fruits[number]}");
            
            // Join the parts from index 2 onwards
            string newString = string.Join(" ", parts, 2, parts.Length - 2);
            Console.WriteLine($"New string without the first and second parts: {newString}");
            
            linesList[number] = newString;
            logItemList.Add(new LogItem { Index = number, Action = parts[0], TextAfter = newString });

        }
    }
}
else
{
    Console.WriteLine($"Adding text to index: {linesList.Count}");

    logItemList.Add(new LogItem { Index = linesList.Count, Action = "Add", TextAfter = input });
    linesList.Add(input);

}

// Display the updated list
foreach (var fruit in linesList)
{
    Console.WriteLine(fruit);
}

