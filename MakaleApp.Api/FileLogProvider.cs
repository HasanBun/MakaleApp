using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleApp.Api
{
    public class FileLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string category)
        {
            return new FileLogger();
        }
        public void Dispose()
        {

        }
    }
}
