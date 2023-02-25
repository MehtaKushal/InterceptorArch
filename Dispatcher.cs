using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public class Dispatcher
    {
        private List<IInterceptor> _interceptors;

        public Dispatcher(List<IInterceptor> interceptors)
        {
            _interceptors = interceptors;
        }
        //attach, detach to remove interceptor
        public void Dispatch(IContext context)
        {
            foreach (var interceptor in _interceptors)
            {
                interceptor.Invoke(context);
            }
        }
    }
}
