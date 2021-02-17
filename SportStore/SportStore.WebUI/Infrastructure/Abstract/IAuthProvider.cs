using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        Boolean Authenticate(String username, String password);
    }
}
