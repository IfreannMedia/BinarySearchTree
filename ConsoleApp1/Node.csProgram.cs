using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Small class containing user commands
    public class UserCommands
    {
        // Possible pre-defined commands, simply add a command here
        // then write the behaviour to the ExecuteCommand() method to add functionality to program
        private string help = "help",
                       createTree = "createTree",
                       smallestValue = "smallestValue",
                       largestValue = "largestValue",
                       inOrderTraversal = "inOrderTraversal",
                       preOrderTraversal = "preOrderTraversal",
                       postOrderTraversal = "postOrderTraversal",
                       getLeafNodes = "getLeafNodes",
                       getHeight = "getHeight",
                       isBalanced = "isBalanced",
                       deleteTree = "deleteTree",
                       quit = "quit";
        // Here are commands that cannot be pre-defined asthey contain parametersand must be parsed
        //find int
        //findRecursive int
        //insert int
        //remove int

        // The string containing the commands:
        public List<string> commands = new List<string>();

        // Constructer which fills the list
        public UserCommands()
        {
            commands.Add(help);
            commands.Add(createTree);
            commands.Add(smallestValue);
            commands.Add(largestValue);
            commands.Add(inOrderTraversal);
            commands.Add(preOrderTraversal);
            commands.Add(postOrderTraversal);
            commands.Add(getLeafNodes);
            commands.Add(getHeight);
            commands.Add(isBalanced);
            commands.Add(deleteTree);
            commands.Add(quit);
        }
    }
    // Main Program class
    class Program
    {
        static string userCommand = null;
        static bool quit = false;
        static Tree currentTree = new Tree(); // create an empty tree
        static UserCommands userCommands = new UserCommands();
        static string welcomeMessage = "This program can generate and manipulate binary search strings.\n"+
                                        "type help for help\n" +
                                        "type createTree to create a new tree";
        // Main program method
        // contains a while loop simply to get user input
        // in the form on console commands
        static void Main(string[] args)
        {
            Console.WriteLine(welcomeMessage);
            while (!quit)
            {
                userCommand = Console.ReadLine(); // get the user command
                // Check for pre-defined commands:

                if (userCommands.commands.Contains(userCommand))
                {
                    ExecuteCommand(userCommand);
                }
                else // otherwise check for commands with parameters:
                {
                    int x = ParseForInteger(userCommand);
                    if (userCommand.Contains("find"))
                    {
                        if (userCommand.Contains("findRecursive"))
                        {
                            if (currentTree.FindRecursive(x) != null)
                            {
                                Console.WriteLine($"Searched tree recursively for {x}, found {x}");

                            }
                            else
                            {
                                Console.WriteLine($"The tree does not contain {x}.");
                            }
                        }
                        else
                        {
                            if (currentTree.Find(x) != null)
                            {
                                Console.WriteLine($"Searched tree for {x}, found {x}");
                            }
                            else
                            {
                                Console.WriteLine($"The tree does not contain {x}.");
                            }
                        }
                    }
                    else if (userCommand.Contains("insert"))
                    {
                        currentTree.Insert(x);
                        Console.WriteLine($"Inserted {x} into the tree:\n");
                        currentTree.PreOrderTraversal();
                    }
                    else if (userCommand.Contains("remove"))
                    {
                        if (currentTree.Find(x) != null)
                        {
                            currentTree.Remove(x);
                            Console.WriteLine($"Removed {x} from the tree:\n");
                        }
                        else
                        {
                            Console.WriteLine($"The tree does not contain {x}.");
                        }
                    }
                    else // default case / print help
                    {
                        ExecuteCommand("asasas");
                    }
                }
                 


            }
        }

        // Execute pre-defined commands:
        private static void ExecuteCommand(string command)
        {
            
            switch (command)
            {
                case "help":
                    string helpMessage = "\nThis program can generate and manipulate binary search strings.\n"
                                        + "Here are the possible commands, which are case sensitive:";
                    for (int i = 0; i < userCommands.commands.Count(); i++)
                    {
                        helpMessage += "\n" + userCommands.commands[i] + "\n";
                    }
                    Console.WriteLine(helpMessage);
                    break;
                case "createTree":
                    Console.WriteLine("\ncreateTree called: creating a new randomly generated tree.\n");
                    if (currentTree == null)
                    {
                        currentTree.PopulateRandom();
                        currentTree.PreOrderTraversal();
                    }
                    else
                    {
                        currentTree = new Tree();
                        currentTree.PopulateRandom();
                        currentTree.PreOrderTraversal();
                    }
                    Console.Write("\n");
                    break;
                case "smallestValue":
                    Console.WriteLine("\nsmallestValue called: ");
                    if (currentTree != null)
                    {
                        Console.WriteLine(currentTree.Smallest().ToString());
                    }
                    break;
                case "largestValue":
                    Console.WriteLine("\nlargestValue called: ");
                    if (currentTree != null)
                    {
                        Console.WriteLine(currentTree.Largest().ToString());
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "inOrderTraversal":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\nInOrderTraversal called: Node values in asccending order:\n");
                        currentTree.InOrderTraversal();

                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "preOrderTraversal":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\npreOrderTraversal called: traversing the tree unordered:");
                        currentTree.PreOrderTraversal();
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "postOrderTraversal":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\npostOrderTraversal called: traversing the tree ???????:");
                        currentTree.PostOrderTraversal();
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "getLeafNodes":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\ngetLeafNodes called: here are the leaf nodes:");
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "getHeight":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\ngetHeight  called: here is the tree height");
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "isBalanced":
                    if (currentTree != null)
                    {
                        Console.WriteLine("\n isBalanced called: is the tree balanced?\n");
                        string message = currentTree.isBalanced() ? "Yes, the tree is balanced\n" : "No, the tree is not balanced\n";
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "deleteTree":
                    if (currentTree != null)
                    {
                        Console.WriteLine("deleteTree called: deleted the tree:\n");
                        currentTree = new Tree();
                        currentTree.PreOrderTraversal();
                    }
                    else
                    {
                        Console.WriteLine("No tree found; you need to create a tree first");
                    }
                    break;
                case "quit":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("type help for help, type quit to quit, type createTree to create a tree\n");
                    break;
            }
             
        }

        private static int ParseForInteger(string input)
        {
            input = new string(userCommand.Where(char.IsDigit).ToArray());
            if (input.Length > 0)
            {
                int value = Int32.Parse(input);
                return value;
            }
            return 0;
        }
    }

}

