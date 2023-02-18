using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public interface IContext { }
    public interface IInterceptor
    {
        void Invoke(IContext context);
    }
}
