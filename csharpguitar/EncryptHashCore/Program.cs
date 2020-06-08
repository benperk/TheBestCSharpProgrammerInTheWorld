using System;
using System.Security.Cryptography;
using System.Text; 

namespace EncryptHashCore
{
    class Program
    {
        //***This program is for fun only, I don't recommend using these patterns for production use***
        static string privateRSAKeyString, publicRSAKeyString;
        static void Main(string[] args)
        {
            bool keepGoing = true;            
            try
            {
                do
                {
                    string source = String.Empty;
                    var selection = DisplayMenu();
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("You selected MD5. Enter a value to hash and press enter.");
                            source = Console.ReadLine();
                            GenerateMd5Hash(source);
                            break;
                        case 2:
                            Console.WriteLine("You selected SHA1. Enter a value to hash and press enter.");
                            source = Console.ReadLine();
                            GenerateSha1Hash(source);
                            break;
                        case 3:
                            Console.WriteLine("You selected SHA256. Enter a value to hash and press enter.");
                            source = Console.ReadLine();
                            GenerateSha256Hash(source);
                            break;
                        case 4:
                            Console.WriteLine("You selected SHA512. Enter a value to hash and press enter.");
                            source = Console.ReadLine();
                            GenerateSha512Hash(source);
                            break;
                        case 5:
                            Console.WriteLine("You selected to Encrypt AES (Symetric). Enter a value to encrypt and press enter.");
                            source = Console.ReadLine();
                            EncryptAES(source);
                            break;
                        case 6:
                            Console.WriteLine("You selected to Decrypt AES (Symetric). Enter a value to decrypt and press enter.");
                            source = Console.ReadLine();
                            DecryptAES(source);
                            break;
                        case 7:
                            Console.WriteLine("You selected to Encrypt RSA (Asymetric). Enter a value to encrypt and press enter.");
                            source = Console.ReadLine();
                            EncryptRSA(source);
                            break;
                        case 8:
                            Console.WriteLine("You selected to Decrypt RSA (Asymetric). Enter a value to decrypt and press enter.");
                            source = Console.ReadLine();
                            DecryptRSA(source);
                            break;
                        case 13:
                            Console.WriteLine("Bye.");
                            keepGoing = false;
                            break;
                        default:
                            throw new InvalidOperationException("You entered an invalid option.  Bye.");
                    }

                } while (keepGoing);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Well...something happend that wasn't expected, specifically: {ex.Message}");
            }
        }
        static public int DisplayMenu()
        {
            //***This program is for fun only, I don't recommend using these patterns for production use***
            Console.WriteLine();
            Console.WriteLine("1.  MD5");
            Console.WriteLine("2.  SHA1");
            Console.WriteLine("3.  SHA256");
            Console.WriteLine("4.  SHA512");
            Console.WriteLine("5.  Encrypt AES");
            Console.WriteLine("6.  Decrypt AES");
            Console.WriteLine("7.  Encrypt RSA");
            Console.WriteLine("8.  Decrypt RSA");
            Console.WriteLine("13. Exit");
            Console.WriteLine("Just for fun, which encryption/hash algorithm would you like to use?  Choose '13' to exit.");
            var result = Console.ReadLine(); 
            return Convert.ToInt32(result);
        }
        static public void GenerateMd5Hash(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("X2"));
                    }
                    Console.WriteLine($"The MD5 hash of {source} is: {sBuilder}");
                }
            }            
        }
        static public void GenerateSha1Hash(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (SHA1Managed sha1Hash = new SHA1Managed())
                {
                    var hash = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                    var sBuilder = new StringBuilder(hash.Length * 2);
                    foreach (byte b in hash)
                    {                        
                        sBuilder.Append(b.ToString("X2"));
                    }
                    Console.WriteLine($"The SHA1 hash of {source} is: {sBuilder}");
                }
            }
        }
        static public void GenerateSha256Hash(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    var hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                    var sBuilder = new StringBuilder(hash.Length * 2);
                    foreach (byte b in hash)
                    {
                        sBuilder.Append(b.ToString("X2"));
                    }
                    Console.WriteLine($"The SHA256 hash of {source} is: {sBuilder}");
                }
            }
        }
        static public void GenerateSha512Hash(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (SHA512 sha512Hash = SHA512.Create())
                {
                    var hash = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                    var sBuilder = new StringBuilder(hash.Length * 2);
                    foreach (byte b in hash)
                    {
                        sBuilder.Append(b.ToString("X2"));
                    }
                    Console.WriteLine($"The SHA512 hash of {source} is: {sBuilder}");
                    Console.WriteLine($"The BitConverted SHA512 hash of {source} is: {BitConverter.ToString(sha512Hash.Hash)}");
                }
            }
        }
        static public void EncryptAES(string source)
        {            
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (SymmetricAlgorithm aes = Aes.Create())
                {
                    Console.WriteLine($"Enter a Salt value: ");
                    var saltValue = Console.ReadLine();
                    Console.WriteLine($"Enter a Pass phrase: ");
                    var passPhrase = Console.ReadLine();

                    byte[] salt = Encoding.ASCII.GetBytes(saltValue);
                    Rfc2898DeriveBytes rfcKey = new Rfc2898DeriveBytes(passPhrase, salt);
                    aes.Key = rfcKey.GetBytes(aes.KeySize / 8);
                    aes.IV = rfcKey.GetBytes(aes.BlockSize / 8);

                    ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
                    byte[] inputbuffer = Encoding.Unicode.GetBytes(source);
                    byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                    Console.WriteLine($"The AES Key (Rijndael) is {Convert.ToBase64String(aes.Key)} ***** AES IV is: {Convert.ToBase64String(aes.IV)}");
                    Console.WriteLine($"The AES (Rijndael) encrypted value of {source} is: {Convert.ToBase64String(outputBuffer)}");
                }   
            }
        }
        static public void DecryptAES(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                Console.WriteLine($"Enter a Salt value: ");
                var saltValue = Console.ReadLine();
                Console.WriteLine($"Enter a Pass phrase: ");
                var passPhrase = Console.ReadLine();

                using (SymmetricAlgorithm aes = Aes.Create())
                {
                    byte[] salt = Encoding.ASCII.GetBytes(saltValue);
                    Rfc2898DeriveBytes rfcKey = new Rfc2898DeriveBytes(passPhrase, salt);
                    aes.Key = rfcKey.GetBytes(aes.KeySize / 8);
                    aes.IV = rfcKey.GetBytes(aes.BlockSize / 8);

                    ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
                    byte[] inputbuffer = Convert.FromBase64String(source);
                    byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                    Console.WriteLine($"The AES Key (Rijndael) is {Convert.ToBase64String(aes.Key)} - AES IV is: {Convert.ToBase64String(aes.IV)}");
                    Console.WriteLine($"The decrypted AES (Rijndael) value of {source} is: {Encoding.Unicode.GetString(outputBuffer)}");
                }        
            }
        }
        static public void EncryptRSA(string source)
        {
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (var rsa = new RSACryptoServiceProvider(2048)) // Generate a new 2048 bit RSA key
                {                    
                    try 
                    {
                        var privateKey = rsa.ExportParameters(true);
                        var publicKey = rsa.ExportParameters(false);

                        //This is for example only, don't implement a pattern like this
                        privateRSAKeyString = GetRSAKeyString(privateKey);
                        publicRSAKeyString = GetRSAKeyString(publicKey);

                        Console.WriteLine($"The RSA private key is: {privateRSAKeyString}");
                        Console.WriteLine($"The RSA public key is: {publicRSAKeyString}");

                        var bytesToEncrypt = Encoding.UTF8.GetBytes(source);
                        rsa.FromXmlString(publicRSAKeyString.ToString());
                        var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                        var base64Encrypted = Convert.ToBase64String(encryptedData);

                        Console.WriteLine($"The RSA encrypted value of {source} is {base64Encrypted}");
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;
                    }                    
                }
            }
        }
        public static string GetRSAKeyString(RSAParameters key)
        {
            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, key);
            return stringWriter.ToString();
        }
        static public void DecryptRSA(string source)
        {
            //https://source.dot.net/#System.Security.Cryptography.Algorithms/System/Security/Cryptography/RSA.cs
            if (source == string.Empty)
            {
                Console.WriteLine("You did not enter any value...?");
            }
            else
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    try 
                    {
                        Console.WriteLine("Make sure you have encrypted a string with RSA so the keys get generated");
                        Console.WriteLine($"The RSA private key is: {privateRSAKeyString}");

                        rsa.PersistKeyInCsp = false;

                        rsa.FromXmlString(privateRSAKeyString);
                        var resultBytes = Convert.FromBase64String(source);
                        var decryptedBytes = rsa.Decrypt(resultBytes, true);
                        var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                        Console.WriteLine($"The RSA decrypted value of {source} is {decryptedData.ToString()}");
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;
                    }                                       
                }
            }
        }
    }
}
