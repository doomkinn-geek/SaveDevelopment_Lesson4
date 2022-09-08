using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lesson4Framework
{
    public class CacheProvider
    {
        static byte[] entropy = { 4, 2, 7, 3, 7 };
        public void CacheConnections(List<ConnectionString> connections)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ConnectionString>));
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            xml.Serialize(writer, connections);
        }

        public byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, entropy, DataProtectionScope.LocalMachine);
            }
            catch(CryptographicException e)
            {
                Console.WriteLine($"Ошибка шифрования: {e.Message}");
                return null;
            }
        }

        private byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, entropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine($"Ошибка дешифрования: {e.Message}");
                return null;
            }
        }
    }
}
