using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BencodeNET;
using BencodeNET.Parsing;
using BencodeNET.Torrents;
using System.IO;
using BencodeNET.Objects;

namespace source
{
    class Program
    {
        
        static string fileLoc = @"C:\Users\User\Desktop\textExample.torrent";

        static void Main(string[] args)
        {
            // Parse torrent by specifying the file path
            var parser = new BencodeParser(); // Default encoding is Encoding.UT8F, but you can specify another if you need to
            var torrent = parser.Parse<Torrent>(fileLoc);

            /*
            // Alternatively, handle the stream yourself
            using (var stream = File.OpenRead(fileLoc))
            {
                torrent = parser.Parse<Torrent>(stream);
            }
            */

            // Calculate the info hash
            string infoHash = torrent.GetInfoHash();
            Console.WriteLine($"infoHash => {infoHash}");
            

            // or as bytes instead of a string
            byte[] infoHashBytes = torrent.GetInfoHashBytes();

            // Get Magnet link
            string magnetLink = torrent.GetMagnetLink();
            Console.WriteLine($"magnetLink => {magnetLink}");
            
            // create object to print th fields in the torrent file
            BencodePrinter Bprinter = new BencodePrinter();

            // Convert Torrent to its BDictionary representation
            BDictionary bencodeDict = torrent.ToBDictionary();
            Console.WriteLine(bencodeDict.Count);

            try
            {
                Bprinter.PrintBdict(bencodeDict);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("DONE!!!!!!!");       
            Console.ReadKey();
            
        }
    }
}
