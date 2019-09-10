namespace Ding.Turing
{
    public class TuringRequest
    {
        public int ReqType { get; set; }
        public TuringRequestPerception Perception { get; set; }
        public TuringRequestUserInfo UserInfo { get; set; }
    }
}
