using Ding.TimedJob.Schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ding.TimedJob.EntityFramework
{
    [Table("AspNetTimedJobs")]
    public class TimedJob : DynamicTimedJob
    {
    }
}
