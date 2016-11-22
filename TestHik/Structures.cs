using System;

namespace TestHik
{
    class ReplayData
    {
        public bool achievement_FileHasBeenFound;
        public bool achievement_PlaybackStarted;
        public bool achievement_FirstFrameHasAppeared;

        public int speed; // 0:  pause, 1: running, 2: fast forward

        public int canal;
        public uint playSecondsPre = 666; //    last played seconds value
        public uint playSecondsCur = 0; // current played seconds value

        public string fileName;
        public DateTime timeStartA; // timpul de start pentru tot intervalul
        public DateTime timeStartB; // timpul de start al fisierului curent
        public int timeInSecondsB = -2; // timpul de stop(nu si data), in secunde

        public byte type; // 0 - play, 1 - restart for next-file-continue, 2 - restart from begin
        public int handle; // play handle, PlayBackByTime return value 

        public int playTimeContinous; // play time in seconds until the DVR file end will be reached
    }

    struct ReplaySettings
    {
        public const int maxFileFindLoops = 0x100;  // de cate ori de incearca gasirea fisierului pe interval
        public const int maxFileTimePlay = 4199500; // valoarea maxima din teste pentru PlayM4_GetPlayedTime

        public struct TimeIntervalUpdate
        {
            public const int startValue = 7; // maximum start difference in second between wanted interval and DVR file stop time  
            public const int retryAfterFrames = 3; // after each retryAfterFrames, stop time receives interval update, a different retry
        }


    }
}
