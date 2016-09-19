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
        // ------------------------------------- 

        //private readonly object m_repLock = new object();

        private CHCNetSDK.PLAYDATACALLBACK_V40 m_rep_CallBack;
        private fDisplayCallBack_Hik m_rep_DisplayCallBack;

        private CHCNetSDK.NET_DVR_TIME
            startTime = new CHCNetSDK.NET_DVR_TIME(),
            stopTime = new CHCNetSDK.NET_DVR_TIME();

        //CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond = new CHCNetSDK.NET_DVR_FILECOND_V40();
        CHCNetSDK.NET_DVR_VOD_PARA pVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();

        int m_rep_oreInMinus = 3; // diferenta de ore intre timp local si UTC ( timp de referinta)
        int m_rep_canal = 39;
        int m_rep_setOre = 3; // inregistarea sa inceapa de acum minus m_rep_setOre, m_rep_setMin
        int m_rep_setMin = 2;
        //int m_rep_foundHandle = -5; // record file pentru
        int m_repPath; // 1:play 2:stop 3:reverse 30: fast forward
        int m_repBuffSz = 3000 * 1024; // buffer size
        int m_repRecordHandle;

        int pbb; // PlayBackByTime return value 
        uint LPOutValue = 0; // PlayBackControl return value by ref        
        bool spdc; // SetPlayDataCallBack return value

        bool m_repPlayOrPause;

        int m_repPlayerPort = -1;

        // ------------------------------------- 


        //  DisplayCallBack_Hik e folosit si de RealPlay si de Replay


        /// <summary>
        /// Incepe procedura de replay pentru ce e salvat pe DVR
        /// </summary>
        /// <param name="canal">Canalul salvarii. Pentru -1 si !on nu va face update de imagine</param>
        /// <param name="directie">1: play 2:stop </param>
        private void SetReplay(int canal, int directie)
        {
            switch (directie)
            {
                case 1: // play normal forwards
                case 3: // play normal backwards
                case 4: // play by frame
                case 10: // fast forward
                case 11:
                    {
                        m_repPath = directie;
                        SetReplay(-1, 2); // stop replay
                        CloseVideo(); // stop si real-play, daca e nevoie, do eet .. 

                        SetReplayCtrlsVisibility(true, true);

                        GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref startTime, ref stopTime);

                        // caut fisierele existente in intervalul de timp si canalul specificat                       
                        /*
                        struFileCond.lChannel = canal;
                        struFileCond.struStartTime = startTime;
                        struFileCond.struStopTime = stopTime;

                        //---------------------------------------
                        //Find record file
                        m_rep_foundHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struFileCond);

                        //MessageBox.Show("struFileCond.struStartTime = " + struFileCond.struStartTime.dwHour.ToString());

                        if (m_rep_foundHandle < 0)
                        {
                            MessageBox.Show(string.Format("WARNING: FindFile failed for channel {0}. Last SDK error: {1}", canal, CHCNetSDK.NET_DVR_GetLastError()));
                        }
                        else // jump around cu findNext
                        {

                            CHCNetSDK.NET_DVR_FINDDATA_V40 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V40();

                            struFileData.struStartTime = startTime;
                            struFileData.struStopTime = stopTime;

                            //msg.Format(_T("REPORT: Searching files for channel %d..."), ch);

                            int result = 0;
                            int nTotalFiles = 0;
                            do
                            {
                                result = CHCNetSDK.NET_DVR_FindNextFile_V40(m_rep_foundHandle, ref struFileData);

                                if (result == CHCNetSDK.NET_DVR_ISFINDING)
                                {
                                    continue;
                                }
                                else
                                if (result == CHCNetSDK.NET_DVR_FILE_SUCCESS)
                                {
                                    ++nTotalFiles;
                                }
                                else
                                {
                                    if (result == CHCNetSDK.NET_DVR_FILE_NOFIND || result == CHCNetSDK.NET_DVR_NOMOREFILE)
                                    {
                                        //MessageBox.Show("No (more) files for this channel!");
                                    }
                                    else
                                    {
                                        //MessageBox.Show(string.Format("Unable to FindNextFile() due to a unknown state! NET SDK err = {0}", CHCNetSDK.NET_DVR_GetLastError()));
                                    }
                                    break;
                                }

                            } while (result == CHCNetSDK.NET_DVR_FILE_SUCCESS || result == CHCNetSDK.NET_DVR_ISFINDING);

                        }

                        // Stop finding
                        CHCNetSDK.NET_DVR_FindClose_V30(m_rep_foundHandle);*/

                        //MessageBox.Show(result.ToString());

                        /*
                        MessageBox.Show(string.Format(
                            " ... found record on channel {0} from [{1}-{2}-{3} {4}:{5}:{6} - {7}-{8}-{9} {10}:{11}:{12}]",
                            canal,
                            startTime.dwDay,
                            startTime.dwMonth,
                            startTime.dwYear,
                            startTime.dwHour,
                            startTime.dwMinute,
                            startTime.dwSecond,
                            stopTime.dwDay,
                             stopTime.dwMonth,
                              stopTime.dwYear,
                               stopTime.dwHour,
                                stopTime.dwMinute,
                                 stopTime.dwSecond));
                                 */

                        pVodPara.struBeginTime = startTime;
                        pVodPara.struEndTime = stopTime;
                        pVodPara.struIDInfo.dwChannel = (uint)canal;

                        pbb = CHCNetSDK.NET_DVR_PlayBackByTime_V40(m_lUserID, ref pVodPara);
                        //pbb = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, canal, ref startTime, ref stopTime, new IntPtr(m_lRealHandle));
                        //pbb = CHCNetSDK.NET_DVR_PlayBackByName(m_lUserID, struFileData.sFileName, new IntPtr(m_lRealHandle));

                        if (pbb < 0)
                        {
                            MessageBox.Show("NET_DVR_PlayBackByTime_V40 failed");
                            return;
                        }


                        bool pbRetVal = false;
                        pbRetVal = CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);

                        /*
                            switch (m_repPath)
                            {
                                case 1:
                                case 3:
                                case 4:
                                case 10:
                            case 11:
                                 
                                    break;

                            }*/

                        //if (CHCNetSDK.NET_DVR_PlayBackControl(pbb, CHCNetSDK.NET_DVR_PLAYSTART, 0, ref LPOutValue))
                        if (pbRetVal)
                        {


                            //bool doi = false;
                            //do                            {
                            spdc = CHCNetSDK.NET_DVR_SetPlayDataCallBack_V40(pbb, m_rep_CallBack, (uint)m_lUserID);
                            //} while (!spdc);

                            //MessageBox.Show("NET_DVR_SetPlayDataCallBack returned: " + spdc.ToString()); 
                        }


                    }
                    break;
                case 2: // stop replay
                    {
                        //m_rep_CallBack = null;
                        //m_rep_DisplayCallBack = null;

                        // Stop any ongoing playback
                        CHCNetSDK.NET_DVR_StopPlayBack(pbb);

                        if (m_repPlayerPort >= 0)
                        {
                            PlayM4_Stop(m_repPlayerPort);
                            PlayM4_CloseStream(m_repPlayerPort);
                            PlayM4_FreePort(m_repPlayerPort);
                            m_repPlayerPort = -1;
                        }


                        //System.Threading.Thread.Sleep(100);



                        if (canal != -1)
                        {
                            SetReplayCtrlsVisibility(false, true);
                            if (pictureBox1.BackgroundImageLayout != ImageLayout.Center)
                                pictureBox1.BackgroundImageLayout = ImageLayout.Center;
                            pictureBox1.BackgroundImage = global::TestHik.Properties.Resources.CAVI_square;
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        private void SetReplayCtrlsVisibility(bool v, bool pause)
        {
            if (pause) btnRepPause.Visible = v;
            btnRepBack.Visible = v;
            btnRepFF.Visible = v;
            btnRepImgF.Visible = v;
            btnRepImgB.Visible = v;
            btnRepRevert.Visible = v;
            btnRepRec.Visible = v;

            btnRepFF.Text = ">>";

            if (pause)
            {
                m_repPlayOrPause = false;
                btnRepPause.Text = "Pause";
            }
        }

        private void ReplayCallBack(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, uint dwUser)
        //Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, int dwBufSize, IntPtr pUser
        {
            //Monitor.Enter(buffer);

            //BeginInvoke((Action)(() => { byte[] bInfo = new byte[dwBufSize]; }));

            if (dwDataType == CHCNetSDK.NET_DVR_SYSHEAD && dwBufSize > 0)
            {
                int port = -1;
                if (PlayM4_GetPort(ref port) != 0)
                {
                    if (port >= 0)
                    {
                        //#define STREAME_REALTIME 0 #define STREAME_FILE 1
                        if (PlayM4_SetStreamOpenMode(port, 1) != 0) //STREAME_REALTIME == 0
                        {
                            byte byFileHeadBuf;
                            if (PlayM4_OpenStream(port, out byFileHeadBuf, (int)dwBufSize, m_repBuffSz) != 0)
                            {
                                if (((m_repPath == 10) ? PlayM4_Fast(port) : PlayM4_Play(port, IntPtr.Zero)) != 0)  //Start play
                                {

                                    if (PlayM4_SetDisplayCallBack(port, m_rep_DisplayCallBack) == 0)
                                    {
                                        PlayM4_Stop(port);
                                        PlayM4_CloseStream(port);
                                        PlayM4_FreePort(port);
                                        port = -1;
                                        MessageBox.Show("PlayM4_SetDisplayCallBack Failed!");
                                    }
                                }
                                else
                                {
                                    PlayM4_CloseStream(port);
                                    PlayM4_FreePort(port);
                                    port = -1;
                                    MessageBox.Show("PlayM4_Play Failed!");
                                }
                            }
                            else
                            {
                                PlayM4_FreePort(port);
                                port = -1;
                                MessageBox.Show("PlayM4_OpenStream Failed!");
                            }
                        }
                        else
                        {
                            PlayM4_FreePort(port);
                            port = -1;
                            MessageBox.Show("PlayM4_SetStreamOpenMode Failed!");
                        }
                    }
                }
                else MessageBox.Show("PlayM4_GetPort Failed!");

                if (port > 0) m_repPlayerPort = port;
            }
            else if ((dwDataType == CHCNetSDK.NET_DVR_STREAMDATA || dwDataType == 10 || dwDataType == 11)
                && dwBufSize > 0 && m_repPlayerPort >= 0)
            {
                unsafe
                {
                    PlayM4_InputData(m_repPlayerPort, (byte*)pBuffer.ToPointer(), (int)dwBufSize);
                }
            }

        }


        private void GetReplayTimeInterval(int sOre, int sMinute, ref CHCNetSDK.NET_DVR_TIME startTime, ref CHCNetSDK.NET_DVR_TIME stopTime)
        {
            DateTime dt = DateTime.UtcNow;

            //CHCNetSDK.VODGetStreamCurrentTime
            //CHCNetSDK.NET_DVR_TIME

            int ora = dt.Hour + m_rep_oreInMinus;

            // Stop time
            stopTime.dwSecond = (uint)dt.Second;
            stopTime.dwMinute = (uint)dt.Minute;
            stopTime.dwHour = (uint)(ora);
            stopTime.dwDay = (uint)dt.Day;
            stopTime.dwMonth = (uint)dt.Month;
            stopTime.dwYear = (uint)dt.Year;

            // Start time
            bool minOverLimit = (sMinute > dt.Minute), oreOverLimit = (sOre > ora);

            startTime.dwSecond = (uint)dt.Second;
            startTime.dwMinute = (uint)(dt.Minute - sMinute + (minOverLimit ? 60 : 0));
            startTime.dwHour = (uint)(ora - sOre + (oreOverLimit ? 12 : 0) - (minOverLimit ? 1 : 0));

            startTime.dwDay = (uint)(dt.Day - (oreOverLimit ? 1 : 0));
            startTime.dwMonth = (uint)dt.Month;
            startTime.dwYear = (uint)dt.Year;
        }

        private void ReplayInit()
        {
            SetReplayCtrlsVisibility(false, true);

            txtRepCh.Text = m_rep_canal.ToString();
            txtRepOre.Text = m_rep_setOre.ToString();
            txtRepMin.Text = m_rep_setMin.ToString();

            m_rep_CallBack = new CHCNetSDK.PLAYDATACALLBACK_V40(ReplayCallBack);
            m_rep_DisplayCallBack = new fDisplayCallBack_Hik(DisplayCallBack_Hik);

            pVodPara.struIDInfo = new CHCNetSDK.NET_DVR_STREAM_INFO();
            pVodPara.byDrawFrame = 0;
            pVodPara.hWnd = new IntPtr(1025); // poate e schimbata la ref din NET_DVR_PlayBackByTime_V40, dar sigur cu 0 intra in iterare
            pVodPara.dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(pVodPara);

            /*
            struFileCond.dwFileType = 0xFF;
            struFileCond.dwIsLocked = 0xFF;
            struFileCond.dwUseCardNo = 0;*/

            // Click InitSDk & Login :
            button2_Click(null, null);
            button1_Click(null, null);
        }

        private void txtRepCh_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(txtRepCh.Text, out m_rep_canal);
        }

        private void txtRepMin_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(txtRepMin.Text, out m_rep_setMin);
        }

        private void txtRepOre_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(txtRepOre.Text, out m_rep_setOre);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

            if (m_repPlayOrPause)
            {
                PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
                //PlayM4_RefreshPlay(m_repPlayerPort);
                CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                CHCNetSDK.NET_DVR_RefreshPlay(pbb);
            }
            else
            {
                int ip = 0;
                bool rval = false;
                int maxIp = 256;
                do
                {
                    rval = CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYPAUSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                    rval &= PlayM4_Pause(m_repPlayerPort, 1);
                    ++ip;
                } while (!rval && (ip < maxIp));
            }

            m_repPlayOrPause = !m_repPlayOrPause;

            btnRepPause.Text = m_repPlayOrPause ? "Play" : "Pause";

            btnRepFF.Text = ">>";
            m_repPath = 1;

            btnRepPause.Update();
            SetReplayCtrlsVisibility(!m_repPlayOrPause, !m_repPlayOrPause);
        }


        private void btnRepRevert_Click(object sender, EventArgs e)
        {
            /*
            CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);

            
            GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref startTime, ref stopTime);


            CHCNetSDK.NET_DVR_PLAYCOND pPlayCond = new CHCNetSDK.NET_DVR_PLAYCOND();
            pPlayCond.struStartTime = startTime;
            pPlayCond.struStopTime = stopTime;
            pPlayCond.dwChannel = (uint)m_rep_canal;
            pPlayCond.byDrawFrame = 0;


            pbb = CHCNetSDK.NET_DVR_PlayBackReverseByTime_V40(m_lUserID, new IntPtr(m_rep_foundHandle), ref pPlayCond);

            //
            CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);






            CHCNetSDK.NET_DVR_RefreshPlay(pbb);


            */



            /*
            
            CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);

            PlayM4_ReversePlay(m_repPlayerPort);*/

            //SetReplay(-1, 2, false);
            //SetReplay(m_rep_canal, 3, true);
            //PlayM4_RefreshPlay(m_repPlayerPort);
            //int u = (int)CHCNetSDK.NET_DVR_GetLastError();
            //MessageBox.Show(""+ CHCNetSDK.NET_DVR_GetErrorMsg(ref u).ToString());
            //PlayM4_ReversePlay(m_repPlayerPort);

            //CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_rev, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);

            //if (!m_repBtn_Play) btnPause_Click(null, null);

            //PlayM4_Stop(m_repPlayerPort);

            //CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            //CHCNetSDK.NET_DVR_RefreshPlay(pbb);
        }

        // jump to next image
        private void btnRepImgF_Click(object sender, EventArgs e)
        {
            //SetReplay(-1, 2, false);
            //SetReplay(m_rep_canal, 4, true);
            // get next image
            m_repPath = 4;
            //PlayM4_Stop(m_repPlayerPort);
            CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            PlayM4_OneByOne(m_repPlayerPort);
            //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
            //SetReplay(m_repPlayerPort, 4, false);

        }

        // play in reverse direction
        private void btnRepImgB_Click(object sender, EventArgs e)
        {
            m_repPath = 5;

            //PlayM4_Stop(m_repPlayerPort);

            PlayM4_OneByOneBack(m_repPlayerPort);
            //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
            //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);


        }

        // Start replay
        private void button15_Click(object sender, EventArgs e)
        {
            SetReplay(-1, 2);
            SetReplay(m_rep_canal, 1);
        }

        // Stop replay, open real play
        private void btnRepBack_Click(object sender, EventArgs e)
        {
            SetReplay(-1, 2);
            SetReplayCtrlsVisibility(false, true);
            OpenVideo();
        }

        // Start fast forward replay
        private void btnRepFF_Click(object sender, EventArgs e)
        {
            //PlayM4_Stop(m_repPlayerPort);
            PlayM4_Pause(m_repPlayerPort, 1);
            if (m_repPath == 30)
            {
                //m_repBuffSz = 4000 * 1024; // buffer size
                m_repPath = 1;
                CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
                btnRepFF.Text = ">>";
            }
            else
            {
                //m_repBuffSz = 7000 * 1024; // buffer size
                m_repPath = 30;
                CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                PlayM4_Fast(m_repPlayerPort);
                btnRepFF.Text = ">";
            }

            //SetReplay(-1, 2, false);
            //SetReplay(m_rep_canal, 10, true);
            //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
            //CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
        }


        // record _> test 2 min
        private void btnRepRec_Click(object sender, EventArgs e)
        {
            
            if (!bSavingStream)
            {
                PrepareDebugOutputBinary();
                string sFilePath = sDebugPath + sDebugFileName;
                sFilePath = "c:\\__\\kk.mp4";

                CHCNetSDK.NET_DVR_PLAYCOND pDownloadCond = new CHCNetSDK.NET_DVR_PLAYCOND();
                GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref startTime, ref stopTime);
                pDownloadCond.struStartTime = startTime;
                pDownloadCond.struStopTime = stopTime;
                pDownloadCond.dwChannel = (uint)m_rep_canal;

                m_repRecordHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, "c:\\__\\test.mp4", ref pDownloadCond);
                if (m_repRecordHandle < 0)
                {
                    int err = (int)CHCNetSDK.NET_DVR_GetLastError();
                    MessageBox.Show("NET_DVR_GetFileByTime_V40 fail,last error %d\n"+ err.ToString());
                     return;
                }

                //---------------------------------------
                //Start downloading
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_repRecordHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero,0, IntPtr.Zero,ref LPOutValue))
                {
                    MessageBox.Show("play back control_V40 failed [%d]\n"+ CHCNetSDK.NET_DVR_GetLastError());
                    return;
                }

                /*
                int nPos = 0;
                for (nPos = 0; nPos < 100 && nPos >= 0; nPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_repRecordHandle))
                {
                    System.Threading.Thread.Sleep(5000);  //millisecond
                }*/
                bSavingStream = true;

            }
            else
            {
                CHCNetSDK.NET_DVR_StopGetFile(m_repRecordHandle);
                bSavingStream = false;
            }

            




            //-----------------------------



            /*
            if (!bSavingStream)
            {
                PrepareDebugOutputBinary();
                string sFilePath = sDebugPath + sDebugFileName;
                if (CHCNetSDK.NET_DVR_SaveRealData_V30(m_lRealHandle, 2, sFilePath))
                {
                    button14.Text = "Stop saving";
                    bSavingStream = true;
                    BeginInvoke(new MyDebugInfo(DebugInfo), "start recording...");
                }
            }
            else
            {
                CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle);
                button14.Text = "Save stream";
                bSavingStream = false;
                BeginInvoke(new MyDebugInfo(DebugInfo), "recording stopped!");
            }
            */

        }




    }
}
