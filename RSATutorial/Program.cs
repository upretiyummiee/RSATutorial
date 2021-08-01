using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RSATutorial
{
    class Program
    {
        static void Main()
        {
            var csp = new RSACryptoServiceProvider(2048);
            var _publicKey = csp.ExportParameters(false);
            var _privateKey = csp.ExportParameters(true);

            /*string plainText;

            Console.WriteLine("Enter random text to encrypt: ");
            plainText = Console.ReadLine();

            var textBytes = Encoding.Unicode.GetBytes(plainText);

            var cypherbytes = csp.Encrypt(textBytes, false);
            var cypherText = Convert.ToBase64String(cypherbytes);

            Console.WriteLine($"Cypher Text: {cypherText}");
            Console.WriteLine();

            Console.ReadKey();

            var bytesCypherText = Convert.FromBase64String(cypherText);

            var decryptedBytes = csp.Decrypt(bytesCypherText, false);
            var plainTextData = Encoding.Unicode.GetString(decryptedBytes);
            Console.WriteLine($"Decrypted Text: {plainTextData}");
            _ = Console.ReadKey();*/

            string myFile= "C:\\Users\\upret\\source\\repos\\RSATutorial\\RSATutorial\\myFile.txt";
            Console.WriteLine($"Encrypting the file: {myFile}");


            MemoryStream ms = new MemoryStream(File.ReadAllBytes(myFile));
            var cypherbytes = csp.Encrypt(ms.ToArray(), false);
            File.WriteAllBytes(myFile + ".wizq", cypherbytes);
            ms.Close();
            File.Delete(myFile);
            _ = Console.ReadKey();

            Console.WriteLine("Decrypting:");
            ms = new MemoryStream(File.ReadAllBytes(myFile+".wizq"));
            var decryptbytes = csp.Decrypt(cypherbytes, false);
            File.WriteAllBytes(myFile, decryptbytes);
            ms.Close();
            File.Delete(myFile+".wizq");
            _ = Console.ReadKey();

        }
    }
}
