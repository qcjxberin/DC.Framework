using System.Collections.Generic;

namespace Ding.Turing
{
    public class TuringResponse
    {
        public TuringIntent Intent { get; set; }
        public List<TuringResponseResult> Results { get; set; }
    }
}
