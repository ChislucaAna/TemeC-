using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport
{
    public class Session
    {
        public int Start;
        public int End;
        public string ExerciseType;
        public int IntensityLevel;
        public string description;

        public Session(int start, int end, string exerciseType, int intensityLevel, string description)
        {
            Start = start;
            End = end;
            ExerciseType = exerciseType;
            IntensityLevel = intensityLevel;
            this.description = description;
        }

        public override string ToString()
        {
            return Start+";"+End+";"+ExerciseType+";"+IntensityLevel+";"+description;
        }
    }
}
