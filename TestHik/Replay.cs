using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHik
{
    public partial class Form1 : Form
    {
        public int nPlayerBufferSize = 0;
        public bool bStopCounting = false;

        // ------------------------------------- 
        private CHCNetSDK.PlayDataCallBack_V40 m_rep_CallBack;
        private fDisplayCallBack_Hik m_rep_DisplayCallBack;

        //private DateTime timpDeReferinta; // UTC curent
        private CHCNetSDK.NET_DVR_TIME timeDVR, timeStart, timeStop;
        private IntPtr timePtr_DVR, m_User;

        //CHCNetSDK.NET_DVR_CERT_PARAM struCertParam;       
        //CHCNetSDK.NET_DVR_PLAYCOND pPlayCond; // reverse play cond
        //CHCNetSDK.NET_DVR_PLAYCOND pDownloadCond;


        CHCNetSDK.NET_DVR_FINDDATA_V40 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V40();
        CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond = new CHCNetSDK.NET_DVR_FILECOND_V40();

        const uint m_rep_oreInMinus = 0; // diferenta de ore, daca exista
        int m_rep_canal = 39;
        int m_rep_setOre = 0; // inregistarea sa inceapa de acum minus m_rep_setOre, m_rep_setMin
        int m_rep_setMin = 2;
        int m_rep_foundHandle = -5; // record file pentru
        //int m_repPath; // 1:play 2:stop 3:reverse 30: fast forward
        const int bufferSize = 6 * 1024 * 1024;
        uint m_repBuffSz = bufferSize; // buffer size
        //byte[] m_repBuffb = new byte[bufferSize];
        //IntPtr m_repBuff;
        int m_repRecordHandle = -1;

        bool m_repFastPlay, m_repBackwardsPlay;

        ReplayData data;

        bool imgBool; // Image loop return value
        bool imgLoop; // ImageLoopTrueOrFalse
        uint LPOutValue = 0; // PlayBackControl return value by ref        
        bool playbackStart; // SetPlayDataCallBack return value

        bool m_repPlayOrPause;

        int m_repPlayerPort = -1;

        // ------------------------------------- 
        Delegate del; // log message delegate

        private void ReplayInit()
        {
            del = new MyDebugInfo(DebugInfo);
            SetReplayCtrlsVisibility(false, true);

            txtRepCh.Text = m_rep_canal.ToString();
            txtRepOre.Text = m_rep_setOre.ToString();
            txtRepMin.Text = m_rep_setMin.ToString();

            m_rep_CallBack = new CHCNetSDK.PlayDataCallBack_V40(ReplayCallBack);
            m_rep_DisplayCallBack = new fDisplayCallBack_Hik(DisplayCallBack_Hik);

            struFileCond.dwFileType = 0xFF;
            struFileCond.dwIsLocked = 0xFF;
            struFileCond.dwUseCardNo = 0;






            timePtr_DVR = MarshalToPointer(timeDVR);

            // pana aici sunt necesare
            //pDownloadCond.byDrawFrame = 0; // record replay

            fepb = new FileEndCallback(FileEnd);
            ferb = new FileRefDoneCallback(FileRef);

            /*
            unsafe
            {
                fixed (byte* p = m_repBuffb)
                {
                    m_repBuff = (IntPtr)p;
                    //IntPtr ptr = (IntPtr)p;
                    // do you stuff here
                }
            }*/




            // Click InitSDk & Login :
            button2_Click(null, null);
            button1_Click(null, null);
        }




        /// <summary>
        /// Incepe procedura de replay pentru ce e salvat pe DVR
        /// </summary>
        /// <param name="canal">Canalul salvarii. -1 si !on => !(update de imagine)</param>
        /// <param name="on">: play :stop </param>
        private void SetReplay(int canal, bool on)
        {

            {
                if (on)
                {
                    //if (canal == -2) PlayM4_Pause(m_repPlayerPort, 0);
                    if (data != null)
                    {
                        SetReplay(-1, false); // stop replay 
                        PlayM4_ResetSourceBuffer(m_repPlayerPort);
                        PlayM4_ResetSourceBufFlag(m_repPlayerPort);
                    }

                    if (canal >= 0)
                    {
                        //
                        CloseVideo(); // stop real-play, do eet .. daca e nevoie

                        SetReplayCtrlsVisibility(true, true);

                        GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref timeStart, ref timeStop);

                        data = new ReplayData();
                        data.canal = canal;
                        data.startBusy = true;
                        data.type = 0;
                        data.timeStartA = GetDate(timeStart);
                        data.timeStartB = data.timeStartA;
                    }

                    //if (TimeDVRUpdate()) UpDvrDate(GetDate(timeStop).AddDays(1), ref timeStop);

                    CHCNetSDK.NET_DVR_VOD_PARA pVodPara;
                    pVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();
                    pVodPara.struIDInfo = new CHCNetSDK.NET_DVR_STREAM_INFO();
                    pVodPara.dwSize = (uint)Marshal.SizeOf(pVodPara);
                    //pVodPara.byDrawFrame = 0;
                    pVodPara.hWnd = IntPtr.Zero; // poate e schimbata la ref din NET_DVR_PlayBackByTime_V40, dar sigur cu 0 intra in iterare


                    pVodPara.struIDInfo.dwChannel = (uint)data.canal;

                    switch (canal)
                    {// 0 - play, 1 - restart for next-file-continue, 2 - restart from begin
                        case -2: data.type = 1; break;
                        case -3: data.type = 2; break;
                        default: data.type = 0; break;
                    }

                    FindFiles(data);

                    pVodPara.struBeginTime = struFileCond.struStartTime;
                    pVodPara.struEndTime = struFileCond.struStopTime;

                    data.handle = CHCNetSDK.NET_DVR_PlayBackByTime_V40(m_lUserID, ref pVodPara);
                    //pbb = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, canal, ref startTime, ref stopTime, new IntPtr(m_lRealHandle));
                    //pbb = CHCNetSDK.NET_DVR_PlayBackByName(m_lUserID, struFileData.sFileName, new IntPtr(m_lRealHandle));

                    if (data.handle < 0)
                    {
                        BeginInvoke(del, "FAILED ->  Replay DVR FROM_ " + GetDate(timeStart).ToString() + " _TO_ " + GetDate(timeStop).ToString());
                        return;
                    }
                    else
                    {
                        /*
                                            IntPtr pUser = new IntPtr();

                                            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();

                                            lpPreviewInfo.lChannel = Convert.ToUInt16(textBox_Ch.Text); //35; // channel number starting from 1 (pentru analogice)
                                            lpPreviewInfo.dwStreamType = 1; // 0=mainstream, 1=sub-stream
                                            lpPreviewInfo.dwLinkMode = 0; // 0-tcp, 1-udp, 2-multicast, 3-rtp, 4-rtp/rtps, 5-rstp/http
                                            lpPreviewInfo.hPlayWnd = IntPtr.Zero;//pictureBox1.Handle;
                                            lpPreviewInfo.bBlocked = 0; // 0-non-blocking stream, 1-blocking stream;
                                            //lpPreviewInfo.dwDisplayBufNum = 5;

                                            m_fRealDataCallBack = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);

                                            m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, m_fRealDataCallBack, pUser);
                        */

                        playbackStart = CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                        //playbackStart &= CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYSTOPAUDIO, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);                    

                        if (playbackStart)
                        {
                            m_User = new IntPtr(m_lUserID);
                            playbackStart &= CHCNetSDK.NET_DVR_SetPlayDataCallBack_V40(data.handle, m_rep_CallBack, m_User);

                        }

                        //BeginInvoke(del, "NET_DVR_PlayBackControl_V40: " + playbackStart.ToString());

                    }

                }
                else
                {
                    // Stop any ongoing playback
                    CHCNetSDK.NET_DVR_StopPlayBack(data.handle);

                    //BeginInvoke(del, "NET_DVR_StopPlayBack: " + m_repPlayerPort.ToString() + " Canal: " + canal.ToString());

                    if (m_repPlayerPort >= 0)
                    {
                        PlayM4_Stop(m_repPlayerPort);

                        PlayM4_CloseStream(m_repPlayerPort);
                        PlayM4_FreePort(m_repPlayerPort);
                        //if (canal != -1) m_repPlayerPort = -1;
                    }

                    if (canal > 0)
                    {
                        SetReplayCtrlsVisibility(false, true);
                        if (pictureBox1.BackgroundImageLayout != ImageLayout.Center)
                            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
                        pictureBox1.BackgroundImage = global::TestHik.Properties.Resources.CAVI_square;
                    }
                }
            }
        }


        private void ReplayCallBack(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser)
        {
            uint dwErr = 0;
            switch (dwDataType)
            {
                case CHCNetSDK.NET_DVR_SYSHEAD:
                    if (m_repPlayerPort != -1)
                    {
                        PlayM4_Stop(m_repPlayerPort);
                        PlayM4_CloseStream(m_repPlayerPort);
                        PlayM4_FreePort(m_repPlayerPort);
                        m_repPlayerPort = -1;
                    }

                    if (!PlayM4_GetPort(ref m_repPlayerPort))
                    {
                        //dwErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                        BeginInvoke(del, "PlayM4_GetPort Failed!");
                    }

                    if (dwBufSize > 0)
                    {
                        if (!PlayM4_SetStreamOpenMode(m_repPlayerPort, 0))  //设置实时流播放模式
                        {
                            BeginInvoke(del, "PlayM4_SetStreamOpenMode Failed!");
                            break;
                        }

                        //if (!PlayM4_SetFileRefCallBack(m_repPlayerPort, ferb, IntPtr.Zero))  //设置实时流播放模式
                        {
                            // BeginInvoke(del, "PlayM4_SetFileRefCallBack Failed!");
                            //break;
                        }

                        // if (!PlayM4_SetFileEndCallback(m_repPlayerPort, fepb, IntPtr.Zero))  //设置实时流播放模式
                        {
                            //BeginInvoke(del, "PlayM4_SetStreamOpenMode Failed!");
                            //break;
                        }

                        if (!PlayM4_OpenStream(m_repPlayerPort, ref pBuffer, dwBufSize, 8 * 1024 * 1024)) //打开流接口
                        {
                            BeginInvoke(del, "PlayM4_OpenStream Failed!"); break;
                        }

                        /*
                        struFileCond.lChannel = pVodPara.struIDInfo.dwChannel;
                        struFileCond.struStartTime = timeStart;
                        struFileCond.struStopTime = timeStop;

                        m_rep_foundHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struFileCond);

                        CHCNetSDK.NET_DVR_FindNextFile_V40(m_rep_foundHandle, ref struFileData);


                        if (!PlayM4_OpenFile(m_repPlayerPort, struFileData.sFileName+ ".mp4"))
                        {
                            BeginInvoke(del, "PlayM4_OpenFile Failed!");
                            break;
                        }

                        if (!PlayM4_SetDisplayBuf(m_repPlayerPort, 15))
                        {
                            dwErr = PlayM4_GetLastError(m_repPlayerPort);
                            BeginInvoke(del, "PlayM4_SetDisplayBuf Failed!");
                            //MessageBox.Show(dwErr.ToString());
                            //break;
                        }*/


                        if (!PlayM4_Play(m_repPlayerPort, IntPtr.Zero))// m_EagleEyePanel.Handle)) //播放开始
                        {
                            BeginInvoke(del, "PlayM4_Play Failed!");
                            break;
                        }

                        if (!PlayM4_SetDisplayCallBack(m_repPlayerPort, m_rep_DisplayCallBack))
                        {
                            PlayM4_Stop(m_repPlayerPort);
                            PlayM4_CloseStream(m_repPlayerPort);
                            PlayM4_FreePort(m_repPlayerPort);
                            m_repPlayerPort = -1;
                            BeginInvoke(del, "PlayM4_SetDisplayCallBack Failed!");
                        }


                    }
                    break;
                default:
                    //case CHCNetSDK.NET_DVR_STREAMDATA:
                    if (dwBufSize > 0 && m_repPlayerPort >= 0)
                    {
                        /*
                        unsafe
                        {
                            PlayM4_InputData(m_repPlayerPort, (byte*)pBuffer.ToPointer(), dwBufSize);
                            //BeginInvoke(del, 
                            //PlayM4_InputVideoData(m_repPlayerPort, (byte*)pBuffer.ToPointer(), dwBufSize);
                        }*/

                        unsafe
                        {
                            byte* pb = (byte*)pBuffer.ToPointer();/*
                            for (int i = 0; i < int.MaxValue; i++)
                            {
                                if (!PlayM4_InputData(m_repPlayerPort, pb, dwBufSize))
                                {
                                    if (!bStopCounting)
                                    {
                                        BeginInvoke(del, "FIRST LOST PlayM4_InputData. Total player buffer size = " + nPlayerBufferSize.ToString());
                                        bStopCounting = true;
                                    }

                                    
                                }
                                else
                                {
                                    if (!bStopCounting)
                                        nPlayerBufferSize += (int)dwBufSize;
                                    break;
                                    //BeginInvoke(del, "!!!!!! ok !!! PlayM4_InputData size=" + dwBufSize.ToString());
                                }
                            }*/

                            {
                                {
                                    for (int i = 0; i < 999; i++)
                                    {
                                        // Into the stream decoding data Input the stream data to decode
                                        if (!PlayM4_InputData(m_repPlayerPort, pb, dwBufSize))
                                            Thread.Sleep(2);
                                        else
                                            break;
                                    }
                                }
                            }
                        }

                    }



                    break;
            }







            /*
                        if (CheckEagleEyeStream())//小鹰眼码流的特殊处理  -- 这个客户不用特殊关注
                        {
                            if (!PlayM4_SetDecodeEngineEx(m_repPlayerPort, HARD_DECODE_ENGINE))
                            {
                                break;
                            }

                            PLAYM4SRMODELMODE struParam = new PLAYM4SRMODELMODE();
                            struParam.emTextureMode = (uint)PLAYM4SRTEXTUREMODE.PLAYM4_TEXTURE_DOUBLE;
                            struParam.ulDisplayType = PLAYM4_MODEL_SOLID;
                            struParam.nTransformMode = 0;
                            struParam.emModelType = (uint)PLAYM4SRMODELTYPE.PLAYM4_MODELTYPE_EAGLE_EYE;
                            struParam.bModelMode = true; // true是碗装，false是块状

                            int dwSize = Marshal.SizeOf(struParam);
                            IntPtr ptrDeviceCfg = Marshal.AllocHGlobal(dwSize);
                            Marshal.StructureToPtr(struParam, ptrDeviceCfg, false);

                            if (!PlayM4_SR_SetConfig(m_repPlayerPort, CFG_DISPLAY_MODEL_MODE, ptrDeviceCfg))
                            {
                                Marshal.FreeHGlobal(ptrDeviceCfg);
                                break;
                            }
                            Marshal.FreeHGlobal(ptrDeviceCfg);
                        }*/






            /*

            if (!PlayM4_InputData(m_repPlayerPort, ref pBuffer, dwBufSize))
            {
                dwErr = PlayM4_GetLastError(m_repPlayerPort);
                return;
            }
        */











            //Monitor.Enter(buffer);
            // BeginInvoke(del, "ReplayCallBack!");
            //BeginInvoke((Action)(() => { byte[] bInfo = new byte[dwBufSize]; }));


            /*
            switch (dwDataType)
            {
                case CHCNetSDK.NET_DVR_SYSHEAD:

                    if (dwBufSize > 0)
                    {
                        int port = -1;
                        if (PlayM4_GetPort(ref port))
                        {
                            if (port >= 0)
                            {
                                //#define STREAME_REALTIME 0 #define STREAME_FILE 1
                                if (PlayM4_SetStreamOpenMode(port, 0)) //STREAME_REALTIME == 0
                                {
                                    IntPtr byFileHeadBuf = new IntPtr();
                                    //if (PlayM4_OpenStreamEx(port, ref byFileHeadBuf, (uint)dwBufSize, (uint)m_repBuffSz))
                                    if (PlayM4_OpenStream(port, ref byFileHeadBuf, dwBufSize, m_repBuffSz))
                                    {
                                        if (PlayM4_Play(port, IntPtr.Zero))  //Start play
                                        {
                                            if (PlayM4_SetDisplayCallBack(port, m_rep_DisplayCallBack) == 0)
                                            {
                                                PlayM4_Stop(port);
                                                PlayM4_CloseStream(port);
                                                PlayM4_FreePort(port);
                                                port = -1;
                                                BeginInvoke(del, "PlayM4_SetDisplayCallBack Failed!");
                                            }
                                        }
                                        else
                                        {
                                            PlayM4_CloseStream(port);
                                            PlayM4_FreePort(port);
                                            port = -1;
                                            BeginInvoke(del, "PlayM4_Play Failed!");
                                        }
                                    }
                                    else
                                    {
                                        PlayM4_FreePort(port);
                                        port = -1;
                                        BeginInvoke(del, "PlayM4_OpenStream Failed!");
                                    }
                                }
                                else
                                {
                                    PlayM4_FreePort(port);
                                    port = -1;
                                    BeginInvoke(del, "PlayM4_SetStreamOpenMode Failed!");
                                }
                            }
                        }
                        else
                        {
                            BeginInvoke(del, "PlayM4_GetPort Failed!");
                        }

                        //if (port > 0)
                        m_repPlayerPort = port;
                    }

                    BeginInvoke(del, "NET_DVR_SYSHEAD: System head data");
                    break; // 1 System head data

                case CHCNetSDK.NET_DVR_STREAMDATA:
                    if (dwBufSize > 0 && m_repPlayerPort >= 0)
                    {
                        unsafe
                        {
                            PlayM4_InputData(m_repPlayerPort, (byte*)pBuffer.ToPointer(), dwBufSize);
                            //BeginInvoke(del, 
                            //PlayM4_InputVideoData(m_repPlayerPort, (byte*)pBuffer.ToPointer(), dwBufSize);
                        }
                        //if (bSavingStream) CHCNetSDK.NET_DVR_PlayBackSaveData(pbb, sFilePathjj);

                        //BeginInvoke(del, CHCNetSDK.NET_DVR_GetPlayBackPos(pbb).ToString());


                    }
                    break; // 2 Stream data(compound stream or only video stream )

                case CHCNetSDK.NET_DVR_CHANGE_FORWARD:
                    {
                        BeginInvoke(del, "NET_DVR_CHANGE_FORWARD: Stream changed to forward play");
                    }
                    break; // 10 Stream changed to forward play

                case CHCNetSDK.NET_DVR_CHANGE_REVERSE:
                    {
                        BeginInvoke(del, "NET_DVR_CHANGE_REVERSE: Stream changed to reverse play");
                    }
                    break; // 11 Stream changed to forward play
            }*/
        }



        /*
IntPtr oo = new IntPtr(), oop = new IntPtr();
CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAYGETPOS, ref oop, 1, ref oo, ref LPOutValue);
BeginInvoke(del, oo.ToString() + LPOutValue.ToString() + oop.ToString());*/




        private void txtRepCh_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtRepCh.Text, out m_rep_canal);
        }

        private void txtRepMin_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtRepMin.Text, out m_rep_setMin);
        }

        private void txtRepOre_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtRepOre.Text, out m_rep_setOre);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

            if (m_repPlayOrPause)
            {
                if (imgLoop)
                {
                    PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
                    //PlayM4_RefreshPlay(m_repPlayerPort);
                    CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                    CHCNetSDK.NET_DVR_RefreshPlay(data.handle); // pentru mai multe in pauza -> NET_DVR_RefreshPlayEx face refresh pe tot ecranul
                }
                else
                {
                    PlayM4_Pause(m_repPlayerPort, 0);
                }

                imgLoop = false;
            }
            else
            {
                int ip = 0;
                bool rval = false;
                int maxIp = 256;
                do
                {
                    rval = CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYPAUSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                    rval &= PlayM4_Pause(m_repPlayerPort, 1);
                    ++ip;
                } while (!rval && (ip < maxIp));
            }

            m_repPlayOrPause = !m_repPlayOrPause;

            btnRepPause.Text = m_repPlayOrPause ? "Play" : "Pause";

            btnRepFF.Text = ">>";

            btnRepPause.Update();
            SetReplayCtrlsVisibility(!m_repPlayOrPause, !m_repPlayOrPause);
        }


        private void btnRepRevert_Click(object sender, EventArgs e)
        {

            //CHCNetSDK.NET_DVR_SetPlayDataCallBack_V40(pbb, m_rep_CallBack, (uint)m_lUserID);
            /*
            pPlayCond.struStartTime = timeStart;
            //pPlayCond.struStartTime.dwHour = (uint)(timpDeReferinta.Hour + m_rep_oreInMinus);
            //pPlayCond.struStartTime.dwMinute = (uint)timpDeReferinta.Minute;
            pPlayCond.struStopTime = timeStop;
            pPlayCond.dwChannel = (uint)m_rep_canal;
            pPlayCond.byDrawFrame = 1;

            pbb = CHCNetSDK.NET_DVR_PlayBackReverseByTime_V40(m_lUserID, new IntPtr(0), ref pPlayCond);
            //pbb = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, canal, ref startTime, ref stopTime, new IntPtr(m_lRealHandle));
            //pbb = CHCNetSDK.NET_DVR_PlayBackByName(m_lUserID, struFileData.sFileName, new IntPtr(m_lRealHandle));


            if (pbb < 0)
            {
                MessageBox.Show("NET_DVR_PlayBackByTime_V40 failed");
                return;
            }
            else
            {
                playbackStart = CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                if (PlayM4_ReversePlay(m_repPlayerPort)) BeginInvoke(del, " ->  DVR ReverseReplay Started");

            }

            //CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            */
            /*
            if (PlayM4_ReversePlay(m_repPlayerPort))  //Start play
            {
                if (PlayM4_SetDisplayCallBack(m_repPlayerPort, m_rep_DisplayCallBack) == 0)
                {
                    PlayM4_Stop(m_repPlayerPort);
                    PlayM4_CloseStream(m_repPlayerPort);
                    PlayM4_FreePort(m_repPlayerPort);
                    m_repPlayerPort = -1;
                    MessageBox.Show("PlayM4_SetDisplayCallBack Failed!");
                }
            }
            else
            {
                PlayM4_CloseStream(m_repPlayerPort);
                PlayM4_FreePort(m_repPlayerPort);
                m_repPlayerPort = -1;
                MessageBox.Show("PlayM4_Play Failed!");
            }*/
        }

        // jump to next image
        private void btnRepImgF_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYFRAME, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            imgBool = PlayM4_OneByOne(m_repPlayerPort);
            BeginInvoke(del, ("PlayM4_OneByOne: " + imgBool + " LastError: " + CHCNetSDK.NET_DVR_GetLastError()));
            CHCNetSDK.NET_DVR_RefreshPlay(data.handle);
            ImgLoop();
        }

        // play in reverse direction
        private void btnRepImgB_Click(object sender, EventArgs e)
        {
            imgBool = CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            imgBool &= CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYGETFRAME, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            //
            imgBool &= CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_START_DRAWFRAME, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            //imgBool &= CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_START_DRAWFRAME, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
            imgBool &= PlayM4_OneByOneBack(m_repPlayerPort);
            //




            /*
            CHCNetSDK.NET_DVR_StopPlayBack(pbb);

            if (m_repPlayerPort >= 0)
            {
                PlayM4_Stop(m_repPlayerPort);
            }*/


            //PlayM4_SetPlayedTimeEx(m_repPlayerPort, PlayM4_GetPlayedTimeEx(m_repPlayerPort) - 10);


            //PlayM4_SetCurrentFrameNum(m_repPlayerPort, PlayM4_GetCurrentFrameNum(m_repPlayerPort));
            //btnRepImgF_Click(null, null);
            /*
            timpDeReferinta = DateTime.UtcNow;
            pPlayCond.struStartTime = startTime;
            pPlayCond.struStartTime.dwHour = (uint)(timpDeReferinta.Hour + m_rep_oreInMinus);
            pPlayCond.struStartTime.dwMinute = (uint)timpDeReferinta.Minute;
            pPlayCond.struStopTime = stopTime;
            pPlayCond.dwChannel = (uint)m_rep_canal;
            pPlayCond.byDrawFrame = 0;

            pbb = CHCNetSDK.NET_DVR_PlayBackReverseByTime_V40(m_lUserID, new IntPtr(pbb), ref pPlayCond);

            if (pbb < 0)
            {
                MessageBox.Show("NET_DVR_PlayBackByTime_V40 failed");
                return;
            }
            else
            {
                spdc = CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                if (spdc) CHCNetSDK.NET_DVR_SetPlayDataCallBack_V40(pbb, m_rep_CallBack, (uint)m_lUserID);
            }

            imgBool = PlayM4_OneByOneBack(m_repPlayerPort);*/
            BeginInvoke(del, ("PlayM4_OneByOneBack: " + imgBool + " LastError: " + CHCNetSDK.NET_DVR_GetLastError()));

            CHCNetSDK.NET_DVR_RefreshPlay(data.handle);

            ImgLoop();
        }

        void ImgLoop()
        {
            imgLoop = true;

            m_repPlayOrPause = true;
            btnRepPause.Text = "Play";
        }

        // Start replay
        private void button15_Click(object sender, EventArgs e)
        {
            nPlayerBufferSize = 0;
            bStopCounting = false;
            SetReplay(m_rep_canal, true);
        }

        // Stop replay, open real play
        private void btnRepBack_Click(object sender, EventArgs e)
        {
            SetReplay(-1, false);
            SetReplayCtrlsVisibility(false, true);

            BeginInvoke(del, " ->  Real Video Play Started");
            OpenVideo();
        }

        // Start fast forward replay
        private void btnRepFF_Click(object sender, EventArgs e)
        {

            PlayM4_Pause(m_repPlayerPort, 1);
            if (m_repFastPlay)
            {
                //m_repBuffSz = 4000 * 1024; // buffer size
                CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYNORMAL, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                PlayM4_Play(m_repPlayerPort, IntPtr.Zero);
                btnRepFF.Text = ">>";

                m_repFastPlay = false;
            }
            else
            {
                //m_repBuffSz = 7000 * 1024; // buffer size
                //CHCNetSDK.NET_DVR_PlayBackControl_V40(pbb, CHCNetSDK.NET_DVR_SETSPEED, new IntPtr(, 8, IntPtr.Zero, ref LPOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl_V40(data.handle, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
                PlayM4_Fast(m_repPlayerPort);
                btnRepFF.Text = ">";

                m_repFastPlay = true;
            }
        }


        int saveRecordFile(int userId, string srcfile, string destfile)
        {
            int bRes = 1;
            int hPlayback = 0;
            if ((hPlayback = CHCNetSDK.NET_DVR_GetFileByName(userId, srcfile, destfile)) < 0)
            {
                BeginInvoke(del, string.Format("GetFileByName failed. error[%d]\n", CHCNetSDK.NET_DVR_GetLastError()));
                bRes = -1;
                return bRes;
            }

            if (!CHCNetSDK.NET_DVR_PlayBackControl(hPlayback, CHCNetSDK.NET_DVR_PLAYSTART, 0, ref LPOutValue))
            {
                BeginInvoke(del, string.Format("play back control failed [%d]\n", CHCNetSDK.NET_DVR_GetLastError()));
                bRes = -1;
                return bRes;
            }

            int nPos = 0;
            for (nPos = 0; nPos < 100 && nPos >= 0; nPos = CHCNetSDK.NET_DVR_GetDownloadPos(hPlayback))
            {
                System.Threading.Thread.Sleep(5000);  //millisecond
            }
            BeginInvoke(del, string.Format("have got %d\n", nPos));

            if (!CHCNetSDK.NET_DVR_StopGetFile(hPlayback))
            {
                BeginInvoke(del, string.Format("failed to stop get file [%d]\n", CHCNetSDK.NET_DVR_GetLastError()));
                bRes = -1;
                return bRes;
            }
            BeginInvoke(del, string.Format("%s\n", srcfile));

            if (nPos < 0 || nPos > 100)
            {
                BeginInvoke(del, string.Format("download err [%d]\n", CHCNetSDK.NET_DVR_GetLastError()));
                bRes = -1;
                return bRes;
            }
            else
            {
                return 0;
            }
        }

        string sFilePathjj;

        // record _> test 2 min
        private void btnRepRec_Click(object sender, EventArgs e)
        {
            /*
            GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref startTime, ref stopTime);

            struFileCond.lChannel = m_rep_canal;
            struFileCond.struStartTime = startTime;
            struFileCond.struStopTime = stopTime;


            m_rep_foundHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struFileCond);            


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

                    PrepareDebugOutputBinary();
                    string sFilePath = sDebugPath + sDebugFileName;//.Replace("3gpp", "mp4");
                    saveRecordFile(m_lUserID, struFileData.sFileName, sFilePath);
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

            // Stop finding
            if (m_rep_foundHandle >= 0)        
        CHCNetSDK.NET_DVR_FindClose_V30(m_rep_foundHandle);
            */



            if (!bSavingStream)
            {
                PrepareDebugOutputBinary();
                sFilePathjj = sDebugPath + sDebugFileName;//.Replace("3gpp", "mp4");


                if (!CHCNetSDK.NET_DVR_PlayBackSaveData(data.handle, sFilePathjj))
                {
                    MessageBox.Show("NET_DVR_PlayBackSaveData fail");
                    return;
                }
                /*
                else
                {
                    if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_repRecordHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue))
                    {
                        MessageBox.Show("play back control_V40 failed [%d]\n" + CHCNetSDK.NET_DVR_GetLastError());
                        return;
                    }
                    else
                    {
                        //CHCNetSDK.NET_DVR_SetPlayDataCallBack_V40(pbb, null, (uint)m_lUserID);
                    }
                }*/

                //PlayM4_GetNextKeyFramePos()

                //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);

                //CHCNetSDK.NET_DVR_RemoteControl(m_lUserID, 6144, m_repBuff, m_repBuffSz);
                //CHCNetSDK.NET_DVR_StartDVRRecord(m_lUserID, m_rep_canal, 0);
                /*
                struCertParam.dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(struCertParam);
                struCertParam.wCertFunc = 0;
                struCertParam.wCertType = 0;
                struCertParam.byFileType = 0;

                m_repRecordHandle = CHCNetSDK.NET_DVR_StartDownload(m_lUserID, 1, ref struCertParam, (uint)System.Runtime.InteropServices.Marshal.SizeOf(struCertParam), sFilePathjj);

                if(m_repRecordHandle <0)
                {
                    BeginInvoke(del, "recording start fail " + CHCNetSDK.NET_DVR_GetLastError());
                }
                */
                /*
            if (CHCNetSDK.NET_DVR_PlayBackSaveData(pbb, sFilePath))
            {
                bSavingStream = true;
                BeginInvoke(del, "recording started...");
            }
            else
            {
                BeginInvoke(del, "recording start fail " + CHCNetSDK.NET_DVR_GetLastError());
            }*/

                bSavingStream = true;
            }
            else
            {
                //CHCNetSDK.NET_DVR_StopDownload(m_repRecordHandle);
                //CHCNetSDK.NET_DVR_StopDVRRecord(m_lUserID, m_rep_canal);
                CHCNetSDK.NET_DVR_StopPlayBackSave(data.handle);
                //CHCNetSDK.NET_DVR_StopPlayBack(pbb);
                bSavingStream = false;
                BeginInvoke(del, "recording stopped!");
            }

            // __ black-out momentan __
            if (false)//!bSavingStream)
            {

                //PrepareDebugOutputBinary();

                sDebugPath = @"c:\__\";
                sDebugFileName = "kk.3gp";/*
                    string.Format("Streaming_{0}-{1:00}-{2:00}_{3:00}{4:00}{5:00}.3gp", 
                    timpDeReferinta.Year, timpDeReferinta.Month, timpDeReferinta.Day,
                    timpDeReferinta.Hour, timpDeReferinta.Minute, timpDeReferinta.Second);*/


                //if (!Directory.Exists(sDebugPath)) Directory.CreateDirectory(sDebugPath);

                //sDebugPath += sDebugFileName;

                sDebugFileName = sDebugPath + sDebugFileName;

                //if (!File.Exists(sDebugFileName)) File.Create(sDebugFileName);

                //m_repRecordHandle = CHCNetSDK.NET_DVR_GetFileByTime(m_lUserID, m_rep_canal, ref startTime, ref stopTime, sDebugFileName);








                /*

                }*/

                /*    
       GetReplayTimeInterval(m_rep_setOre, m_rep_setMin, ref startTime, ref stopTime);
       pDownloadCond.struStartTime = startTime;
       pDownloadCond.struStopTime = stopTime;
       pDownloadCond.dwChannel = (uint)m_rep_canal;

       //m_repRecordHandle = CHCNetSDK.NET_DVR_GetFileByTime(m_lUserID, m_rep_canal, ref startTime, ref stopTime, sFilePath);
       m_repRecordHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sDebugFileName, ref pDownloadCond);
       if (m_repRecordHandle < 0)
       {
           int err = (int)CHCNetSDK.NET_DVR_GetLastError();
           MessageBox.Show("NET_DVR_GetFileByTime_V40 fail,last error %d\n"+ err.ToString());
            return;
       }

       CHCNetSDK.NET_DVR_PlayBackControl_V40(m_repRecordHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref LPOutValue);
       */

                //---------------------------------------
                //Start downloading
                //if ((!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_repRecordHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero,0, IntPtr.Zero,ref LPOutValue))
                //{
                //    MessageBox.Show("play back control_V40 failed [%d]\n"+ CHCNetSDK.NET_DVR_GetLastError());
                //    return;
                //}

                //PlayM4_Play(m_repPlayerPort, IntPtr.Zero);


                /*
                int nPos = 0;
                for (nPos = 0; nPos < 100 && nPos >= 0; nPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_repRecordHandle))
                {
                    System.Threading.Thread.Sleep(5000);  //millisecond
                }

                //CHCNetSDK.NET_DVR_StopGetFile(m_repRecordHandle);
                */

                bSavingStream = true;
            }
            else
            {
                /*
                CHCNetSDK.NET_DVR_StopSaveRealData(pbb);
                //CHCNetSDK.NET_DVR_StopGetFile(m_repRecordHandle);
                bSavingStream = false;
                m_repRecordHandle = -1;*/
            }

            btnRepRec.Text = bSavingStream ? "Stop" : "Record";

        }



        private void btnRepSnap_Click(object sender, EventArgs e)
        {
            PrepareDebugOutputBinary();
            string sFilePath = sDebugPath + sDebugFileName.Replace("3gpp", "bmp");
            if (!CHCNetSDK.NET_DVR_PlayBackCaptureFile(data.handle, sFilePath))
            {
                BeginInvoke(del, "snap image fail : " + CHCNetSDK.NET_DVR_GetLastError());
            }
        }

        int deft;
        // DVR file in intervalul de timp, pentru canalul specificat 
        private void FindFiles(ReplayData info)
        {
            if (info.type == 1 &&
                info.playSecondsCur > uint.MinValue && info.playSecondsCur < uint.MaxValue)
                UpDvrDate(GetDate(timeStart).AddSeconds(info.playSecondsCur), ref timeStart);

            if (info.type == 2) // restart
            {
                UpDvrDate(info.timeStartA, ref timeStart);
            }

            struFileCond.lChannel = (uint)info.canal; // !!!!!!!!!!!!!!! cum spanac merge asta pe -1 ??????
            struFileCond.struStartTime = timeStart;
            struFileCond.struStopTime = timeStop;
            struFileCond.byDrawFrame = 0;

            int ssdk = GetSeconds(struFileCond.struStartTime), ssdk1;
            //UpDvrDate(GetDate(struFileCond.struStartTime).AddSeconds(-16), ref struFileCond.struStartTime); // doar pt NET_DVR_FindFile_V40

            BeginInvoke(del, "DVRFileSearch_" + GetDate(timeStart).ToLongTimeString() + "  TO  " + GetDate(timeStop).ToLongTimeString());

            struFileData.struStartTime = timeStart;
            struFileData.struStopTime = timeStop;

            //---------------------------------------
            //Find record file
            bool
            keepTry = true, // loop de incercari
            oneMoreTry = false; // in case of error, 1 more try from file start
            uint keepCount = 0;
            while (keepTry || oneMoreTry)
            {
                deft = int.MaxValue;

                if (oneMoreTry)
                {
                    UpDvrDate(info.timeStartB, ref timeStart);
                    struFileData.struStartTime = timeStart;
                    struFileCond.struStartTime = timeStart;
                    oneMoreTry = false;
                }

                m_rep_foundHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struFileCond);


                if (m_rep_foundHandle < 0)
                {
                    uint err = CHCNetSDK.NET_DVR_GetLastError();
                    BeginInvoke(del, (string.Format("WARNING: FindFile failed for channel {0}. Last SDK error: {1}", info.canal, err)));
                    if (err == 46  // The number of login or preview connections has exceeded the SDK limitation.
                        || err == 11) // The data sent to the device is illegal, or the data received from the device error.E.g.The input data is not supported by the device for remote configuration.

                    {
                        CloseFileFind();
                        keepTry = false;
                        oneMoreTry = true;
                    }

                    // ToDO: check pentru 7
                    // 7: Failed to connect to the device. The device is off-line, or connection timeout caused by network.
                }
                else // jump around cu findNext
                {
                    int result = 0;

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
                            ssdk1 = GetSeconds(struFileData.struStopTime);
                            BeginInvoke(del, struFileData.sFileName +
                                "_FROM_ " + GetDate(struFileData.struStartTime).ToLongTimeString() + " _TO_ " + GetDate(struFileData.struStopTime).ToLongTimeString());

                            //BeginInvoke(del, GetSeconds(timeStart).ToString() + " _TO_ " + GetSeconds(struFileData.struStopTime).ToString());

                            if (ssdk < ssdk1)
                            {
                                if ((ssdk + 3) < ssdk1)
                                {
                                    keepTry = false;

                                    info.fileName = struFileData.sFileName;
                                    info.timeStartB = GetDate(struFileData.struStartTime);
                                    CloseFileFind();
                                }
                                else
                                {
                                    if (struFileData.struStartTime.dwSecond == struFileCond.struStopTime.dwSecond)
                                    {
                                        BeginInvoke(del, "_ssdk TEST failed: " + struFileCond.struStartTime.dwSecond.ToString());

                                        UpDvrDate(GetDate(struFileCond.struStartTime).AddSeconds(1), ref struFileCond.struStartTime);
                                        UpDvrDate(GetDate(struFileData.struStartTime).AddSeconds(1), ref struFileData.struStartTime);
                                    }
                                    CloseFileFind();
                                    result = -5; // one more try                                    
                                }
                            }
                        }
                        else//NET_DVR_FILE_NOFIND || NET_DVR_NOMOREFILE ||NET_DVR_FILE_EXCEPTION
                        {
                            CloseFileFind();
                            Thread.Sleep(1);
                            result = -3; // one more try                            
                        }

                    } while (result >= 0 && (result == CHCNetSDK.NET_DVR_FILE_SUCCESS || result == CHCNetSDK.NET_DVR_ISFINDING));

                }

                if (keepTry)
                {
                    if (++keepCount == uint.MaxValue)
                    {
                        BeginInvoke(del, "FINAL de incercari");
                        if (!oneMoreTry)
                        {
                            keepTry = false;
                            oneMoreTry = true;
                        }
                    }
                    else Thread.Sleep(1);
                }
                else
                {
                    // struFileData e cu o zi in viitor dar GetSeconds se uita doar la Time
                    deft = GetSeconds(struFileData.struStopTime) - ssdk - 3;// false keepTry daca ssdk <= GetSeconds(struFileData.struStopTime)
                                                                            //ssdk = GetSeconds(struFileCond.struStartTime)
                }
            }

        }

        private void CloseFileFind()
        {
            // Stop finding
            if (m_rep_foundHandle >= 0)
                if (!CHCNetSDK.NET_DVR_FindClose_V30(m_rep_foundHandle))
                {
                    //BeginInvoke(del, "FAIL at NET_DVR_FindClose_V30");
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
            btnRepSnap.Visible = v;
            btnRR.Visible = v;

            btnRepFF.Text = ">>";

            if (pause)
            {
                m_repPlayOrPause = false;
                btnRepPause.Text = "Pause";
            }
        }




    }
}











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




/*  replay <-----x

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


/*
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
