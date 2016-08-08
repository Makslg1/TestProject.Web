using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestProject.Web.Helper
{
    public static  class Base58CheckHelper
    {
        public static string GetShortLink(int id)
        {
           return Base58Check.Base58CheckEncoding.EncodePlain(BitConverter.GetBytes(id));          
        }
        public static int GetOriginalLink(string shortLink)
        {
            return BitConverter.ToInt32(Base58Check.Base58CheckEncoding.DecodePlain(shortLink),0);
        }    

    }
}