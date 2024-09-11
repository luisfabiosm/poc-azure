using criptid.Cript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace criptid.App
{
    public class AppEncriptor
    {

        private readonly Encriptor _encriptor;

        public AppEncriptor()
        {
            _encriptor = new Encriptor();

        }


        public string GetAppSecret(string version, string name)
        {

            var _fullname = version + "#" + name;

            return _encriptor.EncryptInfo(_fullname);

        }

      
    }
}
