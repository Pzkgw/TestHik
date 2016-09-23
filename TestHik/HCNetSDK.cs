using System;
using System.Runtime.InteropServices;

namespace TestHik
{
    public class CHCNetSDK
    {
        public CHCNetSDK()
        {
            //
            // TODO: 
            //
        }

        /***************************************************************************/
        public const int MAX_SUBSYSTEM_NUM = 80;
        public const int MAX_SERIALLEN = 36;
        public const int MAX_LOOPPLANNUM = 16;
        public const int DECODE_TIMESEGMENT = 4;

        public const int MAX_DOMAIN_NAME = 64;
        public const int MAX_DISKNUM_V30 = 33;
        public const int MAX_DAYS = 7;

        public const int NET_DVR_DEV_ADDRESS_MAX_LEN = 129;
        public const int NET_DVR_LOGIN_USERNAME_MAX_LEN = 64;
        public const int NET_DVR_LOGIN_PASSWD_MAX_LEN = 64;


        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct NET_DVR_SUBSYSTEMINFO
        {
            public byte bySubSystemType;
            public byte byChan;
            public byte byLoginType;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_IPADDR struSubSystemIP;
            public ushort wSubSystemPort;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes2;

            public NET_DVR_IPADDR struSubSystemIPMask;
            public NET_DVR_IPADDR struGatewayIpAddr;

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] sUserName;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] sPassword;

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = MAX_DOMAIN_NAME)]
            public string sDomainName;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = MAX_DOMAIN_NAME)]
            public string sDnsAddress;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] sSerialNumber;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_ALLSUBSYSTEMINFO
        {
            public uint dwSize;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = MAX_SUBSYSTEM_NUM, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public NET_DVR_SUBSYSTEMINFO[] struSubSystemInfo;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_LOOPPLAN_SUBCFG
        {
            public uint dwSize;
            public uint dwPoolTime;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = MAX_CYCLE_CHAN_V30, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public NET_DVR_MATRIX_CHAN_INFO_V30[] struChanConInfo;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_LOOPPLAN_ARRAYCFG
        {
            public uint dwSize;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = MAX_LOOPPLANNUM, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public NET_DVR_LOOPPLAN_SUBCFG[] struLoopPlanSubCfg;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_ALARMMODECFG
        {
            public uint dwSize;
            public byte byAlarmMode;
            public ushort wLoopTime;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_CODESYSTEMINFO
        {
            public byte bySerialNum;
            public byte byChan;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes1;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_CODESPLITTERINFO
        {
            public uint dwSize;
            public NET_DVR_IPADDR struIP;
            public ushort wPort;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes1;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] sUserName;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] sPassword;
            public byte byChan;
            public byte by485Port;
            public ushort wBaudRate;
            public byte byDataBit;
            public byte byStopBit;
            public byte byParity;
            public byte byFlowControl;
            public ushort wDecoderType;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes2;
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_CODESPLITTERCFG
        {
            public uint dwSize;
            public NET_DVR_CODESYSTEMINFO struCodeSubsystemInfo;
            public NET_DVR_CODESPLITTERINFO struCodeSplitterInfo;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_ASSOCIATECFG
        {
            public byte byAssociateType;
            public ushort wAlarmDelay;
            public byte byAlarmNum;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_DYNAMICDECODE
        {
            public uint dwSize;
            public NET_DVR_ASSOCIATECFG struAssociateCfg;
            public NET_DVR_PU_STREAM_CFG struPuStreamCfg;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_DECODESCHED
        {
            public NET_DVR_SCHEDTIME struSchedTime;
            public byte byDecodeType;
            public byte byLoopGroup;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_PU_STREAM_CFG struDynamicDec;
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_PLANDECODE
        {
            public uint dwSize;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = MAX_DAYS * DECODE_TIMESEGMENT, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public NET_DVR_DECODESCHED[] struDecodeSched;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byres;
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_VIDEOPLATFORM_ABILITY
        {
            public uint dwSize;
            public byte byCodeSubSystemNums;
            public byte byDecodeSubSystemNums;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byWindowMode;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
        }

        public const int VIDEOPLATFORM_ABILITY = 0x210;
        /************************************end***************************************/


        public const int SDK_PLAYMPEG4 = 1;
        public const int SDK_HCNETSDK = 2;


        public const int INSERTTYPE = 0;
        public const int MODIFYTYPE = 1;
        public const int DELETETYPE = 2;
        /**********************************************************************************/

        public const int DEF_OPE_PREVIEW = 1;
        public const int DEF_OPE_TALK = 2;
        public const int DEF_OPE_SETALARM = 3;
        public const int DEF_OPE_PTZCTRL = 4;
        public const int DEF_OPE_VIDEOPARAM = 5;
        public const int DEF_OPE_PLAYBACK = 6;
        public const int DEF_OPE_REMOTECFG = 7;
        public const int DEF_OPE_GETSERVSTATE = 8;
        public const int DEF_OPE_CHECKTIME = 9;




        public const int DEF_OPE_PRE_STARTPREVIEW = 1;
        public const int DEF_OPE_PRE_STOPPREVIEW = 2;
        public const int DEF_OPE_PRE_STRATCYCPLAY = 3;
        public const int DEF_OPE_PRE_STOPCYCPLAY = 4;
        public const int DEF_OPE_PRE_STARTRECORD = 5;
        public const int DEF_OPE_PRE_STOPRECORD = 6;
        public const int DEF_OPE_PRE_CAPTURE = 7;
        public const int DEF_OPE_PRE_OPENSOUND = 8;
        public const int DEF_OPE_PRE_CLOSESOUND = 9;


        public const int DEF_OPE_TALK_STARTTALK = 1;
        public const int DEF_OPE_TALK_STOPTALK = 2;

        public const int DEF_OPE_ALARM_SETALARM = 1;
        public const int DEF_OPE_ALARM_WITHDRAWALARM = 2;

        public const int DEF_OPE_PTZ_PTZCTRL = 1;

        public const int DEF_OPE_VIDEOPARAM_SET = 1;


        public const int DEF_OPE_PLAYBACK_LOCALSEARCH = 1;
        public const int DEF_OPE_PLAYBACK_LOCALPLAY = 2;
        public const int DEF_OPE_PLAYBACK_LOCALDOWNLOAD = 3;
        public const int DEF_OPE_PLAYBACK_REMOTESEARCH = 4;
        public const int DEF_OPE_PLAYBACK_REMOTEPLAYFILE = 5;
        public const int DEF_OPE_PLAYBACK_REMOTEPLAYTIME = 6;
        public const int DEF_OPE_PLAYBACK_REMOTEDOWNLOAD = 7;

        public const int DEF_OPE_REMOTE_REMOTECFG = 1;

        public const int DEF_OPE_STATE_GETSERVSTATE = 1;

        public const int DEF_OPE_CHECKT_CHECKTIME = 1;


        public const int DEF_ALARM_IO = 1;
        public const int DEF_ALARM_HARDFULL = 2;
        public const int DEF_ALARM_VL = 3;
        public const int DEF_ALARM_MV = 4;
        public const int DEF_ALARM_HARDFORMAT = 5;
        public const int DEF_ALARM_HARDERROR = 6;
        public const int DEF_ALARM_VH = 7;
        public const int DEF_ALARM_NOPATCH = 8;
        public const int DEF_ALARM_ERRORVISIT = 9;
        public const int DEF_ALARM_EXCEPTION = 10;
        public const int DEF_ALARM_RECERROR = 11;


        public const int DEF_SYS_LOGIN = 1;
        public const int DEF_SYS_LOGOUT = 2;
        public const int DEF_SYS_LOCALCFG = 3;




        public const int NAME_LEN = 32;
        public const int PASSWD_LEN = 16;
        public const int MAX_NAMELEN = 16;
        public const int MAX_RIGHT = 32;
        public const int SERIALNO_LEN = 48;
        public const int MACADDR_LEN = 6;
        public const int MAX_ETHERNET = 2;
        public const int PATHNAME_LEN = 128;

        public const int MAX_TIMESEGMENT_V30 = 8;
        public const int MAX_TIMESEGMENT = 4;

        public const int MAX_SHELTERNUM = 4;
        public const int PHONENUMBER_LEN = 32;

        public const int MAX_DISKNUM = 16;
        public const int MAX_DISKNUM_V10 = 8;

        public const int MAX_WINDOW_V30 = 32;
        public const int MAX_WINDOW = 16;
        public const int MAX_VGA_V30 = 4;
        public const int MAX_VGA = 1;

        public const int MAX_USERNUM_V30 = 32;
        public const int MAX_USERNUM = 16;
        public const int MAX_EXCEPTIONNUM_V30 = 32;
        public const int MAX_EXCEPTIONNUM = 16;
        public const int MAX_LINK = 6;

        public const int MAX_DECPOOLNUM = 4;
        public const int MAX_DECNUM = 4;
        public const int MAX_TRANSPARENTNUM = 2;
        public const int MAX_CYCLE_CHAN = 16;
        public const int MAX_CYCLE_CHAN_V30 = 64;
        public const int MAX_DIRNAME_LENGTH = 80;
        public const int MAX_WINDOWS = 16;

        public const int MAX_STRINGNUM_V30 = 8;
        public const int MAX_STRINGNUM = 4;
        public const int MAX_STRINGNUM_EX = 8;
        public const int MAX_AUXOUT_V30 = 16;
        public const int MAX_AUXOUT = 4;
        public const int MAX_HD_GROUP = 16;
        public const int MAX_NFS_DISK = 8;

        public const int IW_ESSID_MAX_SIZE = 32;
        public const int IW_ENCODING_TOKEN_MAX = 32;
        public const int MAX_SERIAL_NUM = 64;
        public const int MAX_DDNS_NUMS = 10;
        public const int MAX_EMAIL_ADDR_LEN = 48;
        public const int MAX_EMAIL_PWD_LEN = 32;

        public const int MAXPROGRESS = 100;
        public const int MAX_SERIALNUM = 2;
        public const int CARDNUM_LEN = 20;
        public const int MAX_VIDEOOUT_V30 = 4;
        public const int MAX_VIDEOOUT = 2;

        public const int MAX_PRESET_V30 = 256;
        public const int MAX_TRACK_V30 = 256;
        public const int MAX_CRUISE_V30 = 256;
        public const int MAX_PRESET = 128;
        public const int MAX_TRACK = 128;
        public const int MAX_CRUISE = 128;

        public const int CRUISE_MAX_PRESET_NUMS = 32;

        public const int MAX_SERIAL_PORT = 8;
        public const int MAX_PREVIEW_MODE = 8;
        public const int MAX_MATRIXOUT = 16;
        public const int LOG_INFO_LEN = 11840;
        public const int DESC_LEN = 16;
        public const int PTZ_PROTOCOL_NUM = 200;

        public const int MAX_AUDIO = 1;
        public const int MAX_AUDIO_V30 = 2;
        public const int MAX_CHANNUM = 16;
        public const int MAX_ALARMIN = 16;
        public const int MAX_ALARMOUT = 4;

        public const int MAX_ANALOG_CHANNUM = 32;
        public const int MAX_ANALOG_ALARMOUT = 32;
        public const int MAX_ANALOG_ALARMIN = 32;

        public const int MAX_IP_DEVICE = 32;
        public const int MAX_IP_CHANNEL = 32;
        public const int MAX_IP_ALARMIN = 128;
        public const int MAX_IP_ALARMOUT = 64;


        public const int MAX_ATM_NUM = 1;
        public const int MAX_ACTION_TYPE = 12;
        public const int ATM_FRAMETYPE_NUM = 4;
        public const int MAX_ATM_PROTOCOL_NUM = 1025;
        public const int ATM_PROTOCOL_SORT = 4;
        public const int ATM_DESC_LEN = 32;



        public const int MAX_CHANNUM_V30 = MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL;
        public const int MAX_ALARMOUT_V30 = MAX_ANALOG_ALARMOUT + MAX_IP_ALARMOUT;
        public const int MAX_ALARMIN_V30 = MAX_ANALOG_ALARMIN + MAX_IP_ALARMIN;


        public const int NORMALCONNECT = 1;
        public const int MEDIACONNECT = 2;


        public const int HCDVR = 1;
        public const int MEDVR = 2;
        public const int PCDVR = 3;
        public const int HC_9000 = 4;
        public const int HF_I = 5;
        public const int PCNVR = 6;
        public const int HC_76NVR = 8;


        public const int DS8000HC_NVR = 0;
        public const int DS9000HC_NVR = 1;
        public const int DS8000ME_NVR = 2;


        public const int NET_DVR_NOERROR = 0;
        public const int NET_DVR_PASSWORD_ERROR = 1;
        public const int NET_DVR_NOENOUGHPRI = 2;
        public const int NET_DVR_NOINIT = 3;
        public const int NET_DVR_CHANNEL_ERROR = 4;
        public const int NET_DVR_OVER_MAXLINK = 5;
        public const int NET_DVR_VERSIONNOMATCH = 6;
        public const int NET_DVR_NETWORK_FAIL_CONNECT = 7;
        public const int NET_DVR_NETWORK_SEND_ERROR = 8;
        public const int NET_DVR_NETWORK_RECV_ERROR = 9;
        public const int NET_DVR_NETWORK_RECV_TIMEOUT = 10;
        public const int NET_DVR_NETWORK_ERRORDATA = 11;
        public const int NET_DVR_ORDER_ERROR = 12;
        public const int NET_DVR_OPERNOPERMIT = 13;
        public const int NET_DVR_COMMANDTIMEOUT = 14;
        public const int NET_DVR_ERRORSERIALPORT = 15;
        public const int NET_DVR_ERRORALARMPORT = 16;
        public const int NET_DVR_PARAMETER_ERROR = 17;
        public const int NET_DVR_CHAN_EXCEPTION = 18;
        public const int NET_DVR_NODISK = 19;
        public const int NET_DVR_ERRORDISKNUM = 20;
        public const int NET_DVR_DISK_FULL = 21;
        public const int NET_DVR_DISK_ERROR = 22;
        public const int NET_DVR_NOSUPPORT = 23;
        public const int NET_DVR_BUSY = 24;
        public const int NET_DVR_MODIFY_FAIL = 25;
        public const int NET_DVR_PASSWORD_FORMAT_ERROR = 26;
        public const int NET_DVR_DISK_FORMATING = 27;
        public const int NET_DVR_DVRNORESOURCE = 28;
        public const int NET_DVR_DVROPRATEFAILED = 29;
        public const int NET_DVR_OPENHOSTSOUND_FAIL = 30;
        public const int NET_DVR_DVRVOICEOPENED = 31;
        public const int NET_DVR_TIMEINPUTERROR = 32;
        public const int NET_DVR_NOSPECFILE = 33;
        public const int NET_DVR_CREATEFILE_ERROR = 34;
        public const int NET_DVR_FILEOPENFAIL = 35;
        public const int NET_DVR_OPERNOTFINISH = 36;
        public const int NET_DVR_GETPLAYTIMEFAIL = 37;
        public const int NET_DVR_PLAYFAIL = 38;
        public const int NET_DVR_FILEFORMAT_ERROR = 39;
        public const int NET_DVR_DIR_ERROR = 40;
        public const int NET_DVR_ALLOC_RESOURCE_ERROR = 41;
        public const int NET_DVR_AUDIO_MODE_ERROR = 42;
        public const int NET_DVR_NOENOUGH_BUF = 43;
        public const int NET_DVR_CREATESOCKET_ERROR = 44;
        public const int NET_DVR_SETSOCKET_ERROR = 45;
        public const int NET_DVR_MAX_NUM = 46;
        public const int NET_DVR_USERNOTEXIST = 47;
        public const int NET_DVR_WRITEFLASHERROR = 48;
        public const int NET_DVR_UPGRADEFAIL = 49;
        public const int NET_DVR_CARDHAVEINIT = 50;
        public const int NET_DVR_PLAYERFAILED = 51;
        public const int NET_DVR_MAX_USERNUM = 52;
        public const int NET_DVR_GETLOCALIPANDMACFAIL = 53;
        public const int NET_DVR_NOENCODEING = 54;
        public const int NET_DVR_IPMISMATCH = 55;
        public const int NET_DVR_MACMISMATCH = 56;
        public const int NET_DVR_UPGRADELANGMISMATCH = 57;
        public const int NET_DVR_MAX_PLAYERPORT = 58;
        public const int NET_DVR_NOSPACEBACKUP = 59;
        public const int NET_DVR_NODEVICEBACKUP = 60;
        public const int NET_DVR_PICTURE_BITS_ERROR = 61;
        public const int NET_DVR_PICTURE_DIMENSION_ERROR = 62;
        public const int NET_DVR_PICTURE_SIZ_ERROR = 63;
        public const int NET_DVR_LOADPLAYERSDKFAILED = 64;
        public const int NET_DVR_LOADPLAYERSDKPROC_ERROR = 65;
        public const int NET_DVR_LOADDSSDKFAILED = 66;
        public const int NET_DVR_LOADDSSDKPROC_ERROR = 67;
        public const int NET_DVR_DSSDK_ERROR = 68;
        public const int NET_DVR_VOICEMONOPOLIZE = 69;
        public const int NET_DVR_JOINMULTICASTFAILED = 70;
        public const int NET_DVR_CREATEDIR_ERROR = 71;
        public const int NET_DVR_BINDSOCKET_ERROR = 72;
        public const int NET_DVR_SOCKETCLOSE_ERROR = 73;
        public const int NET_DVR_USERID_ISUSING = 74;
        public const int NET_DVR_SOCKETLISTEN_ERROR = 75;
        public const int NET_DVR_PROGRAM_EXCEPTION = 76;
        public const int NET_DVR_WRITEFILE_FAILED = 77;
        public const int NET_DVR_FORMAT_READONLY = 78;
        public const int NET_DVR_WITHSAMEUSERNAME = 79;
        public const int NET_DVR_DEVICETYPE_ERROR = 80;
        public const int NET_DVR_LANGUAGE_ERROR = 81;
        public const int NET_DVR_PARAVERSION_ERROR = 82;
        public const int NET_DVR_IPCHAN_NOTALIVE = 83;
        public const int NET_DVR_RTSP_SDK_ERROR = 84;
        public const int NET_DVR_CONVERT_SDK_ERROR = 85;
        public const int NET_DVR_IPC_COUNT_OVERFLOW = 86;

        public const int NET_PLAYM4_NOERROR = 500;//no error
        public const int NET_PLAYM4_PARA_OVER = 501;//input parameter is invalid
        public const int NET_PLAYM4_ORDER_ERROR = 502;//The order of the function to be called is error
        public const int NET_PLAYM4_TIMER_ERROR = 503;//Create multimedia clock failed
        public const int NET_PLAYM4_DEC_VIDEO_ERROR = 504;//Decode video data failed
        public const int NET_PLAYM4_DEC_AUDIO_ERROR = 505;//Decode audio data failed
        public const int NET_PLAYM4_ALLOC_MEMORY_ERROR = 506;//Allocate memory failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR = 507;//Open the file failed
        public const int NET_PLAYM4_CREATE_OBJ_ERROR = 508;//Create thread or event failed
        public const int NET_PLAYM4_CREATE_DDRAW_ERROR = 509;//Create DirectDraw object failed
        public const int NET_PLAYM4_CREATE_OFFSCREEN_ERROR = 510;//failed when creating off-screen surface
        public const int NET_PLAYM4_BUF_OVER = 511;//buffer is overflow
        public const int NET_PLAYM4_CREATE_SOUND_ERROR = 512;//failed when creating audio device
        public const int NET_PLAYM4_SET_VOLUME_ERROR = 513;//Set volume failed
        public const int NET_PLAYM4_SUPPORT_FILE_ONLY = 514;//The function only support play file
        public const int NET_PLAYM4_SUPPORT_STREAM_ONLY = 515;//The function only support play stream
        public const int NET_PLAYM4_SYS_NOT_SUPPORT = 516;//System not support
        public const int NET_PLAYM4_FILEHEADER_UNKNOWN = 517;//No file header
        public const int NET_PLAYM4_VERSION_INCORRECT = 518;//The version of decoder and encoder is not adapted
        public const int NET_PALYM4_INIT_DECODER_ERROR = 519;//Initialize decoder failed
        public const int NET_PLAYM4_CHECK_FILE_ERROR = 520;//The file data is unknown
        public const int NET_PLAYM4_INIT_TIMER_ERROR = 521;//Initialize multimedia clock failed
        public const int NET_PLAYM4_BLT_ERROR = 522;//Blt failed
        public const int NET_PLAYM4_UPDATE_ERROR = 523;//Update failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR_MULTI = 524;//openfile error, streamtype is multi
        public const int NET_PLAYM4_OPEN_FILE_ERROR_VIDEO = 525;//openfile error, streamtype is video
        public const int NET_PLAYM4_JPEG_COMPRESS_ERROR = 526;//JPEG compress error
        public const int NET_PLAYM4_EXTRACT_NOT_SUPPORT = 527;//Don't support the version of this file
        public const int NET_PLAYM4_EXTRACT_DATA_ERROR = 528;//extract video data failed



        public const int NET_DVR_SUPPORT_DDRAW = 1;
        public const int NET_DVR_SUPPORT_BLT = 2;
        public const int NET_DVR_SUPPORT_BLTFOURCC = 4;
        public const int NET_DVR_SUPPORT_BLTSHRINKX = 8;
        public const int NET_DVR_SUPPORT_BLTSHRINKY = 16;
        public const int NET_DVR_SUPPORT_BLTSTRETCHX = 32;
        public const int NET_DVR_SUPPORT_BLTSTRETCHY = 64;
        public const int NET_DVR_SUPPORT_SSE = 128;
        public const int NET_DVR_SUPPORT_MMX = 256;


        public const int LIGHT_PWRON = 2;
        public const int WIPER_PWRON = 3;
        public const int FAN_PWRON = 4;
        public const int HEATER_PWRON = 5;
        public const int AUX_PWRON1 = 6;
        public const int AUX_PWRON2 = 7;
        public const int SET_PRESET = 8;
        public const int CLE_PRESET = 9;

        public const int ZOOM_IN = 11;
        public const int ZOOM_OUT = 12;
        public const int FOCUS_NEAR = 13;
        public const int FOCUS_FAR = 14;
        public const int IRIS_OPEN = 15;
        public const int IRIS_CLOSE = 16;

        public const int TILT_UP = 21;
        public const int TILT_DOWN = 22;
        public const int PAN_LEFT = 23;
        public const int PAN_RIGHT = 24;
        public const int UP_LEFT = 25;
        public const int UP_RIGHT = 26;
        public const int DOWN_LEFT = 27;
        public const int DOWN_RIGHT = 28;
        public const int PAN_AUTO = 29;

        public const int FILL_PRE_SEQ = 30;
        public const int SET_SEQ_DWELL = 31;
        public const int SET_SEQ_SPEED = 32;
        public const int CLE_PRE_SEQ = 33;
        public const int STA_MEM_CRUISE = 34;
        public const int STO_MEM_CRUISE = 35;
        public const int RUN_CRUISE = 36;
        public const int RUN_SEQ = 37;
        public const int STOP_SEQ = 38;
        public const int GOTO_PRESET = 39;


        public const int NET_DVR_PLAYSTART = 1;// Start playing
        public const int NET_DVR_PLAYPAUSE = 3; //Pause
        public const int NET_DVR_PLAYRESTART = 4;// Macro Definition Resume play
        public const int NET_DVR_PLAYFAST = 5; //Fast
        public const int NET_DVR_PLAYSLOW = 6; //Slow
        public const int NET_DVR_PLAYNORMAL = 7; //Normal speed(resume the speed before after pause)
        public const int NET_DVR_PLAYFRAME = 8; //Play frame one by one(using the command NET_DVR_PLAYNORMAL to resume normal playback) 
        public const int NET_DVR_PLAYSTARTAUDIO = 9;// Open sound
        public const int NET_DVR_PLAYSTOPAUDIO = 10; //Close sound
        public const int NET_DVR_PLAYAUDIOVOLUME = 11; //Adjust the volume
        public const int NET_DVR_PLAYSETPOS = 12; //Change the progress of the file playback
        public const int NET_DVR_PLAYGETPOS = 13; //Get the progress of the file playback
        public const int NET_DVR_PLAYGETTIME = 14; //Get currently played time(valid when playing back by file)
        public const int NET_DVR_PLAYGETFRAME = 15; //Get currently played frames(valid when playing back by file)
        public const int NET_DVR_GETTOTALFRAMES = 16; //Get currently total frames(valid when playing back by file)
        public const int NET_DVR_GETTOTALTIME = 17;// Get currently total time(valid when playing back by file)
        public const int NET_DVR_THROWBFRAME = 20; //Throw B frame
        public const int NET_DVR_SETSPEED = 24; //Set speed of stream
        public const int NET_DVR_KEEPALIVE = 25; //Keep heartbeat with device(If the callback blocked, suggest setting 2s to send one time)
        public const int NET_DVR_PLAYSETTIME = 26;// Positioning by absolute time
        public const int NET_DVR_PLAYGETTOTALLEN = 27; //Get total length of all files in corresponding time period of playback by time
        public const int NET_DVR_PLAY_FORWARD = 29;// Switch rewind to forward playback
        public const int NET_DVR_PLAY_REVERSE = 30; //Switch forward playback to rewind(IPC doesn't support it) 
        public const int NET_DVR_SET_TRANS_TYPE = 32; //Set type of transcode
        public const int NET_DVR_PLAY_CONVERT = 33; //Convert stream format when playback, should be call before NET_DVR_PLAYSTART
        public const int NET_DVR_START_DRAWFRAME = 34; //Start frame extracting playback
        public const int NET_DVR_STOP_DRAWFRAME = 35; //Stop frame extracting playback



        /* key value send to CONFIG program */
        public const int KEY_CODE_1 = 1;
        public const int KEY_CODE_2 = 2;
        public const int KEY_CODE_3 = 3;
        public const int KEY_CODE_4 = 4;
        public const int KEY_CODE_5 = 5;
        public const int KEY_CODE_6 = 6;
        public const int KEY_CODE_7 = 7;
        public const int KEY_CODE_8 = 8;
        public const int KEY_CODE_9 = 9;
        public const int KEY_CODE_0 = 10;
        public const int KEY_CODE_POWER = 11;
        public const int KEY_CODE_MENU = 12;
        public const int KEY_CODE_ENTER = 13;
        public const int KEY_CODE_CANCEL = 14;
        public const int KEY_CODE_UP = 15;
        public const int KEY_CODE_DOWN = 16;
        public const int KEY_CODE_LEFT = 17;
        public const int KEY_CODE_RIGHT = 18;
        public const int KEY_CODE_EDIT = 19;
        public const int KEY_CODE_ADD = 20;
        public const int KEY_CODE_MINUS = 21;
        public const int KEY_CODE_PLAY = 22;
        public const int KEY_CODE_REC = 23;
        public const int KEY_CODE_PAN = 24;
        public const int KEY_CODE_M = 25;
        public const int KEY_CODE_A = 26;
        public const int KEY_CODE_F1 = 27;
        public const int KEY_CODE_F2 = 28;

        /* for PTZ control */
        public const int KEY_PTZ_UP_START = KEY_CODE_UP;
        public const int KEY_PTZ_UP_STOP = 32;

        public const int KEY_PTZ_DOWN_START = KEY_CODE_DOWN;
        public const int KEY_PTZ_DOWN_STOP = 33;


        public const int KEY_PTZ_LEFT_START = KEY_CODE_LEFT;
        public const int KEY_PTZ_LEFT_STOP = 34;

        public const int KEY_PTZ_RIGHT_START = KEY_CODE_RIGHT;
        public const int KEY_PTZ_RIGHT_STOP = 35;

        public const int KEY_PTZ_AP1_START = KEY_CODE_EDIT;
        public const int KEY_PTZ_AP1_STOP = 36;

        public const int KEY_PTZ_AP2_START = KEY_CODE_PAN;
        public const int KEY_PTZ_AP2_STOP = 37;

        public const int KEY_PTZ_FOCUS1_START = KEY_CODE_A;
        public const int KEY_PTZ_FOCUS1_STOP = 38;

        public const int KEY_PTZ_FOCUS2_START = KEY_CODE_M;
        public const int KEY_PTZ_FOCUS2_STOP = 39;

        public const int KEY_PTZ_B1_START = 40;
        public const int KEY_PTZ_B1_STOP = 41;

        public const int KEY_PTZ_B2_START = 42;
        public const int KEY_PTZ_B2_STOP = 43;


        public const int KEY_CODE_11 = 44;
        public const int KEY_CODE_12 = 45;
        public const int KEY_CODE_13 = 46;
        public const int KEY_CODE_14 = 47;
        public const int KEY_CODE_15 = 48;
        public const int KEY_CODE_16 = 49;


        public const int NET_DVR_GET_DEVICECFG = 100;
        public const int NET_DVR_SET_DEVICECFG = 101;
        public const int NET_DVR_GET_NETCFG = 102;
        public const int NET_DVR_SET_NETCFG = 103;
        public const int NET_DVR_GET_PICCFG = 104;
        public const int NET_DVR_SET_PICCFG = 105;
        public const int NET_DVR_GET_COMPRESSCFG = 106;
        public const int NET_DVR_SET_COMPRESSCFG = 107;
        public const int NET_DVR_GET_RECORDCFG = 108;
        public const int NET_DVR_SET_RECORDCFG = 109;
        public const int NET_DVR_GET_DECODERCFG = 110;
        public const int NET_DVR_SET_DECODERCFG = 111;
        public const int NET_DVR_GET_RS232CFG = 112;
        public const int NET_DVR_SET_RS232CFG = 113;
        public const int NET_DVR_GET_ALARMINCFG = 114;
        public const int NET_DVR_SET_ALARMINCFG = 115;
        public const int NET_DVR_GET_ALARMOUTCFG = 116;
        public const int NET_DVR_SET_ALARMOUTCFG = 117;
        public const int NET_DVR_GET_TIMECFG = 118;
        public const int NET_DVR_SET_TIMECFG = 119;
        public const int NET_DVR_GET_PREVIEWCFG = 120;
        public const int NET_DVR_SET_PREVIEWCFG = 121;
        public const int NET_DVR_GET_VIDEOOUTCFG = 122;
        public const int NET_DVR_SET_VIDEOOUTCFG = 123;
        public const int NET_DVR_GET_USERCFG = 124;
        public const int NET_DVR_SET_USERCFG = 125;
        public const int NET_DVR_GET_EXCEPTIONCFG = 126;
        public const int NET_DVR_SET_EXCEPTIONCFG = 127;
        public const int NET_DVR_GET_ZONEANDDST = 128;
        public const int NET_DVR_SET_ZONEANDDST = 129;
        public const int NET_DVR_GET_SHOWSTRING = 130;
        public const int NET_DVR_SET_SHOWSTRING = 131;
        public const int NET_DVR_GET_EVENTCOMPCFG = 132;
        public const int NET_DVR_SET_EVENTCOMPCFG = 133;

        public const int NET_DVR_GET_AUXOUTCFG = 140;
        public const int NET_DVR_SET_AUXOUTCFG = 141;
        public const int NET_DVR_GET_PREVIEWCFG_AUX = 142;
        public const int NET_DVR_SET_PREVIEWCFG_AUX = 143;

        public const int NET_DVR_GET_PICCFG_EX = 200;
        public const int NET_DVR_SET_PICCFG_EX = 201;
        public const int NET_DVR_GET_USERCFG_EX = 202;
        public const int NET_DVR_SET_USERCFG_EX = 203;
        public const int NET_DVR_GET_COMPRESSCFG_EX = 204;
        public const int NET_DVR_SET_COMPRESSCFG_EX = 205;

        public const int NET_DVR_GET_NETAPPCFG = 222;
        public const int NET_DVR_SET_NETAPPCFG = 223;
        public const int NET_DVR_GET_NTPCFG = 224;
        public const int NET_DVR_SET_NTPCFG = 225;
        public const int NET_DVR_GET_DDNSCFG = 226;
        public const int NET_DVR_SET_DDNSCFG = 227;

        public const int NET_DVR_GET_EMAILCFG = 228;
        public const int NET_DVR_SET_EMAILCFG = 229;

        public const int NET_DVR_GET_NFSCFG = 230;/* NFS disk config */
        public const int NET_DVR_SET_NFSCFG = 231;/* NFS disk config */

        public const int NET_DVR_GET_SHOWSTRING_EX = 238;
        public const int NET_DVR_SET_SHOWSTRING_EX = 239;
        public const int NET_DVR_GET_NETCFG_OTHER = 244;
        public const int NET_DVR_SET_NETCFG_OTHER = 245;


        public const int NET_DVR_GET_EMAILPARACFG = 250;//Get EMAIL parameters
        public const int NET_DVR_SET_EMAILPARACFG = 251;//Setup EMAIL parameters

        public const int NET_DVR_GET_DDNSCFG_EX = 274;
        public const int NET_DVR_SET_DDNSCFG_EX = 275;

        public const int NET_DVR_SET_PTZPOS = 292;
        public const int NET_DVR_GET_PTZPOS = 293;
        public const int NET_DVR_GET_PTZSCOPE = 294;



        public const int NET_DVR_GET_NETCFG_V30 = 1000;
        public const int NET_DVR_SET_NETCFG_V30 = 1001;


        public const int NET_DVR_GET_PICCFG_V30 = 1002;
        public const int NET_DVR_SET_PICCFG_V30 = 1003;


        public const int NET_DVR_GET_RECORDCFG_V30 = 1004;
        public const int NET_DVR_SET_RECORDCFG_V30 = 1005;


        public const int NET_DVR_GET_USERCFG_V30 = 1006;
        public const int NET_DVR_SET_USERCFG_V30 = 1007;


        public const int NET_DVR_GET_DDNSCFG_V30 = 1010;
        public const int NET_DVR_SET_DDNSCFG_V30 = 1011;


        public const int NET_DVR_GET_EMAILCFG_V30 = 1012;
        public const int NET_DVR_SET_EMAILCFG_V30 = 1013;


        public const int NET_DVR_GET_CRUISE = 1020;
        public const int NET_DVR_SET_CRUISE = 1021;


        public const int NET_DVR_GET_ALARMINCFG_V30 = 1024;
        public const int NET_DVR_SET_ALARMINCFG_V30 = 1025;


        public const int NET_DVR_GET_ALARMOUTCFG_V30 = 1026;
        public const int NET_DVR_SET_ALARMOUTCFG_V30 = 1027;


        public const int NET_DVR_GET_VIDEOOUTCFG_V30 = 1028;
        public const int NET_DVR_SET_VIDEOOUTCFG_V30 = 1029;


        public const int NET_DVR_GET_SHOWSTRING_V30 = 1030;
        public const int NET_DVR_SET_SHOWSTRING_V30 = 1031;


        public const int NET_DVR_GET_EXCEPTIONCFG_V30 = 1034;
        public const int NET_DVR_SET_EXCEPTIONCFG_V30 = 1035;


        public const int NET_DVR_GET_RS232CFG_V30 = 1036;
        public const int NET_DVR_SET_RS232CFG_V30 = 1037;


        public const int NET_DVR_GET_NET_DISKCFG = 1038;
        public const int NET_DVR_SET_NET_DISKCFG = 1039;


        public const int NET_DVR_GET_COMPRESSCFG_V30 = 1040;
        public const int NET_DVR_SET_COMPRESSCFG_V30 = 1041;


        public const int NET_DVR_GET_DECODERCFG_V30 = 1042;
        public const int NET_DVR_SET_DECODERCFG_V30 = 1043;


        public const int NET_DVR_GET_PREVIEWCFG_V30 = 1044;
        public const int NET_DVR_SET_PREVIEWCFG_V30 = 1045;


        public const int NET_DVR_GET_PREVIEWCFG_AUX_V30 = 1046;
        public const int NET_DVR_SET_PREVIEWCFG_AUX_V30 = 1047;


        public const int NET_DVR_GET_IPPARACFG = 1048;
        public const int NET_DVR_SET_IPPARACFG = 1049;


        public const int NET_DVR_GET_IPALARMINCFG = 1050;
        public const int NET_DVR_SET_IPALARMINCFG = 1051;


        public const int NET_DVR_GET_IPALARMOUTCFG = 1052;
        public const int NET_DVR_SET_IPALARMOUTCFG = 1053;


        public const int NET_DVR_GET_HDCFG = 1054;
        public const int NET_DVR_SET_HDCFG = 1055;


        public const int NET_DVR_GET_HDGROUP_CFG = 1056;
        public const int NET_DVR_SET_HDGROUP_CFG = 1057;


        public const int NET_DVR_GET_COMPRESSCFG_AUD = 1058;
        public const int NET_DVR_SET_COMPRESSCFG_AUD = 1059;


        public const int NET_DVR_GET_IPPARACFG_V31 = 1060;
        public const int NET_DVR_SET_IPPARACFG_V31 = 1061;

        public const int NET_DVR_GET_DEVICECFG_V40 = 1100;




        public const int NET_DVR_FILE_SUCCESS = 1000;
        public const int NET_DVR_FILE_NOFIND = 1001;
        public const int NET_DVR_ISFINDING = 1002;
        public const int NET_DVR_NOMOREFILE = 1003;
        public const int NET_DVR_FILE_EXCEPTION = 1004;


        public const int COMM_ALARM = 4352;
        public const int COMM_TRADEINFO = 5376;
        public const int COMM_ALARM_V30 = 16384;
        public const int COMM_ALARM_V40 = 16391; //0x4007
        public const int COMM_IPCCFG = 16385;
        public const int COMM_IPCCFG_V31 = 16386;
        public const int COMM_ALARM_RULE_CALC = 0x1110;


        public const int EXCEPTION_EXCHANGE = 32768;
        public const int EXCEPTION_AUDIOEXCHANGE = 32769;
        public const int EXCEPTION_ALARM = 32770;
        public const int EXCEPTION_PREVIEW = 32771;
        public const int EXCEPTION_SERIAL = 32772;
        public const int EXCEPTION_RECONNECT = 32773;
        public const int EXCEPTION_ALARMRECONNECT = 32774;
        public const int EXCEPTION_SERIALRECONNECT = 32775;
        public const int EXCEPTION_PLAYBACK = 32784;
        public const int EXCEPTION_DISKFMT = 32785;


        public const int NET_DVR_SYSHEAD = 1;
        public const int NET_DVR_STREAMDATA = 2;
        public const int NET_DVR_AUDIOSTREAMDATA = 3;
        public const int NET_DVR_STD_VIDEODATA = 4;
        public const int NET_DVR_STD_AUDIODATA = 5;
        public const int NET_DVR_CHANGE_FORWARD = 10;
        public const int NET_DVR_CHANGE_REVERSE = 11;


        public const int NET_DVR_REALPLAYEXCEPTION = 111;
        public const int NET_DVR_REALPLAYNETCLOSE = 112;
        public const int NET_DVR_REALPLAY5SNODATA = 113;
        public const int NET_DVR_REALPLAYRECONNECT = 114;


        public const int NET_DVR_PLAYBACKOVER = 101;
        public const int NET_DVR_PLAYBACKEXCEPTION = 102;
        public const int NET_DVR_PLAYBACKNETCLOSE = 103;
        public const int NET_DVR_PLAYBACK5SNODATA = 104;



        public const int DVR = 1;
        public const int ATMDVR = 2;/*atm dvr*/
        public const int DVS = 3;/*DVS*/
        public const int DEC = 4;/* 6001D */
        public const int ENC_DEC = 5;/* 6001F */
        public const int DVR_HC = 6;/*8000HC*/
        public const int DVR_HT = 7;/*8000HT*/
        public const int DVR_HF = 8;/*8000HF*/
        public const int DVR_HS = 9;/* 8000HS DVR(no audio) */
        public const int DVR_HTS = 10; /* 8016HTS DVR(no audio) */
        public const int DVR_HB = 11; /* HB DVR(SATA HD) */
        public const int DVR_HCS = 12; /* 8000HCS DVR */
        public const int DVS_A = 13;
        public const int DVR_HC_S = 14; /* 8000HC-S */
        public const int DVR_HT_S = 15;/* 8000HT-S */
        public const int DVR_HF_S = 16;/* 8000HF-S */
        public const int DVR_HS_S = 17; /* 8000HS-S */
        public const int ATMDVR_S = 18;/* ATM-S */
        public const int LOWCOST_DVR = 19;
        public const int DEC_MAT = 20;
        public const int DVR_MOBILE = 21;/* mobile DVR */
        public const int DVR_HD_S = 22;   /* 8000HD-S */
        public const int DVR_HD_SL = 23;/* 8000HD-SL */
        public const int DVR_HC_SL = 24;/* 8000HC-SL */
        public const int DVR_HS_ST = 25;/* 8000HS_ST */
        public const int DVS_HW = 26; /* 6000HW */
        public const int DS630X_D = 27;
        public const int IPCAM = 30;
        public const int MEGA_IPCAM = 31;
        public const int IPCAM_X62MF = 32;
        public const int IPDOME = 40;
        public const int IPDOME_MEGA200 = 41;
        public const int IPDOME_MEGA130 = 42;
        public const int IPMOD = 50;
        public const int DS71XX_H = 71;/* DS71XXH_S */
        public const int DS72XX_H_S = 72;/* DS72XXH_S */
        public const int DS73XX_H_S = 73;/* DS73XXH_S */
        public const int DS76XX_H_S = 76;/* DS76XX_H_S */
        public const int DS81XX_HS_S = 81;/* DS81XX_HS_S */
        public const int DS81XX_HL_S = 82;/* DS81XX_HL_S */
        public const int DS81XX_HC_S = 83;/* DS81XX_HC_S */
        public const int DS81XX_HD_S = 84;/* DS81XX_HD_S */
        public const int DS81XX_HE_S = 85;/* DS81XX_HE_S */
        public const int DS81XX_HF_S = 86;/* DS81XX_HF_S */
        public const int DS81XX_AH_S = 87;/* DS81XX_AH_S */
        public const int DS81XX_AHF_S = 88;/* DS81XX_AHF_S */
        public const int DS90XX_HF_S = 90;  /*DS90XX_HF_S*/
        public const int DS91XX_HF_S = 91;  /*DS91XX_HF_S*/
        public const int DS91XX_HD_S = 92; /*91XXHD-S(MD)*/



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_TIME
        {
            public uint dwYear;
            public uint dwMonth;
            public uint dwDay;
            public uint dwHour;
            public uint dwMinute;
            public uint dwSecond;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SCHEDTIME
        {
            public byte byStartHour;
            public byte byStartMin;
            public byte byStopHour;
            public byte byStopMin;
        }


        public const int NOACTION = 0;
        public const int WARNONMONITOR = 1;
        public const int WARNONAUDIOOUT = 2;
        public const int UPTOCENTER = 4;
        public const int TRIGGERALARMOUT = 8;


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HANDLEEXCEPTION_V30
        {
            public uint dwHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelAlarmOut;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HANDLEEXCEPTION
        {
            public uint dwHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelAlarmOut;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICECFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDVRName;
            public uint dwDVRID;
            public uint dwRecycleRecord;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public uint dwSoftwareVersion;
            public uint dwSoftwareBuildDate;
            public uint dwDSPSoftwareVersion;
            public uint dwDSPSoftwareBuildDate;
            public uint dwPanelVersion;
            public uint dwHardwareVersion;
            public byte byAlarmInPortNum;
            public byte byAlarmOutPortNum;
            public byte byRS232Num;
            public byte byRS485Num;
            public byte byNetworkPortNum;
            public byte byDiskCtrlNum;
            public byte byDiskNum;
            public byte byDVRType;
            public byte byChanNum;
            public byte byStartChan;
            public byte byDecordChans;
            public byte byVGANum;
            public byte byUSBNum;
            public byte byAuxoutNum;
            public byte byAudioNum;
            public byte byIPChanNum;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICECFG_V40
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDVRName;                 // DVR name
            public uint dwDVRID;                    // DVR ID //V1.4 (0- 99) ,  V1.5 (0- 255) 
            public uint dwRecycleRecord;            // cycle record, 0-disable, 1-enable
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public uint dwSoftwareVersion;          // Software version
            public uint dwSoftwareBuildDate;        // Software build Date, 0xYYYYMMDD
            public uint dwDSPSoftwareVersion;       // DSP Version: 16 high bit is the major version, and 16 low bit is the minor version
            public uint dwDSPSoftwareBuildDate;     // DSP Build, 0xYYYYMMDD
            public uint dwPanelVersion;             // Front panel version
            public uint dwHardwareVersion;          // Hardware version
            public byte byAlarmInPortNum;           // DVR Alarm input
            public byte byAlarmOutPortNum;          // DVR Alarm output
            public byte byRS232Num;                 // DVR 232 port number
            public byte byRS485Num;                 // DVR 485 port number
            public byte byNetworkPortNum;           // Network port number (nr total de porturi/interfete TCP/IP)
            public byte byDiskCtrlNum;              // DVR HDD number
            public byte byDiskNum;                  // DVR disk number
            public byte byDVRType;                  // DVR type,  1: DVR, 2: ATM DVR, 3: DVS ......- - 
            public byte byChanNum;                  // DVR channel number
            public byte byStartChan;                // start Channel number, DVS - 1, DVR -  1
            public byte byDecordChans;              // DVR decoding
            public byte byVGANum;                   // VGA number 
            public byte byUSBNum;                   // USB number
            public byte byAuxoutNum;                // Aux output number
            public byte byAudioNum;                 // voice interface number
            public byte byIPChanNum;                // Max. IP channel number 
            public byte byZeroChanNum;              // Zero channel number
            public byte bySupport;                  // Ability set
            //bySupport & 0x1,  smart search
            //bySupport & 0x2,  backup
            //bySupport & 0x4,  compression ability set
            //bySupport & 0x8,  multiple network adapter
            //bySupport & 0x10, remote SADP
            //bySupport & 0x20  support Raid
            //bySupport & 0x40  support IPSAN
            //bySupport & 0x80, support RTP over RTSP
            public byte byEsataUseage;              // Default E-SATA: 0- backup, 1- record
            public byte byIPCPlug;                  // 0- disable plug-and-play, 1- enable plug-and-play
            public byte byStorageMode;              // Hard Disk Mode: 0-group, 1-quota, 2-drawframe
            public byte bySupport1;                 // Ability set
            //bySupport1 & 0x1, support snmp v30
            //bySupport1 & 0x2, support distinguish download and playback
            //bySupport1 & 0x4, support deployment level
            //bySupport1 & 0x8, support vca alarm time extension 
            //bySupport1 & 0x10, support muti disks(more than 33)
            //bySupport1 & 0x20, support rtsp over http
            public short wDevType;                  //Device type
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byDevTypeName;
            public byte bySupport2;                 // The ability set extension
            //bySupport2 & 0x1, Whether to support extended the OSD character overlay (terminal and capture machine expansion distinguish)
            public byte byAnalogAlarmInPortNum;     // Analog alarm in number
            public byte byStartAlarmInNo;           // Analog alarm in Start No.
            public byte byStartAlarmOutNo;          // Analog alarm Out Start No.
            public byte byStartIPAlarmInNo;         // IP alarm in Start No.  0-Invalid
            public byte byStartIPAlarmOutNo;        // IP Alarm Out Start No.  0-Invalid
            public byte byHighIPChanNum;            // Ip Chan Num High 8 Bit 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_IPADDR
        {

            /// char[16]
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIpV4;

            /// BYTE[128]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[128];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ETHERNET_V30
        {
            public NET_DVR_IPADDR struDVRIP;
            public NET_DVR_IPADDR struDVRIPMask;
            public uint dwNetInterface;
            public ushort wDVRPort;
            public ushort wMTU;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_ETHERNET
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIPMask;
            public uint dwNetInterface;
            public ushort wDVRPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PPPOECFG
        {
            public uint dwPPPOE;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPPPoEUser;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = PASSWD_LEN)]
            public string sPPPoEPassword;
            public NET_DVR_IPADDR struPPPoEIP;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_NETCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_ETHERNET_V30[] struEtherNet;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPADDR[] struRes1;
            public NET_DVR_IPADDR struAlarmHostIpAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U2)]
            public ushort[] wRes2;
            public ushort wAlarmHostIpPort;
            public byte byUseDhcp;
            public byte byRes3;
            public NET_DVR_IPADDR struDnsServer1IpAddr;
            public NET_DVR_IPADDR struDnsServer2IpAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byIpResolver;
            public ushort wIpResolverPort;
            public ushort wHttpPortNo;
            public NET_DVR_IPADDR struMulticastIpAddr;
            public NET_DVR_IPADDR struGatewayIpAddr;
            public NET_DVR_PPPOECFG struPPPoE;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_NETCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_ETHERNET[] struEtherNet;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sManageHostIP;
            public ushort wManageHostPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIPServerIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sMultiCastIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sGatewayIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sNFSIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNFSDirectory;
            public uint dwPPPOE;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPPPoEUser;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = PASSWD_LEN)]
            public string sPPPoEPassword;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sPPPoEIP;
            public ushort wHttpPort;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MOTION_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96 * 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byMotionScope;
            public byte byMotionSensitive;
            public byte byEnableHandleMotion;
            public byte byPrecision;
            public byte reservedData;
            public NET_DVR_HANDLEEXCEPTION_V30 struMotionHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MOTION
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 396, ArraySubType = UnmanagedType.I1)]
            public byte[] byMotionScope;
            public byte byMotionSensitive;
            public byte byEnableHandleMotion;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string reservedData;
            public NET_DVR_HANDLEEXCEPTION strMotionHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HIDEALARM_V30
        {
            public uint dwEnableHideAlarm;
            public ushort wHideAlarmAreaTopLeftX;
            public ushort wHideAlarmAreaTopLeftY;
            public ushort wHideAlarmAreaWidth;
            public ushort wHideAlarmAreaHeight;
            public NET_DVR_HANDLEEXCEPTION_V30 strHideAlarmHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HIDEALARM
        {
            public uint dwEnableHideAlarm;
            public ushort wHideAlarmAreaTopLeftX;
            public ushort wHideAlarmAreaTopLeftY;
            public ushort wHideAlarmAreaWidth;
            public ushort wHideAlarmAreaHeight;
            public NET_DVR_HANDLEEXCEPTION strHideAlarmHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VILOST_V30
        {
            public byte byEnableHandleVILost;
            public NET_DVR_HANDLEEXCEPTION_V30 strVILostHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 56, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VILOST
        {
            public byte byEnableHandleVILost;
            public NET_DVR_HANDLEEXCEPTION strVILostHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
        }


        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NET_DVR_SHELTER
        {
            public ushort wHideAreaTopLeftX;
            public ushort wHideAreaTopLeftY;
            public ushort wHideAreaWidth;
            public ushort wHideAreaHeight;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COLOR
        {
            public byte byBrightness;
            public byte byContrast;
            public byte bySaturation;
            public byte byHue;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PICCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sChanName;
            public uint dwVideoFormat;
            public NET_DVR_COLOR struColor;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 60)]
            public string reservedData;

            public uint dwShowChanName;
            public ushort wShowNameTopLeftX;
            public ushort wShowNameTopLeftY;

            public NET_DVR_VILOST_V30 struVILost;
            public NET_DVR_VILOST_V30 struRes;

            public NET_DVR_MOTION_V30 struMotion;

            public NET_DVR_HIDEALARM_V30 struHideAlarm;

            public uint dwEnableHide;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_SHELTERNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SHELTER[] struShelter;

            public uint dwShowOsd;
            public ushort wOSDTopLeftX;
            public ushort wOSDTopLeftY;
            public byte byOSDType;

            public byte byDispWeek;
            public byte byOSDAttrib;

            public byte byHourOSDType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PICCFG_EX
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sChanName;
            public uint dwVideoFormat;
            public byte byBrightness;
            public byte byContrast;
            public byte bySaturation;
            public byte byHue;

            public uint dwShowChanName;
            public ushort wShowNameTopLeftX;
            public ushort wShowNameTopLeftY;

            public NET_DVR_VILOST struVILost;

            public NET_DVR_MOTION struMotion;

            public NET_DVR_HIDEALARM struHideAlarm;

            public uint dwEnableHide;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_SHELTERNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SHELTER[] struShelter;

            public uint dwShowOsd;
            public ushort wOSDTopLeftX;
            public ushort wOSDTopLeftY;
            public byte byOSDType;

            public byte byDispWeek;
            public byte byOSDAttrib;

            public byte byHourOsdType;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PICCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sChanName;
            public uint dwVideoFormat;
            public byte byBrightness;
            public byte byContrast;
            public byte bySaturation;
            public byte byHue;

            public uint dwShowChanName;
            public ushort wShowNameTopLeftX;
            public ushort wShowNameTopLeftY;

            public NET_DVR_VILOST struVILost;

            public NET_DVR_MOTION struMotion;

            public NET_DVR_HIDEALARM struHideAlarm;

            public uint dwEnableHide;
            public ushort wHideAreaTopLeftX;
            public ushort wHideAreaTopLeftY;
            public ushort wHideAreaWidth;
            public ushort wHideAreaHeight;

            public uint dwShowOsd;
            public ushort wOSDTopLeftX;
            public ushort wOSDTopLeftY;
            public byte byOSDType;

            public byte byDispWeek;
            public byte byOSDAttrib;

            public byte reservedData2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSION_INFO_V30
        {
            public byte byStreamType;
            public byte byResolution;
            public byte byBitrateType;
            public byte byPicQuality;
            public uint dwVideoBitrate;
            public uint dwVideoFrameRate;
            public ushort wIntervalFrameI;

            public byte byIntervalBPFrame;
            public byte byres1;
            public byte byVideoEncType;
            public byte byAudioEncType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byres;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSIONCFG_V30
        {
            public uint dwSize;
            public NET_DVR_COMPRESSION_INFO_V30 struNormHighRecordPara;
            public NET_DVR_COMPRESSION_INFO_V30 struRes;
            public NET_DVR_COMPRESSION_INFO_V30 struEventRecordPara;
            public NET_DVR_COMPRESSION_INFO_V30 struNetPara;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSION_INFO
        {
            public byte byStreamType;
            public byte byResolution;
            public byte byBitrateType;
            public byte byPicQuality;
            public uint dwVideoBitrate;
            public uint dwVideoFrameRate;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSIONCFG
        {
            public uint dwSize;
            public NET_DVR_COMPRESSION_INFO struRecordPara;
            public NET_DVR_COMPRESSION_INFO struNetPara;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSION_INFO_EX
        {
            public byte byStreamType;
            public byte byResolution;
            public byte byBitrateType;
            public byte byPicQuality;
            public uint dwVideoBitrate;
            public uint dwVideoFrameRate;
            public ushort wIntervalFrameI;
            public byte byIntervalBPFrame;
            public byte byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSIONCFG_EX
        {
            public uint dwSize;
            public NET_DVR_COMPRESSION_INFO_EX struRecordPara;
            public NET_DVR_COMPRESSION_INFO_EX struNetPara;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_RECORDSCHED
        {
            public NET_DVR_SCHEDTIME struRecordTime;
            public byte byRecordType;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
            public string reservedData;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RECORDDAY
        {
            public ushort wAllDayRecord;
            public byte byRecordType;
            public byte reservedData;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RECORD_V30
        {
            public uint dwSize;
            public uint dwRecord;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_RECORDDAY[] struRecAllDay;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_RECORDSCHED[] struRecordSched;
            public uint dwRecordTime;
            public uint dwPreRecordTime;
            public uint dwRecorderDuration;
            public byte byRedundancyRec;
            public byte byAudioRec;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byReserve;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RECORD
        {
            public uint dwSize;
            public uint dwRecord;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_RECORDDAY[] struRecAllDay;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_RECORDSCHED[] struRecordSched;
            public uint dwRecordTime;
            public uint dwPreRecordTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PTZ_PROTOCOL
        {
            public uint dwType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = DESC_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byDescribe;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PTZCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PTZ_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_PTZ_PROTOCOL[] struPtz;
            public uint dwPtzNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECODERCFG_V30
        {
            public uint dwSize;
            public uint dwBaudRate;
            public byte byDataBit;
            public byte byStopBit;
            public byte byParity;
            public byte byFlowcontrol;
            public ushort wDecoderType;
            public ushort wDecoderAddress;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_PRESET_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetPreset;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CRUISE_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetCruise;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_TRACK_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetTrack;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECODERCFG
        {
            public uint dwSize;
            public uint dwBaudRate;
            public byte byDataBit;
            public byte byStopBit;
            public byte byParity;
            public byte byFlowcontrol;
            public ushort wDecoderType;
            public ushort wDecoderAddress;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_PRESET, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetPreset;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CRUISE, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetCruise;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_TRACK, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetTrack;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PPPCFG_V30
        {
            public NET_DVR_IPADDR struRemoteIP;
            public NET_DVR_IPADDR struLocalIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sLocalIPMask;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public byte byPPPMode;
            public byte byRedial;
            public byte byRedialMode;
            public byte byDataEncrypt;
            public uint dwMTU;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = PHONENUMBER_LEN)]
            public string sTelephoneNumber;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PPPCFG
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sRemoteIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sLocalIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sLocalIPMask;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public byte byPPPMode;
            public byte byRedial;
            public byte byRedialMode;
            public byte byDataEncrypt;
            public uint dwMTU;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = PHONENUMBER_LEN)]
            public string sTelephoneNumber;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SINGLE_RS232
        {
            public uint dwBaudRate;
            public byte byDataBit;
            public byte byStopBit;
            public byte byParity;
            public byte byFlowcontrol;
            public uint dwWorkMode;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RS232CFG_V30
        {
            public uint dwSize;
            public NET_DVR_SINGLE_RS232 struRs232;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 84, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_PPPCFG_V30 struPPPConfig;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RS232CFG
        {
            public uint dwSize;
            public uint dwBaudRate;
            public byte byDataBit;
            public byte byStopBit;
            public byte byParity;
            public byte byFlowcontrol;
            public uint dwWorkMode;
            public NET_DVR_PPPCFG struPPPConfig;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMINCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAlarmInName;
            public byte byAlarmType;
            public byte byAlarmInHandle;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_HANDLEEXCEPTION_V30 struAlarmHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnablePreset;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byPresetNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 192, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCruise;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byCruiseNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnablePtzTrack;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byPTZTrack;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMINCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAlarmInName;
            public byte byAlarmType;
            public byte byAlarmInHandle;
            public NET_DVR_HANDLEEXCEPTION struAlarmHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnablePreset;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byPresetNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCruise;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byCruiseNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnablePtzTrack;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byPTZTrack;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMINFO_V30
        {
            public int dwAlarmType;
            public int dwAlarmInputNumber;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutputNumber;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmRelateChannel;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byChannel;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISKNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byDiskNumber;
            public void Init()
            {
                dwAlarmType = 0;
                dwAlarmInputNumber = 0;
                byAlarmRelateChannel = new byte[MAX_CHANNUM_V30];
                byChannel = new byte[MAX_CHANNUM_V30];
                byAlarmOutputNumber = new byte[MAX_ALARMOUT_V30];
                byDiskNumber = new byte[MAX_DISKNUM_V30];
                for (int i = 0; i < MAX_CHANNUM_V30; i++)
                {
                    byAlarmRelateChannel[i] = Convert.ToByte(0);
                    byChannel[i] = Convert.ToByte(0);
                }
                for (int i = 0; i < MAX_ALARMOUT_V30; i++)
                {
                    byAlarmOutputNumber[i] = Convert.ToByte(0);
                }
                for (int i = 0; i < MAX_DISKNUM_V30; i++)
                {
                    byDiskNumber[i] = Convert.ToByte(0);
                }
            }
            public void Reset()
            {
                dwAlarmType = 0;
                dwAlarmInputNumber = 0;

                for (int i = 0; i < MAX_CHANNUM_V30; i++)
                {
                    byAlarmRelateChannel[i] = Convert.ToByte(0);
                    byChannel[i] = Convert.ToByte(0);
                }
                for (int i = 0; i < MAX_ALARMOUT_V30; i++)
                {
                    byAlarmOutputNumber[i] = Convert.ToByte(0);
                }
                for (int i = 0; i < MAX_DISKNUM_V30; i++)
                {
                    byDiskNumber[i] = Convert.ToByte(0);
                }
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMINFO
        {
            public int dwAlarmType;
            public int dwAlarmInputNumber;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT, ArraySubType = UnmanagedType.U4)]
            public int[] dwAlarmOutputNumber;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.U4)]
            public int[] dwAlarmRelateChannel;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.U4)]
            public int[] dwChannel;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISKNUM, ArraySubType = UnmanagedType.U4)]
            public int[] dwDiskNumber;
            public void Init()
            {
                dwAlarmType = 0;
                dwAlarmInputNumber = 0;
                dwAlarmOutputNumber = new int[MAX_ALARMOUT];
                dwAlarmRelateChannel = new int[MAX_CHANNUM];
                dwChannel = new int[MAX_CHANNUM];
                dwDiskNumber = new int[MAX_DISKNUM];
                for (int i = 0; i < MAX_ALARMOUT; i++)
                {
                    dwAlarmOutputNumber[i] = 0;
                }
                for (int i = 0; i < MAX_CHANNUM; i++)
                {
                    dwAlarmRelateChannel[i] = 0;
                    dwChannel[i] = 0;
                }
                for (int i = 0; i < MAX_DISKNUM; i++)
                {
                    dwDiskNumber[i] = 0;
                }
            }
            public void Reset()
            {
                dwAlarmType = 0;
                dwAlarmInputNumber = 0;

                for (int i = 0; i < MAX_ALARMOUT; i++)
                {
                    dwAlarmOutputNumber[i] = 0;
                }
                for (int i = 0; i < MAX_CHANNUM; i++)
                {
                    dwAlarmRelateChannel[i] = 0;
                    dwChannel[i] = 0;
                }
                for (int i = 0; i < MAX_DISKNUM; i++)
                {
                    dwDiskNumber[i] = 0;
                }
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPDEVINFO
        {
            public uint dwEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public NET_DVR_IPADDR struIP;
            public ushort wDVRPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                sUserName = new byte[NAME_LEN];
                sPassword = new byte[PASSWD_LEN];
                byRes = new byte[34];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_IPDEVINFO_V31
        {
            public byte byEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byDomain;
            public NET_DVR_IPADDR struIP;
            public ushort wDVRPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                byRes1 = new byte[3];
                sUserName = new byte[NAME_LEN];
                sPassword = new byte[PASSWD_LEN];
                byDomain = new byte[MAX_DOMAIN_NAME];

                byRes2 = new byte[34];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPCHANINFO
        {
            public byte byEnable;
            public byte byIPID;
            public byte byChannel;
            public byte byProType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void Init()
            {
                byRes = new byte[32];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPPARACFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPDEVINFO[] struIPDevInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAnalogChanEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPCHANINFO[] struIPChanInfo;

            public void Init()
            {
                int i = 0;
                struIPDevInfo = new NET_DVR_IPDEVINFO[MAX_IP_DEVICE];

                for (i = 0; i < MAX_IP_DEVICE; i++)
                {
                    struIPDevInfo[i].Init();
                }
                byAnalogChanEnable = new byte[MAX_ANALOG_CHANNUM];
                struIPChanInfo = new NET_DVR_IPCHANINFO[MAX_IP_CHANNEL];
                for (i = 0; i < MAX_IP_CHANNEL; i++)
                {
                    struIPChanInfo[i].Init();
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPPARACFG_V31
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_IPDEVINFO_V31[] struIPDevInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAnalogChanEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPCHANINFO[] struIPChanInfo;

            public void Init()
            {
                int i = 0;
                struIPDevInfo = new tagNET_DVR_IPDEVINFO_V31[MAX_IP_DEVICE];

                for (i = 0; i < MAX_IP_DEVICE; i++)
                {
                    struIPDevInfo[i].Init();
                }
                byAnalogChanEnable = new byte[MAX_ANALOG_CHANNUM];
                struIPChanInfo = new NET_DVR_IPCHANINFO[MAX_IP_CHANNEL];
                for (i = 0; i < MAX_IP_CHANNEL; i++)
                {
                    struIPChanInfo[i].Init();
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTINFO
        {
            public byte byIPID;
            public byte byAlarmOut;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[18];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;

            public void Init()
            {
                struIPAlarmOutInfo = new NET_DVR_IPALARMOUTINFO[MAX_IP_ALARMOUT];
                for (int i = 0; i < MAX_IP_ALARMOUT; i++)
                {
                    struIPAlarmOutInfo[i].Init();
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMININFO
        {
            public byte byIPID;
            public byte byAlarmIn;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMINCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_IPALARMINFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPDEVINFO[] struIPDevInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAnalogChanEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPCHANINFO[] struIPChanInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_IPALARMINFO_V31
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_IPDEVINFO_V31[] struIPDevInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAnalogChanEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPCHANINFO[] struIPChanInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;
        }

        public enum HD_STAT
        {
            HD_STAT_OK = 0,
            HD_STAT_UNFORMATTED = 1,
            HD_STAT_ERROR = 2,
            HD_STAT_SMART_FAILED = 3,
            HD_STAT_MISMATCH = 4,
            HD_STAT_IDLE = 5,
            NET_HD_STAT_OFFLINE = 6,
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SINGLE_HD
        {
            public uint dwHDNo;
            public uint dwCapacity;
            public uint dwFreeSpace;
            public uint dwHdStatus;
            public byte byHDAttr;
            public byte byHDType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwHdGroup;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HDCFG
        {
            public uint dwSize;
            public uint dwHDCount;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SINGLE_HD[] struHDInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SINGLE_HDGROUP
        {
            public uint dwHDGroupNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byHDGroupChans;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HDGROUP_CFG
        {
            public uint dwSize;
            public uint dwHDGroupCount;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_HD_GROUP, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SINGLE_HDGROUP[] struHDGroupAttr;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SCALECFG
        {
            public uint dwSize;
            public uint dwMajorScale;
            public uint dwMinorScale;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMOUTCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAlarmOutName;
            public uint dwAlarmOutDelay;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmOutTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMOUTCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAlarmOutName;
            public uint dwAlarmOutDelay;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmOutTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PREVIEWCFG_V30
        {
            public uint dwSize;
            public byte byPreviewNumber;
            public byte byEnableAudio;
            public ushort wSwitchTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_PREVIEW_MODE * MAX_WINDOW_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] bySwitchSeq;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PREVIEWCFG
        {
            public uint dwSize;
            public byte byPreviewNumber;
            public byte byEnableAudio;
            public ushort wSwitchTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_WINDOW, ArraySubType = UnmanagedType.I1)]
            public byte[] bySwitchSeq;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VGAPARA
        {
            public ushort wResolution;
            public ushort wFreq;
            public uint dwBrightness;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIXPARA_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.U2)]
            public ushort[] wOrder;
            public ushort wSwitchTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIXPARA
        {
            public ushort wDisplayLogo;
            public ushort wDisplayOsd;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VOOUT
        {
            public byte byVideoFormat;
            public byte byMenuAlphaValue;
            public ushort wScreenSaveTime;
            public ushort wVOffset;
            public ushort wBrightness;
            public byte byStartMode;
            public byte byEnableScaler;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VIDEOOUT_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_VIDEOOUT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_VOOUT[] struVOOut;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_VGA_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_VGAPARA[] struVGAPara;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_MATRIXOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_MATRIXPARA_V30[] struMatrixPara;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VIDEOOUT
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_VIDEOOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_VOOUT[] struVOOut;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_VGA, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_VGAPARA[] struVGAPara;
            public NET_DVR_MATRIXPARA struMatrixPara;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_USER_INFO_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
            public byte[] byLocalRight;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
            public byte[] byRemoteRight;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPreviewRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byLocalPlaybackRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPlaybackRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byLocalRecordRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetRecordRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byLocalPTZRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPTZRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byLocalBackupRight;
            public NET_DVR_IPADDR struUserIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
            public byte byPriority;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 17, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_USER_INFO_EX
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwLocalRight;

            public uint dwLocalPlaybackRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRemoteRight;

            public uint dwNetPreviewRight;
            public uint dwNetPlaybackRight;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sUserIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_USER_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwLocalRight;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRemoteRight;

            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sUserIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_USER_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_USERNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_USER_INFO_V30[] struUser;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_USER_EX
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_USERNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_USER_INFO_EX[] struUser;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_USER
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_USERNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_USER_INFO[] struUser;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EXCEPTION_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EXCEPTIONNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_HANDLEEXCEPTION_V30[] struExceptionHandleType;

        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EXCEPTION
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EXCEPTIONNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_HANDLEEXCEPTION[] struExceptionHandleType;

        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CHANNELSTATE_V30
        {
            public byte byRecordStatic;
            public byte bySignalStatic;
            public byte byHardwareStatic;
            public byte byRes1;
            public uint dwBitRate;
            public uint dwLinkNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_LINK, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPADDR[] struClientIP;
            public uint dwIPLinkNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                struClientIP = new NET_DVR_IPADDR[MAX_LINK];

                for (int i = 0; i < MAX_LINK; i++)
                {
                    struClientIP[i].Init();
                }
                byRes = new byte[12];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CHANNELSTATE
        {
            public byte byRecordStatic;
            public byte bySignalStatic;
            public byte byHardwareStatic;
            public byte reservedData;
            public uint dwBitRate;
            public uint dwLinkNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_LINK, ArraySubType = UnmanagedType.U4)]
            public uint[] dwClientIP;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DISKSTATE
        {
            public uint dwVolume;
            public uint dwFreeSpace;
            public uint dwHardDiskStatic;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_WORKSTATE_V30
        {
            public uint dwDeviceStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DISKSTATE[] struHardDiskStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_CHANNELSTATE_V30[] struChanStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutStatic;
            public uint dwLocalDisplay;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_AUDIO_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAudioChanStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                struHardDiskStatic = new NET_DVR_DISKSTATE[MAX_DISKNUM_V30];
                struChanStatic = new NET_DVR_CHANNELSTATE_V30[MAX_CHANNUM_V30];
                for (int i = 0; i < MAX_CHANNUM_V30; i++)
                {
                    struChanStatic[i].Init();
                }
                byAlarmInStatic = new byte[MAX_ALARMOUT_V30];
                byAlarmOutStatic = new byte[MAX_ALARMOUT_V30];
                byAudioChanStatus = new byte[MAX_AUDIO_V30];
                byRes = new byte[10];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_WORKSTATE
        {
            public uint dwDeviceStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISKNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DISKSTATE[] struHardDiskStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_CHANNELSTATE[] struChanStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMIN, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInStatic;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutStatic;
            public uint dwLocalDisplay;

            public void Init()
            {
                struHardDiskStatic = new NET_DVR_DISKSTATE[MAX_DISKNUM];
                struChanStatic = new NET_DVR_CHANNELSTATE[MAX_CHANNUM];
                byAlarmInStatic = new byte[MAX_ALARMIN];
                byAlarmOutStatic = new byte[MAX_ALARMOUT];
            }
        }




        public const int MAJOR_ALARM = 1;

        public const int MINOR_ALARM_IN = 1;
        public const int MINOR_ALARM_OUT = 2;
        public const int MINOR_MOTDET_START = 3;
        public const int MINOR_MOTDET_STOP = 4;
        public const int MINOR_HIDE_ALARM_START = 5;
        public const int MINOR_HIDE_ALARM_STOP = 6;
        public const int MINOR_VCA_ALARM_START = 7;
        public const int MINOR_VCA_ALARM_STOP = 8;


        public const int MAJOR_EXCEPTION = 2;

        public const int MINOR_VI_LOST = 33;
        public const int MINOR_ILLEGAL_ACCESS = 34;
        public const int MINOR_HD_FULL = 35;
        public const int MINOR_HD_ERROR = 36;
        public const int MINOR_DCD_LOST = 37;
        public const int MINOR_IP_CONFLICT = 38;
        public const int MINOR_NET_BROKEN = 39;
        public const int MINOR_REC_ERROR = 40;
        public const int MINOR_IPC_NO_LINK = 41;
        public const int MINOR_VI_EXCEPTION = 42;
        public const int MINOR_IPC_IP_CONFLICT = 43;


        public const int MINOR_FANABNORMAL = 49;
        public const int MINOR_FANRESUME = 50;
        public const int MINOR_SUBSYSTEM_ABNORMALREBOOT = 51;
        public const int MINOR_MATRIX_STARTBUZZER = 52;


        public const int MAJOR_OPERATION = 3;

        public const int MINOR_START_DVR = 65;
        public const int MINOR_STOP_DVR = 66;
        public const int MINOR_STOP_ABNORMAL = 67;
        public const int MINOR_REBOOT_DVR = 68;

        public const int MINOR_LOCAL_LOGIN = 80;
        public const int MINOR_LOCAL_LOGOUT = 81;
        public const int MINOR_LOCAL_CFG_PARM = 82;
        public const int MINOR_LOCAL_PLAYBYFILE = 83;
        public const int MINOR_LOCAL_PLAYBYTIME = 84;
        public const int MINOR_LOCAL_START_REC = 85;
        public const int MINOR_LOCAL_STOP_REC = 86;
        public const int MINOR_LOCAL_PTZCTRL = 87;
        public const int MINOR_LOCAL_PREVIEW = 88;
        public const int MINOR_LOCAL_MODIFY_TIME = 89;
        public const int MINOR_LOCAL_UPGRADE = 90;
        public const int MINOR_LOCAL_RECFILE_OUTPUT = 91;
        public const int MINOR_LOCAL_FORMAT_HDD = 92;
        public const int MINOR_LOCAL_CFGFILE_OUTPUT = 93;
        public const int MINOR_LOCAL_CFGFILE_INPUT = 94;
        public const int MINOR_LOCAL_COPYFILE = 95;
        public const int MINOR_LOCAL_LOCKFILE = 96;
        public const int MINOR_LOCAL_UNLOCKFILE = 97;
        public const int MINOR_LOCAL_DVR_ALARM = 98;
        public const int MINOR_IPC_ADD = 99;
        public const int MINOR_IPC_DEL = 100;
        public const int MINOR_IPC_SET = 101;
        public const int MINOR_LOCAL_START_BACKUP = 102;
        public const int MINOR_LOCAL_STOP_BACKUP = 103;
        public const int MINOR_LOCAL_COPYFILE_START_TIME = 104;
        public const int MINOR_LOCAL_COPYFILE_END_TIME = 105;
        public const int MINOR_LOCAL_ADD_NAS = 106;
        public const int MINOR_LOCAL_DEL_NAS = 107;
        public const int MINOR_LOCAL_SET_NAS = 108;

        public const int MINOR_REMOTE_LOGIN = 112;
        public const int MINOR_REMOTE_LOGOUT = 113;
        public const int MINOR_REMOTE_START_REC = 114;
        public const int MINOR_REMOTE_STOP_REC = 115;
        public const int MINOR_START_TRANS_CHAN = 116;
        public const int MINOR_STOP_TRANS_CHAN = 117;
        public const int MINOR_REMOTE_GET_PARM = 118;
        public const int MINOR_REMOTE_CFG_PARM = 119;
        public const int MINOR_REMOTE_GET_STATUS = 120;
        public const int MINOR_REMOTE_ARM = 121;
        public const int MINOR_REMOTE_DISARM = 122;
        public const int MINOR_REMOTE_REBOOT = 123;
        public const int MINOR_START_VT = 124;
        public const int MINOR_STOP_VT = 125;
        public const int MINOR_REMOTE_UPGRADE = 126;
        public const int MINOR_REMOTE_PLAYBYFILE = 127;
        public const int MINOR_REMOTE_PLAYBYTIME = 128;
        public const int MINOR_REMOTE_PTZCTRL = 129;
        public const int MINOR_REMOTE_FORMAT_HDD = 130;
        public const int MINOR_REMOTE_STOP = 131;
        public const int MINOR_REMOTE_LOCKFILE = 132;
        public const int MINOR_REMOTE_UNLOCKFILE = 133;
        public const int MINOR_REMOTE_CFGFILE_OUTPUT = 134;
        public const int MINOR_REMOTE_CFGFILE_INTPUT = 135;
        public const int MINOR_REMOTE_RECFILE_OUTPUT = 136;
        public const int MINOR_REMOTE_DVR_ALARM = 137;
        public const int MINOR_REMOTE_IPC_ADD = 138;
        public const int MINOR_REMOTE_IPC_DEL = 139;
        public const int MINOR_REMOTE_IPC_SET = 140;
        public const int MINOR_REBOOT_VCA_LIB = 141;
        public const int MINOR_REMOTE_ADD_NAS = 142;
        public const int MINOR_REMOTE_DEL_NAS = 143;
        public const int MINOR_REMOTE_SET_NAS = 144;


        public const int MINOR_SUBSYSTEMREBOOT = 160;
        public const int MINOR_MATRIX_STARTTRANSFERVIDEO = 161;
        public const int MINOR_MATRIX_STOPTRANSFERVIDEO = 162;
        public const int MINOR_REMOTE_SET_ALLSUBSYSTEM = 163;
        public const int MINOR_REMOTE_GET_ALLSUBSYSTEM = 164;
        public const int MINOR_REMOTE_SET_PLANARRAY = 165;
        public const int MINOR_REMOTE_GET_PLANARRAY = 166;
        public const int MINOR_MATRIX_STARTTRANSFERAUDIO = 167;
        public const int MINOR_MATRIX_STOPRANSFERAUDIO = 168;
        public const int MINOR_LOGON_CODESPITTER = 169;
        public const int MINOR_LOGOFF_CODESPITTER = 170;


        public const int MAJOR_INFORMATION = 4;

        public const int MINOR_HDD_INFO = 161;
        public const int MINOR_SMART_INFO = 162;
        public const int MINOR_REC_START = 163;
        public const int MINOR_REC_STOP = 164;
        public const int MINOR_REC_OVERDUE = 165;
        public const int MINOR_LINK_START = 166;
        public const int MINOR_LINK_STOP = 167;
        public const int MINOR_NET_DISK_INFO = 168;


        public const int PARA_VIDEOOUT = 1;
        public const int PARA_IMAGE = 2;
        public const int PARA_ENCODE = 4;
        public const int PARA_NETWORK = 8;
        public const int PARA_ALARM = 16;
        public const int PARA_EXCEPTION = 32;
        public const int PARA_DECODER = 64;
        public const int PARA_RS232 = 128;
        public const int PARA_PREVIEW = 256;
        public const int PARA_SECURITY = 512;
        public const int PARA_DATETIME = 1024;
        public const int PARA_FRAMETYPE = 2048;

        //vca
        public const int PARA_VCA_RULE = 4096;


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_LOG_V30
        {
            public NET_DVR_TIME strLogTime;
            public uint dwMajorType;
            public uint dwMinorType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPanelUser;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNetUser;
            public NET_DVR_IPADDR struRemoteHostAddr;
            public uint dwParaType;
            public uint dwChannel;
            public uint dwDiskNumber;
            public uint dwAlarmInPort;
            public uint dwAlarmOutPort;
            public uint dwInfoLen;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = LOG_INFO_LEN)]
            public string sInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_LOG
        {
            public NET_DVR_TIME strLogTime;
            public uint dwMajorType;
            public uint dwMinorType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPanelUser;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNetUser;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sRemoteHostAddr;
            public uint dwParaType;
            public uint dwChannel;
            public uint dwDiskNumber;
            public uint dwAlarmInPort;
            public uint dwAlarmOutPort;
        }




        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMOUTSTATUS_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] Output;

            public void Init()
            {
                Output = new byte[MAX_ALARMOUT_V30];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARMOUTSTATUS
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] Output;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_TRADEINFO
        {
            public ushort m_Year;
            public ushort m_Month;
            public ushort m_Day;
            public ushort m_Hour;
            public ushort m_Minute;
            public ushort m_Second;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] DeviceName;
            public uint dwChannelNumer;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] CardNumber;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 12)]
            public string cTradeType;
            public uint dwCash;
        }


        public const int NCR = 0;
        public const int DIEBOLD = 1;
        public const int WINCOR_NIXDORF = 2;
        public const int SIEMENS = 3;
        public const int OLIVETTI = 4;
        public const int FUJITSU = 5;
        public const int HITACHI = 6;
        public const int SMI = 7;
        public const int IBM = 8;
        public const int BULL = 9;
        public const int YiHua = 10;
        public const int LiDe = 11;
        public const int GDYT = 12;
        public const int Mini_Banl = 13;
        public const int GuangLi = 14;
        public const int DongXin = 15;
        public const int ChenTong = 16;
        public const int NanTian = 17;
        public const int XiaoXing = 18;
        public const int GZYY = 19;
        public const int QHTLT = 20;
        public const int DRS918 = 21;
        public const int KALATEL = 22;
        public const int NCR_2 = 23;
        public const int NXS = 24;


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FRAMETYPECODE
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] code;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FRAMEFORMAT_V30
        {
            public uint dwSize;
            public NET_DVR_IPADDR struATMIP;
            public uint dwATMType;
            public uint dwInputMode;
            public uint dwFrameSignBeginPos;
            public uint dwFrameSignLength;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byFrameSignContent;
            public uint dwCardLengthInfoBeginPos;
            public uint dwCardLengthInfoLength;
            public uint dwCardNumberInfoBeginPos;
            public uint dwCardNumberInfoLength;
            public uint dwBusinessTypeBeginPos;
            public uint dwBusinessTypeLength;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_FRAMETYPECODE[] frameTypeCode;
            public ushort wATMPort;
            public ushort wProtocolType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_FRAMEFORMAT
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sATMIP;
            public uint dwATMType;
            public uint dwInputMode;
            public uint dwFrameSignBeginPos;
            public uint dwFrameSignLength;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byFrameSignContent;
            public uint dwCardLengthInfoBeginPos;
            public uint dwCardLengthInfoLength;
            public uint dwCardNumberInfoBeginPos;
            public uint dwCardNumberInfoLength;
            public uint dwBusinessTypeBeginPos;
            public uint dwBusinessTypeLength;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_FRAMETYPECODE[] frameTypeCode;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_FILTER
        {
            public byte byEnable;
            public byte byMode;
            public byte byFrameBeginPos;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byFilterText;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_IDENTIFICAT
        {
            public byte byStartMode;
            public byte byEndMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_FRAMETYPECODE struStartCode;
            public NET_DVR_FRAMETYPECODE struEndCode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_PACKAGE_LOCATION
        {
            public byte byOffsetMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwOffsetPos;
            public NET_DVR_FRAMETYPECODE struTokenCode;
            public byte byMultiplierValue;
            public byte byEternOffset;
            public byte byCodeMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_PACKAGE_LENGTH
        {
            public byte byLengthMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwFixLength;
            public uint dwMaxLength;
            public uint dwMinLength;
            public byte byEndMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public NET_DVR_FRAMETYPECODE struEndCode;
            public uint dwLengthPos;
            public uint dwLengthLen;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_OSD_POSITION
        {
            public byte byPositionMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwPos_x;
            public uint dwPos_y;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVR_DATE_FORMAT
        {
            public byte byItem1;/*Month,0.mm;1.mmm;2.mmmm*/
            public byte byItem2;/*Day,0.dd;*/
            public byte byItem3;/*Year,0.yy;1.yyyy*/
            public byte byDateForm;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string chSeprator;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string chDisplaySeprator;
            public byte byDisplayForm;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 27, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVRT_TIME_FORMAT
        {
            public byte byTimeForm;/*1. HH MM SS;0. HH MM*/
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public byte byHourMode;/*0,12;1,24*/ //lili mode
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string chSeprator;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string chDisplaySeprator;
            public byte byDisplayForm;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
            public byte byDisplayHourMode;/*0,12;1,24*/ //lili mode
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes4;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_OVERLAY_CHANNEL
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byChannel;
            public uint dwDelayTime;
            public byte byEnableDelayTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_PACKAGE_ACTION
        {
            public tagNET_DVR_PACKAGE_LOCATION struPackageLocation;
            public tagNET_DVR_OSD_POSITION struOsdPosition;
            public NET_DVR_FRAMETYPECODE struActionCode;
            public NET_DVR_FRAMETYPECODE struPreCode;
            public byte byActionCodeMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_PACKAGE_DATE
        {
            public tagNET_DVR_PACKAGE_LOCATION struPackageLocation;
            public tagNET_DVR_DATE_FORMAT struDateForm;
            public tagNET_DVR_OSD_POSITION struOsdPosition;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_PACKAGE_TIME
        {
            public tagNET_DVR_PACKAGE_LOCATION location;
            public tagNET_DVRT_TIME_FORMAT struTimeForm;
            public tagNET_DVR_OSD_POSITION struOsdPosition;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_PACKAGE_OTHERS
        {
            public tagNET_DVR_PACKAGE_LOCATION struPackageLocation;
            public tagNET_DVR_PACKAGE_LENGTH struPackageLength;
            public tagNET_DVR_OSD_POSITION struOsdPosition;
            public NET_DVR_FRAMETYPECODE struPreCode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_FRAMETYPE_NEW
        {
            public byte byEnable;
            public byte byInputMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byAtmName;
            public NET_DVR_IPADDR struAtmIp;
            public ushort wAtmPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public uint dwAtmType;
            public tagNET_DVR_IDENTIFICAT struIdentification;
            public tagNET_DVR_FILTER struFilter;
            public tagNET_DVR_ATM_PACKAGE_OTHERS struCardNoPara;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ACTION_TYPE, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_ATM_PACKAGE_ACTION[] struTradeActionPara;
            public tagNET_DVR_ATM_PACKAGE_OTHERS struAmountPara;
            public tagNET_DVR_ATM_PACKAGE_OTHERS struSerialNoPara;
            public tagNET_DVR_OVERLAY_CHANNEL struOverlayChan;
            public tagNET_DVR_ATM_PACKAGE_DATE byRes4;
            public tagNET_DVR_ATM_PACKAGE_TIME byRes5;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 132, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_FRAMEFORMAT_V31
        {
            public uint dwSize;
            public tagNET_DVR_ATM_FRAMETYPE_NEW struAtmFrameTypeNew;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_ATM_FRAMETYPE_NEW[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVR_ATM_PROTOIDX
        {
            public uint dwAtmType;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = ATM_DESC_LEN)]
            public string chDesc;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_ATM_PROTOCOL
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ATM_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_ATM_PROTOIDX[] struAtmProtoidx;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ATM_PROTOCOL_SORT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwAtmNumPerSort;
        }


        //DS-6001D Decoder
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECODERINFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderUser;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderPasswd;
            public byte bySendMode;
            public byte byEncoderChannel;
            public ushort wEncoderPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] reservedData;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECODERSTATE
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderUser;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byEncoderPasswd;
            public byte byEncoderChannel;
            public byte bySendMode;
            public ushort wEncoderPort;
            public uint dwConnectState;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] reservedData;
        }


        public const int NET_DEC_STARTDEC = 1;
        public const int NET_DEC_STOPDEC = 2;
        public const int NET_DEC_STOPCYCLE = 3;
        public const int NET_DEC_CONTINUECYCLE = 4;


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_DECCHANINFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIP;
            public ushort wDVRPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public byte byChannel;
            public byte byLinkMode;
            public byte byLinkType;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECINFO
        {
            public byte byPoolChans;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DECPOOLNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DECCHANINFO[] struchanConInfo;
            public byte byEnablePoll;
            public byte byPoolTime;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECCFG
        {
            public uint dwSize;
            public uint dwDecChanNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DECNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DECINFO[] struDecInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PORTINFO
        {
            public uint dwEnableTransPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDecoderIP;
            public ushort wDecoderPort;
            public ushort wDVRTransPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string cReserve;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PORTCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_TRANSPARENTNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_PORTINFO[] struTransPortInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PLAYREMOTEFILE
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDecoderIP;
            public ushort wDecoderPort;
            public ushort wLoadMode;

            [StructLayoutAttribute(LayoutKind.Explicit)]
            public struct mode_size
            {
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
                [FieldOffsetAttribute(0)]
                public byte[] byFile;

                [StructLayoutAttribute(LayoutKind.Sequential)]
                public struct bytime
                {
                    public uint dwChannel;
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                    public byte[] sUserName;
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                    public byte[] sPassword;
                    public NET_DVR_TIME struStartTime;
                    public NET_DVR_TIME struStopTime;
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_DECCHANSTATUS
        {
            public uint dwWorkType;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIP;
            public ushort wDVRPort;
            public byte byChannel;
            public byte byLinkMode;
            public uint dwLinkType;

            [StructLayoutAttribute(LayoutKind.Explicit)]
            public struct objectInfo
            {
                [StructLayoutAttribute(LayoutKind.Sequential)]
                public struct userInfo
                {
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                    public byte[] sUserName;
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                    public byte[] sPassword;
                    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 52)]
                    public string cReserve;
                }

                [StructLayoutAttribute(LayoutKind.Sequential)]
                public struct fileInfo
                {
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
                    public byte[] fileName;
                }
                [StructLayoutAttribute(LayoutKind.Sequential)]
                public struct timeInfo
                {
                    public uint dwChannel;
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                    public byte[] sUserName;
                    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                    public byte[] sPassword;
                    public NET_DVR_TIME struStartTime;
                    public NET_DVR_TIME struStopTime;
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DECSTATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DECNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DECCHANSTATUS[] struTransPortInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_SHOWSTRINGINFO
        {
            public ushort wShowString;
            public ushort wStringSize;
            public ushort wShowStringTopLeftX;
            public ushort wShowStringTopLeftY;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 44)]
            public string sString;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SHOWSTRING_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_STRINGNUM_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SHOWSTRINGINFO[] struStringInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SHOWSTRING_EX
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_STRINGNUM_EX, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SHOWSTRINGINFO[] struStringInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SHOWSTRING
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_STRINGNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SHOWSTRINGINFO[] struStringInfo;
        }




        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struReceiver
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAddress;
        }
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EMAILCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAccount;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EMAIL_PWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;

            [StructLayoutAttribute(LayoutKind.Sequential)]
            public struct struSender
            {
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
                public byte[] sName;
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
                public byte[] sAddress;
            }

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSmtpServer;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPop3Server;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.Struct)]
            public struReceiver[] struStringInfo;

            public byte byAttachment;
            public byte bySmtpServerVerify;
            public byte byMailInterval;
            public byte byEnableSSL;
            public ushort wSmtpPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 74, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CRUISE_PARA
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.I1)]
            public byte[] byPresetNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.I1)]
            public byte[] byCruiseSpeed;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CRUISE_MAX_PRESET_NUMS, ArraySubType = UnmanagedType.U2)]
            public ushort[] wDwellTime;
            public byte byEnableThisCruise;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_TIMEPOINT
        {
            public uint dwMonth;
            public uint dwWeekNo;
            public uint dwWeekDate;
            public uint dwHour;
            public uint dwMin;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ZONEANDDST
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwEnableDST;
            public byte byDSTBias;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public NET_DVR_TIMEPOINT struBeginPoint;
            public NET_DVR_TIMEPOINT struEndPoint;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_JPEGPARA
        {
            public ushort wPicSize;
            public ushort wPicQuality;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_AUXOUTCFG
        {
            public uint dwSize;
            public uint dwAlarmOutChan;
            public uint dwAlarmChanSwitchTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_AUXOUT, ArraySubType = UnmanagedType.U4)]
            public uint[] dwAuxSwitchTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_AUXOUT * MAX_WINDOW, ArraySubType = UnmanagedType.I1)]
            public byte[] byAuxOrder;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_NTPPARA
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sNTPServer;
            public ushort wInterval;
            public byte byEnableNTP;
            public byte cTimeDifferenceH;
            public byte cTimeDifferenceM;
            public byte res1;
            public ushort wNtpPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] res2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DDNSPARA
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sDomainName;
            public byte byEnableDDNS;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DDNSPARA_EX
        {
            public byte byHostIndex;
            public byte byEnableDDNS;
            public ushort wDDNSPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] sDomainName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] sServerName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struDDNS
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] sDomainName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] sServerName;
            public ushort wDDNSPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DDNSPARA_V30
        {
            public byte byEnableDDNS;
            public byte byHostIndex;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DDNS_NUMS, ArraySubType = UnmanagedType.Struct)]
            public struDDNS[] struDDNS;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EMAILPARA
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sUsername;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sSmtpServer;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sPop3Server;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sMailAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sEventMailAddr1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] sEventMailAddr2;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_NETAPPCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDNSIp;
            public NET_DVR_NTPPARA struNtpClientParam;
            public NET_DVR_DDNSPARA struDDNSClientParam;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 464, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_SINGLE_NFS
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sNfsHostIPAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNfsDirectory;

            public void Init()
            {
                this.sNfsDirectory = new byte[PATHNAME_LEN];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_NFSCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NFS_DISK, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SINGLE_NFS[] struNfsDiskParam;

            public void Init()
            {
                this.struNfsDiskParam = new NET_DVR_SINGLE_NFS[MAX_NFS_DISK];

                for (int i = 0; i < MAX_NFS_DISK; i++)
                {
                    struNfsDiskParam[i].Init();
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CRUISE_POINT
        {
            public byte PresetNum;
            public byte Dwell;
            public byte Speed;
            public byte Reserve;

            public void Init()
            {
                PresetNum = 0;
                Dwell = 0;
                Speed = 0;
                Reserve = 0;
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CRUISE_RET
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_CRUISE_POINT[] struCruisePoint;

            public void Init()
            {
                struCruisePoint = new NET_DVR_CRUISE_POINT[32];
                for (int i = 0; i < 32; i++)
                {
                    struCruisePoint[i].Init();
                }
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_NETCFG_OTHER
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sFirstDNSIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sSecondDNSIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MATRIX_DECINFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIP;
            public ushort wDVRPort;
            public byte byChannel;
            public byte byTransProtocol;
            public byte byTransMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_DYNAMIC_DEC
        {
            public uint dwSize;
            public NET_DVR_MATRIX_DECINFO struDecChanInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MATRIX_DEC_CHAN_STATUS
        {
            public uint dwSize;
            public uint dwIsLinked;
            public uint dwStreamCpRate;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string cRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MATRIX_DEC_CHAN_INFO
        {
            public uint dwSize;
            public NET_DVR_MATRIX_DECINFO struDecChanInfo;
            public uint dwDecState;
            public NET_DVR_TIME StartTime;
            public NET_DVR_TIME StopTime;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sFileName;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_DECCHANINFO
        {
            public uint dwEnable;
            public NET_DVR_MATRIX_DECINFO struDecChanInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_LOOP_DECINFO
        {
            public uint dwSize;
            public uint dwPoolTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CYCLE_CHAN, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_MATRIX_DECCHANINFO[] struchanConInfo;
        }

        //2007-12-22
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct TTY_CONFIG
        {
            public byte baudrate;
            public byte databits;
            public byte stopbits;
            public byte parity;
            public byte flowcontrol;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MATRIX_TRAN_CHAN_INFO
        {
            public byte byTranChanEnable;

            public byte byLocalSerialDevice;

            public byte byRemoteSerialDevice;
            public byte res1;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sRemoteDevIP;
            public ushort wRemoteDevPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] res2;
            public TTY_CONFIG RemoteSerialDevCfg;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_TRAN_CHAN_CONFIG
        {
            public uint dwSize;
            public byte by232IsDualChan;
            public byte by485IsDualChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_SERIAL_NUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_MATRIX_TRAN_CHAN_INFO[] struTranInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sDVRIP;
            public ushort wDVRPort;
            public byte byChannel;
            public byte byReserve;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public uint dwPlayMode;
            public NET_DVR_TIME StartTime;
            public NET_DVR_TIME StopTime;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sFileName;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY_CONTROL
        {
            public uint dwSize;
            public uint dwPlayCmd;
            public uint dwCmdParam;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS
        {
            public uint dwSize;
            public uint dwCurMediaFileLen;
            public uint dwCurMediaFilePosition;
            public uint dwCurMediaFileDuration;
            public uint dwCurPlayTime;
            public uint dwCurMediaFIleFrames;
            public uint dwCurDataType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 72, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_MATRIX_PASSIVEMODE
        {
            public ushort wTransProtol;
            public ushort wPassivePort;
            public NET_DVR_IPADDR struMcastIP;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagDEV_CHAN_INFO
        {
            public NET_DVR_IPADDR struIP;
            public ushort wDVRPort;
            public byte byChannel;
            public byte byTransProtocol;
            public byte byTransMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 71, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagMATRIX_TRAN_CHAN_INFO
        {
            public byte byTranChanEnable;

            public byte byLocalSerialDevice;/* Local serial device */

            public byte byRemoteSerialDevice;/* Remote output serial device */
            public byte byRes1;
            public NET_DVR_IPADDR struRemoteDevIP;/* Remote Device IP */
            public ushort wRemoteDevPort;/* Remote Net Communication Port */
            public byte byIsEstablished;
            public byte byRes2;
            public TTY_CONFIG RemoteSerialDevCfg;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byUsername;/* 32BYTES */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byPassword;/* 16BYTES */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagMATRIX_TRAN_CHAN_CONFIG
        {
            public uint dwSize;
            public byte by232IsDualChan;
            public byte by485IsDualChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] vyRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_SERIAL_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagMATRIX_TRAN_CHAN_INFO[] struTranInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_STREAM_MEDIA_SERVER_CFG
        {
            public byte byValid;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_IPADDR struDevIP;
            public ushort wDevPort;
            public byte byTransmitType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 69, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PU_STREAM_CFG
        {
            public uint dwSize;
            public NET_DVR_STREAM_MEDIA_SERVER_CFG struStreamMediaSvrCfg;
            public tagDEV_CHAN_INFO struDevChanInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_CHAN_INFO_V30
        {
            public uint dwEnable;
            public NET_DVR_STREAM_MEDIA_SERVER_CFG streamMediaServerCfg;
            public tagDEV_CHAN_INFO struDevChanInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagMATRIX_LOOP_DECINFO_V30
        {
            public uint dwSize;
            public uint dwPoolTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CYCLE_CHAN_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_MATRIX_CHAN_INFO_V30[] struchanConInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagDEC_MATRIX_CHAN_INFO
        {
            public uint dwSize;
            public NET_DVR_STREAM_MEDIA_SERVER_CFG streamMediaServerCfg;
            public tagDEV_CHAN_INFO struDevChanInfo;
            public uint dwDecState;
            public NET_DVR_TIME StartTime;
            public NET_DVR_TIME StopTime;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sFileName;
            public uint dwGetStreamMode;
            public tagNET_MATRIX_PASSIVEMODE struPassiveMode;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_MATRIX_ABILITY
        {
            public uint dwSize;
            public byte byDecNums;
            public byte byStartChan;
            public byte byVGANums;
            public byte byBNCNums;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byVGAWindowMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byBNCWindowMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] res;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_DISP_LOGOCFG
        {
            public uint dwCorordinateX;
            public uint dwCorordinateY;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public byte byFlash;
            public byte byTranslucent;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public uint dwLogoSize;
        }


        public const int NET_DVR_ENCODER_UNKOWN = 0;
        public const int NET_DVR_ENCODER_H264 = 1;
        public const int NET_DVR_ENCODER_S264 = 2;
        public const int NET_DVR_ENCODER_MPEG4 = 3;

        public const int NET_DVR_STREAM_TYPE_UNKOWN = 0;
        public const int NET_DVR_STREAM_TYPE_HIKPRIVT = 1;
        public const int NET_DVR_STREAM_TYPE_TS = 7;
        public const int NET_DVR_STREAM_TYPE_PS = 8;
        public const int NET_DVR_STREAM_TYPE_RTP = 9;


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_MATRIX_CHAN_STATUS
        {
            public byte byDecodeStatus;
            public byte byStreamType;
            public byte byPacketType;
            public byte byRecvBufUsage;
            public byte byDecBufUsage;
            public byte byFpsDecV;
            public byte byFpsDecA;
            public byte byCpuLoad;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwDecodedV;
            public uint dwDecodedA;
            public ushort wImgW;
            public ushort wImgH;
            public byte byVideoFormat;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 27, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        public const int NET_DVR_MAX_DISPREGION = 16;

        public enum VGA_MODE
        {
            VGA_NOT_AVALIABLE,
            VGA_THS8200_MODE_SVGA_60HZ,//£¨800*600£©
            VGA_THS8200_MODE_SVGA_75HZ, //£¨800*600£©
            VGA_THS8200_MODE_XGA_60HZ,//£¨1024*768£©
            VGA_THS8200_MODE_XGA_70HZ, //£¨1024*768£©
            VGA_THS8200_MODE_SXGA_60HZ,//£¨1280*1024£©
            VGA_THS8200_MODE_720P_60HZ,//£¨1280*720 £©
            VGA_THS8200_MODE_1080i_60HZ,//£¨1920*1080£©
            VGA_THS8200_MODE_1080P_30HZ,//£¨1920*1080£©
            VGA_THS8200_MODE_1080P_25HZ,//£¨1920*1080£©
            VGA_THS8200_MODE_UXGA_30HZ,//£¨1600*1200£©
        }


        public enum VIDEO_STANDARD
        {
            VS_NON = 0,
            VS_NTSC = 1,
            VS_PAL = 2,
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_VGA_DISP_CHAN_CFG
        {
            public uint dwSize;
            public byte byAudio;
            public byte byAudioWindowIdx;
            public byte byVgaResolution;
            public byte byVedioFormat;
            public uint dwWindowMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
            public byte[] byJoinDecChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DISP_CHAN_STATUS
        {
            public byte byDispStatus;
            public byte byBVGA;
            public byte byVideoFormat;
            public byte byWindowMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byJoinDecChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NET_DVR_MAX_DISPREGION, ArraySubType = UnmanagedType.I1)]
            public byte[] byFpsDisp;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        public const int MAX_DECODECHANNUM = 32;
        public const int MAX_DISPCHANNUM = 24;


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR__DECODER_WORK_STATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DECODECHANNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_MATRIX_CHAN_STATUS[] struDecChanStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DISPCHANNUM, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_DISP_CHAN_STATUS[] struDispChanStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_ALARMIN, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ANALOG_ALARMOUT, ArraySubType = UnmanagedType.I1)]
            public byte[] byAalarmOutStatus;
            public byte byAudioInChanStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_EMAILCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sPassWord;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sFromName;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
            public string sFromAddr;/* Sender address */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sToName1;/* Receiver1 */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sToName2;/* Receiver2 */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
            public string sToAddr1;/* Receiver address1 */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
            public string sToAddr2;/* Receiver address2 */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sEmailServer;/* Email server address */
            public byte byServerType;/* Email server type: 0-SMTP, 1-POP, 2-IMTP¡­*/
            public byte byUseAuthen;/* Email server authentication method: 1-enable, 0-disable */
            public byte byAttachment;/* enable attachment */
            public byte byMailinterval;/* mail interval 0-2s, 1-3s, 2-4s. 3-5s*/
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSIONCFG_NEW
        {
            public uint dwSize;
            public NET_DVR_COMPRESSION_INFO_EX struLowCompression;
            public NET_DVR_COMPRESSION_INFO_EX struEventCompression;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PTZPOS
        {
            public ushort wAction;
            public ushort wPanPos;
            public ushort wTiltPos;
            public ushort wZoomPos;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PTZSCOPE
        {
            public ushort wPanPosMin;
            public ushort wPanPosMax;
            public ushort wTiltPosMin;
            public ushort wTiltPosMax;
            public ushort wZoomPosMin;
            public ushort wZoomPosMax;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_RTSPCFG
        {
            public uint dwSize;
            public ushort wPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 54, ArraySubType = UnmanagedType.I1)]
            public byte[] byReserve;
        }




        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public byte byAlarmInPortNum;
            public byte byAlarmOutPortNum;
            public byte byDiskNum;
            public byte byDVRType;
            public byte byChanNum;
            public byte byStartChan;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public byte byAlarmInPortNum;
            public byte byAlarmOutPortNum;
            public byte byDiskNum;
            public byte byDVRType;
            public byte byChanNum;
            public byte byStartChan;
            public byte byAudioChanNum;
            public byte byIPChanNum;

            public byte byZeroChanNum; 			//Zero channel encoding number//2010- 01- 16
            public byte byMainProto; 			//Main stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySubProto; 				//Sub stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySupport;         //Ability, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1,  smart search
            //bySupport & 0x2,  backup
            //bySupport & 0x4,  get compression configuration ability
            //bySupport & 0x8,  multi network adapter
            //bySupport & 0x10, support remote SADP
            //bySupport & 0x20  support Raid card
            // bySupport & 0x40 support IPSAN directory search
            public byte bySupport1;        // Ability expand, the 'AND' result by bit: 0- not support;  1- support
            // bySupport1 & 0x1, support snmp v30
            // bySupport1& 0x2£¬support distinguish download and playback
            //bySupport1 & 0x4, support deployment level
            //bySupport1 & 0x8, support vca alarm time extension 
            //bySupport1 & 0x10, support muti disks(more than 33)
            //bySupport1 & 0x20, support rtsp over http
            //bySupport1 & 0x40, support delay preview
            //bySuppory1 & 0x80 support NET_DVR_IPPARACFG_V40, in addition  support  License plate of the new alarm information
            public byte bySupport2;		// Ability expand, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1, decoder support get stream by URL
            //bySupport2 & 0x2,  support FTPV40
            //bySupport2 & 0x4,  support ANR
            //bySupport2 & 0x20, support get single item of device status
            //bySupport2 & 0x40,  support stream encryt
            public short wDevType;              //device type
            public byte bySupport3;		//Support  epresent by bit, 0 - not support 1 - support 
            //bySupport3 & 0x1-muti stream support 
            //bySupport3 & 0x8  support use delay preview parameter when delay preview
            //bySupport3 & 0x10 support the interface of getting alarmhost main status V40
            public byte byMultiStreamProto;//support multi stream, represent by bit, 0-not support ;1- support; bit1-stream 3 ;bit2-stream 4, bit7-main stream, bit8-sub stream
            public byte byStartDChan;		//Start digital channel
            public byte byStartDTalkChan;	//Start digital talk channel
            public byte byHighDChanNum;		//Digital channel number high
            public byte bySupport4;        //Support  epresent by bit, 0 - not support 1 - support
            //bySupport4 & 0x4 whether support video wall unified interface
            // bySupport4 & 0x80 Support device upload center alarm enable
            public byte byLanguageType;	// support language type by bit,0-support,1-not support  
            //  byLanguageType 0 -old device
            //  byLanguageType & 0x1 support chinese
            //  byLanguageType & 0x2 support english
            public byte byVoiceInChanNum;   //voice in chan num 
            public byte byStartVoiceInChanNo; //start voice in chan num
            public byte bySupport5;  //0-no support,1-support,bit0-muti stream
            //bySupport5 &0x01support wEventTypeEx 
            //bySupport5 &0x04support sence expend
            //bySupport5 &0x08 not support record type 13 cfg
            public byte bySupport6;
            public byte byMirrorChanNum;    //mirror channel num£¬<it represents direct channel in the recording host>
            public short wStartMirrorChanNo;  //start mirror chan
            public byte bySupport7;
            public byte byRes2;


            //[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            //public byte[] byRes1;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V40
        {
            public NET_DVR_DEVICEINFO_V30 struDeviceV30;
            public byte bySupportLock;
            public byte byRetryLoginTime;
            public byte byPasswordLevel;
            public byte byRes1;
            public int dwSurplusLockTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        public delegate void fnLoginResultCallBack(int lUserID, int dwResult, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo, IntPtr pUser);//

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_USER_LOGIN_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NET_DVR_DEV_ADDRESS_MAX_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDeviceAddress;
            public byte byRes1;
            public ushort wPort;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NET_DVR_LOGIN_USERNAME_MAX_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NET_DVR_LOGIN_PASSWD_MAX_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public fnLoginResultCallBack cbLoginResult;
            public IntPtr pUser;
            public int bUseAsynLogin;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        public enum SDK_NETWORK_ENVIRONMENT
        {
            LOCAL_AREA_NETWORK = 0,
            WIDE_AREA_NETWORK,
        }


        public enum DISPLAY_MODE
        {
            NORMALMODE = 0,
            OVERLAYMODE
        }


        public enum SEND_MODE
        {
            PTOPTCPMODE = 0,
            PTOPUDPMODE,
            MULTIMODE,
            RTPMODE,
            RESERVEDMODE
        }


        public enum CAPTURE_MODE
        {
            BMP_MODE = 0,
            JPEG_MODE = 1
        }


        public enum REALSOUND_MODE
        {
            MONOPOLIZE_MODE = 1,
            SHARE_MODE = 2
        }




        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SDKSTATE
        {
            public uint dwTotalLoginNum;
            public uint dwTotalRealPlayNum;
            public uint dwTotalPlayBackNum;
            public uint dwTotalAlarmChanNum;
            public uint dwTotalFormatNum;
            public uint dwTotalFileSearchNum;
            public uint dwTotalLogSearchNum;
            public uint dwTotalSerialNum;
            public uint dwTotalUpgradeNum;
            public uint dwTotalVoiceComNum;
            public uint dwTotalBroadCastNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SDKABL
        {
            public uint dwMaxLoginNum;
            public uint dwMaxRealPlayNum;
            public uint dwMaxPlayBackNum;
            public uint dwMaxAlarmChanNum;
            public uint dwMaxFormatNum;
            public uint dwMaxFileSearchNum;
            public uint dwMaxLogSearchNum;
            public uint dwMaxSerialNum;
            public uint dwMaxUpgradeNum;
            public uint dwMaxVoiceComNum;
            public uint dwMaxBroadCastNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_ALARMER
        {
            public byte byUserIDValid;
            public byte bySerialValid;
            public byte byVersionValid;
            public byte byDeviceNameValid;
            public byte byMacAddrValid;
            public byte byLinkPortValid;
            public byte byDeviceIPValid;
            public byte bySocketIPValid;
            public int lUserID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public uint dwDeviceVersion;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NAME_LEN)]
            public string sDeviceName;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMacAddr;
            public ushort wLinkPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sDeviceIP;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sSocketIP;
            public byte byIpProtocol;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DISPLAY_PARA
        {
            public int bToScreen;
            public int bToVideoOut;
            public int nLeft;
            public int nTop;
            public int nWidth;
            public int nHeight;
            public int nReserved;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARDINFO
        {
            public int lChannel;
            public int lLinkMode;
            [MarshalAsAttribute(UnmanagedType.LPStr)]
            public string sMultiCastIP;
            public NET_DVR_DISPLAY_PARA struDisplayPara;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_FIND_DATA
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string sFileName;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public uint dwFileSize;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_FINDDATA_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string sFileName;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public uint dwFileSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sCardNum;
            public byte byLocked;
            public byte byFileType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_FINDDATA_V40
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string sFileName;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public uint dwFileSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sCardNum;
            public byte byLocked;
            public byte byFileType;
            public byte byQuickSearch;
            public byte byRes;
            uint dwFileIndex;
            byte byStreamType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
            byte[] byRes1;
        }

        //const int STREAM_ID_LEN = 32;

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_STREAM_INFO
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = STREAM_ID_LEN, ArraySubType = UnmanagedType.U1)]
            public byte[] byID;
            public uint dwChannel;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes;
        };

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_VOD_PARA
        {
            public uint dwSize;
            public NET_DVR_STREAM_INFO struIDInfo;
            public NET_DVR_TIME struBeginTime;
            public NET_DVR_TIME struEndTime;
            public IntPtr hWnd;
            public byte byDrawFrame;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes;
        };

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PLAYCOND
        {
            public uint dwChannel;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public byte byDrawFrame;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes;
        };


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_FINDDATA_CARD
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string sFileName;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public uint dwFileSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string sCardNum;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FILECOND
        {
            public int lChannel;
            public uint dwFileType;
            public uint dwIsLocked;
            public uint dwUseCardNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] sCardNumber;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FILECOND_V40
        {
            public int lChannel; public uint dwFileType;
            public uint dwIsLocked; public uint dwUseCardNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] sCardNumber;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struStopTime;
            public byte byDrawFrame;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        };

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CERT_PARAM
        {
            public uint dwSize;
            public uint wCertFunc;
            public uint wCertType;
            public byte byFileType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 35, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes;
        }


    [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_POINT_FRAME
        {
            public int xTop;
            public int yTop;
            public int xBottom;
            public int yBottom;
            public int bCounter;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_COMPRESSION_AUDIO
        {
            public byte byAudioEncType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
            public byte[] byres;
        }



        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Cleanup();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);


        public delegate void EXCEPYIONCALLBACK(uint dwType, int lUserID, int lHandle, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);


        public delegate int MESSCALLBACK(int lCommand, string sDVRIP, string pBuf, uint dwBufLen);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);


        public delegate int MESSCALLBACKEX(int iCommand, int iUserID, string pBuf, uint dwBufLen);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);


        public delegate int MESSCALLBACKNEW(int lCommand, string sDVRIP, string pBuf, uint dwBufLen, ushort dwLinkDVRPort);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);


        public delegate int MESSAGECALLBACK(int lCommand, System.IntPtr sDVRIP, System.IntPtr pBuf, uint dwBufLen, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);



        public delegate void MSGCallBack(int lCommand, ref NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

        [DllImport("HCNetSDK.dll")]
        public static extern uint NET_DVR_GetSDKVersion();

        [DllImport("HCNetSDK.dll")]
        public static extern uint NET_DVR_GetSDKBuildVersion();

        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_IsSupport();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopListen();

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartListen_V30(string sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopListen_V30(Int32 lListenHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout(int iUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern uint NET_DVR_GetLastError();

        [DllImport("HCNetSDK.dll")]
        public static extern string NET_DVR_GetErrorMsg(ref int pErrorNo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, ref byte sDVRName, ushort wDVRNameLen, ref byte sDVRSerialNumber, ushort wDVRSerialLen, string sGetIP, ref uint dwPort);


        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_SDK_RealPlay(int iUserLogID, ref NET_SDK_CLIENTINFO lpDVRClientInfo);

        public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, int dwBufSize, IntPtr pUser);
        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);


        public delegate void DRAWFUN(int lRealHandle, IntPtr hDc, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ThrowBFrame(Int32 lRealHandle, uint dwNum);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetAudioMode(uint dwMode);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_OpenSound(Int32 lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseSound();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_OpenSoundShare(Int32 lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseSoundShare(Int32 lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Volume(Int32 lRealHandle, ushort wVolume);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SaveRealData(Int32 lRealHandle, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopSaveRealData(Int32 lRealHandle);

        public delegate void SETREALDATACALLBACK(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);

        public delegate void STDDATACALLBACK(int lRealHandle, uint dwDataType, ref byte pBuffer, uint dwBufSize, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MakeKeyFrame(Int32 lUserID, Int32 lChannel);//Ö÷ÂëÁ÷

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MakeKeyFrameSub(Int32 lUserID, Int32 lChannel);//×ÓÂëÁ÷


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPTZCtrl(Int32 lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPTZCtrl_Other(Int32 lUserID, int lChannel);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControl_Other(Int32 lUserID, Int32 lChannel, uint dwPTZCommand, uint dwStop);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_TransPTZ(Int32 lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, int dwPTZCommand, int dwStop, int dwSpeed);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_FindClose(int lFindHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_FindClose_V30(int lFindHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, System.IntPtr hWnd);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle,
            uint dwControlCode, IntPtr lpInBuffer, uint dwInLen,
            IntPtr lpOutBuffer, ref uint lpOutLen); // lpOutBuffer si lpInBuffer: neinteresante

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle,
            uint dwControlCode, ref IntPtr lpInBuffer, uint dwInLen,
            ref IntPtr lpOutBuffer, ref uint lpOutLen);
        /*
        [DllImport("HCNetSDK.dll")]
        public unsafe static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle,
            uint dwControlCode, IntPtr lpInBuffer, uint dwInLen,
            void* lpOutBuffer, ref uint lpOutLen);*/

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopPlayBack(int lPlayHandle);


        public delegate void PLAYDATACALLBACK(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, uint dwUser);
        public delegate void PlayDataCallBack_V40(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser);
        
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetPlayDataCallBack_V40(int lPlayHandle, PlayDataCallBack_V40 cbPlayDataCallBack, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopPlayBackSave(int lPlayHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopGetFile(int lFileHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetDownloadPos(int lFileHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetPlayBackPos(int lPlayHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_Upgrade(int lUserID, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetUpgradeState(int lUpgradeHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseFormatHandle(int lFormatHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_SetupAlarmChan(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseAlarmChan(int lAlarmHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_SetupAlarmChan_V30(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);


        public delegate void VOICEDATACALLBACK(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);


        public delegate void VOICEDATACALLBACKV30(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, System.IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopVoiceCom(int lVoiceComHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientAudioStart();


        public delegate void VOICEAUDIOSTART(string pRecvDataBuffer, uint dwBufSize, IntPtr pUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientAudioStop();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_AddDVR(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DelDVR(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DelDVR_V30(int lVoiceHandle);



        public delegate void SERIALDATACALLBACK(int lSerialHandle, string pRecvDataBuffer, uint dwBufSize, uint dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SerialStop(int lSerialHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);


        [DllImport("HCNetSDK.dll")]
        public static extern System.IntPtr NET_DVR_InitG722Decoder(int nBitrate);

        [DllImport("HCNetSDK.dll")]
        public static extern void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);


        [DllImport("HCNetSDK.dll")]
        public static extern IntPtr NET_DVR_InitG722Encoder();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport("HCNetSDK.dll")]
        public static extern void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_StartDownload(int lUserID,
            uint dwDownloadType, ref NET_DVR_CERT_PARAM lpInBuffer,
            uint dwInBufferSize, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopDownload(int lHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RemoteControl(int lUserID, uint dwCommand, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ReleaseDevice_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ReleaseDDraw_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RefreshSurface_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClearSurface_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RestoreSurface_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_OpenSound_Card(int lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseSound_Card(int lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetCardLastError_Card();

        [DllImport("HCNetSDK.dll")]
        public static extern System.IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_FindLogClose(int lLogHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_FindLogClose_V30(int lLogHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);



        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_InitDDrawDevice();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ReleaseDDrawDevice();

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetDDrawDeviceTotalNums();

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopDecode(int lUserID, int lChannel);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref tagMATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref tagMATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref tagDEC_MATRIX_CHAN_INFO lpInter);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref tagMATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref tagMATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref tagNET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref tagNET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);


        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref tagNET_MATRIX_PASSIVEMODE lpPassiveMode);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixSendData(int lPassiveHandle, System.IntPtr pSendBuf, uint dwBufSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref tagNET_DVR_DISP_LOGOCFG lpDispLogoCfg, System.IntPtr sLogoBuffer);

        public const int NET_DVR_SHOWLOGO = 1;
        public const int NET_DVR_HIDELOGO = 2;

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref tagNET_DVR__DECODER_WORK_STATUS lpDecoderCfg);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RigisterPlayBackDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);


        public const int DISP_CMD_ENLARGE_WINDOW = 1;
        public const int DISP_CMD_RENEW_WINDOW = 2;

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RefreshPlay(int lPlayHandle);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RestoreConfig(int lUserID);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SaveConfig(int lUserID);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_RebootDVR(int lUserID);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ShutDownDVR(int lUserID);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, System.IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientGetframeformat_V30(int lUserID, ref NET_DVR_FRAMEFORMAT_V30 lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientSetframeformat_V30(int lUserID, ref NET_DVR_FRAMEFORMAT_V30 lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Getframeformat_V31(int lUserID, ref tagNET_DVR_FRAMEFORMAT_V31 lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Setframeformat_V31(int lUserID, ref tagNET_DVR_FRAMEFORMAT_V31 lpFrameFormat);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetAtmProtocol(int lUserID, ref tagNET_DVR_ATM_PROTOCOL lpAtmProtocol);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetConfigFile(int lUserID, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetConfigFile(int lUserID, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetLogToFile(int bLogEnable, string strLogDir, int bAutoDel);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_LockPanel(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_UnLockPanel(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);



        public const int DS6001_HF_B = 60;
        public const int DS6001_HF_P = 61;
        public const int DS6002_HF_B = 62;
        public const int DS6101_HF_B = 63;
        public const int IDS52XX = 64;
        public const int DS9000_IVS = 65;
        public const int DS8004_AHL_A = 66;
        public const int DS6101_HF_P = 67;


        public const int VCA_DEV_ABILITY = 256;
        public const int VCA_CHAN_ABILITY = 272;
        public const int MATRIXDECODER_ABILITY = 512;

        public const int NET_DVR_SET_PLATECFG = 150;
        public const int NET_DVR_GET_PLATECFG = 151;

        public const int NET_DVR_SET_RULECFG = 152;
        public const int NET_DVR_GET_RULECFG = 153;


        public const int NET_DVR_SET_LF_CFG = 160;
        public const int NET_DVR_GET_LF_CFG = 161;


        public const int NET_DVR_SET_IVMS_STREAMCFG = 162;
        public const int NET_DVR_GET_IVMS_STREAMCFG = 163;


        public const int NET_DVR_SET_VCA_CTRLCFG = 164;
        public const int NET_DVR_GET_VCA_CTRLCFG = 165;


        public const int NET_DVR_SET_VCA_MASK_REGION = 166;
        public const int NET_DVR_GET_VCA_MASK_REGION = 167;


        public const int NET_DVR_SET_VCA_ENTER_REGION = 168;
        public const int NET_DVR_GET_VCA_ENTER_REGION = 169;


        public const int NET_DVR_SET_VCA_LINE_SEGMENT = 170;
        public const int NET_DVR_GET_VCA_LINE_SEGMENT = 171;


        public const int NET_DVR_SET_IVMS_MASK_REGION = 172;
        public const int NET_DVR_GET_IVMS_MASK_REGION = 173;

        public const int NET_DVR_SET_IVMS_ENTER_REGION = 174;
        public const int NET_DVR_GET_IVMS_ENTER_REGION = 175;

        public const int NET_DVR_SET_IVMS_BEHAVIORCFG = 176;
        public const int NET_DVR_GET_IVMS_BEHAVIORCFG = 177;


        public const int NET_DVR_IVMS_SET_SEARCHCFG = 178;
        public const int NET_DVR_IVMS_GET_SEARCHCFG = 179;


        public const int COMM_ALARM_PLATE = 4353;

        public const int COMM_ALARM_RULE = 4354;


        public const int VCA_MAX_POLYGON_POINT_NUM = 10;
        public const int MAX_RULE_NUM = 8;
        public const int MAX_TARGET_NUM = 30;
        public const int MAX_CALIB_PT = 6;
        public const int MIN_CALIB_PT = 4;
        public const int MAX_TIMESEGMENT_2 = 2;
        public const int MAX_LICENSE_LEN = 16;
        public const int MAX_PLATE_NUM = 3;
        public const int MAX_MASK_REGION_NUM = 4;
        public const int MAX_SEGMENT_NUM = 6;
        public const int MIN_SEGMENT_NUM = 3;



        public const int MAX_VCA_CHAN = 16;
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_CTRLINFO
        {
            public byte byVCAEnable;
            public byte byVCAType;
            public byte byStreamWithVCA;
            public byte byMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_CTRLCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_VCA_CHAN, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_CTRLINFO[] struCtrlInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_DEV_ABILITY
        {
            public uint dwSize;
            public byte byVCAChanNum;
            public byte byPlateChanNum;
            public byte byBBaseChanNum;
            public byte byBAdvanceChanNum;
            public byte byBFullChanNum;
            public byte byATMChanNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        public enum VCA_ABILITY_TYPE
        {
            TRAVERSE_PLANE_ABILITY = 1,
            ENTER_AREA_ABILITY = 2,
            EXIT_AREA_ABILITY = 4,
            INTRUSION_ABILITY = 8,
            LOITER_ABILITY = 16,
            LEFT_TAKE_ABILITY = 32,
            PARKING_ABILITY = 64,
            RUN_ABILITY = 128,
            HIGH_DENSITY_ABILITY = 256,
            LF_TRACK_ABILITY = 512,
            STICK_UP_ABILITY = 1073741824,
            INSTALL_SCANNER_ABILITY = -2147483648,
        }


        public enum VCA_CHAN_ABILITY_TYPE
        {
            VCA_BEHAVIOR_BASE = 1,
            VCA_BEHAVIOR_ADVANCE = 2,
            VCA_BEHAVIOR_FULL = 3,
            VCA_PLATE = 4,
            VCA_ATM = 5,
        }


        public enum VCA_CHAN_MODE_TYPE
        {
            VCA_ATM_PANEL = 0,
            VCA_ATM_SURROUND = 1,
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_CHAN_IN_PARAM
        {
            public byte byVCAType;
            public byte byMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_BEHAVIOR_ABILITY
        {
            public uint dwSize;
            public uint dwAbilityType;
            public byte byMaxRuleNum;
            public byte byMaxTargetNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_POINT
        {
            public float fX;
            public float fY;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_RECT
        {
            public float fX;
            public float fY;
            public float fWidth;
            public float fHeight;
        }


        public enum VCA_EVENT_TYPE
        {
            VCA_TRAVERSE_PLANE = 1,
            VCA_ENTER_AREA = 2,
            VCA_EXIT_AREA = 4,
            VCA_INTRUSION = 8,
            VCA_LOITER = 16,
            VCA_LEFT_TAKE = 32,
            VCA_PARKING = 64,
            VCA_RUN = 128,
            VCA_HIGH_DENSITY = 256,
            VCA_STICK_UP = 1073741824,
            VCA_INSTALL_SCANNER = -2147483648,
        }


        public enum VCA_CROSS_DIRECTION
        {
            VCA_BOTH_DIRECTION,
            VCA_LEFT_GO_RIGHT,
            VCA_RIGHT_GO_LEFT,
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_LINE
        {
            public tagNET_VCA_POINT struStart;
            public tagNET_VCA_POINT struEnd;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_POLYGON
        {
            public uint dwPointNum;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_TRAVERSE_PLANE
        {
            public tagNET_VCA_LINE struPlaneBottom;
            public VCA_CROSS_DIRECTION dwCrossDirection;
            public byte byRes1;
            public byte byPlaneHeight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 38, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_AREA
        {
            public tagNET_VCA_POLYGON struRegion;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_INTRUSION
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PARAM_LOITER
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_TAKE_LEFT
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PARKING
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_RUN
        {
            public tagNET_VCA_POLYGON struRegion;
            public float fRunDistance;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_HIGH_DENSITY
        {
            public tagNET_VCA_POLYGON struRegion;
            public float fDensity;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_STICK_UP
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            public byte bySensitivity;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_SCANNER
        {
            public tagNET_VCA_POLYGON struRegion;
            public ushort wDuration;
            public byte bySensitivity;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct tagNET_VCA_EVENT_UNION
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.U4)]
            [FieldOffsetAttribute(0)]
            public uint[] uLen;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_TRAVERSE_PLANE struTraversePlane;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_AREA struArea;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_INTRUSION struIntrusion;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_PARAM_LOITER struLoiter;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_TAKE_LEFT struTakeTeft;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_PARKING struParking;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_RUN struRun;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_HIGH_DENSITY struHighDensity;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_STICK_UP struStickUp;
            [FieldOffsetAttribute(0)]
            public tagNET_VCA_SCANNER struScanner;
        }


        public enum SIZE_FILTER_MODE
        {
            IMAGE_PIX_MODE,
            REAL_WORLD_MODE,
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_SIZE_FILTER
        {
            public byte byActive;
            public byte byMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public tagNET_VCA_RECT struMiniRect;
            public tagNET_VCA_RECT struMaxRect;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_ONE_RULE
        {
            public byte byActive;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRuleName;
            public VCA_EVENT_TYPE dwEventType;
            public tagNET_VCA_EVENT_UNION uEventParam;
            public tagNET_VCA_SIZE_FILTER struSizeFilter;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_RULECFG
        {
            public uint dwSize;
            public byte byPicProType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_JPEGPARA struPictureParam;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_ONE_RULE[] struRule;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_TARGET_INFO
        {
            public uint dwID;
            public tagNET_VCA_RECT struRect;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_RULE_INFO
        {
            public byte byRuleID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRuleName;
            public VCA_EVENT_TYPE dwEventType;
            public tagNET_VCA_EVENT_UNION uEventParam;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_DEV_INFO
        {
            public NET_DVR_IPADDR struDevIP;
            public ushort wPort;
            public byte byChannel;
            public byte byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_RULE_ALARM
        {
            public uint dwSize;
            public uint dwRelativeTime;
            public uint dwAbsTime;
            public tagNET_VCA_RULE_INFO struRuleInfo;
            public tagNET_VCA_TARGET_INFO struTargetInfo;
            public tagNET_VCA_DEV_INFO struDevInfo;
            public uint dwPicDataLen;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
            public IntPtr pImage;
        }


        public enum IVS_PARAM_KEY
        {
            OBJECT_DETECT_SENSITIVE = 1,
            BACKGROUND_UPDATE_RATE = 2,
            SCENE_CHANGE_RATIO = 3,
            SUPPRESS_LAMP = 4,
            MIN_OBJECT_SIZE = 5,
            OBJECT_GENERATE_RATE = 6,
            MISSING_OBJECT_HOLD = 7,
            MAX_MISSING_DISTANCE = 8,
            OBJECT_MERGE_SPEED = 9,
            REPEATED_MOTION_SUPPRESS = 10,
            ILLUMINATION_CHANGE = 11,
            TRACK_OUTPUT_MODE = 12,
            ENTER_CHANGE_HOLD = 13,
            RESUME_DEFAULT_PARAM = 255,
        }


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_DRAW_MODE
        {
            public uint dwSize;
            public byte byDspAddTarget;
            public byte byDspAddRule;
            public byte byDspPicAddTarget;
            public byte byDspPicAddRule;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }



        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref tagNET_VCA_DRAW_MODE lpDrawMode);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref tagNET_VCA_DRAW_MODE lpDrawMode);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_CB_POINT
        {
            public tagNET_VCA_POINT struPoint;
            public NET_DVR_PTZPOS struPtzPos;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_LF_CALIBRATION_PARAM
        {
            public byte byPointNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CALIB_PT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_CB_POINT[] struCBPoint;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_LF_CFG
        {
            public uint dwSize;
            public byte byEnable;
            public byte byFollowChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public tagNET_DVR_LF_CALIBRATION_PARAM struCalParam;
        }


        public enum TRACK_MODE
        {
            MANUAL_CTRL = 0,
            ALARM_TRACK,
            TARGET_TRACK,
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_LF_MANUAL_CTRL_INFO
        {
            public tagNET_VCA_POINT struCtrlPoint;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_LF_TRACK_TARGET_INFO
        {
            public uint dwTargetID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_LF_TRACK_MODE
        {
            public uint dwSize;
            public byte byTrackMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [StructLayoutAttribute(LayoutKind.Explicit)]
            public struct uModeParam
            {
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
                [FieldOffsetAttribute(0)]
                public uint[] dwULen;
                [FieldOffsetAttribute(0)]
                public tagNET_DVR_LF_MANUAL_CTRL_INFO struManualCtrl;
                [FieldOffsetAttribute(0)]
                public tagNET_DVR_LF_TRACK_TARGET_INFO struTargetTrack;
            }
        }


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref tagNET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref tagNET_DVR_LF_TRACK_MODE lpTrackMode);


        public enum VCA_RECOGNIZE_SCENE
        {
            VCA_LOW_SPEED_SCENE = 0,
            VCA_HIGH_SPEED_SCENE = 1,
            VCA_MOBILE_CAMERA_SCENE = 2,
        }


        public enum VCA_RECOGNIZE_RESULT
        {
            VCA_RECOGNIZE_FAILURE = 0,
            VCA_IMAGE_RECOGNIZE_SUCCESS,
            VCA_VIDEO_RECOGNIZE_SUCCESS_OF_BEST_LICENSE,
            VCA_VIDEO_RECOGNIZE_SUCCESS_OF_NEW_LICENSE,
            VCA_VIDEO_RECOGNIZE_FINISH_OF_CUR_LICENSE,
        }


        public enum VCA_PLATE_COLOR
        {
            VCA_BLUE_PLATE = 0,
            VCA_YELLOW_PLATE,
            VCA_WHITE_PLATE,
            VCA_BLACK_PLATE,
        }


        public enum VCA_PLATE_TYPE
        {
            VCA_STANDARD92_PLATE = 0,
            VCA_STANDARD02_PLATE,
            VCA_WJPOLICE_PLATE,
            VCA_JINGCHE_PLATE,
            STANDARD92_BACK_PLATE,
        }


        public enum VCA_TRIGGER_TYPE
        {
            INTER_TRIGGER = 0,
            EXTER_TRIGGER = 1,
        }

        public const int MAX_CHINESE_CHAR_NUM = 64;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PLATE_PARAM
        {
            public tagNET_VCA_RECT struSearchRect;
            public tagNET_VCA_RECT struInvalidateRect;
            public ushort wMinPlateWidth;
            public ushort wTriggerDuration;
            public byte byTriggerType;
            public byte bySensitivity;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byCharPriority;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PLATEINFO
        {
            public VCA_RECOGNIZE_SCENE eRecogniseScene;
            public tagNET_VCA_PLATE_PARAM struModifyParam;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PLATECFG
        {
            public uint dwSize;
            public byte byPicProType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_JPEGPARA struPictureParam;
            public tagNET_VCA_PLATEINFO struPlateInfo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SCHEDTIME[] struAlarmTime;
            public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRelRecordChan;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_VCA_PLATE_INFO
        {
            public VCA_RECOGNIZE_RESULT eResultFlag;
            public VCA_PLATE_TYPE ePlateType;
            public VCA_PLATE_COLOR ePlateColor;
            public tagNET_VCA_RECT struPlateRect;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
            public uint dwLicenseLen;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = MAX_LICENSE_LEN)]
            public string sLicense;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = MAX_LICENSE_LEN)]
            public string sBelieve;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_PLATE_RESULT
        {
            public uint dwSize;
            public uint dwRelativeTime;
            public uint dwAbsTime;
            public byte byPlateNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_PLATE_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_PLATE_INFO[] struPlateInfo;
            public uint dwPicDataLen;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes2;
            public System.IntPtr pImage;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_ONE_RULE_
        {
            public byte byActive;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRuleName;
            public VCA_EVENT_TYPE dwEventType;
            public tagNET_VCA_EVENT_UNION uEventParam;
            public tagNET_VCA_SIZE_FILTER struSizeFilter;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_RULECFG
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_IVMS_ONE_RULE_[] struRule;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_BEHAVIORCFG
        {
            public uint dwSize;
            public byte byPicProType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_JPEGPARA struPicParam;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_IVMS_RULECFG[] struRuleCfg;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_DEVSCHED
        {
            public NET_DVR_SCHEDTIME struTime;
            public NET_DVR_PU_STREAM_CFG struPUStream;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_STREAMCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_IVMS_DEVSCHED[] struDevSched;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_MASK_REGION
        {
            public byte byEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public tagNET_VCA_POLYGON struPolygon;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_MASK_REGION_LIST
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_MASK_REGION_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_MASK_REGION[] struMask;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_ENTER_REGION
        {
            public uint dwSize;
            public byte byEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public tagNET_VCA_POLYGON struPolygon;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_VCA_RestartLib(int lUserID, int lChannel);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_LINE_SEGMENT
        {
            public tagNET_VCA_POINT struStartPoint;
            public tagNET_VCA_POINT struEndPoint;
            public float fValue;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_VCA_LINE_SEG_LIST
        {
            public uint dwSize;
            public byte bySegNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_SEGMENT_NUM, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_LINE_SEGMENT[] struSeg;
        }

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref tagNET_VCA_LINE lpLine, ref Single lpHeight);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref tagNET_VCA_LINE lpLine, ref Single lpLength);


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_MASK_REGION_LIST
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_MASK_REGION_LIST[] struList;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_ENTER_REGION
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_VCA_ENTER_REGION[] struEnter;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_ALARM_JPEG
        {
            public byte byPicProType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_JPEGPARA struPicParam;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_IVMS_SEARCHCFG
        {
            public uint dwSize;
            public NET_DVR_MATRIX_DEC_REMOTE_PLAY struRemotePlay;
            public tagNET_IVMS_ALARM_JPEG struAlarmJpeg;
            public tagNET_IVMS_RULECFG struRuleCfg;
        }


        public const int NET_DVR_GET_AP_INFO_LIST = 305;
        public const int NET_DVR_SET_WIFI_CFG = 306;
        public const int NET_DVR_GET_WIFI_CFG = 307;
        public const int NET_DVR_SET_WIFI_WORKMODE = 308;
        public const int NET_DVR_GET_WIFI_WORKMODE = 309;

        //public const int IW_ESSID_MAX_SIZE = 32;
        public const int WIFI_WEP_MAX_KEY_COUNT = 4;
        public const int WIFI_WEP_MAX_KEY_LENGTH = 33;
        public const int WIFI_WPA_PSK_MAX_KEY_LENGTH = 63;
        public const int WIFI_WPA_PSK_MIN_KEY_LENGTH = 8;
        public const int WIFI_MAX_AP_COUNT = 20;

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVR_AP_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = IW_ESSID_MAX_SIZE)]
            public string sSsid;
            public uint dwMode;
            public uint dwSecurity;
            public uint dwChannel;
            public uint dwSignalStrength;
            public uint dwSpeed;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_AP_INFO_LIST
        {
            public uint dwSize;
            public uint dwCount;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = WIFI_MAX_AP_COUNT, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_AP_INFO[] struApInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVR_WIFIETHERNET
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIpAddress;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIpMask;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] bRes;
            public uint dwEnableDhcp;
            public uint dwAutoDns;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sFirstDns;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sSecondDns;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sGatewayIpAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] bRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct tagNET_DVR__WIFI_CFG_EX
        {
            public tagNET_DVR_WIFIETHERNET struEtherNet;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = IW_ESSID_MAX_SIZE)]
            public string sEssid;
            public uint dwMode;
            public uint dwSecurity;
            [StructLayoutAttribute(LayoutKind.Explicit)]
            public struct key
            {
                [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
                public struct wep
                {
                    public uint dwAuthentication;
                    public uint dwKeyLength;
                    public uint dwKeyType;
                    public uint dwActive;
                    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = WIFI_WEP_MAX_KEY_COUNT * WIFI_WEP_MAX_KEY_LENGTH)]
                    public string sKeyInfo;
                }

                [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
                public struct wpa_psk
                {
                    public uint dwKeyLength;
                    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = WIFI_WPA_PSK_MAX_KEY_LENGTH)]
                    public string sKeyInfo;
                    public byte sRes;
                }
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_WIFI_CFG
        {
            public uint dwSize;
            public tagNET_DVR__WIFI_CFG_EX struWifiCfg;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_WIFI_WORKMODE
        {
            public uint dwSize;
            public uint dwNetworkInterfaceMode;
        }

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_EncodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_SINGLE_NET_DISK_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_IPADDR struNetDiskAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDirectory;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        public const int MAX_NET_DISK = 16;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_NET_DISKCFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NET_DISK, ArraySubType = UnmanagedType.Struct)]
            public tagNET_DVR_SINGLE_NET_DISK_INFO[] struNetDiskParam;
        }


        public enum MAIN_EVENT_TYPE
        {
            EVENT_MOT_DET = 0,
            EVENT_ALARM_IN = 1,
            EVENT_VCA_BEHAVIOR = 2,
        }


        public enum BEHAVIOR_MINOR_TYPE
        {
            EVENT_TRAVERSE_PLANE = 0,
            EVENT_ENTER_AREA,
            EVENT_EXIT_AREA,
            EVENT_INTRUSION,
            EVENT_LOITER,
            EVENT_LEFT_TAKE,
            EVENT_PARKING,
            EVENT_RUN,
            EVENT_HIGH_DENSITY,
            EVENT_STICK_UP,
            EVENT_INSTALL_SCANNER,
        }


        public const int SEARCH_EVENT_INFO_LEN = 300;

        [StructLayoutAttribute(LayoutKind.Sequential)]

        public struct struAlarmParam
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SEARCH_EVENT_INFO_LEN - MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void init()
            {
                byAlarmInNo = new byte[MAX_ALARMIN_V30];
                byRes = new byte[SEARCH_EVENT_INFO_LEN - MAX_CHANNUM_V30];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struMotionParam
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byMotDetChanNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SEARCH_EVENT_INFO_LEN - MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void init()
            {
                byMotDetChanNo = new byte[MAX_CHANNUM_V30];
                byRes = new byte[SEARCH_EVENT_INFO_LEN - MAX_CHANNUM_V30];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struVcaParam
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byChanNo;
            public byte byRuleID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 43, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;

            public void init()
            {
                byChanNo = new byte[MAX_CHANNUM_V30];
                byRes1 = new byte[43];
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct uSeniorParam
        {
            //             [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
            //             public byte[] byLen;
            [FieldOffset(0)]
            public struMotionParam struMotionPara;
            [FieldOffset(0)]
            public struAlarmParam struAlarmPara;

            //             public struVcaParam struVcaPara;

            public void init()
            {
                //                 byLen = new byte[SEARCH_EVENT_INFO_LEN];
                struAlarmPara = new struAlarmParam();
                struAlarmPara.init();
                //                 struMotionPara = new struMotionParam();
                //                 struMotionPara.init();
                //                 struVcaPara = new struVcaParam();
                //                 struVcaPara.init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_SEARCH_EVENT_PARAM
        {
            public ushort wMajorType;
            public ushort wMinorType;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struEndTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 132, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public uSeniorParam uSeniorPara;

            public void init()
            {
                byRes = new byte[132];
                uSeniorPara = new uSeniorParam();
                uSeniorPara.init();
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struAlarmRet
        {
            public uint dwAlarmInNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void init()
            {
                byRes = new byte[SEARCH_EVENT_INFO_LEN];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struMotionRet
        {
            public uint dwMotDetNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void init()
            {
                byRes = new byte[SEARCH_EVENT_INFO_LEN];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struVcaRet
        {
            public uint dwChanNo;
            public byte byRuleID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRuleName;
            public tagNET_VCA_EVENT_UNION uEvent;

            public void init()
            {
                byRes1 = new byte[3];
                byRuleName = new byte[NAME_LEN];
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct uSeniorRet
        {
            [FieldOffset(0)]
            public struAlarmRet struAlarmRe;
            [FieldOffset(0)]
            public struMotionRet struMotionRe;
            //             public struVcaRet struVcaRe;

            public void init()
            {
                struAlarmRe = new struAlarmRet();
                struAlarmRe.init();
                //                 struVcaRe = new struVcaRet();
                //                 struVcaRe.init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_SEARCH_EVENT_RET
        {
            public ushort wMajorType;
            public ushort wMinorType;
            public NET_DVR_TIME struStartTime;
            public NET_DVR_TIME struEndTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
            public byte[] byChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public uSeniorRet uSeniorRe;

            public void init()
            {
                byChan = new byte[MAX_CHANNUM_V30];
                byRes = new byte[36];
                uSeniorRe = new uSeniorRet();
                uSeniorRe.init();
            }
        }



        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_EmailTest(int lUserID);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindFileByEvent(int lUserID, ref tagNET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);

        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextEvent(int lSearchHandle, ref tagNET_DVR_SEARCH_EVENT_RET lpSearchEventRet);



        public const int PLATE_INFO_LEN = 1024;
        public const int PLATE_NUM_LEN = 16;
        public const int FILE_NAME_LEN = 256;


        public enum Anonymous_26594f67_851c_4f7d_bec4_094765b7ff83
        {
            BLUE_PLATE,
            YELLOW_PLATE,
            WHITE_PLATE,
            BLACK_PLATE,
        }

        //liscense plate result
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_PLATE_RET
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PLATE_NUM_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byPlateNum;
            public byte byVehicleType;
            public byte byTrafficLight;
            public byte byPlateColor;
            public byte byDriveChan;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byTimeInfo;

            public byte byCarSpeed;
            public byte byCarSpeedH;
            public byte byCarSpeedL;
            public byte byRes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PLATE_INFO_LEN - 36, ArraySubType = UnmanagedType.I1)]
            public byte[] byInfo;
            public uint dwPicLen;
        }


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_INVOKE_PLATE_RECOGNIZE(int lUserID, int lChannel, string pPicFileName, ref tagNET_DVR_PLATE_RET pPlateRet, string pPicBuf, uint dwPicBufLen);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagNET_DVR_CCD_CFG
        {
            public uint dwSize;
            public byte byBlc;
            public byte byBlcMode;
            public byte byAwb;
            public byte byAgc;
            public byte byDayNight;
            public byte byMirror;
            public byte byShutter;
            public byte byIrCutTime;
            public byte byLensType;
            public byte byEnVideoTrig;
            public byte byCapShutter;
            public byte byEnRecognise;
        }

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref tagNET_DVR_CCD_CFG lpCCDCfg);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref tagNET_DVR_CCD_CFG lpCCDCfg);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagCAMERAPARAMCFG
        {
            public uint dwSize;
            public uint dwPowerLineFrequencyMode;
            public uint dwWhiteBalanceMode;
            public uint dwWhiteBalanceModeRGain;
            public uint dwWhiteBalanceModeBGain;
            public uint dwExposureMode;
            public uint dwExposureSet;
            public uint dwExposureUserSet;
            public uint dwExposureTarget;
            public uint dwIrisMode;
            public uint dwGainLevel;
            public uint dwBrightnessLevel;
            public uint dwContrastLevel;
            public uint dwSharpnessLevel;
            public uint dwSaturationLevel;
            public uint dwHueLevel;
            public uint dwGammaCorrectionEnabled;
            public uint dwGammaCorrectionLevel;
            public uint dwWDREnabled;
            public uint dwWDRLevel1;
            public uint dwWDRLevel2;
            public uint dwWDRContrastLevel;
            public uint dwDayNightFilterType;
            public uint dwSwitchScheduleEnabled;

            public uint dwBeginTime;
            public uint dwEndTime;

            public uint dwDayToNightFilterLevel;//0-7
            public uint dwNightToDayFilterLevel;//0-7
            public uint dwDayNightFilterTime;
            public uint dwBacklightMode;
            public uint dwPositionX1;
            public uint dwPositionY1;
            public uint dwPositionX2;
            public uint dwPositionY2;
            public uint dwBacklightLevel;/*0x0-0xF*/
            public uint dwDigitalNoiseRemoveEnable;
            public uint dwDigitalNoiseRemoveLevel;/*0x0-0xF*/
            public uint dwMirror;
            public uint dwDigitalZoom;
            public uint dwDeadPixelDetect;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.U4)]
            public uint[] dwRes;
        }

        public const int NET_DVR_GET_CCDPARAMCFG = 1067;
        public const int NET_DVR_SET_CCDPARAMCFG = 1068;


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagIMAGEREGION
        {
            public uint dwSize;
            public ushort wImageRegionTopLeftX;
            public ushort wImageRegionTopLeftY;
            public ushort wImageRegionWidth;
            public ushort wImageRegionHeight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagIMAGESUBPARAM
        {
            public NET_DVR_SCHEDTIME struImageStatusTime;
            public byte byImageEnhancementLevel;
            public byte byImageDenoiseLevel;
            public byte byImageStableEnable;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        public const int NET_DVR_GET_IMAGEREGION = 1062;
        public const int NET_DVR_SET_IMAGEREGION = 1063;
        public const int NET_DVR_GET_IMAGEPARAM = 1064;
        public const int NET_DVR_SET_IMAGEPARAM = 1065;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagIMAGEPARAM
        {
            public uint dwSize;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
            public tagIMAGESUBPARAM[] struImageParamSched;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);

        public struct NET_DVR_CLIENTINFO
        {
            public Int32 lChannel;
            public Int32 lLinkMode;
            public IntPtr hPlayWnd;
            public string sMultiCastIP;
        }



        public const int STREAM_ID_LEN = 32;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PREVIEWINFO
        {
            public Int32 lChannel;          // Channel no.
            public Int32 dwStreamType;	    // Stream type 0-main stream£¬1-sub stream£¬2-third stream£¬3-forth stream, and so on
            public Int32 dwLinkMode;		// Protocol type: 0-TCP, 1-UDP, 2-Muticast, 3-RTP£¬4-RTP/RTSP, 5-RSTP/HTTP
            public IntPtr hPlayWnd;		    // Play window's handle;  set NULL to disable preview
            public Int32 bBlocked;          // 0 - non-blocking stream getting，1 - blocking stream getting. if it is block, there will be 5s timeout return when connect failed in the SDK, it is not suitable for polling stream gettitng. 
            public Int32 bPassbackRecord;   // 0 - disable video passback，1 - enable video passback. back tracking when ANR disconnected- devices send the data automaticly after the network recovery between client and devices.(need devices support) 
            public byte byPreviewMode;      // Prerview mode:0- normally preview，1- delay preview 

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = STREAM_ID_LEN, ArraySubType = UnmanagedType.U1)]
            public byte[] byStreamID;       // Stream ID，combination of letter, number and '_',enable the parameter when lChannel = 0xffffffff 
            public byte byProtoType;        // Application layer protocol: 0 - private protocol，1 - RTSP. The protocol supported by main stream gets from byMainProto, bySubProto of NET_DVR_DEVICEINFO_V30. The parameter is valid when devices support private and RTSP simultaneously. Deafult- private (RTSP optional) 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes1;
            public Int32 dwDisplayBufNum;   // soft player display buffer size(number of frames), range:1-50, default:1 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 216, ArraySubType = UnmanagedType.U1)]
            public byte[] byRes;
        }

        public struct NET_SDK_CLIENTINFO
        {
            public Int32 lChannel;
            public Int32 lLinkType;
            public Int32 lLinkMode;
            public IntPtr hPlayWnd;
            public string sMultiCastIP;
            public Int32 iMediaSrvNum;
            public System.IntPtr pMediaSrvDir;
        }


        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);


        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);



        #region

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct PLAY_INFO
        {
            public int iUserID;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string strDeviceIP;
            public int iDevicePort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string strDevAdmin;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string strDevPsd;
            public int iChannel;
            public int iLinkMode;
            public bool bUseMedia;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string strMediaIP;
            public int iMediaPort;
        }


        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_Init();

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_UnInit();


        [DllImport("GetStream.dll")]
        public static extern int CLIENT_SDK_GetStream(PLAY_INFO lpPlayInfo); //

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SetRealDataCallBack(int iRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint lUser); //

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_StopStream(int iRealHandle);

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_GetVideoEffect(int iRealHandle, ref int iBrightValue, ref int iContrastValue, ref int iSaturationValue, ref int iHueValue);

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_SetVideoEffect(int iRealHandle, int iBrightValue, int iContrastValue, int iSaturationValue, int iHueValue);

        [DllImport("GetStream.dll")]
        public static extern bool CLIENT_SDK_MakeKeyFrame(int iRealHandle);

        #endregion


        #region

        public const int WM_NETERROR = 0x0400 + 102;
        public const int WM_STREAMEND = 0x0400 + 103;

        public const int FILE_HEAD = 0;
        public const int VIDEO_I_FRAME = 1;
        public const int VIDEO_B_FRAME = 2;
        public const int VIDEO_P_FRAME = 3;
        public const int VIDEO_BP_FRAME = 4;
        public const int VIDEO_BBP_FRAME = 5;
        public const int AUDIO_PACKET = 10;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BLOCKTIME
        {
            public ushort wYear;
            public byte bMonth;
            public byte bDay;
            public byte bHour;
            public byte bMinute;
            public byte bSecond;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct VODSEARCHPARAM
        {
            public IntPtr sessionHandle;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string dvrIP;
            public uint dvrPort;
            public uint channelNum;
            public BLOCKTIME startTime;
            public BLOCKTIME stopTime;
            public bool bUseIPServer;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string SerialNumber;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct SECTIONLIST
        {
            public BLOCKTIME startTime;
            public BLOCKTIME stopTime;
            public byte byRecType;
            public IntPtr pNext;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct VODOPENPARAM
        {
            public IntPtr sessionHandle;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string dvrIP;
            public uint dvrPort;
            public uint channelNum;
            public BLOCKTIME startTime;
            public BLOCKTIME stopTime;
            public uint uiUser;
            public bool bUseIPServer;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string SerialNumber;

            public VodStreamFrameData streamFrameData;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct CONNPARAM
        {
            public uint uiUser;
            public ErrorCallback errorCB;
        }



        public delegate void ErrorCallback(System.IntPtr hSession, uint dwUser, int lErrorType);

        public delegate void VodStreamFrameData(System.IntPtr hStream, uint dwUser, int lFrameType, System.IntPtr pBuffer, uint dwSize);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODServerConnect(string strServerIp, uint uiServerPort, ref IntPtr hSession, ref CONNPARAM struConn, IntPtr hWnd);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODServerDisconnect(IntPtr hSession);

        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODStreamSearch(IntPtr pSearchParam, ref IntPtr pSecList);

        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODDeleteSectionList(IntPtr pSecList);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODOpenStream(IntPtr pOpenParam, ref IntPtr phStream);

        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODCloseStream(IntPtr hStream);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODOpenDownloadStream(ref VODOPENPARAM struVodParam, ref IntPtr phStream);

        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODCloseDownloadStream(IntPtr hStream);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODStartStreamData(IntPtr phStream);
        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODPauseStreamData(IntPtr hStream, bool bPause);
        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODStopStreamData(IntPtr hStream);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODSeekStreamData(IntPtr hStream, IntPtr pStartTime);



        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODSetStreamSpeed(IntPtr hStream, int iSpeed);


        [DllImport("PdCssVodClient.dll")]
        public static extern bool VODGetStreamCurrentTime(IntPtr hStream, ref BLOCKTIME pCurrentTime);

        #endregion


        #region


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct PACKET_INFO
        {
            public int nPacketType;     // packet type
            // 0:  file head
            // 1:  video I frame
            // 2:  video B frame
            // 3:  video P frame
            // 10: audio frame
            // 11: private frame only for PS


            //      [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
            public IntPtr pPacketBuffer;
            public uint dwPacketSize;
            public int nYear;
            public int nMonth;
            public int nDay;
            public int nHour;
            public int nMinute;
            public int nSecond;
            public uint dwTimeStamp;
        }



        /******************************************************************************
        * function£ºget a empty port number
        * parameters£º
        * return£º 0 - 499 : empty port number
        *          -1      : server is full  			
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern int AnalyzeDataGetSafeHandle();


        /******************************************************************************
        * function£ºopen standard stream data for analyzing
        * parameters£ºlHandle - working port number
        *             pHeader - pointer to file header or info header
        * return£ºTRUE or FALSE
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataOpenStreamEx(int iHandle, byte[] pFileHead);


        /******************************************************************************
        * function£ºclose analyzing
        * parameters£ºlHandle - working port number
        * return£º
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataClose(int iHandle);


        /******************************************************************************
        * function£ºinput stream data
        * parameters£ºlHandle		- working port number
        *			  pBuffer		- data pointer
        *			  dwBuffersize	- data size
        * return£ºTRUE or FALSE
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataInputData(int iHandle, IntPtr pBuffer, uint uiSize); //byte []


        /******************************************************************************
        * function£ºget analyzed packet
        * parameters£ºlHandle		- working port number
        *			  pPacketInfo	- returned structure
        * return£º-1 : error
        *          0 : succeed
        *		   1 : failed
        *		   2 : file end (only in file mode)				
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern int AnalyzeDataGetPacket(int iHandle, ref PACKET_INFO pPacketInfo);


        /******************************************************************************
        * function£ºget remain data from input buffer
        * parameters£ºlHandle		- working port number
        *			  pBuf	        - pointer to the mem which stored remain data
        *             dwSize        - size of remain data  
        * return£º TRUE or FALSE				
        * comment£º
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataGetTail(int iHandle, ref IntPtr pBuffer, ref uint uiSize);


        [DllImport("AnalyzeData.dll")]
        public static extern uint AnalyzeDataGetLastError(int iHandle);

        #endregion


        #region

        public const int DATASTREAM_HEAD = 0;
        public const int DATASTREAM_BITBLOCK = 1;
        public const int DATASTREAM_KEYFRAME = 2;
        public const int DATASTREAM_NORMALFRAME = 3;


        public const int MESSAGEVALUE_DISKFULL = 0x01;
        public const int MESSAGEVALUE_SWITCHDISK = 0x02;
        public const int MESSAGEVALUE_CREATEFILE = 0x03;
        public const int MESSAGEVALUE_DELETEFILE = 0x04;
        public const int MESSAGEVALUE_SWITCHFILE = 0x05;




        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct STOREINFO
        {
            public int iMaxChannels;
            public int iDiskGroup;
            public int iStreamType;
            public bool bAnalyze;
            public bool bCycWrite;
            public uint uiFileSize;

            public CALLBACKFUN_MESSAGE funCallback;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct CREATEFILE_INFO
        {
            public int iHandle;

            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string strCameraid;

            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string strFileName;

            public BLOCKTIME tFileCreateTime;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct CLOSEFILE_INFO
        {
            public int iHandle;

            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string strCameraid;

            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string strFileName;

            public BLOCKTIME tFileSwitchTime;
        }



        public delegate int CALLBACKFUN_MESSAGE(int iMessageType, System.IntPtr pBuf, int iBufLen);


        [DllImport("RecordDLL.dll")]
        public static extern int Initialize(STOREINFO struStoreInfo);

        [DllImport("RecordDLL.dll")]
        public static extern int Release();

        [DllImport("RecordDLL.dll")]
        public static extern int OpenChannelRecord(string strCameraid, IntPtr pHead, uint dwHeadLength);

        [DllImport("RecordDLL.dll")]
        public static extern bool CloseChannelRecord(int iRecordHandle);

        [DllImport("RecordDLL.dll")]
        public static extern int GetData(int iHandle, int iDataType, IntPtr pBuf, uint uiSize);

        #endregion


        public const int REGIONTYPE = 0;
        public const int MATRIXTYPE = 11;
        public const int DEVICETYPE = 2;
        public const int CHANNELTYPE = 3;
        public const int USERTYPE = 5;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_LOG_MATRIX
        {
            public NET_DVR_TIME strLogTime;
            public uint dwMajorType;
            public uint dwMinorType;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPanelUser;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNetUser;
            public NET_DVR_IPADDR struRemoteHostAddr;
            public uint dwParaType;
            public uint dwChannel;
            public uint dwDiskNumber;
            public uint dwAlarmInPort;
            public uint dwAlarmOutPort;
            public uint dwInfoLen;
            public byte byDevSequence;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMacAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = LOG_INFO_LEN - SERIALNO_LEN - MACADDR_LEN - 1)]
            public string sInfo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagVEDIOPLATLOG
        {
            public byte bySearchCondition;
            public byte byDevSequence;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMacAddr;
        }

        [DllImportAttribute("HCNetSDK.dll")]
        public static extern int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);


        [DllImportAttribute("HCNetSDK.dll")]
        public static extern int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
    }

}
