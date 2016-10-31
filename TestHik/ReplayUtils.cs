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

        private bool GetReplayTimeInterval(int sOre, int sMinute, ref CHCNetSDK.NET_DVR_TIME startTime, ref CHCNetSDK.NET_DVR_TIME stopTime)
        {
            if (TimeDVRUpdate())
            {
                DateTime d0 = GetDate(timeDVR), d1 = GetDate(timeDVR);
                d0 = d0.AddHours(sOre * -1);
                d0 = d0.AddMinutes(sMinute * -1);

                d1 = d1.AddHours(3);

                UpDvrDate(d0, ref startTime);
                UpDvrDate(d1, ref stopTime);
                return true;
            }
            return false;
        }



    }
}
