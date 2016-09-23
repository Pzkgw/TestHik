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

        private bool GetReplayTimeInterval(int sOre, int sMinute, ref CHCNetSDK.NET_DVR_TIME startTime, ref CHCNetSDK.NET_DVR_TIME stopTime)
        {
            if (TimeDVRUpdate())
            {
                //CHCNetSDK.VODGetStreamCurrentTime
                //CHCNetSDK.NET_DVR_TIME

                uint ora = timeDVR.dwHour + m_rep_oreInMinus;

                // Stop time
                stopTime.dwSecond = timeDVR.dwSecond;
                stopTime.dwMinute = timeDVR.dwMinute;
                stopTime.dwHour = (ora);
                stopTime.dwDay = timeDVR.dwDay;
                stopTime.dwMonth = timeDVR.dwMonth;
                stopTime.dwYear = timeDVR.dwYear;

                // Start time
                bool minOverLimit = (sMinute > timeDVR.dwMinute), oreOverLimit = (sOre > ora);

                startTime.dwSecond = timeDVR.dwSecond;
                startTime.dwMinute = (uint)(timeDVR.dwMinute - sMinute + (minOverLimit ? 60 : 0));
                startTime.dwHour = (uint)(ora - sOre + (oreOverLimit ? 12 : 0) - (minOverLimit ? 1 : 0));

                startTime.dwDay = (uint)(timeDVR.dwDay - (oreOverLimit ? 1 : 0));
                startTime.dwMonth = timeDVR.dwMonth;
                startTime.dwYear = timeDVR.dwYear;
                return true;
            }
            return false;
        }



    }
}
