using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vepeeta.Service.Abstract
{
    public interface IAppUserService
    {
        public Task<bool> IsEmailExistExcludeSelf(string id, string email);
    }
}
