using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedFileEncryption
{
    public class MyCryptography
    {
        public SymmetricAlgorithm[] encryptAlgs, decryptAlgs;
        public SymmetricAlgorithm encryptAlg, decryptAlg;

        public MyCryptography()
        {
            try
            {
                encryptAlgs = new SymmetricAlgorithm[5];
                encryptAlgs[0] = Rijndael.Create();
                encryptAlgs[1] = Aes.Create();
                encryptAlgs[2] = DES.Create();
                encryptAlgs[3] = TripleDES.Create();
                encryptAlgs[4] = RC2.Create();

                encryptAlg = encryptAlgs[0];

                decryptAlgs = new SymmetricAlgorithm[5];
                decryptAlgs[0] = Rijndael.Create();
                decryptAlgs[1] = Aes.Create();
                decryptAlgs[2] = DES.Create();
                decryptAlgs[3] = TripleDES.Create();
                decryptAlgs[4] = RC2.Create();

                decryptAlg = decryptAlgs[0];
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void ZipFileBeforeEncr(string input, string output)
        {
            try
            {

                using (FileStream target = new FileStream
                    (output, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream alg = new GZipStream(target, CompressionMode.Compress))
                    {
                        byte[] data = File.ReadAllBytes(input);
                        alg.Write(data, 0, data.Length);
                        alg.Flush();
                    }
                }
                MessageBox.Show("Zipped File successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public byte[] Encrypt(string email, byte[] plainData, byte[] key, byte[] iv, 
            CipherMode mode, PaddingMode padding, int blockSize, int keySize)
        {
            string secretKeyEncrypted = encryptSecretKey(key, email);
            byte[] secretKeyEncrBytes = UTF8Encoding.UTF8.GetBytes(secretKeyEncrypted); /**/
            
            //init
            encryptAlg.KeySize = keySize;
            encryptAlg.Key = key;
            encryptAlg.Mode = mode;
            encryptAlg.Padding = padding;
            encryptAlg.BlockSize = blockSize;

            if (mode != CipherMode.ECB)
            {
                try
                {
                    encryptAlg.IV = iv;
                }
                catch (CryptographicException ce)
                {
                    MessageBox.Show("Vector IV không hợp lệ");
                    return null;
                }
            }

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptAlg.CreateEncryptor(), CryptoStreamMode.Write);

            //Encrypt
            cs.Write(plainData, 0, plainData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            ms.Close();

            // Create integer bytes
            byte[] blockBytes = BitConverter.GetBytes(blockSize); /**/
            int paddingIndex = -1;
            switch (padding)
            {
                case PaddingMode.PKCS7:
                    paddingIndex = 1;
                    break;
                case PaddingMode.ANSIX923:
                    paddingIndex = 2;
                    break;
                case PaddingMode.ISO10126:
                    paddingIndex = 3;
                    break;
                case PaddingMode.Zeros:
                    paddingIndex = 4;
                    break;
            }
            byte[] paddingBytes = BitConverter.GetBytes(paddingIndex); /**/
            int modeIndex = -1;
            switch (mode)
            {
                case CipherMode.CBC:
                    modeIndex = 1;
                    break;
                case CipherMode.CFB:
                    modeIndex = 2;
                    break;
                case CipherMode.CTS:
                    modeIndex = 3;
                    break;
                case CipherMode.ECB:
                    modeIndex = 4;
                    break;
                case CipherMode.OFB:
                    modeIndex = 5;
                    break;
            }
            byte[] modeBytes = BitConverter.GetBytes(modeIndex); /**/
            int algIndex = -1;
            if (encryptAlg == encryptAlgs[0])  algIndex = 0;
            else if (encryptAlg == encryptAlgs[1]) algIndex = 1;
            else if (encryptAlg == encryptAlgs[2]) algIndex = 2;
            else if (encryptAlg == encryptAlgs[3]) algIndex = 3;
            else if (encryptAlg == encryptAlgs[4]) algIndex = 4;
            byte[] algBytes = BitConverter.GetBytes(algIndex); /**/
            byte[] ivSizeBytes = null;
            if (mode != CipherMode.ECB)
            {
                ivSizeBytes = BitConverter.GetBytes(iv.Length); /**/
            }
            byte[] encrKeySize = BitConverter.GetBytes(secretKeyEncrBytes.Length); /**/

            // Init data bytes to write
            byte[] encryptedDataFinal;

            // Add all bytes to list and convert to array
            var tempList = new List<byte>();
            tempList.AddRange(blockBytes);
            tempList.AddRange(paddingBytes);
            tempList.AddRange(modeBytes);
            tempList.AddRange(algBytes);
            if (ivSizeBytes != null)
            {
                tempList.AddRange(ivSizeBytes);
                tempList.AddRange(iv);
            }
            tempList.AddRange(encrKeySize);
            tempList.AddRange(secretKeyEncrBytes);
            tempList.AddRange(encryptedData);
            encryptedDataFinal = tempList.ToArray();
            
            
            return encryptedDataFinal;
        }

        private string encryptSecretKey(byte[] secretKey, string email)
        {
            UserAccount acc = new UserAccount();
            string publicKey = acc.getPublicKeyByEmail(email);

            byte[] keyArray;
            byte[] toEncryptArray = secretKey;

            // If hashing use get hashcode regards to your key

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(publicKey));
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

        public byte[] decryptSecretKey(string secretKeyEncr, string email, string passphrase)
        {
            UserAccount acc = new UserAccount();
            string privateKeyEncr = acc.getPrivateKeyByEmail(email);
            string privateKeyData =
                acc.decryptPrivateKey(privateKeyEncr, passphrase);
            string privateKey = privateKeyData.Substring
                (privateKeyData.IndexOf("<Modulus>") + 9,
                privateKeyData.IndexOf("</Modulus>") - privateKeyData.IndexOf("<Modulus>") - 9);

            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(secretKeyEncr.Replace(' ', '+'));

            // If hashing was used get the hash code with regards to your key
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(privateKey));
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
            return resultArray;
        }

        public byte[] Decrypt(string inputPath, string passphrase, string email)
        {
            FileStream stream = new FileStream
                (inputPath, FileMode.Open, FileAccess.Read);
            try
            {
                int streamSize = (int)stream.Length;
                int headerSize = 0;
                byte[] int32Byte = new byte[4];
                int blockSize = 0, padding = 0, mode = 0, 
                    algIndex = -1, ivSize = 0, keyEncrSize = 0;
                byte[] iv = null, keyEncr = null, encrData = null;
                using (stream)
                {
                    stream.Read(int32Byte, 0, 4);
                    blockSize = BitConverter.ToInt32(int32Byte, 0);
                    headerSize += 4;

                    stream.Read(int32Byte, 0, 4);
                    padding = BitConverter.ToInt32(int32Byte, 0);
                    headerSize += 4;

                    stream.Read(int32Byte, 0, 4);
                    mode = BitConverter.ToInt32(int32Byte, 0);
                    headerSize += 4;

                    stream.Read(int32Byte, 0, 4);
                    algIndex = BitConverter.ToInt32(int32Byte, 0);
                    headerSize += 4;

                    if (mode != 4)
                    {
                        stream.Read(int32Byte, 0, 4);
                        ivSize = BitConverter.ToInt32(int32Byte, 0);
                        iv = new byte[ivSize];
                        stream.Read(iv, 0, ivSize);
                        headerSize += 4 + ivSize;
                    }

                    stream.Read(int32Byte, 0, 4);
                    keyEncrSize = BitConverter.ToInt32(int32Byte, 0);
                    keyEncr = new byte[keyEncrSize];
                    stream.Read(keyEncr, 0, keyEncrSize);
                    headerSize += 4 + keyEncrSize;

                    int dataSize = streamSize - headerSize;
                    encrData = new byte[dataSize];
                    stream.Read(encrData, 0, dataSize);
                }

                PaddingMode paddingMode = PaddingMode.None;
                switch (padding)
                {
                    case 1:
                        paddingMode = PaddingMode.PKCS7;
                        break;
                    case 2:
                        paddingMode = PaddingMode.ANSIX923;
                        break;
                    case 3:
                        paddingMode = PaddingMode.ISO10126;
                        break;
                    case 4:
                        paddingMode = PaddingMode.Zeros;
                        break;
                }

                CipherMode cipherMode = CipherMode.CBC;
                switch (mode)
                {
                    case 1:
                        cipherMode = CipherMode.CBC;
                        break;
                    case 2:
                        cipherMode = CipherMode.CFB;
                        break;
                    case 3:
                        cipherMode = CipherMode.CTS;
                        break;
                    case 4:
                        cipherMode = CipherMode.ECB;
                        break;
                    case 5:
                        cipherMode = CipherMode.OFB;
                        break;
                }

                decryptAlg = decryptAlgs[algIndex];
                byte[] key = decryptSecretKey(UTF8Encoding.UTF8.GetString(keyEncr), email, passphrase);

                try
                {
                    decryptAlg.KeySize = key.Length * 8;
                    decryptAlg.Key = key;
                    decryptAlg.Mode = cipherMode;
                    decryptAlg.Padding = paddingMode;
                    decryptAlg.BlockSize = blockSize;


                    if (cipherMode != CipherMode.ECB)
                    {
                        try
                        {
                            decryptAlg.IV = iv;
                        }
                        catch (CryptographicException ce)
                        {
                            MessageBox.Show("Vector IV không hợp lệ");
                            return null;
                        }
                    }

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, decryptAlg.CreateDecryptor(), CryptoStreamMode.Write);

                    //Encrypt

                    cs.Write(encrData, 0, encrData.Length);
                    cs.Close();

                    byte[] decryptedData = ms.ToArray();
                    ms.Close();

                    return decryptedData;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
