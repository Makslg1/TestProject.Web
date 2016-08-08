using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestProject.Web.Helper
{
    /// <summary>
    /// Вспомогательный класс для шифрования id ссылки
    /// </summary>
    public static class Base58CheckHelper
    {
        /// <summary>
        /// Метод для создания ссылки
        /// </summary>
        /// <param name="id">идентификатор ссылки в таблице</param>
        /// <returns>сгенерированная ссылка</returns>
        public static string GetShortLink(int id)
        {
            return Base58Check.Base58CheckEncoding.EncodePlain(BitConverter.GetBytes(id));
        }
        /// <summary>
        /// Обратное преобразование ссылки в id 
        /// </summary>
        /// <param name="shortLink">Короткая ссылка</param>
        /// <returns>идентификатор ссылки </returns>
        public static int GetOriginalLink(string shortLink)
        {
            return BitConverter.ToInt32(Base58Check.Base58CheckEncoding.DecodePlain(shortLink), 0);
        }

    }
}