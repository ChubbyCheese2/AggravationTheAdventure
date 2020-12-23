using System.Collections.Generic;

namespace Aggravation
{
    public class Job
    {
        public int TimeDelay { get; set; }
        public string ApplicationPath { get; set; }
        public List<string> Parameters { get; set; }

    }
}