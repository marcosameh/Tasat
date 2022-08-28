using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicData.Admin.DTO
{
    public class UserModel
    {
        public string Email { get; set; }
        public string ActivationLink { get; set; }
        public string ResetPasswordLink { get; set; }
        public string LoginLink { get; set; }
        public string Password { get; set; }
    }
}
