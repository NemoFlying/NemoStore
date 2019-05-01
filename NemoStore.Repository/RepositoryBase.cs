using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.Repository
{
    public class RepositoryBase
    {
        public ILogger Logger { get; set; } = NullLogger.Instance;
        public RepositoryBase(ILogger logger)
        {
            Logger = logger;
        }
    }
}
