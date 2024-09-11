using criptid.Cript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace criptid.Account
{
    public class AccountEncriptor
    {

        private readonly Encriptor _encriptor;

        public AccountEncriptor()
        {
            _encriptor = new Encriptor();

        }

        public string GetAccountID(int agency, int number, int accType, string tokenKey)
        {
            var _fullname = agency.ToString() + "/" + number.ToString() + "/" +accType.ToString();


            for (int i = 0; i < accType; i++)
            {
                _fullname = ReverseString(_fullname);
            }

            return _encriptor.EncryptInfo(_fullname, tokenKey);
        }


        public (int agency, int number, int accType) GetAccount(string encryptedAccountID, int accType, string tokenKey)
        {
            string decryptedFullname = _encriptor.DecryptInfo(encryptedAccountID, tokenKey);

            for (int i = 0; i < accType; i++)
            {
                decryptedFullname = ReverseString(decryptedFullname);
            }
            string[] parts = decryptedFullname.Split('/');
            int agency = int.Parse(parts[0]);
            int number = int.Parse(parts[1]);
            int decryptedAccType = int.Parse(parts[2]);

            return (agency, number, decryptedAccType);
        }


        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

      
    }
}
