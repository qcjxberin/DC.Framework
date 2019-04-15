using Microsoft.EntityFrameworkCore;

namespace Ding.TimedJob.EntityFramework
{
    public interface ITimedJobContext
    {
        DbSet<TimedJob> TimedJobs { get; set; }

        int SaveChanges();
    }
}
