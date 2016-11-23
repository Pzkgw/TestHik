using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHik
{
    public partial class Form1 : Form
    {
        //struct FRAME_POS { long nFilePos; long nFrameNum; long nFrameTime; };
        public delegate void funVerify(int nPort, IntPtr pFilePos, uint bIsVideo, uint nUser);

        public delegate void FileEndCallback(int nPort, IntPtr pUser);

        FileEndCallback fepb;
        void FileEnd(int nPort, IntPtr pUser)
        {
            BeginInvoke(del, "FILE END");
        }

        public delegate void FileRefDoneCallback(int nPort, IntPtr pUser);
        FileRefDoneCallback ferb;
        void FileRef(int nPort, IntPtr pUser)
        {
            BeginInvoke(del, "FILE REF");
        }

        // get current DVR time --> timeDVR
        private bool TimeDVRUpdate()
        {
            uint bytesRet = 0;
            if (CHCNetSDK.NET_DVR_GetDVRConfig(
                    m_lUserID,
                    CHCNetSDK.NET_DVR_GET_TIMECFG,
                    0,
                    timePtr_DVR,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(timeDVR),
                    ref bytesRet))
            {
                timeDVR = (CHCNetSDK.NET_DVR_TIME)MarshalToStruct(timePtr_DVR, typeof(CHCNetSDK.NET_DVR_TIME));
                //BeginInvoke(del, "TIMPMIN: " + timeDVR.dwMinute.ToString());
                return true;
            }

            return false;
        }

        private DateTime GetDate(CHCNetSDK.NET_DVR_TIME t)
        {
            return new DateTime((int)t.dwYear, (int)t.dwMonth, (int)t.dwDay, (int)t.dwHour, (int)t.dwMinute, (int)t.dwSecond);
        }

        private void UpDvrDate(DateTime d, ref CHCNetSDK.NET_DVR_TIME t)
        {
            t.dwYear = (uint)d.Year;
            t.dwMonth = (uint)d.Month;
            t.dwDay = (uint)d.Day;
            t.dwHour = (uint)d.Hour;
            t.dwMinute = (uint)d.Minute;
            t.dwSecond = (uint)d.Second;
        }

        private void UpDvrDate(CHCNetSDK.NET_DVR_TIME t0, ref CHCNetSDK.NET_DVR_TIME t)
        {
            t.dwYear = t0.dwYear;
            t.dwMonth = t0.dwMonth;
            t.dwDay = t0.dwDay;
            t.dwHour = t0.dwHour;
            t.dwMinute = t0.dwMinute;
            t.dwSecond = t0.dwSecond;
        }

        private bool GetReplayTimeInterval(int sDays, int sOre, int sMinute, ref DateTime t1, ref DateTime t2)
        {
            if (TimeDVRUpdate())
            {
                t1 = GetDate(timeDVR);
                t2 = t1;
                t1 = t1.AddDays(sDays * -1);
                t1 = t1.AddHours(sOre * -1);
                t1 = t1.AddMinutes(sMinute * -1);

                t2 = t2.AddDays(1);

                return true;
            }
            return false;
        }

        private int GetSeconds(CHCNetSDK.NET_DVR_TIME t)
        {
            return (int)(t.dwHour * 3600 + t.dwMinute * 60 + t.dwSecond);
        }

    }
}
