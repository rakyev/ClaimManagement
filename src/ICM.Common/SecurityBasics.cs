using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICM.Data;

namespace ICM.Common
{
    public class SecurityBasics
    {
        ICMDBContext _context;

        private static SecurityBasics _securityBasics;
        private List<string> _localTokenList = new List<string>();


        

        private SecurityBasics()
        {
        }
        
        public static SecurityBasics GetInstance()
        {
            return _securityBasics ?? (_securityBasics = new SecurityBasics());
        }


        public Boolean IsValidUser(string token)
        {
            if (_localTokenList.Contains(token))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //todo--need to confirm if we have a password table in the database
        public string InValidUser(string userName, string passWord)
        {
            if (_context == null)
                _context = new ICMDBContext();


            var result = from sfs in _context.SFSUsers
                         where sfs.us_Username == userName
                         select sfs;
                        
            if (result != null)
            {
                string token = new Guid().ToString();
                _localTokenList.Add(token);
                return token;
            }
            else
            {
                return "Not Valid Credential";
            }
        }
    }
}
