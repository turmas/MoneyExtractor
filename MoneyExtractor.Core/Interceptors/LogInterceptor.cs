using Dlp.Framework.Container.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Interceptors {

    public sealed class LogInterceptor : IInterceptor {

        public LogInterceptor() { }

        public void Intercept(IInvocation invocation) {

            try {
                // TODO: Log request.

                invocation.Proceed();
            }
            catch (Exception ex) {
            
                // TODO: Log exceção
            }

            // TODO: Log response.
        }
    }
}
