using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Service.Implemention
{
    public class OTPService : IOTPService
    {
        public string GenerateOTP(int length)
        {
            Random random = new Random();
            return new string(Enumerable.Range(0, length).Select(_ => (char)('0' + random.Next(0, 10))).ToArray());
        }
    }
}
