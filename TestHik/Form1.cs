using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;


using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;// pt PixelFormat
using System.Activities.Statements;

namespace TestHik
{
    public partial class Form1 : Form
    {
        private bool bPauseMessages = false;

        public Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private Int32 m_lRealHandle = -1;
        public string DVRIPAddress = "87.243.6.12";
        public Int16 DVRPortNumber = 8082;
        public string DVRUserName = "admin";
        public string DVRPassword = "CaVi00pro";
        public int nChNo = 39;

        private bool bAuto = false;


        public string LocalIPAddress = "";
        public ushort LocalPort = 7200;

        public int nPlayerPort = -1;

        public bool bDebugAccessGranted = true;
        private string sDebugFileName = string.Empty;
        private string sDebugPath = string.Empty;
        public readonly object debugLock = new object(); // lock pt acces unic la resursa de scriere in fisierul de salvare streaming

        public bool bSavingStream = false;



        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V40 m_struDeviceInfoV40;
        public CHCNetSDK.NET_DVR_USER_LOGIN_INFO m_struLoginInfo;

        private CHCNetSDK.MSGCallBack m_falarmData = null;
        private CHCNetSDK.EXCEPYIONCALLBACK m_fException = null;

        public CHCNetSDK.fnLoginResultCallBack m_fLoginResultCallBack = null;
        private CHCNetSDK.REALDATACALLBACK m_fRealDataCallBack = null;
        private fDisplayCallBack_Hik m_fDisplayCallBack = null;

        private Int32 m_lAlarmHandle = -1;
        private Int32 m_lAlarmChHandle = -1;


