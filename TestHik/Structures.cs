using System;

namespace TestHik
{
    class ReplayData
    {
        public bool startBusy;
        public bool running;
        public bool paused;

        public int canal;
        public uint playSecondsPre = 666; //    last played seconds value
        public uint playSecondsCur = 0; // current played seconds value

        public string fileName;
        public DateTime timeStartA; // timpul de start pentru tot intervalul
        public DateTime timeStartB; // timpul de start al fisierului curent

        public byte type; // 0 - play, 1 - restart for next-file-continue, 2 - restart from begin
        public int handle; // play handle, PlayBackByTime return value 
    }
}
