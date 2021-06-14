using System;
using System.Collections.Generic;
using System.Linq;

namespace KVstore
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();
            bool endApp = false;

            Console.WriteLine("Storage APP\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string[] inputArgs = Console.ReadLine().Split(" ");
                var commandName = inputArgs[0];
                try
                {

                    switch (commandName)
                    {

                        case "exit":
                            endApp = true;
                            break;

                        case "add":
                            storage.Add(inputArgs[1], inputArgs[2]);
                            break;
                        case "remove":
                            storage.Remove(inputArgs[1]);
                            break;
                        case "keys":
                            storage.Keys();
                            break;
                        case "members":
                            storage.Members(inputArgs[1]);
                            break;

                        case "removeAll":
                            storage.Members(inputArgs[1]);
                            break;

                        case "clear":
                            storage.Clear();
                            break;

                        case "keyExist":
                            storage.KeyExist(inputArgs[1]);
                            break;

                        case "allMembers":
                            storage.AllMembers();
                            break;
                        case "items":
                            storage.Items();
                            break;
                        default:
                            Console.WriteLine("Command does not exist");
                            break;

                    }

                }
                catch (Exception e)
                {
                    if (e is IndexOutOfRangeException)
                    {
                        Console.WriteLine("Missing parameter");

                    }
                    else
                    {
                        Console.WriteLine(e);
                    }
                }
            }

        }
        class Storage
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            public void Add(string key, string value)
            {
                var result = dictionary.TryAdd(key, value);
                Console.WriteLine(result ? "Added" : "ERROR, member already exists for key");
            }


            public void Remove(string key)
            {
                var result = dictionary.Remove(key);
                Console.WriteLine(result ? "Removed" : "ERROR, member does not exist");
            }

            public void Keys()
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    Console.WriteLine(kvp.Key);
                }
            }

            public void Members(string key)
            {
                var kvps = dictionary.Where(kvp => kvp.Key == key).ToList();
                if (kvps.Count == 0)
                {
                    Console.WriteLine("ERROR, key does not exist.");
                    return;
                }

                foreach (var kvp in kvps)
                {
                    Console.WriteLine(kvp.Value);
                }
            }


            public void RemoveAll(string key)
            {
                if (dictionary.ContainsKey(key))
                {
                    foreach (var kvp in dictionary.Where(kvp => kvp.Key == key).ToList())
                    {
                        dictionary.Remove(kvp.Key);
                    }
                }

                else
                {
                    Console.WriteLine("ERROR, key does not exist.");
                }
            }

            public void Clear()
            {
                dictionary.Clear();
                Console.WriteLine("Storage Cleared");

            }

            public void KeyExist(string key)
            {
                var result = dictionary.ContainsKey(key);
                Console.WriteLine(result);
            }

            public void AllMembers()
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    Console.WriteLine(kvp.Value);
                }
            }
            public void Items()
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
                }
            }
        }
    }
}
