using System;

namespace ProductiveBob_Firebase
{
    public class Session
    {
        public string DeviceID { get; set; }
        public Guid ID { get; set; }
        public int Rating { get; set; }
        public TimeSpan Duration { get; set; }
        public string Timestamp { get; set; }
    }
}
