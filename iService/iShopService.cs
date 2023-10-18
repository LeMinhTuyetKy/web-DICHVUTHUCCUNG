using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace clonePetService.iService
{
    public interface iShopService
    {
           Task<Int32> Login(string emplyeeCode, string password);
        
    }
}