        [DllImport("Filters.dll", SetLastError = true, EntryPoint = "YV12ToBGR24", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern int YV12ToBGR24(byte* pSource, int nSourceSize, byte* pDest, int nWidth, int nHeight);//

        //readonly object lo1 = new object(), lo2 = new object(), lo3 = new object();
        // callback pentru receptionarea frame-urilor (in format YV12)
        public delegate void fDisplayCallBack_Hik(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReserved);
        private void DisplayCallBack_Hik(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReserved)
        {
            //lock (lo2)
            {
                if (nType == 3 && (nSize > 0) && (nPort >= 0) && ((nWidth * nHeight * 3) == (nSize * 2)))
                {
                    //BeginInvoke(new MyDebugReplacebleInfo(DebugReplacebleInfo), string.Format("LastFrame on Port[{0}], BuffSize[{1}], Dim[{2}x{3}]", nPort, nSize, nWidth, nHeight));

                    // copiez continutul intr-un array byte[]
                    byte[] bInput = new byte[nSize];
                    Marshal.Copy(pBuf, bInput, 0, nSize);

                    // urmeaza procesarea bufferului:
                    int dwBuffSize = bInput.Length;

                    // ***************************************************
                    // ******************** YV12 -> RGB ******************
                    // ***************************************************
                    // Byte order: in the YV12 format, all the Y values come first, followed by all the V values, followed finally by all the U values.

                    // 1. transform din YV12 -> RGB888
                    byte[] pFromYV12 = new byte[dwBuffSize * 2];
                    // apelez la filtrul de conversie:
                    unsafe
                    {
                        fixed (byte* pSource = bInput)
                        {
                            fixed (byte* pBGR = pFromYV12)
                            {
                                YV12ToBGR24(pSource, dwBuffSize, pBGR, nWidth, nHeight);
                            }
                        }
                    }
                    // 2. creez bitmap-ul pornind de la bufferul trasformat la pasul anterior
                    Bitmap bitmap = new Bitmap(nWidth, nHeight, PixelFormat.Format24bppRgb);
                    BitmapData bmData = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadWrite,
                        bitmap.PixelFormat);
                    IntPtr pDest = bmData.Scan0;
                    Marshal.Copy(pFromYV12, 0, pDest, (nWidth * nHeight * 3));

                    bitmap.UnlockBits(bmData);

                    if (pictureBox1.BackgroundImageLayout != ImageLayout.Stretch)
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox1.BackgroundImage = bitmap;

                    

                }
            }
        }

        public void LoginResultCallBack(int lUserID, int dwResult, ref CHCNetSDK.NET_DVR_DEVICEINFO_V30 lpDeviceInfo, IntPtr pUser)
        {
            BeginInvoke(new MyDebugInfo(DebugInfo), "LoginResultCallBack Result = {0} ", dwResult);

            //m_lAlarmChHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V30(m_lUserID);
            //// incerc sa afisez structura m_struDeviceInfo, byte cu byte, in urma apelului Login.
            //// pentru a copia structura intr-un byte[] trebuie sa urmez mai multi pasi:

            //// 1. creez array-ul destinatie
            ////byte[] bInfo = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_DEVICEINFO_V30))];
            //byte[] bInfo = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_DEVICEINFO_V40))];

            //// 2. Initialize unmanged memory to hold the struct.
            //IntPtr ptr = Marshal.AllocHGlobal(bInfo.Length);
            //try
            //{
            //    // 3. copiez structura in zona alocata anterior cu alloc
            //    Marshal.StructureToPtr(m_struDeviceInfoV40, ptr, false);
            //    //Marshal.StructureToPtr(m_struDeviceInfo, ptr, false);


            //    // 4. copiez datele in array-ul bInfo[]
            //    Marshal.Copy(ptr, bInfo, 0, bInfo.Length);
            //}
            //finally
            //{
            //    // 5. free the unmanaged memory
            //    Marshal.FreeHGlobal(ptr);
            //}
            //// acum sa vedem ce contine bInfo[]
            //string sir = "";
            //if (bInfo.Length > CHCNetSDK.SERIALNO_LEN)
            //{
            //    //sir += Environment.NewLine;
            //    sir = "Serial No: ";
            //    sir += Environment.NewLine;
            //    for (int i = 0; i < CHCNetSDK.SERIALNO_LEN; i++)
            //    {
            //        sir += string.Format("{0:X2} ", bInfo[i]);
            //    }
            //    sir += Environment.NewLine;
            //    sir += "DeviceInfo Data:";
            //    sir += Environment.NewLine;
            //    for (int i = CHCNetSDK.SERIALNO_LEN; i < bInfo.Length; i++)
            //    {
            //        sir += string.Format("{0:X2} ", bInfo[i]);
            //    }
            //}
            //sir = string.Format("Login Success! UserID[{0}]{1}{2}", m_lUserID, Environment.NewLine, Environment.NewLine) + sir;
            //BeginInvoke(new MyDebugInfo(DebugInfo), sir);
            //textBox1.Enabled = false; textBox3.Enabled = false;

        }

        //*************************************************************************
        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_GetPort(ref int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_SetStreamOpenMode(int nPort, int nMode);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_OpenStream(int nPort, out byte pFileHeadBuf, int nSize, int nBufPoolSize);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_OpenStreamEx(int nPort, out byte pFileHeadBuf, int nSize, int nBufPoolSize);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_Play(int nPort, IntPtr hWnd);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_Fast(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_OneByOne(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_OneByOneBack(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_SetDisplayCallBack(int nPort, fDisplayCallBack_Hik pProc);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_SetDisplayBuf(int nPort, int nNum);// the number of images to be buffered

        [DllImport("PlayCtrl.dll")]
        private unsafe static extern int PlayM4_InputData(int nPort, byte* pBuf, int nSize);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_CloseStream(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_Stop(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern int PlayM4_FreePort(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern bool PlayM4_Pause(int nPort, uint nPause);

        [DllImport("PlayCtrl.dll")]
        private static extern void PlayM4_RefreshPlay(int nPort);

        [DllImport("PlayCtrl.dll")]
        private static extern bool PlayM4_ReversePlay(int nPort);

        //*************************************************************************






        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load1;

        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            ReplayInit();
        }


        public delegate void MyDebugInfo(string str);
        public void DebugInfo(string str)
        {
            if (!bPauseMessages)
            {
                if (str.Length > 0)
                {
                    str += Environment.NewLine;
                    textBox2.AppendText(str);
                }
            }

        }

        public delegate void MyDebugReplacebleInfo(string str);
        public void DebugReplacebleInfo(string str)
        {
            if (str.Length > 0)
            {
                DateTime dt = DateTime.Now;
                string complete_str = string.Format("{0:00}:{1:00}:{2:00}.{3:000} {4}", dt.Hour, dt.Minute, dt.Second, dt.Millisecond, str);

                textBoxLastFrame.Text = complete_str;
            }
        }

        protected string GetLocalIP()
        {

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString(); // preiau primul IP care il gasesc
                    break;
                }
            }

            return localIP;
        }


        // init SDK
        private void button2_Click(object sender, EventArgs e)
        {
            if (!m_bInitSDK)
            {
                m_bInitSDK = CHCNetSDK.NET_DVR_Init();
                if (m_bInitSDK == false)
                {
                    BeginInvoke(new MyDebugInfo(DebugInfo), "SDK init error!");
                    return;
                }
                else
                {
                    //BeginInvoke(new MyDebugInfo(DebugInfo), "SDK init succeeded!");
                    //if (CHCNetSDK.NET_DVR_SetLogToFile(3, null, 0))
                    //    BeginInvoke(new MyDebugInfo(DebugInfo), "SetLogFile() succeeded!");//C:\\SdkLog\\
                    //else
                    //    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("SetLogFile() failed with error {0} !",CHCNetSDK.NET_DVR_GetLastError()));

                    SetMessageCallBack();
                    SetExceptionCallBack();
                    CHCNetSDK.NET_DVR_SetConnectTime(1000, 1);
                    CHCNetSDK.NET_DVR_SetReconnect(2000, 0);// dezactivare reconectare
                }
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "SDK is already initialized");
        }

        // Login
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_bInitSDK)
            {
                if (m_lUserID < 0)
                {
                    m_struLoginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
                    m_struDeviceInfoV40 = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();

                    m_struLoginInfo.sDeviceAddress = new byte[CHCNetSDK.NET_DVR_DEV_ADDRESS_MAX_LEN];
                    byte[] buff1 = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
                    Buffer.BlockCopy(buff1, 0, m_struLoginInfo.sDeviceAddress, 0, buff1.Length);

                    m_struLoginInfo.sUserName = new byte[CHCNetSDK.NET_DVR_LOGIN_USERNAME_MAX_LEN];
                    byte[] buff2 = System.Text.Encoding.ASCII.GetBytes(DVRUserName);
                    Buffer.BlockCopy(buff2, 0, m_struLoginInfo.sUserName, 0, buff2.Length);

                    m_struLoginInfo.sPassword = new byte[CHCNetSDK.NET_DVR_LOGIN_PASSWD_MAX_LEN];
                    byte[] buff3 = System.Text.Encoding.ASCII.GetBytes(DVRPassword);
                    Buffer.BlockCopy(buff3, 0, m_struLoginInfo.sPassword, 0, buff3.Length);

                    m_struLoginInfo.byRes2 = new byte[128];

                    m_struLoginInfo.wPort = Convert.ToUInt16(textBox3.Text);
                    m_struLoginInfo.pUser = IntPtr.Zero;

                    //m_fLoginResultCallBack = new CHCNetSDK.fnLoginResultCallBack(LoginResultCallBack);

                    m_struLoginInfo.cbLoginResult = null; //m_fLoginResultCallBack;//
                    m_struLoginInfo.bUseAsynLogin = 0; // 1 sau 0


                    //byte[] xs = System.Text.Encoding.ASCII.GetBytes(m_struLoginInfo.sDeviceAddress);
                    //string sret = "";
                    //for (int i = 0; i < xs.Length; i++)
                    //    sret += string.Format("{0:X2} ",xs[i]);
                    //BeginInvoke(new MyDebugInfo(DebugInfo), sret);

                    m_lUserID = CHCNetSDK.NET_DVR_Login_V40(ref m_struLoginInfo, ref m_struDeviceInfoV40);
                    //m_lUserID = CHCNetSDK.NET_DVR_Login_V30(textBox1.Text, Convert.ToInt16(textBox3.Text), DVRUserName, DVRPassword, ref m_struDeviceInfo);

                    //BeginInvoke(new MyDebugInfo(DebugInfo), "Login set ");


                    if (m_lUserID == -1)
                    {
                        BeginInvoke(new MyDebugInfo(DebugInfo), "Login error " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                        return;
                    }
                    else if (m_struLoginInfo.bUseAsynLogin == 0)
                    {
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("DisksPresent = [{0}]", m_struDeviceInfoV40.struDeviceV30.byDiskNum));
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("MaxAnalogCh = [{0}]", m_struDeviceInfoV40.struDeviceV30.byChanNum));
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("MaxIPCh = [{0}]", m_struDeviceInfoV40.struDeviceV30.byIPChanNum));
                        if (m_struDeviceInfoV40.struDeviceV30.byIPChanNum > 0)
                            BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("StartIPCh = [{0}]", m_struDeviceInfoV40.struDeviceV30.byStartDChan));


                        m_lAlarmChHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V30(m_lUserID);

                        // incerc sa afisez structura m_struDeviceInfo, byte cu byte, in urma apelului Login.
                        // pentru a copia structura intr-un byte[] trebuie sa urmez mai multi pasi:

                        // 1. creez array-ul destinatie
                        //byte[] bInfo = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_DEVICEINFO_V30))];
                        byte[] bInfo = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(CHCNetSDK.NET_DVR_DEVICEINFO_V40))];

                        // 2. Initialize unmanged memory to hold the struct.
                        IntPtr ptr = Marshal.AllocHGlobal(bInfo.Length);
                        try
                        {
                            // 3. copiez structura in zona alocata anterior cu alloc
                            Marshal.StructureToPtr(m_struDeviceInfoV40, ptr, false);
                            //Marshal.StructureToPtr(m_struDeviceInfo, ptr, false);


                            // 4. copiez datele in array-ul bInfo[]
                            Marshal.Copy(ptr, bInfo, 0, bInfo.Length);
                        }
                        finally
                        {
                            // 5. free the unmanaged memory
                            Marshal.FreeHGlobal(ptr);
                        }
                        // acum sa vedem ce contine bInfo[]
                        string sir = "";
                        if (bInfo.Length > CHCNetSDK.SERIALNO_LEN)
                        {

                            //sir += Environment.NewLine;
                            sir = "Serial No: ";
                            sir += Environment.NewLine;

                            // aflu mai intai lungimea sirului SerialNo:
                            int nSerialLen = CHCNetSDK.SERIALNO_LEN;
                            for (int i = 0; i < CHCNetSDK.SERIALNO_LEN; i++)
                            {
                                if (bInfo[i] == 0)
                                {
                                    nSerialLen = i;
                                    break;
                                }
                                //sir += string.Format("{0:X2} ", bInfo[i]);
                            }
                            if (nSerialLen > 0)
                                sir += System.Text.Encoding.ASCII.GetString(bInfo, 0, nSerialLen);
                            else
                                sir += "ND";
                            sir += Environment.NewLine;

                            sir += Environment.NewLine;
                            sir += "DeviceInfo Data:";
                            sir += Environment.NewLine;
                            for (int i = CHCNetSDK.SERIALNO_LEN; i < bInfo.Length; i++)
                            {
                                sir += string.Format("{0:X2} ", bInfo[i]);
                            }
                        }
                        sir = string.Format("Login Success! UserID[{0}]{1}{2}", m_lUserID, Environment.NewLine, Environment.NewLine) + sir;
                        BeginInvoke(new MyDebugInfo(DebugInfo), sir);
                        textBox1.Enabled = false; textBox3.Enabled = false;
                    }
                }
                else BeginInvoke(new MyDebugInfo(DebugInfo), "Already logged in!");
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "First you have to init SDK");
        }

        // cleanup SDK
        private void button4_Click(object sender, EventArgs e)
        {
            if (m_lAlarmHandle >= 0)
            {
                BeginInvoke(new MyDebugInfo(DebugInfo), "First you have to stop the alarm listener!");
            }
            else
            {
                if (CHCNetSDK.NET_DVR_Cleanup())
                {
                    m_bInitSDK = false;
                    m_lUserID = -1;
                    m_lRealHandle = -1;
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Cleanup SDK succeeded!");
                    pictureBox1.Refresh();
                    textBox1.Enabled = true; textBox3.Enabled = true;
                    textBox4.Enabled = true; textBox5.Enabled = true;
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), "SDK already cleaned");
            }
        }

        // Logout
        private void button3_Click(object sender, EventArgs e)
        {
            if (m_lUserID >= 0)
            {
                // daca am flux video deschis atunci inchid mai intai acest flux
                if (m_lRealHandle >= 0)
                {
                    if (bSavingStream)
                        SwitchRecording();

                    if (CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                    {
                        m_lRealHandle = -1;
                        BeginInvoke(new MyDebugInfo(DebugInfo), "Video stream closed!");
                        m_fRealDataCallBack = null;

                        if (nPlayerPort >= 0)
                        {
                            PlayM4_Stop(nPlayerPort);
                            PlayM4_CloseStream(nPlayerPort);
                            PlayM4_FreePort(nPlayerPort);
                            nPlayerPort = -1;
                            m_fDisplayCallBack = null;
                        }
                        if (pictureBox1.BackgroundImageLayout != ImageLayout.Center)
                            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
                        pictureBox1.BackgroundImage = global::TestHik.Properties.Resources.CAVI_square;
                    }
                    else
                        BeginInvoke(new MyDebugInfo(DebugInfo), "Failed to close video stream!");
                }

                if (m_lAlarmChHandle != 0)
                    CHCNetSDK.NET_DVR_CloseAlarmChan_V30(m_lAlarmChHandle);
                m_lAlarmChHandle = -1;

                if (CHCNetSDK.NET_DVR_Logout_V30(m_lUserID))
                {
                    m_lUserID = -1;
                    m_lRealHandle = -1;
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Logout succeeded!");
                    pictureBox1.Refresh();
                    textBox1.Enabled = true; textBox3.Enabled = true;
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Logout failed!");
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "Already Logout!");
        }

        // open video
        private void OpenVideo()
        {
            if (m_lRealHandle == -1)
            {

                //CHCNetSDK.NET_DVR_CLIENTINFO lpClientInfo = new CHCNetSDK.NET_DVR_CLIENTINFO();
                //lpClientInfo.lChannel = 1;
                //lpClientInfo.lLinkMode = 0;// 1 << 31;//0x0000; // 0 = tcp mainstream, 1<<31 = tcp substream
                //lpClientInfo.sMultiCastIP = "";
                //lpClientInfo.hPlayWnd = pictureBox1.Handle;
                IntPtr pUser = new IntPtr();
                //m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V30(m_lUserID, ref lpClientInfo, null, pUser, 1);    

                // pentru versiunea noua de firmware trebuie importata si folosita metoda
                // NET_DVR_RealPlay_V40 si definita structura NET_DVR_PREVIEWINFO


                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();

                lpPreviewInfo.lChannel = Convert.ToUInt16(textBox_Ch.Text); //35; // channel number starting from 1 (pentru analogice)
                lpPreviewInfo.dwStreamType = 0; // 0=mainstream, 1=sub-stream
                lpPreviewInfo.dwLinkMode = 0; // 0-tcp, 1-udp, 2-multicast, 3-rtp, 4-rtp/rtps, 5-rstp/http
                lpPreviewInfo.hPlayWnd = IntPtr.Zero;//pictureBox1.Handle;
                lpPreviewInfo.bBlocked = 0; // 0-non-blocking stream, 1-blocking stream;
                //lpPreviewInfo.dwDisplayBufNum = 5;


                m_fRealDataCallBack = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, m_fRealDataCallBack, pUser);


                if (m_lRealHandle == -1)
                {
                    uint nError = CHCNetSDK.NET_DVR_GetLastError();
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("NET_DVR_RealPlay fail with error: {0}", nError));
                }
                else
                {
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Video stream opened with handle[{0}]", m_lRealHandle));
                    pictureBox1.SetBounds(pictureBox1.Bounds.X, pictureBox1.Bounds.Y, pictureBox1.Bounds.Width, pictureBox1.Bounds.Height);

                }
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "Video stream already opened!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnRepBack_Click(null, null);
        }

        // close video
        private void CloseVideo()
        {

            if (m_lRealHandle >= 0)
            {
                if (bSavingStream)
                    SwitchRecording();

                if (CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    m_lRealHandle = -1;
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Video stream closed!");
                    m_fRealDataCallBack = null;

                    if (nPlayerPort >= 0)
                    {
                        PlayM4_Stop(nPlayerPort);
                        PlayM4_CloseStream(nPlayerPort);
                        PlayM4_FreePort(nPlayerPort);
                        nPlayerPort = -1;
                        m_fDisplayCallBack = null;
                    }
                    if (pictureBox1.BackgroundImageLayout != ImageLayout.Center)
                        pictureBox1.BackgroundImageLayout = ImageLayout.Center;
                    pictureBox1.BackgroundImage = global::TestHik.Properties.Resources.CAVI_square;
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Failed to close video stream!");
            }
            else
            {
                BeginInvoke(new MyDebugInfo(DebugInfo), "Already closed");
            }
            pictureBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetReplay(m_rep_canal, 2);
            CloseVideo();
        }

        private void SetMessageCallBack()
        {
            if (m_falarmData == null)
            {
                m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
                if (CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V30(m_falarmData, IntPtr.Zero))
                {
                    BeginInvoke(new MyDebugInfo(DebugInfo), "NET_DVR_SetDVRMessageCallBack_V30 Succ");
                }
                else
                {
                    uint i = CHCNetSDK.NET_DVR_GetLastError();
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("NET_DVR_SetDVRMessageCallBack_V30 Fail with error: {0}", i));
                    m_falarmData = null;
                }
            }
        }

        private void SetExceptionCallBack()
        {
            if (m_fException == null)
            {
                m_fException = new CHCNetSDK.EXCEPYIONCALLBACK(ExceptionCallBack);
                if (CHCNetSDK.NET_DVR_SetExceptionCallBack_V30(0, IntPtr.Zero, m_fException, IntPtr.Zero))
                {
                    BeginInvoke(new MyDebugInfo(DebugInfo), "NET_DVR_SetExceptionCallBack_V30 Succ");
                }
                else
                {
                    uint i = CHCNetSDK.NET_DVR_GetLastError();
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("NET_DVR_SetExceptionCallBack_V30 Fail with error: {0}", i));
                    m_fException = null;
                }
            }
        }

        public void ExceptionCallBack(uint dwType, int lUserID, int lHandle, IntPtr pUser)
        {
            // [lUserID] reprezinta Login ID
            // [lHandle] reprezinta handle-ul returnat de NET_DVR_RealPlay/V30/V40

            // EXCEPTION_PREVIEW = 0x8003,         // Exception during live view (se poate genera de exemplu daca se incearca deschiderea unui flux pe un canal situat in afara domeniului acceptat, ex. canalul 20 la un DVR care contine doar 8 sau 16 canale analogice)
            // EXCEPTION_RECONNECT = 0x8005,       // Exception reconnect during live view (se genereaza daca echipamentul devine offline si nu se poate realiza reconectarea)
            // PREVIEW_RECONNECT_SUCCESS = 0x8015  // Live view reconnected successfully (aceasta exceptie reprezinta semnalul de restaurare a fluxului video)


            if (dwType == 0x8003)
            {
                // Network preview exception
                BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("ExceptionCallBack -> Open Failed! lHandle[{0}]", lHandle));
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("ExceptionCallBack dwType[{0}], lUserID[{1}], lHandle[{2}]", dwType.ToString("X"), lUserID, lHandle));
        }

        private void PrepareDebugOutputBinary()
        {
            // pregatesc datele pentru fisierul de Debug:
            sDebugPath = AppDomain.CurrentDomain.BaseDirectory + "DbgMessages\\";
            DateTime dt = DateTime.Now;
            sDebugFileName = string.Format("Streaming_{0}-{1:00}-{2:00}_{3:00}{4:00}{5:00}.3gpp", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            try
            {
                Directory.CreateDirectory(sDebugPath);
            }
            catch
            {
                bDebugAccessGranted = false;
                BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Create path to file failed!"));
            }
        }

        public void OutputDebugBinary(byte[] bin_arr, int start_offset, int len)
        {
            if (bDebugAccessGranted)
            {
                // apelul acestei metode se poate face simultan din mai multe thread-uri, 
                // deci trebuie asigurat accesul secvential
                lock (debugLock)
                {
                    string sFilePath = sDebugPath + sDebugFileName;
                    try
                    {
                        using (BinaryWriter b = new BinaryWriter(File.Open(sFilePath, FileMode.Append)))
                        {
                            b.Write(bin_arr, start_offset, len);
                        }
                    }
                    catch
                    {
                        // probabil nu am drepturi de scriere in acest director/fisier

                        // nu mai incerc scrierea in fisier pentru urmatoarele apeluri ale metodei
                        bDebugAccessGranted = false;
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Create/append file failed!"));
                    }
                }
            }
        }


        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, int dwBufSize, IntPtr pUser)
        {
            //BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("RealDataCallBack lRealHandle[{0}], dwDataType[{1}], dwBufSize[{2}]", lRealHandle, dwDataType, dwBufSize));
            //if (dwBufSize > 0 && (dwDataType == CHCNetSDK.NET_DVR_SYSHEAD || dwDataType == CHCNetSDK.NET_DVR_STREAMDATA))
            //{
            //    // copiez continutul intr-un array byte[]
            //    byte[] bInfo = new byte[dwBufSize];
            //    Marshal.Copy(pBuffer, bInfo, 0, dwBufSize);

            //    OutputDebugBinary(bInfo, 0, dwBufSize);
            //    if (dwDataType == CHCNetSDK.NET_DVR_SYSHEAD)
            //        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Streaming header..."));
            //    else
            //        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Streaming data..."));
            //}

            if (dwDataType == CHCNetSDK.NET_DVR_SYSHEAD && dwBufSize > 0)
            {
                if (PlayM4_GetPort(ref nPlayerPort) != 0)
                {
                    //BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("RealDataCallBack GetPort => [{0}]", nPlayerPort));
                    if (nPlayerPort >= 0)
                    {
                        if (PlayM4_SetStreamOpenMode(nPlayerPort, 0) != 0) //STREAME_REALTIME == 0
                        {
                            byte byFileHeadBuf;
                            if (PlayM4_OpenStream(nPlayerPort, out byFileHeadBuf, (int)dwBufSize, 2000 * 1000) != 0)
                            {
                                if (PlayM4_Play(nPlayerPort, IntPtr.Zero) != 0)  //Start play
                                {
                                    fDisplayCallBack_Hik fdcb = new fDisplayCallBack_Hik(DisplayCallBack_Hik);
                                    if (PlayM4_SetDisplayCallBack(nPlayerPort, fdcb) != 0)
                                    {
                                        //lock (dataLock)
                                        {
                                            m_fDisplayCallBack = fdcb;
                                        }
                                    }
                                    else
                                    {
                                        PlayM4_Stop(nPlayerPort);
                                        PlayM4_CloseStream(nPlayerPort);
                                        PlayM4_FreePort(nPlayerPort);
                                        nPlayerPort = -1;
                                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("PlayM4_SetDisplayCallBack Failed!"));
                                    }
                                }
                                else
                                {
                                    PlayM4_CloseStream(nPlayerPort);
                                    PlayM4_FreePort(nPlayerPort);
                                    nPlayerPort = -1;
                                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("PlayM4_Play Failed!"));
                                }
                            }
                            else
                            {
                                PlayM4_FreePort(nPlayerPort);
                                nPlayerPort = -1;
                                BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("PlayM4_OpenStream Failed!"));
                            }
                        }
                        else
                        {
                            PlayM4_FreePort(nPlayerPort);
                            nPlayerPort = -1;
                            BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("PlayM4_SetStreamOpenMode Failed!"));
                        }
                    }

                    if (m_fDisplayCallBack != null)
                    {
                        // BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("SetDisplayCallBack => Succeeded!"));
                    }
                    else
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("SetDisplayCallBack => Failed!"));
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("PlayM4_GetPort Failed!"));
            }
            else if (dwDataType == CHCNetSDK.NET_DVR_STREAMDATA)
            {
                if (dwBufSize > 0 && nPlayerPort >= 0)
                {
                    // copiez continutul intr-un array byte[]
                    byte[] bInfo = new byte[dwBufSize];
                    Marshal.Copy(pBuffer, bInfo, 0, dwBufSize);

                    // transmit player-ului bufferul (fiindca folosesc aceeasi metoda pentru toate instantele callbackurilor voi folosi un lock dedicat player-ului)
                    //lock (playerLock)
                    {
                        unsafe
                        {
                            fixed (byte* pb = bInfo)
                            {
                                // Transmit player-ului informatia bruta (nedecodata), iar acesta va trimite periodic, prin callback-ul <DisplayCallBack>, 
                                // cate un buffer pt un frame YUV, imediat ce o imagine va fi compusa din aceste franturi de informatii brute.
                                PlayM4_InputData(nPlayerPort, pb, (int)dwBufSize);
                            }
                        }
                    }

                }
            }
        }

        public void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("ExceptionCallBack lCommand[{0}]", lCommand));

            MyDebugInfo AlarmInfo = new MyDebugInfo(DebugInfo);
            switch (lCommand)
            {
                case CHCNetSDK.COMM_ALARM:
                    this.BeginInvoke(AlarmInfo, "COMM_ALARM");
                    ProcessCommAlarm(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ALARM_V30:
                    //this.BeginInvoke(AlarmInfo, string.Format(">>> COMM_ALARM_V30 - from IP: {0}:{1}", pAlarmer.sDeviceIP, pAlarmer.wLinkPort));
                    //ProcessCommAlarm_V30(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ALARM_RULE:
                    this.BeginInvoke(AlarmInfo, "COMM_ALARM_RULE");
                    break;
                case CHCNetSDK.COMM_TRADEINFO:
                    this.BeginInvoke(AlarmInfo, "COMM_TRADEINFO");
                    break;
                case CHCNetSDK.COMM_IPCCFG:
                    this.BeginInvoke(AlarmInfo, "COMM_IPCCFG");
                    break;
                case CHCNetSDK.COMM_IPCCFG_V31:
                    this.BeginInvoke(AlarmInfo, "COMM_IPCCFG_V31");
                    break;
                case CHCNetSDK.COMM_ALARM_V40:
                    this.BeginInvoke(AlarmInfo, string.Format(">>> COMM_ALARM_V40 - from IP: {0}:{1}", pAlarmer.sDeviceIP, pAlarmer.wLinkPort));
                    ProcessCommAlarm_V40(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                default:
                    this.BeginInvoke(AlarmInfo, string.Format("cmd [0x{1:X4}] - from IP: {0}", pAlarmer.sDeviceIP, lCommand));
                    break;
            }
        }

        public void ProcessCommAlarm(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            MyDebugInfo AlarmInfo = new MyDebugInfo(DebugInfo);
            CHCNetSDK.NET_DVR_ALARMINFO struAlarmInfo = new CHCNetSDK.NET_DVR_ALARMINFO();

            struAlarmInfo = (CHCNetSDK.NET_DVR_ALARMINFO)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO));

            string str;
            switch (struAlarmInfo.dwAlarmType)
            {
                case 0:
                    this.BeginInvoke(AlarmInfo, "sensor alarm");
                    break;
                case 1:
                    this.BeginInvoke(AlarmInfo, "hard disk full");
                    break;
                case 2:
                    this.BeginInvoke(AlarmInfo, "video lost");
                    break;
                case 3:
                    str = "";
                    str += pAlarmer.sDeviceIP;
                    str += " motion detection";
                    this.BeginInvoke(AlarmInfo, str);
                    //m_bJpegCapture = true;
                    break;
                case 4:
                    this.BeginInvoke(AlarmInfo, "hard disk unformatted");
                    break;
                case 5:
                    this.BeginInvoke(AlarmInfo, "hard disk error");
                    break;
                case 6:
                    this.BeginInvoke(AlarmInfo, "tampering detection");
                    break;
                case 7:
                    this.BeginInvoke(AlarmInfo, "unmatched video output standard");
                    break;
                case 8:
                    this.BeginInvoke(AlarmInfo, "illegal operation");
                    break;
                default:
                    this.BeginInvoke(AlarmInfo, "Unknow alarm");
                    break;
            }
        }

        private void ProcessCommAlarm_V30(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            MyDebugInfo AlarmInfo = new MyDebugInfo(DebugInfo);

            CHCNetSDK.NET_DVR_ALARMINFO_V30 struAlarmInfoV30 = new CHCNetSDK.NET_DVR_ALARMINFO_V30();
            struAlarmInfoV30 = (CHCNetSDK.NET_DVR_ALARMINFO_V30)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO_V30));

            byte[] nChannel = null;
            byte[] nDisk = null;
            int totalCh = CHCNetSDK.MAX_CHANNUM_V30;// > 16 ? 16 : CHCNetSDK.MAX_CHANNUM_V30;
            int totalDsk = CHCNetSDK.MAX_DISKNUM_V30;

            string strCh;
            string strDsk;
            int i;

            nChannel = struAlarmInfoV30.byChannel;
            strCh = "Chn[";
            for (i = 0; i < totalCh; i++)
                strCh += nChannel[i].ToString();
            strCh += "]";

            nDisk = struAlarmInfoV30.byDiskNumber;
            strDsk = "Dsk[";
            for (i = 0; i < totalDsk; i++)
                strDsk += nDisk[i].ToString();
            strDsk += "]";



            switch (struAlarmInfoV30.dwAlarmType)
            {
                case 0:// === neutilizat
                    this.BeginInvoke(AlarmInfo, "sensor alarm");
                    break;

                // info in DISKS index table
                case 1:
                    this.BeginInvoke(AlarmInfo, "hard disk full: " + strDsk);
                    break;

                // info in CHANNELS index table
                case 2:

                    this.BeginInvoke(AlarmInfo, "video lost: " + strCh);
                    break;

                // info in CHANNELS index table
                case 3:

                    this.BeginInvoke(AlarmInfo, "Motion: " + strCh);
                    //this.BeginInvoke(AlarmInfo, "================");
                    break;

                // info in DISKS index table
                case 4:
                    this.BeginInvoke(AlarmInfo, "hard disk unformatted" + strDsk);
                    break;

                // info in DISKS index table
                case 5:

                    this.BeginInvoke(AlarmInfo, "HDD error: " + strDsk);
                    break;

                // info in CHANNELS index table
                case 6:
                    this.BeginInvoke(AlarmInfo, "tampering detection" + strCh);
                    break;

                case 7:// === neutilizat
                    this.BeginInvoke(AlarmInfo, "unmatched video output standard");
                    break;
                case 8:// === neutilizat
                    this.BeginInvoke(AlarmInfo, "illegal operation");
                    break;

                // info in CHANNELS index table
                case 9:
                    this.BeginInvoke(AlarmInfo, "videl Signal abnormal" + strCh);
                    break;

                // info in CHANNELS index table
                case 10:
                    this.BeginInvoke(AlarmInfo, "REC abnormal: " + strCh);
                    break;

                default:// === neutilizat
                    this.BeginInvoke(AlarmInfo, "Unknow alarm");
                    break;
            }

        }

        private void ProcessCommAlarm_V40(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            MyDebugInfo AlarmInfo = new MyDebugInfo(DebugInfo);

            byte[] buff = new byte[dwBufLen];
            System.Runtime.InteropServices.Marshal.Copy(pAlarmInfo, buff, 0, (int)dwBufLen);

            //struct
            //{
            //    NET_DVR_ALRAM_FIXED_HEADER    struAlarmFixedHeader;
            //    DWORD                         *pAlarmData;
            //} NET_DVR_ALARMINFO_V40, *LPNET_DVR_ALARMINFO_V40;

            //struct
            //{
            //    DWORD              dwAlarmType;       // 4 bytes
            //    NET_DVR_TIME_EX    struAlarmTime;     // 8 bytes
            //    union                                 // 128 bytes
            //    {
            //        BYTE        byUnionLen[128];
            //        struct
            //        {
            //            DWORD     dwAlarmInputNo;
            //            DWORD     dwTrigerAlarmOutNum;
            //            DWORD     dwTrigerRecordChanNum;
            //        } struIOAlarm;
            //        struct
            //        {
            //            DWORD     dwAlarmChanNum;
            //        } struAlarmChannel;
            //        struct
            //        {
            //            DWORD     dwAlarmHardDiskNum;
            //        } struAlarmHardDisk;        
            //    } uStruAlarm;
            //} NET_DVR_ALRAM_FIXED_HEADER,*LPNET_DVR_ALRAM_FIXED_HEADER;



            string sBuff = "";

            if (dwBufLen - 140 > 0 && (dwBufLen - 140) % 4 == 0)
            {
                // Conform definitiei structurii ar trebui ca lungimea pachetului sa fie intotdeauna = 144 octeti, 
                // insa in realitate este [144 + t*4], unde t>=0. Practic octetii cu index >= 144 trebuie ignorati

                int msgType = BitConverter.ToInt32(buff, 0);
                string sMsgType = "";
                bool bAcceptedMsg = false;
                int nTargetType = 0; // 1 = channels, 2 = disks

                switch (msgType)
                {
                    // info in CHANNELS index table:
                    case 2:
                        sMsgType = "Video Loss"; bAcceptedMsg = true; nTargetType = 1; break;

                    case 3:
                        sMsgType = "Motion"; nTargetType = 1; break;

                    case 6:
                        sMsgType = "Tampering"; bAcceptedMsg = true; nTargetType = 1; break;

                    case 9:
                        sMsgType = "Video abnormal"; bAcceptedMsg = true; nTargetType = 1; break;

                    case 10:
                        sMsgType = "Rec abnormal"; bAcceptedMsg = true; nTargetType = 1; break;

                    case 11:
                        sMsgType = "Intelligent scene change"; nTargetType = 1; break;

                    case 13:
                        sMsgType = "Resolution of recorder and camera different"; nTargetType = 1; break;

                    case 15:
                        sMsgType = "Intelligent detection"; nTargetType = 1; break;

                    case 16:
                        sMsgType = "POE abnormal"; nTargetType = 1; break;

                    // info in DISKS index table:
                    case 1:
                        sMsgType = "hard disk full"; nTargetType = 2; break;

                    case 4:
                        sMsgType = "hard disk unformatted"; bAcceptedMsg = true; nTargetType = 2; break;

                    case 5:
                        sMsgType = "HDD error"; bAcceptedMsg = true; nTargetType = 2; break;


                    // === neutilizate:
                    case 0:
                        sMsgType = "IO alarm"; break;

                    case 7:
                        sMsgType = "unmatched video output standard"; break;

                    case 8:
                        sMsgType = "illegal operation"; break;

                    // === neutilizat
                    default:
                        this.BeginInvoke(AlarmInfo, "Unknow alarm type");
                        break;

                }
                sBuff += string.Format("Msg type: {0}", sMsgType); sBuff += Environment.NewLine;

                if (bAcceptedMsg)
                {
                    int nTotalElements = BitConverter.ToInt32(buff, 12); // nTotalElements reprezinta nr de canale sau discuri ce fac obiectul acestui mesaj

                    if ((nTargetType == 1 && nTotalElements <= CHCNetSDK.MAX_CHANNUM_V30) || (nTargetType == 2 && nTotalElements <= CHCNetSDK.MAX_DISKNUM_V30))
                    {
                        // fiecare element este reprezentat pe 4 octeti (deci nr canalului sau disk-ului este reprezentat ca int32)

                        int len = nTotalElements * 4; // lungimea totala a bufferului necesar pt stocarea acestor canale/discuri (int)dwBufLen - 140;
                        byte[] channels = new byte[len]; // bufferul ce va contine informatia cautata

                        sBuff += string.Format("Total elements: {0}", nTotalElements); sBuff += Environment.NewLine;

                        unsafe
                        {
                            fixed (byte* bpt = &buff[140])
                            {
                                byte b1 = bpt[0];
                                byte b2 = bpt[1];
                                byte b3 = bpt[2];
                                byte b4 = bpt[3];

                                IntPtr dwDataAddress = new IntPtr(b1 + b2 * (1 << 8) + b3 * (1 << 16) + b4 * (1 << 24));
                                System.Runtime.InteropServices.Marshal.Copy(dwDataAddress, channels, 0, len);
                                //sBuff += string.Format("{0} {1} {2} {3}, ptr = {4}", b1, b2, b3, b4, dwDataAddress);
                                //sBuff += Environment.NewLine;
                            }


                            //byte* pAddressAlarmInfo = (byte*)pAlarmInfo;
                            //UInt32 dwAddressData = buff[140];
                            //sBuff += dwAddressData.ToString();
                            //sBuff += Environment.NewLine;
                        }

                        for (int i = 0; i <= len - 4; i += 4)
                        {
                            //sBuff += string.Format("Data: {0:X2} {1:X2} {2:X2} {3:X2}", channels[i], channels[i + 1], channels[i + 2], channels[i + 3]);
                            sBuff += string.Format("Channel No: {0}", BitConverter.ToInt32(channels, i));
                            sBuff += Environment.NewLine;
                        }
                    }
                }
            }

            // Show buffer:
            //StringBuilder hex = new StringBuilder(buff.Length * 3);
            //for (int i = 0; i < buff.Length; i++)
            //    hex.AppendFormat("{0:X2} ", buff[i]);
            //sBuff += hex.ToString();
            //sBuff += Environment.NewLine;

            //this.BeginInvoke(AlarmInfo, sBuff);



            //for (int i = 140; i <= (buff.Length - 4); i += 4)
            //{
            //    sBuff += string.Format("Data: {0:X2} {1:X2} {2:X2} {3:X2}", buff[i], buff[i + 1], buff[i + 2], buff[i + 3]);
            //    sBuff += Environment.NewLine;
            //}
            this.BeginInvoke(AlarmInfo, sBuff);






            //struAlarmInfoV30 = (CHCNetSDK.NET_DVR_ALARMINFO_V30)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO_V30));

            //byte[] nChannel = null;
            //byte[] nDisk = null;
            //int totalCh = CHCNetSDK.MAX_CHANNUM_V30;// > 16 ? 16 : CHCNetSDK.MAX_CHANNUM_V30;
            //int totalDsk = CHCNetSDK.MAX_DISKNUM_V30;

            //string strCh;
            //string strDsk;
            //int i;

            //nChannel = struAlarmInfoV30.byChannel;
            //strCh = "Chn[";
            //for (i = 0; i < totalCh; i++)
            //    strCh += nChannel[i].ToString();
            //strCh += "]";

            //nDisk = struAlarmInfoV30.byDiskNumber;
            //strDsk = "Dsk[";
            //for (i = 0; i < totalDsk; i++)
            //    strDsk += nDisk[i].ToString();
            //strDsk += "]";



            //switch (struAlarmInfoV30.dwAlarmType)
            //{
            //    case 0:// === neutilizat
            //        this.BeginInvoke(AlarmInfo, "sensor alarm");
            //        break;

            //    // info in DISKS index table
            //    case 1:
            //        this.BeginInvoke(AlarmInfo, "hard disk full" + strDsk);
            //        break;

            //    // info in CHANNELS index table
            //    case 2:

            //        this.BeginInvoke(AlarmInfo, "video lost. " + strCh);
            //        break;

            //    // info in CHANNELS index table
            //    case 3:

            //        this.BeginInvoke(AlarmInfo, "Motion: " + strCh);
            //        //System.Threading.Thread.Sleep(2000);
            //        this.BeginInvoke(AlarmInfo, "================");
            //        break;

            //    // info in DISKS index table
            //    case 4:
            //        this.BeginInvoke(AlarmInfo, "hard disk unformatted" + strDsk);
            //        break;

            //    // info in DISKS index table
            //    case 5:

            //        this.BeginInvoke(AlarmInfo, "HDD error: " + strDsk);
            //        break;

            //    // info in CHANNELS index table
            //    case 6:
            //        this.BeginInvoke(AlarmInfo, "tampering detection" + strCh);
            //        break;

            //    case 7:// === neutilizat
            //        this.BeginInvoke(AlarmInfo, "unmatched video output standard");
            //        break;
            //    case 8:// === neutilizat
            //        this.BeginInvoke(AlarmInfo, "illegal operation");
            //        break;

            //    // info in CHANNELS index table
            //    case 9:
            //        this.BeginInvoke(AlarmInfo, "videl Signal abnormal" + strCh);
            //        break;

            //    // info in CHANNELS index table
            //    case 10:
            //        this.BeginInvoke(AlarmInfo, "REC abnormal: " + strCh);
            //        break;

            //    default:// === neutilizat
            //        this.BeginInvoke(AlarmInfo, "Unknow alarm");
            //        break;
            //}

        }


        // Start alarm Listener
        private void button7_Click(object sender, EventArgs e)
        {
            if (m_falarmData != null)
            {
                if (m_lAlarmHandle == -1)
                {
                    m_lAlarmHandle = CHCNetSDK.NET_DVR_StartListen_V30(textBox4.Text, Convert.ToUInt16(textBox5.Text), m_falarmData, IntPtr.Zero);
                    //m_lAlarmHandle = CHCNetSDK.NET_DVR_StartListen(textBox4.Text, Convert.ToUInt16(textBox5.Text))==true?1:-1;
                    if (m_lAlarmHandle < 0)
                    {
                        uint i = CHCNetSDK.NET_DVR_GetLastError();
                        BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("NET_DVR_StartListen_V30 Fail with error: {0}", i));
                        m_lAlarmHandle = -1;
                        //m_falarmData = null;
                    }
                    else
                    {
                        BeginInvoke(new MyDebugInfo(DebugInfo), "Listener On!");
                        textBox4.Enabled = false; textBox5.Enabled = false;
                    }
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Listener already on!");
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "NET_DVR_SetDVRMessageCallBack_V30 not set yet!");
        }

        // Stop alarm Listener
        private void button8_Click(object sender, EventArgs e)
        {
            if (m_lAlarmHandle >= 0)
            {
                if (CHCNetSDK.NET_DVR_StopListen_V30(m_lAlarmHandle))
                //if (CHCNetSDK.NET_DVR_StopListen())
                {
                    m_lAlarmHandle = -1;
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Listener OFF!");
                    textBox4.Enabled = true; textBox5.Enabled = true;
                }
                else
                    BeginInvoke(new MyDebugInfo(DebugInfo), "Failed to stop Listener!");
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "Listener already OFF!");
        }

        // clear textbox
        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            LocalIPAddress = GetLocalIP();
            textBox4.Text = LocalIPAddress;
            textBox5.Text = LocalPort.ToString();
            textBox_Ch.Text = nChNo.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Turbo HD -> DS-8100 Series
            DVRUserName = "admin";

            DVRPassword = "1qaz2wsx";
            DVRIPAddress = "10.10.10.208";

            DVRPortNumber = 8000;
            nChNo = 33;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to DS-7600 series!");

        }

        private void btn_NVR_Click(object sender, EventArgs e)
        {
            DVRUserName = "admin";
            DVRPassword = "CaVi00pro";
            DVRIPAddress = "87.243.6.12";
            DVRPortNumber = 8082;
            nChNo = 33;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to NVR!");
        }

        private void btn_DVR_V30_Click(object sender, EventArgs e)
        {
            DVRUserName = "admin";
            DVRPassword = "111234";//12345
            DVRIPAddress = "10.10.10.210";
            DVRPortNumber = 8000;
            nChNo = 1;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to DVR_V30!");
        }

        private void btn_DVR_V40_Click(object sender, EventArgs e)
        {
            DVRUserName = "admin";
            DVRPassword = "1qaz@WSX";
            DVRIPAddress = "10.10.10.203";
            DVRPortNumber = 8000;
            nChNo = 1;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to DVR_V40!");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bPauseMessages = (checkBox1.CheckState == CheckState.Checked ? true : false);
        }

        private IntPtr MarshalToPointer(object data)
        {
            IntPtr buf = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            Marshal.StructureToPtr(data, buf, false);
            return buf;
        }

        private object MarshalToStruct(IntPtr buf, Type t)
        {
            return Marshal.PtrToStructure(buf, t);
        }

        [StructLayout(LayoutKind.Explicit)]
        struct DWORD
        {

            [FieldOffset(0)]
            public uint Value;

            [FieldOffset(0)]
            public ushort LOWORD;

            [FieldOffset(2)]
            public ushort HIWORD;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct WORD
        {

            [FieldOffset(0)]
            public ushort Value;

            [FieldOffset(0)]
            public byte LOBYTE;

            [FieldOffset(1)]
            public byte HIBYTE;
        }

        private void btn_GetConfig_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_DEVICECFG_V40 m_struDeviceCfg = new CHCNetSDK.NET_DVR_DEVICECFG_V40();
            IntPtr lpstruct = MarshalToPointer(m_struDeviceCfg);

            if (m_lUserID >= 0)
            {
                uint bytesRet = 0;
                string sir = "====== Config: ======" + Environment.NewLine;

                if (CHCNetSDK.NET_DVR_GetDVRConfig(
                    m_lUserID,
                    (uint)(CHCNetSDK.NET_DVR_GET_DEVICECFG_V40),
                    0,
                    lpstruct,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(m_struDeviceCfg),
                    ref bytesRet))
                {
                    m_struDeviceCfg = (CHCNetSDK.NET_DVR_DEVICECFG_V40)MarshalToStruct(lpstruct, typeof(CHCNetSDK.NET_DVR_DEVICECFG_V40));


                    sir += string.Format("Firmware version [{0}.{1}.{2}], build [{3:00}-{4:00}-{5:00}]",
                        m_struDeviceCfg.dwSoftwareVersion >> 24,
                        (m_struDeviceCfg.dwSoftwareVersion >> 16) & 0xFF,
                        m_struDeviceCfg.dwSoftwareVersion & 0xFFFF,
                        (m_struDeviceCfg.dwSoftwareBuildDate >> 16) + 2000, // year
                        (m_struDeviceCfg.dwSoftwareBuildDate & 0xFF00) >> 8, // month
                        m_struDeviceCfg.dwSoftwareBuildDate & 0xFF); // day
                    sir += Environment.NewLine;

                    sir += string.Format("Network ports: {0}",
                        m_struDeviceCfg.byNetworkPortNum);
                    sir += Environment.NewLine;


                    int nDeviveTypeNameLen = 24;
                    for (int i = 0; i < 24; i++)
                    {
                        if (m_struDeviceCfg.byDevTypeName[i] == 0)
                        {
                            nDeviveTypeNameLen = i;
                            break;
                        }
                    }
                    sir += "Device model: ";
                    if (nDeviveTypeNameLen > 0)
                        sir += System.Text.Encoding.ASCII.GetString(m_struDeviceCfg.byDevTypeName, 0, nDeviveTypeNameLen);
                    else
                        sir += "[undefined]";
                    sir += Environment.NewLine;


                    sir += string.Format("Analog Ch[{0}], Digital Ch[{1}], Disks[{2}]", m_struDeviceCfg.byChanNum, m_struDeviceCfg.byIPChanNum, m_struDeviceCfg.byDiskNum);
                    sir += Environment.NewLine;

                    sir += string.Format("Start Analog Ch: {0}",
                        m_struDeviceCfg.byStartChan);
                    sir += Environment.NewLine;

                    BeginInvoke(new MyDebugInfo(DebugInfo), sir);
                }
                else
                {
                    BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Failed with err[{0}]", CHCNetSDK.NET_DVR_GetLastError()));
                }
            }

            Marshal.FreeHGlobal(lpstruct);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DVRUserName = "admin";
            DVRPassword = "3004";
            DVRIPAddress = "81.180.121.118";
            DVRPortNumber = 8100;
            nChNo = 1;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to Contesti 1!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DVRUserName = "admin";
            DVRPassword = "3004";
            DVRIPAddress = "81.180.121.118";
            DVRPortNumber = 8200;
            nChNo = 1;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to Contesti 2!");

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bAuto = (checkBox2.CheckState == CheckState.Checked);
            timerAutoOpen.Enabled = bAuto;
            BeginInvoke(new MyDebugInfo(DebugInfo), string.Format("Auto open/close = {0}", bAuto.ToString()));
        }

        private void timerAutoOpen_Tick(object sender, EventArgs e)
        {
            if (m_lRealHandle == -1)
                OpenVideo();
            else
                CloseVideo();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Turbo HD -> DS-8100 Series
            DVRUserName = "admin";
            DVRPassword = "cavi1234";
            DVRIPAddress = "10.10.10.101";

            //DVRPassword = "1qaz2WSX";
            //DVRIPAddress = "10.10.10.90";

            DVRPortNumber = 8000;
            nChNo = 1;
            textBox1.Text = DVRIPAddress;
            textBox3.Text = DVRPortNumber.ToString();
            textBox_Ch.Text = nChNo.ToString();
            BeginInvoke(new MyDebugInfo(DebugInfo), "Switch parameters to DS-8100 series!");

        }
        private void SwitchRecording()
        {
            if (m_lRealHandle >= 0)
            {
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
            }
            else
                BeginInvoke(new MyDebugInfo(DebugInfo), "Open stream first!");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SwitchRecording();
        }


    }
}
