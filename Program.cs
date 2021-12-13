using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework13
{
    class Program
    {
        static void Main()
        {
            var choice = 0;
            var counter = 0;
            var scrollamount = 0;
            var placement = 0;
            List<string> scrolls = new List<string>() { "Book of Peace", "Scroll of Swords", "Silence Guide Book" };
            List<string> newscroll = new List<string>();
            while (true)
            {
                Console.WriteLine("1. My Scroll List");
                Console.WriteLine("2. Add Scrolls");
                Console.WriteLine("3. Search Scrolls");
                Console.WriteLine("4. Delete Scrolls");
                Console.WriteLine("What option do you choose?");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    counter = 0;
                    Console.WriteLine("List of scrolls that have not been learnt :");
                    foreach (var scroll in scrolls)
                    {
                        counter++;
                        Console.WriteLine($"Scroll {counter} : {scroll}");
                    }
                }
                if (choice == 2)
                {
                    Console.WriteLine("How many scrolls to add?");
                    scrollamount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Which placement in queue?");
                    placement = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < scrollamount; i++)
                    {
                        Console.WriteLine($"Name of scroll {i + 1} :");
                        newscroll.Add(Console.ReadLine());
                    }
                    if (placement < 1)
                    {
                        placement = 0;
                    }
                    else if (placement > scrolls.Count())
                    {
                        placement = scrolls.Count();
                    }
                    counter = -1;
                    foreach (var scroll in newscroll)
                    {
                        scrolls.Insert(placement + counter, scroll);
                        counter++;
                    }
                    newscroll.Clear();

                    Console.Clear();
                    counter = 0;
                    foreach (var scroll in scrolls)
                    {
                        counter++;
                        Console.WriteLine($"Scroll {counter} : {scroll}");
                    }
                }
                if (choice == 3)
                {
                    scrolls.ForEach(j => j.ToLower());
                    Console.WriteLine("Input scroll name:");
                    string searchscroll = Console.ReadLine().ToLower();
                    for (int i = 0; i < scrolls.Count(); i++)
                    {
                        if (scrolls[i] == searchscroll)
                        {
                            Console.WriteLine($"Scroll found in queue number {i + 1}");
                        }
                        else
                        {
                            Console.WriteLine("Unable to find scroll");
                        }
                    }
                }
                if (choice == 4)
                {
                    Console.Write("Remove from list by scroll name ? (y/n)");
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        Console.Write("Insert scroll name: ");
                        string insertname = Console.ReadLine();
                        if (scrolls.Contains(insertname, StringComparer.OrdinalIgnoreCase))
                        {
                            scrolls.Remove(insertname);
                            Console.WriteLine("Scroll removed");
                        }
                        else
                            Console.WriteLine("Book not found!");
                    }
                    else if (option == "n")
                    {
                        Console.Write("Input scroll queue: ");
                        int inputqueue = Convert.ToInt32(Console.ReadLine());
                        while (inputqueue > scrolls.Count)
                        {
                            Console.Write("Unable to find scroll in queue, input scroll queue: ");
                            inputqueue = Convert.ToInt32(Console.ReadLine());
                        }
                        scrolls.RemoveAt(inputqueue - 1);
                        Console.WriteLine("Scroll removed");
                    }
                }
            }
        }
    }
}
