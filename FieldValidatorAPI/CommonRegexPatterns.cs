using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public class CommonRegexPatterns
    {
        public const string PasswordRegex = "^([a-zA-Z0-9@*#]{8,15})$";
        public const string PhoneNumberRegex = "^[2-9]\\d{2}-\\d{3}-\\d{4}$";

    }
}
