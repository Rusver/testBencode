using BencodeNET.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source
{
    // prints bencode objects
    class BencodePrinter
    {
        // prints bencode list
        public void PrintBlist(BList list)
        {
            foreach (var item in list)
            {
                if (item is BDictionary)
                    PrintBdict(item as BDictionary);
                else if (item is BList)
                    PrintBlist(item as BList);
                else
                    Console.WriteLine($"item => {item}");
            }
        }

        // prints bencode dictionary
        public void PrintBdict(BDictionary dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"key => {pair.Key}");

                if (pair.Value is BDictionary)
                    PrintBdict(pair.Value as BDictionary);

                else if (pair.Value is BList)
                    PrintBlist(pair.Value as BList);

                else
                    Console.WriteLine($"value => {pair.Value}");
            }
        }

        // prints bencode generic object
        public void Print(BObject BObj)
        {
            if (BObj is BDictionary)
                PrintBdict(BObj as BDictionary);

            else if (BObj is BList)
                PrintBlist(BObj as BList);

            else
                Console.WriteLine(BObj);
        }
    }
}
