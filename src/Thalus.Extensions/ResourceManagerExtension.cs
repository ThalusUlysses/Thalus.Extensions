using System.Collections.Generic;
using System.Resources;

namespace Thalus.Extensions
{
    public static class ResourceManagerExtension
    {
        static readonly Dictionary<ResourceManager,ResourceManagerFluent>  FluentCache = new Dictionary<ResourceManager, ResourceManagerFluent>();

        public static ResourceManagerFluent Get(this ResourceManager m, string resourceId = null)
        {
            lock (FluentCache)
            {
                if (!FluentCache.TryGetValue(m, out var fluent))
                {
                    fluent = new ResourceManagerFluent(m);
                    FluentCache[m] = fluent;
                }

                return fluent;
            }
        }
    }
}