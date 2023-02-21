using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public class CdPlayerInterceptor : IInterceptor
    {
        /*private CdPlayer _cdPlayer;

        public CdPlayerInterceptor(CdPlayer cdPlayer)
        {
            _cdPlayer = cdPlayer;
        }*/

        public void Invoke(IContext context)
        {
            var buttonContext = context as ButtonContext;
            buttonContext.notifyButtonPushed();
        }
    }
}
