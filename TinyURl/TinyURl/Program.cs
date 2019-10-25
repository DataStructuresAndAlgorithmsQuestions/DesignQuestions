// simple program for covering the int to base 62 and creating the tiny url from it and retrive 
//back the base 62 id to the decimal no and retrive long url from data base
using System;
using System.Text;

namespace TinyURl
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 123456;
            string shorturl = converIntegerToBase62(n);
            Console.WriteLine(shorturl);
            Console.WriteLine(getIdAssociatedwithLongUrl(shorturl));
        }
        // this function to generate the short url from Id associated with long url
        public static String converIntegerToBase62(int n) {

            String str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] ch = str.ToCharArray();
           
            StringBuilder builder = new StringBuilder();
            while (n > 0) {
                builder.Append(ch[n % 62]);
                n = n / 62;
            }
            int j = builder.Length-1;
            int i = 0;
            while (j >= i) {
                char temp = builder[i];
                builder[i] = builder[j];
                builder[j] = temp;
                j--;
                i++;
            }
            return builder.ToString();
        }
        public static int getIdAssociatedwithLongUrl(string shortUrl) {
            int digit = 0;
            for (int i = 0; i < shortUrl.Length; i++) {
                if ('a' <= shortUrl[i] && shortUrl[i] <= 'z') {
                    digit = digit * 62 +( shortUrl[i] - 'a');

                }
                else if ('A' <= shortUrl[i] && shortUrl[i] <= 'Z')
                {
                    digit = digit * 62 + (shortUrl[i] - 'A')+26;
                }
                else if ('0' <= shortUrl[i] && shortUrl[i] <= '9')
                {
                    digit = digit * 62 + (shortUrl[i] - '0') + 52;
                }
            }
            return digit;
        }
    }
}
