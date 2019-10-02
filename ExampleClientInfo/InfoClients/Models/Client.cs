using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class Client
    {
        private string nit;
        string key = "E546C8DF278CD5931069B522E695D4F2";

        public int ClientId { get; set; }        

        [Required, Description("It must be stored encrypted")]        
        public string Nit {
            get {
                if (nit?.Length > 20)
                    return DecryptString(nit, key).ToString();
                else
                    return nit;
            }
            set { 
                nit = value; 
            } 
        }

        // [MaxLength(100), Required, DisplayName("Full name")]
        public string Fullname { get; set; }        
        
        public string Address { get; set; }

       // [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Country name")]
        public int CountryId { get; set; }

        [DisplayName("State name")]
        public int StateId { get; set; }

        [DisplayName("City name")]
        public int CityId { get; set; }

        [ DisplayName("Credit Limit"), Description("Maximum amount assigned for visits")]
        public int CreditLimit { get; set; }        

        [Required(AllowEmptyStrings =true),ReadOnly(true),DisplayName("Available Credit"), Description("Each time a visit is registered, you must lower it, subtracting the Visit total from the visit registered.")]
        public int AvailableCredit { get; set; }

        [DisplayName("Visits Percentage"), ReadOnly(true), Required(AllowEmptyStrings = true)]
        public int VisitsPercentage { get; set; }


        // Relaciones
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }


        public static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }   
}
