using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using OpenSalary.Web.Core.Entities;

namespace OpenSalary.Web.Models {
    public class User {
        public User() {            
        }
        public string AuthID { get; set; }
        [DisplayName("Användarnamn")]
        public string UserName { get; set; }
        [DisplayName("För- och efternamn")]
        public string Name { get; set; }
        public JudgmentModel CurrentJudgment { get; set; }

        const string ConstantSalt = "jsh#js!fd54sad12fds9!#";
        [ScaffoldColumn(false)]
        protected string HashedPassword { get; private set; }
        [ScaffoldColumn(false)]
        private string PasswordSalt {
            get
            {
                return _passwordSalt ?? (_passwordSalt = Guid.NewGuid().ToString("N"));
            }
            set { _passwordSalt = value; }
        }
        private string _passwordSalt;
        public User SetPassword(string pwd) {
            HashedPassword = GetHashedPassword(pwd);
            return this;
        }
        private string GetHashedPassword(string pwd) {
            using (var sha = SHA256.Create()) {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(PasswordSalt + pwd + ConstantSalt));
                return Convert.ToBase64String(computedHash);
            }
        }
        public bool ValidatePassword(string maybePwd) {
            if (HashedPassword == null)
                return true;
            return HashedPassword == GetHashedPassword(maybePwd);
        }



        [DisplayName("Visa publikt")]
        public bool IsPublic { get; set; }        
    }
}