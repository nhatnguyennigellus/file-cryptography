using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace AdvancedFileEncryption
{
    public class UserAccount
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Birthdate { get; set; }
        public string Passphrase { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        XmlDocument doc = new XMLInit().ReadXML();
        public void register(string publicKeyXML, string privateKeyXML)
        {
            string Xpath = "/Accounts";
            XmlElement eleAccList = (XmlElement)doc.SelectSingleNode(Xpath);
            XmlElement eleNewAcc = doc.CreateElement("Account");
            eleNewAcc.SetAttribute("Email", Email);
            eleNewAcc.SetAttribute("Fullname", Fullname);
            eleNewAcc.SetAttribute("Birthdate", Birthdate);
            eleNewAcc.SetAttribute("Address", Address);
            eleNewAcc.SetAttribute("Phone", Phone);

            byte[] saltBytes = null;
            saltBytes = generateSalt();

            eleNewAcc.SetAttribute("Salt", Encoding.UTF8.GetString(saltBytes));
            eleNewAcc.SetAttribute("Hash", generateHash(Passphrase, saltBytes));

            XmlElement elePublic = doc.CreateElement("PublicKey");
            elePublic.InnerXml = publicKeyXML;
            XmlElement elePrivate = doc.CreateElement("PrivateKey");
            elePrivate.InnerXml = privateKeyXML;


            eleNewAcc.AppendChild(elePublic);
            eleNewAcc.AppendChild(elePrivate);
            eleAccList.AppendChild(eleNewAcc);
            doc.Save(new XMLInit().GetFileName());
        }

        public bool existedEmail(string email)
        {

            string Xpath = "/Accounts/Account[contains(@Email, '" + email + "')]";

            XmlNode eleAcc = doc.SelectSingleNode(Xpath);
            if (eleAcc != null)
            {
                return true;
            }
            return false;
        }

        public UserAccount getAccountByEmail(string email)
        {
            string Xpath = "/Accounts/Account[contains(@Email, '"
                + email + "')]";

            XmlElement eleAcc = (XmlElement)doc.SelectSingleNode(Xpath);

            UserAccount acc = new UserAccount
            {
                Email = email,
                Fullname = eleAcc.GetAttribute("Fullname"),
                Address = eleAcc.GetAttribute("Address"),
                Phone = eleAcc.GetAttribute("Phone"),
                Birthdate = eleAcc.GetAttribute("Birthdate")
                
            };
            return acc;
        }

        public bool isAuthenticated(string email, string passphrase)
        {
            string Xpath = "/Accounts/Account[contains(@Email, '"
                + email + "')]";

            XmlElement eleAcc = (XmlElement) doc.SelectSingleNode(Xpath);
            if (eleAcc == null)
            {
                return false;
            }
            string hashValue = eleAcc.GetAttribute("Hash");

            if (VerifyHash(passphrase, hashValue))
            {
                return true;
            }
            return false;
        }

        public bool editProfile()
        {
            try
            {
                string Xpath = "/Accounts/Account[contains(@Email, '"
                        + this.Email + "')]";
                XmlElement eleAcc = (XmlElement)doc.SelectSingleNode(Xpath);

                eleAcc.Attributes["Address"].Value = this.Address;
                eleAcc.Attributes["Phone"].Value = this.Phone;
                eleAcc.Attributes["Fullname"].Value = this.Fullname;
                eleAcc.Attributes["Birthdate"].Value = this.Birthdate;

                doc.Save(new XMLInit().GetFileName());
                return true;
            }
            catch (Exception)
            {   

                throw;
            }
        }

        public bool changePassphrase(string passphrase)
        {
            try
            {
                string Xpath = "/Accounts/Account[contains(@Email, '"
                        + this.Email + "')]";
                XmlElement eleAcc = (XmlElement)doc.SelectSingleNode(Xpath);

                byte[] saltBytes = null;
                saltBytes = generateSalt();

                eleAcc.Attributes["Salt"].Value = Encoding.UTF8.GetString(saltBytes);
                eleAcc.Attributes["Hash"].Value = generateHash(passphrase, saltBytes);

                doc.Save(new XMLInit().GetFileName());
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            //return false;
        }

        public byte[] generateSalt()
        {
            byte[] saltBytes = null;
            // If salt is not specified, generate it on the fly.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            return saltBytes;
        }

        public string generateHash(string plainText, byte[] saltBytes)
        {
            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            MD5CryptoServiceProvider hash;

            hash = new MD5CryptoServiceProvider();

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public bool VerifyHash(string plainText, string hashValue)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            //// Make sure that hashing algorithm name is specified.
            //if (hashAlgorithm == null)
            //    hashAlgorithm = "";

            //// Size of hash is based on the specified algorithm.
            //switch (hashAlgorithm.ToUpper())
            //{
            //    case "SHA1":
            //        hashSizeInBits = 160;
            //        break;

            //    case "SHA256":
            //        hashSizeInBits = 256;
            //        break;

            //    case "SHA384":
            //        hashSizeInBits = 384;
            //        break;

            //    case "SHA512":
            //        hashSizeInBits = 512;
            //        break;

            //    default: // Must be MD5
            hashSizeInBits = 128;
            //        break;
            //}

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        generateHash(plainText, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
}
