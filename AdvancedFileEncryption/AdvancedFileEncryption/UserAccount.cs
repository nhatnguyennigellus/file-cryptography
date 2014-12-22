using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
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

        public List<string> getEmailList()
        {
            List<string> emailList = new List<string>();
            string Xpath = "/Accounts/Account";
            XmlNodeList eleList = doc.SelectNodes(Xpath);
            foreach (XmlElement eleAcc in eleList)
            {
                emailList.Add(eleAcc.GetAttribute("Email"));
            }
            return emailList;
        }
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

            elePrivate.InnerXml = encryptPrivateKey(privateKeyXML, Passphrase);


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

        public string getPublicKeyByEmail(string email)
        {
            string Xpath = "/Accounts/Account[contains(@Email, '"
                + email + "')]/PublicKey/RSAKeyValue/Modulus";

            XmlElement elePubKey = (XmlElement)doc.SelectSingleNode(Xpath);

            return elePubKey.InnerText;
        }

        public string getPublicKeyXMLByEmail(string email)
        {
            string Xpath = "/Accounts/Account[contains(@Email, '"
                + email + "')]/PublicKey";

            XmlElement elePubKey = (XmlElement)doc.SelectSingleNode(Xpath);

            return elePubKey.InnerXml;
        }
        public string getPrivateKeyByEmail(string email)
        {
            string Xpath = "/Accounts/Account[contains(@Email, '"
                + email + "')]/PrivateKey";

            XmlElement elePrivKey = (XmlElement)doc.SelectSingleNode(Xpath);

            return elePrivKey.InnerText;
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

        public bool changePassphrase(string NewPassphrase, string OldPassphrase)
        {
            try
            {
                string Xpath = "/Accounts/Account[contains(@Email, '"
                        + this.Email + "')]";
                XmlElement eleAcc = (XmlElement)doc.SelectSingleNode(Xpath);

                byte[] saltBytes = null;
                saltBytes = generateSalt();

                eleAcc.Attributes["Salt"].Value = Encoding.UTF8.GetString(saltBytes);
                eleAcc.Attributes["Hash"].Value = generateHash(NewPassphrase, saltBytes);

                string privateKey = decryptPrivateKey
                    (doc.SelectSingleNode(Xpath + "/PrivateKey").InnerText, OldPassphrase);
                doc.SelectSingleNode(Xpath + "/PrivateKey").InnerText = 
                    encryptPrivateKey(privateKey, NewPassphrase);

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

        public bool exportKeyInfo(string result, string email, string passphrase, string saveTo)
        {
            if (result == "OK")
            {

                try
                {
                    string Xpath = "/Accounts/Account[contains(@Email, '"
                            + email + "')]";

                    XmlElement eleAcc = (XmlElement)doc.SelectSingleNode(Xpath);
                    string fileName = email.Substring(0, email.IndexOf('@'));
                    XmlTextWriter writer = new XmlTextWriter
                        (saveTo, Encoding.UTF8);

                    writer.WriteStartDocument(true);
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 2;
                    writer.WriteStartElement("Account");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();

                    XmlDocument docExport = new XmlDocument();
                    docExport.Load(saveTo);
                    XmlElement eleExp = (XmlElement)docExport.SelectSingleNode("/Account");
                    eleExp.SetAttribute("Email", email);
                    eleExp.SetAttribute("Fullname", eleAcc.GetAttribute("Fullname"));
                    eleExp.SetAttribute("Address", eleAcc.GetAttribute("Address"));
                    eleExp.SetAttribute("Phone", eleAcc.GetAttribute("Phone"));
                    eleExp.SetAttribute("Birthdate", eleAcc.GetAttribute("Birthdate"));
                    eleExp.SetAttribute("Hash", eleAcc.GetAttribute("Hash"));
                    eleExp.SetAttribute("Salt", eleAcc.GetAttribute("Salt"));

                    XmlElement elePublic = docExport.CreateElement("PublicKey");
                    foreach (XmlNode node in doc.SelectSingleNode(Xpath + "/PublicKey/RSAKeyValue")
                        .ChildNodes)
                    {
                        XmlElement eleChild = docExport.CreateElement(node.Name);
                        eleChild.InnerText = node.InnerText;
                        elePublic.AppendChild(eleChild);
                    }
                    XmlElement elePrivate = docExport.CreateElement("PrivateKey");
                    
                    elePrivate.InnerText = doc.SelectSingleNode(Xpath + "/PrivateKey").InnerText;

                    eleExp.AppendChild(elePublic);
                    eleExp.AppendChild(elePrivate);

                    docExport.Save(saveTo);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
                
            } return false;
        }

        public bool import(string fileName)
        {
            try
            {
                XmlDocument docImport = new XmlDocument();
                docImport.Load(fileName);

                XmlElement eleImport = (XmlElement)docImport.SelectSingleNode("/Account");

                string Xpath = "/Accounts";
                XmlElement eleAccList = (XmlElement)doc.SelectSingleNode(Xpath);
                XmlElement eleNewAcc = doc.CreateElement("Account");
                eleNewAcc.SetAttribute("Email", eleImport.GetAttribute("Email"));
                eleNewAcc.SetAttribute("Fullname", eleImport.GetAttribute("Fullname"));
                eleNewAcc.SetAttribute("Birthdate", eleImport.GetAttribute("Birthdate"));
                eleNewAcc.SetAttribute("Address", eleImport.GetAttribute("Address"));
                eleNewAcc.SetAttribute("Phone", eleImport.GetAttribute("Phone"));
                eleNewAcc.SetAttribute("Hash", eleImport.GetAttribute("Hash"));
                eleNewAcc.SetAttribute("Salt", eleImport.GetAttribute("Salt"));
                XmlElement elePublicImport = (XmlElement)docImport.SelectSingleNode("/Account/PublicKey");
                XmlElement elePublic = (XmlElement)doc.CreateElement("PublicKey");
                XmlElement eleRSAKeyValue = (XmlElement)doc.CreateElement("RSAKeyValue");
                foreach (XmlNode node in elePublicImport.ChildNodes)
                {
                    XmlElement eleChild = doc.CreateElement(node.Name);
                    eleChild.InnerText = node.InnerText;
                    eleRSAKeyValue.AppendChild(eleChild);
                }
                elePublic.AppendChild(eleRSAKeyValue);

                XmlElement elePrivateImport = (XmlElement)docImport.SelectSingleNode("/Account/PrivateKey");
                string privateKey = elePrivateImport.InnerText;
                XmlElement elePrivate = (XmlElement)doc.CreateElement("PrivateKey");
                elePrivate.InnerText = privateKey;

                eleNewAcc.AppendChild(elePublic);
                eleNewAcc.AppendChild(elePrivate);
                eleAccList.AppendChild(eleNewAcc);

                doc.Save(new XMLInit().GetFileName());
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
            return false;
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

            // MD5 Algorithm
            hashSizeInBits = 128;

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

        public string encryptPrivateKey(string privKey, string passphrase)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(privKey);

            // If hashing use get hashcode regards to your key
            
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(passphrase));
            hashmd5.Clear();

            // Set the secret key for the tripleDES algorithm
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            // Transform the specified region of bytes array to resultArray
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            // Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string decryptPrivateKey(string cipherString, string passphrase)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString.Replace(' ', '+'));

            // If hashing was used get the hash code with regards to your key
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(passphrase));
            hashmd5.Clear();
            
            // Set the secret key for the tripleDES algorithm
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            // Return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public bool sendFileViaEmail(string toMail, string filePath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Email);
                mail.To.Add(toMail);
                mail.Subject = "[Advanced File Cryptography] File sent from "
                    + this.Email.Substring(0, this.Email.IndexOf('@'));
                mail.Body = "This is the encrypted file! "
                 + "Use your private key to decrypt! <br/> Enjoy!" ;

                Attachment attachment;
                attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = 
                    new NetworkCredential("icecreamweb2013@gmail.com", "voyygkkgbeqepgbw");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs while sending email: "
                    + ex.Message);
                return false;
            }
        }
    }
}
