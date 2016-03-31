using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniqueIdGenerator
{
    class Program
    {
        private const int MAX_UNIQUE_CODE_SIZE = 8;
        private const string ALLOWED_CODE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                string generatedId = GenerateUniqueCode();
                Console.WriteLine(generatedId);
            }
            Console.ReadLine();
        }

        private static string GenerateUniqueCode()
        {
            char[] chars = ALLOWED_CODE_CHARACTERS.ToCharArray();
            byte[] data = new byte[MAX_UNIQUE_CODE_SIZE];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder();
            foreach (byte b in data)
                result.Append(chars[b % (chars.Length - 1)]);

            
            return result.ToString();
        }
    }
}
