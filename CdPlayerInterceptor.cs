using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public class CdPlayerInterceptor : IInterceptor
    {
        // Add additional functionality kind of a logger and a file logger
        public void Invoke(IContext context)
        {
            var buttonContext = context as ButtonContext;
            string buttonName = buttonContext.button.getName();
            string logMessage = $"{DateTime.Now}: {buttonName} button pushed";
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
