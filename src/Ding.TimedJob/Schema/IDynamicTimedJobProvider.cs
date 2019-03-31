using System.Collections.Generic;

namespace Ding.TimedJob.Schema
{
    public interface IDynamicTimedJobProvider
    {
        IList<DynamicTimedJob> GetJobs();
    }
}
