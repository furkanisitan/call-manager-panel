using HashidsNet;
using System.Linq;

namespace CallManagerPanel.MVCWebUI.Library.Helpers
{
    public static class HashidsHelper
    {
        private const string Salt = "uq48Q7^9X*NjJJp5?.B&g";
        private static readonly Hashids Hashids = new Hashids(Salt, 10);

        /// <summary>
        /// Sayıyı şifrelenmiş bir string olarak döner.
        /// </summary>
        public static string Encrypt(int number) =>
            number < 0 ? null : Hashids.Encode(number);

        /// <summary>
        /// Şifrelenmiş string'i sayı olarak döner. İşlem başarısın olursa 0 döner.
        /// </summary>
        public static int Decrypt(string hash) =>
             hash == null ? 0 : Hashids.Decode(hash).FirstOrDefault();

    }
}