﻿namespace StreamProgress
{
    public class StreamProgressInfo
    {
        private IStreamable stream;

        public StreamProgressInfo(IStreamable stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}