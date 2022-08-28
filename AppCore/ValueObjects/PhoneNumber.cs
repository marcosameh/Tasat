using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ValueObjects
{
    public class PhoneNumber
    {
        private string nonFormattedNumber;
        private string formattedNumber;
        public string NonFormattedNumber
        {
            get
            {
                return nonFormattedNumber;
            }
        }

        public string FormattedNumber
        {
            get
            {
                return formattedNumber;
            }
        }

        public string WhatsAppFormat
        {
            get
            {
                if (this.nonFormattedNumber.Substring(0, 2) == "00")
                {
                    return nonFormattedNumber.Substring(2);
                }
                return nonFormattedNumber;
            }
        }

        public PhoneNumber(string number)
        {
            formattedNumber = number;
            if (!string.IsNullOrEmpty(number))
            {
                this.nonFormattedNumber = number.Replace("+", "00").Replace("-", "").Replace(" ", "");
            }
        }
    }
}
