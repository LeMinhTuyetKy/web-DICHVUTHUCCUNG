using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using clonePetService.iService;

namespace clonePetService.service
{
    public class ShopService : iShopService
    {
        public async Task<Int32> Login(string emplyeeCode, string password)
        {
                
            return 1;
        }
    }
    
}