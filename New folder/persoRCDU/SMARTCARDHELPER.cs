using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Runtime.InteropServices;

namespace persoRCDU
{
    public class SMARTCARDHELPER
    {
        private const int SCARD_SCOPE_USER = 0;
        private const int SCARD_SCOPE_TERMINAL = 1;
        private const uint SCARD_SCOPE_SYSTEM = 2;
        private const int SCARD_AUTOALLOCATE = -1;
        private const int SCARD_S_SUCCESS = 0;
        public const int SCARD_PROTOCOL_UNDEFINED = 0;
        private const int SCARD_PROTOCOL_T0 = 1;
        private const int SCARD_PROTOCOL_T1 = 2;
        private const long SCARD_F_INTERNAL_ERROR = 2148532225;
        private const long SCARD_E_CANCELLED = 2148532226;
        private const long SCARD_E_INVALID_HANDLE = 2148532227;
        private const long SCARD_E_INVALID_PARAMETER = 2148532228;
        private const long SCARD_E_INVALID_TARGET = 2148532229;
        private const long SCARD_E_NO_MEMORY = 2148532230;
        private const long SCARD_F_WAITED_TOO_LONG = 2148532231;
        private const long SCARD_E_INSUFFICIENT_BUFFER = 2148532232;
        private const long SCARD_E_UNKNOWN_READER = 2148532233;
        private const long SCARD_E_TIMEOUT = 2148532234;
        private const long SCARD_E_SHARING_VIOLATION = 2148532235;
        private const long SCARD_E_NO_SMARTCARD = 2148532236;
        private const long SCARD_E_UNKNOWN_CARD = 2148532237;
        private const long SCARD_E_CANT_DISPOSE = 2148532238;
        private const long SCARD_E_PROTO_MISMATCH = 2148532239;
        private const long SCARD_E_NOT_READY = 2148532240;
        private const long SCARD_E_INVALID_VALUE = 2148532241;
        private const long SCARD_E_SYSTEM_CANCELLED = 2148532242;
        private const long SCARD_F_COMM_ERROR = 2148532243;
        private const long SCARD_F_UNKNOWN_ERROR = 2148532244;
        private const long SCARD_E_INVALID_ATR = 2148532245;
        private const long SCARD_E_NOT_TRANSACTED = 2148532246;
        private const long SCARD_E_READER_UNAVAILABLE = 2148532247;
        private const long SCARD_P_SHUTDOWN = 2148532248;
        private const long SCARD_E_PCI_TOO_SMALL = 2148532249;
        private const long SCARD_E_READER_UNSUPPORTED = 2148532250;
        private const long SCARD_E_DUPLICATE_READER = 2148532251;
        private const long SCARD_E_CARD_UNSUPPORTED = 2148532252;
        private const long SCARD_E_NO_SERVICE = 2148532253;
        private const long SCARD_E_SERVICE_STOPPED = 2148532254;
        private const long SCARD_E_UNEXPECTED = 2148532255;
        private const long SCARD_E_ICC_INSTALLATION = 2148532256;
        private const long SCARD_E_ICC_CREATEORDER = 2148532257;
        private const long SCARD_E_UNSUPPORTED_FEATURE = 2148532258;
        private const long SCARD_E_DIR_NOT_FOUND = 2148532259;
        private const long SCARD_E_FILE_NOT_FOUND = 2148532260;
        private const long SCARD_E_NO_DIR = 2148532261;
        private const long SCARD_E_NO_FILE = 2148532262;
        private const long SCARD_E_NO_ACCESS = 2148532263;
        private const long SCARD_E_WRITE_TOO_MANY = 2148532264;
        private const long SCARD_E_BAD_SEEK = 2148532265;
        private const long SCARD_E_INVALID_CHV = 2148532266;
        private const long SCARD_E_UNKNOWN_RES_MNG = 2148532267;
        private const long SCARD_E_NO_SUCH_CERTIFICATE = 2148532268;
        private const long SCARD_E_CERTIFICATE_UNAVAILABLE = 2148532269;
        private const long SCARD_E_NO_READERS_AVAILABLE = 2148532270;
        private const long SCARD_E_COMM_DATA_LOST = 2148532271;
        private const long SCARD_E_NO_KEY_CONTAINER = 2148532272;
        private const long SCARD_W_UNSUPPORTED_CARD = 2148532325;
        private const long SCARD_W_UNRESPONSIVE_CARD = 2148532326;
        private const long SCARD_W_UNPOWERED_CARD = 2148532327;
        private const long SCARD_W_RESET_CARD = 2148532328;
        private const long SCARD_W_REMOVED_CARD = 2148532329;
        private const long SCARD_W_SECURITY_VIOLATION = 2148532330;
        private const long SCARD_W_WRONG_CHV = 2148532331;
        private const long SCARD_W_CHV_BLOCKED = 2148532332;
        private const long SCARD_W_EOF = 2148532333;
        private const long SCARD_W_CANCELLED_BY_USER = 2148532334;
        private const long SCARD_W_CARD_NOT_AUTHENTICATED = 2148532335;
        private const long SCARD_E_SERVER_TOO_BUSY = 2148532273;
        private const long SCARD_W_CACHE_ITEM_NOT_FOUND = 2148532336;
        private const long SCARD_W_CACHE_ITEM_STALE = 2148532337;
        private const long SCARD_W_CACHE_ITEM_TOO_BIG = 2148532338;
        private const int NO_ERROR = 0;
        private const int ERROR_SUCCESS = 0;
        private const int ERROR_INVALID_FUNCTION = 1;
        private const int ERROR_FILE_NOT_FOUND = 2;
        private const int ERROR_PATH_NOT_FOUND = 3;
        private const int ERROR_TOO_MANY_OPEN_FILES = 4;
        private const int ERROR_ACCESS_DENIED = 5;
        private const int ERROR_INVALID_HANDLE = 6;
        private const int ERROR_ARENA_TRASHED = 7;
        private const int ERROR_NOT_ENOUGH_MEMORY = 8;
        private const int ERROR_INVALID_BLOCK = 9;
        private const int ERROR_BAD_ENVIRONMENT = 10;
        private const int ERROR_BAD_FORMAT = 11;
        private const int ERROR_INVALID_ACCESS = 12;
        private const int ERROR_INVALID_DATA = 13;
        private const int ERROR_OUTOFMEMORY = 14;
        private const int ERROR_INVALID_DRIVE = 15;
        private const int ERROR_CURRENT_DIRECTORY = 16;
        private const int ERROR_NOT_SAME_DEVICE = 17;
        private const int ERROR_NO_MORE_FILES = 18;
        private const int ERROR_WRITE_PROTECT = 19;
        private const int ERROR_BAD_UNIT = 20;
        private const int ERROR_NOT_READY = 21;
        private const int ERROR_BAD_COMMAND = 22;
        private const int ERROR_CRC = 23;
        private const int ERROR_BAD_LENGTH = 24;
        private const int ERROR_SEEK = 25;
        private const int ERROR_NOT_DOS_DISK = 26;
        private const int ERROR_SECTOR_NOT_FOUND = 27;
        private const int ERROR_OUT_OF_PAPER = 28;
        private const int ERROR_WRITE_FAULT = 29;
        private const int ERROR_READ_FAULT = 30;
        private const int ERROR_GEN_FAILURE = 31;
        private const int ERROR_SHARING_VIOLATION = 32;
        private const int ERROR_LOCK_VIOLATION = 33;
        private const int ERROR_WRONG_DISK = 34;
        private const int ERROR_SHARING_BUFFER_EXCEEDED = 36;
        private const int ERROR_HANDLE_EOF = 38;
        private const int ERROR_HANDLE_DISK_FULL = 39;
        private const int ERROR_NOT_SUPPORTED = 50;
        private const int ERROR_REM_NOT_LIST = 51;
        private const int ERROR_DUP_NAME = 52;
        private const int ERROR_BAD_NETPATH = 53;
        private const int ERROR_NETWORK_BUSY = 54;
        private const int ERROR_DEV_NOT_EXIST = 55;
        private const int ERROR_TOO_MANY_CMDS = 56;
        private const int ERROR_ADAP_HDW_ERR = 57;
        private const int ERROR_BAD_NET_RESP = 58;
        private const int ERROR_UNEXP_NET_ERR = 59;
        private const int ERROR_BAD_REM_ADAP = 60;
        private const int ERROR_PRINTQ_FULL = 61;
        private const int ERROR_NO_SPOOL_SPACE = 62;
        private const int ERROR_PRINT_CANCELLED = 63;
        private const int ERROR_NETNAME_DELETED = 64;
        private const int ERROR_NETWORK_ACCESS_DENIED = 65;
        private const int ERROR_BAD_DEV_TYPE = 66;
        private const int ERROR_BAD_NET_NAME = 67;
        private const int ERROR_TOO_MANY_NAMES = 68;
        private const int ERROR_TOO_MANY_SESS = 69;
        private const int ERROR_SHARING_PAUSED = 70;
        private const int ERROR_REQ_NOT_ACCEP = 71;
        private const int ERROR_REDIR_PAUSED = 72;
        private const int ERROR_FILE_EXISTS = 80;
        private const int ERROR_CANNOT_MAKE = 82;
        private const int ERROR_FAIL_I24 = 83;
        private const int ERROR_OUT_OF_STRUCTURES = 84;
        private const int ERROR_ALREADY_ASSIGNED = 85;
        private const int ERROR_INVALID_PASSWORD = 86;
        private const int ERROR_INVALID_PARAMETER = 87;
        private const int ERROR_NET_WRITE_FAULT = 88;
        private const int ERROR_NO_PROC_SLOTS = 89;
        private const int ERROR_TOO_MANY_SEMAPHORES = 100;
        private const int ERROR_EXCL_SEM_ALREADY_OWNED = 101;
        private const int ERROR_SEM_IS_SET = 102;
        private const int ERROR_TOO_MANY_SEM_REQUESTS = 103;
        private const int ERROR_INVALID_AT_INTERRUPT_TIME = 104;
        private const int ERROR_SEM_OWNER_DIED = 105;
        private const int ERROR_SEM_USER_LIMIT = 106;
        private const int ERROR_DISK_CHANGE = 107;
        private const int ERROR_DRIVE_LOCKED = 108;
        private const int ERROR_BROKEN_PIPE = 109;
        private const int ERROR_OPEN_FAILED = 110;
        private const int ERROR_BUFFER_OVERFLOW = 111;
        private const int ERROR_DISK_FULL = 112;
        private const int ERROR_NO_MORE_SEARCH_HANDLES = 113;
        private const int ERROR_INVALID_TARGET_HANDLE = 114;
        private const int ERROR_INVALID_CATEGORY = 117;
        private const int ERROR_INVALID_VERIFY_SWITCH = 118;
        private const int ERROR_BAD_DRIVER_LEVEL = 119;
        private const int ERROR_CALL_NOT_IMPLEMENTED = 120;
        private const int ERROR_SEM_TIMEOUT = 121;
        private const int ERROR_INSUFFICIENT_BUFFER = 122;
        private const int ERROR_INVALID_NAME = 123;
        private const int ERROR_INVALID_LEVEL = 124;
        private const int ERROR_NO_VOLUME_LABEL = 125;
        private const int ERROR_MOD_NOT_FOUND = 126;
        private const int ERROR_PROC_NOT_FOUND = 127;
        private const int ERROR_WAIT_NO_CHILDREN = 128;
        private const int ERROR_CHILD_NOT_COMPLETE = 129;
        private const int ERROR_DIRECT_ACCESS_HANDLE = 130;
        private const int ERROR_NEGATIVE_SEEK = 131;
        private const int ERROR_SEEK_ON_DEVICE = 132;
        private const int ERROR_IS_JOIN_TARGET = 133;
        private const int ERROR_IS_JOINED = 134;
        private const int ERROR_IS_SUBSTED = 135;
        private const int ERROR_NOT_JOINED = 136;
        private const int ERROR_NOT_SUBSTED = 137;
        private const int ERROR_JOIN_TO_JOIN = 138;
        private const int ERROR_SUBST_TO_SUBST = 139;
        private const int ERROR_JOIN_TO_SUBST = 140;
        private const int ERROR_SUBST_TO_JOIN = 141;
        private const int ERROR_BUSY_DRIVE = 142;
        private const int ERROR_SAME_DRIVE = 143;
        private const int ERROR_DIR_NOT_ROOT = 144;
        private const int ERROR_DIR_NOT_EMPTY = 145;
        private const int ERROR_IS_SUBST_PATH = 146;
        private const int ERROR_IS_JOIN_PATH = 147;
        private const int ERROR_PATH_BUSY = 148;
        private const int ERROR_IS_SUBST_TARGET = 149;
        private const int ERROR_SYSTEM_TRACE = 150;
        private const int ERROR_INVALID_EVENT_COUNT = 151;
        private const int ERROR_TOO_MANY_MUXWAITERS = 152;
        private const int ERROR_INVALID_LIST_FORMAT = 153;
        private const int ERROR_LABEL_TOO_LONG = 154;
        private const int ERROR_TOO_MANY_TCBS = 155;
        private const int ERROR_SIGNAL_REFUSED = 156;
        private const int ERROR_DISCARDED = 157;
        private const int ERROR_NOT_LOCKED = 158;
        private const int ERROR_BAD_THREADID_ADDR = 159;
        private const int ERROR_BAD_ARGUMENTS = 160;
        private const int ERROR_BAD_PATHNAME = 161;
        private const int ERROR_SIGNAL_PENDING = 162;
        private const int ERROR_MAX_THRDS_REACHED = 164;
        private const int ERROR_LOCK_FAILED = 167;
        private const int ERROR_BUSY = 170;
        private const int ERROR_CANCEL_VIOLATION = 173;
        private const int ERROR_ATOMIC_LOCKS_NOT_SUPPORTED = 174;
        private const int ERROR_INVALID_SEGMENT_NUMBER = 180;
        private const int ERROR_INVALID_ORDINAL = 182;
        private const int ERROR_ALREADY_EXISTS = 183;
        private const int ERROR_INVALID_FLAG_NUMBER = 186;
        private const int ERROR_SEM_NOT_FOUND = 187;
        private const int ERROR_INVALID_STARTING_CODESEG = 188;
        private const int ERROR_INVALID_STACKSEG = 189;
        private const int ERROR_INVALID_MODULETYPE = 190;
        private const int ERROR_INVALID_EXE_SIGNATURE = 191;
        private const int ERROR_EXE_MARKED_INVALID = 192;
        private const int ERROR_BAD_EXE_FORMAT = 193;
        private const int ERROR_ITERATED_DATA_EXCEEDS_64k = 194;
        private const int ERROR_INVALID_MINALLOCSIZE = 195;
        private const int ERROR_DYNLINK_FROM_INVALID_RING = 196;
        private const int ERROR_IOPL_NOT_ENABLED = 197;
        private const int ERROR_INVALID_SEGDPL = 198;
        private const int ERROR_AUTODATASEG_EXCEEDS_64k = 199;
        private const int ERROR_RING2SEG_MUST_BE_MOVABLE = 200;

        [DllImport("winscard.dll")]
        private static extern int SCardEstablishContext(uint dwScope, IntPtr pvReserved1, IntPtr pvReserved2, out int phContext);

        [DllImport("winscard.dll", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
        private static extern int SCardListReaders(int hContext, byte[] mszGroups, byte[] mszReaders, ref uint pcchReaders);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardConnect(int SCHCONTEXT, string ReaderName, uint dwShareMode, uint dwPreferredProtocols, out uint phCard, out uint pdwActiveProtocol);

        [DllImport("winscard.dll")]
        private static extern int SCardDisconnect(uint cardhandle, uint disposition);

        [DllImport("winscard.dll", SetLastError = true)]
        private static extern int SCardTransmit(uint hCard, IntPtr SendPci, byte[] SendBuffer, uint SendLength, IntPtr RecvPci, [Out] byte[] RecvBuffer, ref uint RecvLength);

        [DllImport("WINSCARD.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint SCardReleaseContext(int context);

        [DllImport("winscard")]
        private static extern uint SCardCancel(int hContext);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string filename);

        [DllImport("kernel32.dll")]
        private static extern void FreeLibrary(IntPtr handle);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr handle, string ProcName);

        private static IntPtr GetPciT0(string ProToName)
        {
            IntPtr handle = SMARTCARDHELPER.LoadLibrary("Winscard.dll");
            IntPtr procAddress = SMARTCARDHELPER.GetProcAddress(handle, ProToName);
            SMARTCARDHELPER.FreeLibrary(handle);
            return procAddress;
        }

        private static string print_winscard_error(ref string function_name, ref long the_result, ref bool silent)
        {
            string str1 = (string)null;
            string str2;
            switch (the_result)
            {
                case 109:
                    str2 = "ERROR_BROKEN_PIPE";
                    str1 = "ERROR_BROKEN_PIPE";
                    break;
                case 2148532225:
                    str2 = "SCARD_F_INTERNAL_ERROR";
                    str1 = "An internal consistency check failed.";
                    break;
                case 2148532226:
                    str2 = "SCARD_E_CANCELLED";
                    str1 = "The action was canceled by an SCardCancel request.";
                    break;
                case 2148532227:
                    str2 = "SCARD_E_INVALID_HANDLE";
                    str1 = "The supplied handle was not valid.";
                    break;
                case 2148532228:
                    str2 = "SCARD_E_INVALID_PARAMETER";
                    str1 = "One or more of the supplied parameters could not be properly interpreted.";
                    break;
                case 2148532229:
                    str2 = "SCARD_E_INVALID_TARGET";
                    str1 = "Registry startup information is missing or not valid.";
                    break;
                case 2148532230:
                    str2 = "SCARD_E_NO_MEMORY";
                    str1 = "Not enough memory available to complete this command.";
                    break;
                case 2148532231:
                    str2 = "SCARD_F_WAITED_TOO_LONG";
                    str1 = "An internal consistency timer has expired.";
                    break;
                case 2148532232:
                    str2 = "SCARD_E_INSUFFICIENT_BUFFER";
                    str1 = "The data buffer for returned data is too small for the returned data.";
                    break;
                case 2148532233:
                    str2 = "SCARD_E_UNKNOWN_READER";
                    str1 = "The specified reader name is not recognized.";
                    break;
                case 2148532234:
                    str2 = "SCARD_E_TIMEOUT";
                    str1 = "The user-specified time-out value has expired.";
                    break;
                case 2148532235:
                    str2 = "SCARD_E_SHARING_VIOLATION";
                    str1 = "The smart card cannot be accessed because of other outstanding connections.";
                    break;
                case 2148532236:
                    str2 = "SCARD_E_NO_SMARTCARD";
                    str1 = "The operation requires a smart card, but no smart card is currently in the device.";
                    break;
                case 2148532237:
                    str2 = "SCARD_E_UNKNOWN_CARD";
                    str1 = "The specified smart card name is not recognized.";
                    break;
                case 2148532238:
                    str2 = "SCARD_E_CANT_DISPOSE";
                    str1 = "The system could not dispose of the media in the requested manner.";
                    break;
                case 2148532239:
                    str2 = "SCARD_E_PROTO_MISMATCH";
                    str1 = "The requested protocols are incompatible with the protocol currently in use with the card.";
                    break;
                case 2148532240:
                    str2 = "SCARD_E_NOT_READY";
                    str1 = "The reader or card is not ready to accept commands.";
                    break;
                case 2148532241:
                    str2 = "SCARD_E_INVALID_VALUE";
                    str1 = "One or more of the supplied parameter values could not be properly interpreted.";
                    break;
                case 2148532242:
                    str2 = "SCARD_E_SYSTEM_CANCELLED";
                    str1 = "The action was canceled by the system, presumably to log off or shut down.";
                    break;
                case 2148532243:
                    str2 = "SCARD_F_COMM_ERROR";
                    str1 = "An internal communications error has been detected.\n A communication error occured with the reader.";
                    break;
                case 2148532244:
                    str2 = "SCARD_F_UNKNOWN_ERROR";
                    str1 = "An internal error has been detected, but the source is unknown.";
                    break;
                case 2148532245:
                    str2 = "SCARD_E_INVALID_ATR";
                    str1 = "An ATR string obtained from the registry is not a valid ATR string.";
                    break;
                case 2148532246:
                    str2 = "SCARD_E_NOT_TRANSACTED";
                    str1 = "An attempt was made to end a nonexistent transaction.";
                    break;
                case 2148532247:
                    str2 = "SCARD_E_READER_UNAVAILABLE";
                    str1 = "The specified reader is not currently available for use.";
                    break;
                case 2148532248:
                    str2 = "SCARD_P_SHUTDOWN";
                    str1 = "The operation has been aborted to allow the server application to exit.";
                    break;
                case 2148532249:
                    str2 = "SCARD_E_PCI_TOO_SMALL";
                    str1 = "The PCI receive buffer was too small.";
                    break;
                case 2148532250:
                    str2 = "SCARD_E_READER_UNSUPPORTED";
                    str1 = "The reader driver does not meet minimal requirements for support.";
                    break;
                case 2148532251:
                    str2 = "SCARD_E_DUPLICATE_READER";
                    str1 = "The reader driver did not produce a unique reader name.";
                    break;
                case 2148532252:
                    str2 = "SCARD_E_CARD_UNSUPPORTED";
                    str1 = "The smart card does not meet minimal requirements for support.";
                    break;
                case 2148532253:
                    str2 = "SCARD_E_NO_SERVICE";
                    str1 = "The smart card resource manager is not running.";
                    break;
                case 2148532254:
                    str2 = "SCARD_E_SERVICE_STOPPED";
                    str1 = "The smart card resource manager has shut down.";
                    break;
                case 2148532255:
                    str2 = "SCARD_E_UNEXPECTED";
                    str1 = "An unexpected card error has occurred.";
                    break;
                case 2148532256:
                    str2 = "SCARD_E_ICC_INSTALLATION";
                    str1 = "No primary provider can be found for the smart card.";
                    break;
                case 2148532257:
                    str2 = "SCARD_E_ICC_CREATEORDER";
                    str1 = "The requested order of object creation is not supported.";
                    break;
                case 2148532258:
                    str2 = "SCARD_E_UNSUPPORTED_FEATURE";
                    str1 = "This smart card does not support the requested feature.";
                    break;
                case 2148532259:
                    str2 = "SCARD_E_DIR_NOT_FOUND";
                    str1 = "The specified directory does not exist in the smart card.";
                    break;
                case 2148532260:
                    str2 = "SCARD_E_FILE_NOT_FOUND";
                    str1 = "The specified file does not exist in the smart card.";
                    break;
                case 2148532261:
                    str2 = "SCARD_E_NO_DIR";
                    str1 = "The supplied path does not represent a smart card directory.";
                    break;
                case 2148532262:
                    str2 = "SCARD_E_NO_FILE";
                    str1 = "The supplied path does not represent a smart card file.";
                    break;
                case 2148532263:
                    str2 = "SCARD_E_NO_ACCESS";
                    str1 = "Access is denied to the file.";
                    break;
                case 2148532264:
                    str2 = "SCARD_E_WRITE_TOO_MANY";
                    str1 = "An attempt was made to write more data than would fit in the target object.";
                    break;
                case 2148532265:
                    str2 = "SCARD_E_BAD_SEEK";
                    str1 = "An error occurred in setting the smart card file object pointer.";
                    break;
                case 2148532266:
                    str2 = "SCARD_E_INVALID_CHV";
                    str1 = "The supplied PIN is incorrect.";
                    break;
                case 2148532267:
                    str2 = "SCARD_E_UNKNOWN_RES_MNG";
                    str1 = "An unrecognized error code was returned from a layered component.";
                    break;
                case 2148532268:
                    str2 = "SCARD_E_NO_SUCH_CERTIFICATE";
                    str1 = "The requested certificate does not exist.";
                    break;
                case 2148532269:
                    str2 = "SCARD_E_CERTIFICATE_UNAVAILABLE";
                    str1 = "The requested certificate could not be obtained.";
                    break;
                case 2148532270:
                    str2 = "SCARD_E_NO_READERS_AVAILABLE";
                    str1 = "No smart card reader is available.";
                    break;
                case 2148532271:
                    str2 = "SCARD_E_COMM_DATA_LOST";
                    str1 = "A communications error with the smart card has been detected.";
                    break;
                case 2148532272:
                    str2 = "SCARD_E_NO_KEY_CONTAINER";
                    str1 = "SCARD_E_NO_KEY_CONTAINER";
                    break;
                case 2148532273:
                    str2 = "SCARD_E_SERVER_TOO_BUSY";
                    str1 = "SCARD_E_SERVER_TOO_BUSY";
                    break;
                case 2148532325:
                    str2 = "SCARD_W_UNSUPPORTED_CARD";
                    str1 = "The reader cannot communicate with the card, due to ATR string configuration conflicts.";
                    break;
                case 2148532326:
                    str2 = "SCARD_W_UNRESPONSIVE_CARD";
                    str1 = "The smart card is not responding to a reset.";
                    break;
                case 2148532327:
                    str2 = "SCARD_W_UNPOWERED_CARD";
                    str1 = "Power has been removed from the smart card, so that further communication is not possible.";
                    break;
                case 2148532328:
                    str2 = "SCARD_W_RESET_CARD";
                    str1 = "The smart card has been reset, so any shared state information is not valid.";
                    break;
                case 2148532329:
                    str2 = "SCARD_W_REMOVED_CARD";
                    str1 = "The smart card has been removed, so further communication is not possible.";
                    break;
                case 2148532330:
                    str2 = "SCARD_W_SECURITY_VIOLATION";
                    str1 = "Access was denied because of a security violation.";
                    break;
                case 2148532331:
                    str2 = "SCARD_W_WRONG_CHV";
                    str1 = "The card cannot be accessed because the wrong PIN was presented.";
                    break;
                case 2148532332:
                    str2 = "SCARD_W_CHV_BLOCKED";
                    str1 = "The card cannot be accessed because the maximum number of PIN entry attempts has been reached.";
                    break;
                case 2148532333:
                    str2 = "SCARD_W_EOF";
                    str1 = "The end of the smart card file has been reached.";
                    break;
                case 2148532334:
                    str2 = "SCARD_W_CANCELLED_BY_USER";
                    str1 = "The action was canceled by the user.";
                    break;
                case 2148532335:
                    str2 = "SCARD_W_CARD_NOT_AUTHENTICATED";
                    str1 = "SCARD_W_CARD_NOT_AUTHENTICATED";
                    break;
                case 2148532336:
                    str2 = "SCARD_W_CACHE_ITEM_NOT_FOUND";
                    str1 = "SCARD_W_CACHE_ITEM_NOT_FOUND";
                    break;
                case 2148532337:
                    str2 = "SCARD_W_CACHE_ITEM_STALE";
                    str1 = "SCARD_W_CACHE_ITEM_STALE";
                    break;
                case 2148532338:
                    str2 = "SCARD_W_CACHE_ITEM_TOO_BIG";
                    str1 = "SCARD_W_CACHE_ITEM_TOO_BIG";
                    break;
                case 50:
                    str2 = "ERROR_NOT_SUPPORTED";
                    str1 = "Attribute value not supported.";
                    break;
                case 87:
                    str2 = "ERROR_INVALID_PARAMETER";
                    str1 = "The parameter is incorrect.";
                    break;
                case 0:
                    str2 = "SCARD_S_SUCCESS";
                    str1 = "No error was encountered.";
                    break;
                case 22:
                    str2 = "STATUS_INVALID_DEVICE_STATE";
                    str1 = "The reader is not in the correct state to select a protocol. That is, a smart card is inserted, but not reset.";
                    break;
                case 31:
                    str2 = "ERROR_GEN_FAILURE";
                    str1 = "A device attached to the system is not functioning.";
                    break;
                default:
                    str2 = "UNKNOWN_ERROR";
                    str1 = "Error Code (DEC): " + (object)the_result;
                    break;
            }
            string str3;
            if (!silent)
                str3 = "The function " + function_name + "() returned an error... \n\nError Code: \n" + str2 + "\n\nError Description:\n\n";
            else
                str3 = str2;
            return str3;
        }

        private void Load_ReaderName_In_LIST(ref List<string> READERNAME, byte[] ReaderList)
        {
            string str = (string)null;
            int index = 0;
            READERNAME.Clear();
            while ((int)ReaderList[index] != 0)
            {
                for (; (int)ReaderList[index] != 0; ++index)
                    str +=Convert.ToString( (object)Convert.ToChar(ReaderList[index]));
                ++index;
                READERNAME.Add(str);
                str = "";
            }
        }

        private bool GetFileLength(string OUTPUTDATA, ref int TagLength, ref int Record)
        {
            int length = OUTPUTDATA.Length;
            int startIndex1 = 4;
            string str1 = string.Empty;
            while (startIndex1 < length)
            {
                string str2 = OUTPUTDATA.Substring(startIndex1, 2);
                int startIndex2 = startIndex1 + 2;
                if (str2 == "80")
                {
                    TagLength = 0;
                    int startIndex3 = startIndex2 + 2;
                    this.HEX2DEC(OUTPUTDATA.Substring(startIndex3, 4), ref TagLength);
                    Record = 0;
                    return true;
                }
                if (str2 == "82")
                {
                    TagLength = 0;
                    if (OUTPUTDATA.Substring(startIndex2, 2) == "05")
                    {
                        int startIndex3 = startIndex2 + 6;
                        this.HEX2DEC(OUTPUTDATA.Substring(startIndex3, 4), ref TagLength);
                        int startIndex4 = startIndex3 + 4;
                        this.HEX2DEC(OUTPUTDATA.Substring(startIndex4, 2), ref Record);
                        return true;
                    }
                    TagLength = 0;
                    this.HEX2DEC(OUTPUTDATA.Substring(startIndex2, 2), ref TagLength);
                    startIndex1 = startIndex2 + (TagLength * 2 + 2);
                }
                else
                {
                    TagLength = 0;
                    this.HEX2DEC(OUTPUTDATA.Substring(startIndex2, 2), ref TagLength);
                    startIndex1 = startIndex2 + (TagLength * 2 + 2);
                }
            }
            return false;
        }

        public bool Get_Reader_List(ref List<string> READERLIST, ref int SCHCONTEXT, ref string MSGSTATUS)
        {
            uint pcchReaders = 1024;
            byte[] numArray = new byte[1024];
            int num1 = SMARTCARDHELPER.SCardEstablishContext(2U, IntPtr.Zero, IntPtr.Zero, out SCHCONTEXT);
            if (num1 == 0)
            {
                int num2 = SMARTCARDHELPER.SCardListReaders(SCHCONTEXT, (byte[])null, numArray, ref pcchReaders);
                if (num2 == 0)
                {
                    this.Load_ReaderName_In_LIST(ref READERLIST, numArray);
                    MSGSTATUS = "SUCESS";
                    return true;
                }
                long the_result = (long)num2;
                bool silent = false;
                string function_name = "SCardListReader";
                MSGSTATUS = SMARTCARDHELPER.print_winscard_error(ref function_name, ref the_result, ref silent);
                return false;
            }
            long the_result1 = (long)num1;
            bool silent1 = false;
            string function_name1 = "SCardEstablishContext";
            MSGSTATUS = SMARTCARDHELPER.print_winscard_error(ref function_name1, ref the_result1, ref silent1);
            return false;
        }

        public bool Connect_Selected_Reader(int SCHCONTEXT, string READERNAME, ref uint READERHANDEL, ref uint READERACTIVEPROTOCAL, ref string MSGSTATUS)
        {
            int ReturnConnectValue=SMARTCARDHELPER.SCardConnect(SCHCONTEXT, READERNAME, 2U, 3U, out READERHANDEL, out READERACTIVEPROTOCAL);
            if (ReturnConnectValue == 0)
            {
                MSGSTATUS = "0:SUCESS";
                return true;
            }
            else
            {

                MSGSTATUS = ErrorNumber(ReturnConnectValue); //"Smart Card Connection Error ... ";
                return false;
            }
        }

        public string ErrorNumber(int errorNumber)
        {
            string ErrorValue = Convert.ToString(errorNumber);
            string ReturnError = string.Empty;
            switch (ErrorValue)
            {
                case "-2146434967":
                    ReturnError = "No Card Found "+ ErrorValue;
                    break;
                case "-2146434970":
                    ReturnError = "Card Found but Card Not set" + ErrorValue;
                    break;

            }
            return ReturnError;
           

        }

        public bool Disconnect_Selected_Reader(uint READERHANDEL, ref string MSGSTATUS)
        {
            uint disposition = 0;
            if (SMARTCARDHELPER.SCardDisconnect(READERHANDEL, disposition) == 0)
            {
                MSGSTATUS = "0:SUCESS";
                return true;
            }
            MSGSTATUS = "Reader Disconnect Error...";
            return false;
        }

        public bool GetCardResponse(uint READERHANDEL, uint ACTIVPROTO, int Len, ref string OUTPUTRESULT)
        {
            byte[] numArray = new byte[(int)byte.MaxValue];
            IntPtr SendPci = IntPtr.Zero;
            if ((int)ACTIVPROTO == 1)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT0Pci");
            else if ((int)ACTIVPROTO == 2)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT1Pci");
            string str = string.Empty;
            byte[] SendBuffer = new byte[5]
      {
        (byte) 0,
        (byte) 192,
        (byte) 0,
        (byte) 0,
        (byte) Len
      };
            uint RecvLength = (uint)byte.MaxValue;
            if (SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, SendBuffer, (uint)SendBuffer.Length, IntPtr.Zero, numArray, ref RecvLength) != 0)
                return false;
            this.ByteToHex(numArray, (int)RecvLength, ref OUTPUTRESULT);
            return true;
        }

        public bool ReadChipSrnoWithExecuteCommand(uint READERHANDEL, uint ACTIVPROTO, ref string CMDRESULT)
        {
            byte[] OutputByte = (byte[])null;
            byte[] numArray = new byte[(int)byte.MaxValue];
            uint RecvLength = (uint)byte.MaxValue;
            int num = -1;
            string str1 = string.Empty;
            IntPtr SendPci = IntPtr.Zero;
            string InputStr = "00CA024600";
            if ((int)ACTIVPROTO == 1)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT0Pci");
            else if ((int)ACTIVPROTO == 2)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT1Pci");
            if (!this.HexToByte(InputStr, ref OutputByte))
                return false;
            if (SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength) == 0)
            {
                this.ByteToHex(numArray, (int)RecvLength, ref CMDRESULT);
                string str2 = CMDRESULT.Substring(0, 2).ToString();
                if ((int)ACTIVPROTO == 2 && (int)OutputByte[1] == 164 && (int)OutputByte[3] == 4 && CMDRESULT == "9000")
                {
                    CMDRESULT = string.Empty;
                    return this.GetCardResponse(READERHANDEL, ACTIVPROTO, (int)byte.MaxValue, ref CMDRESULT);
                }
                if (str2 == "61")
                {
                    OutputByte = (byte[])null;
                    this.HexToByte("00C00000" + CMDRESULT.Substring(2, 2).ToString(), ref OutputByte);
                    RecvLength = 500U;
                    num = SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength);
                    this.ByteToHex(numArray, (int)RecvLength - 2, ref CMDRESULT);
                    return true;
                }
                if (str2 == "6C")
                {
                    this.HexToByte("00CA0246" + CMDRESULT.Substring(2, 2).ToString(), ref OutputByte);
                    RecvLength = 500U;
                    num = SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength);
                    this.ByteToHex(numArray, (int)RecvLength - 2, ref CMDRESULT);
                    return true;
                }
                if (CMDRESULT == "9000")
                    return true;
                if ((int)RecvLength == 2 || !(CMDRESULT.Substring(CMDRESULT.Length - 4, 4) == "9000"))
                    return false;
                CMDRESULT = CMDRESULT.Substring(0, CMDRESULT.Length - 4);
                return true;
            }
            CMDRESULT = "Please Check Your Command ...";
            return false;
        }

        public bool ExecuteCommand(uint READERHANDEL, uint ACTIVPROTO, string Command, ref string CMDRESULT)
        {
            byte[] OutputByte = (byte[])null;
            byte[] numArray = new byte[(int)byte.MaxValue];
            uint RecvLength = (uint)byte.MaxValue;
            int num = -1;
            string str1 = string.Empty;
            IntPtr SendPci = IntPtr.Zero;
            if ((int)ACTIVPROTO == 1)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT0Pci");
            else if ((int)ACTIVPROTO == 2)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT1Pci");
            if (!this.HexToByte(Command, ref OutputByte))
                return false;
            if (SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength) == 0)
            {
                this.ByteToHex(numArray, (int)RecvLength, ref CMDRESULT);
                string str2 = CMDRESULT.Substring(0, 2).ToString();
                if ((int)ACTIVPROTO == 2 && (int)OutputByte[1] == 164 && (int)OutputByte[3] == 4 && CMDRESULT == "9000")
                {
                    CMDRESULT = string.Empty;
                    return this.GetCardResponse(READERHANDEL, ACTIVPROTO, (int)byte.MaxValue, ref CMDRESULT);
                }
                if (str2 == "61")
                {
                    OutputByte = (byte[])null;
                    Command = "00C00000" + CMDRESULT.Substring(2, 2).ToString();
                    this.HexToByte(Command, ref OutputByte);
                    RecvLength = 500U;
                    num = SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength);
                    this.ByteToHex(numArray, (int)RecvLength - 2, ref CMDRESULT);
                    return true;
                }
                if (str2 == "6C")
                {
                    Command = Command.Substring(0, Command.Length - 2) + CMDRESULT.Substring(2, 2).ToString();
                    this.HexToByte(Command, ref OutputByte);
                    RecvLength = 500U;
                    num = SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte, (uint)OutputByte.Length, IntPtr.Zero, numArray, ref RecvLength);
                    this.ByteToHex(numArray, (int)RecvLength - 2, ref CMDRESULT);
                    return true;
                }
                if (CMDRESULT == "9000")
                    return true;
                if ((int)RecvLength == 2 || !(CMDRESULT.Substring(CMDRESULT.Length - 4, 4) == "9000"))
                    return false;
                CMDRESULT = CMDRESULT.Substring(0, CMDRESULT.Length - 4);
                return true;
            }
            CMDRESULT = "Please Check Your Command ...";
            return false;
        }

        public bool ExecuteCommand(uint READERHANDEL, uint ACTIVPROTO, string Command, ref byte[] CMDRESULT)
        {
            byte[] OutputByte1 = (byte[])null;
            byte[] RecvBuffer = new byte[500];
            int num = -1;
            string str1 = string.Empty;
            IntPtr SendPci = IntPtr.Zero;
            if ((int)ACTIVPROTO == 1)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT0Pci");
            else if ((int)ACTIVPROTO == 2)
                SendPci = SMARTCARDHELPER.GetPciT0("g_rgSCardT1Pci");
            string str2 = string.Empty;
            uint RecvLength = 500;
            if (this.HexToByte(Command, ref OutputByte1))
            {
                if (SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte1, (uint)OutputByte1.Length, IntPtr.Zero, RecvBuffer, ref RecvLength) == 0)
                {
                    string str3 = RecvBuffer[(int)(RecvLength - 2U)].ToString("X").ToString().PadLeft(2, '0') + RecvBuffer[(int)(RecvLength - 1U)].ToString("X").ToString().PadLeft(2, '0');
                    if (str3.Substring(0, 2).ToString() == "61")
                    {
                        byte[] OutputByte2 = (byte[])null;
                        Command = "00C00000" + str3.Substring(2, 2).ToString();
                        this.HexToByte(Command, ref OutputByte2);
                        RecvLength = 500U;
                        num = SMARTCARDHELPER.SCardTransmit(READERHANDEL, SendPci, OutputByte2, (uint)OutputByte2.Length, IntPtr.Zero, RecvBuffer, ref RecvLength);
                        CMDRESULT = new byte[(int)(RecvLength - 2U)];
                        Array.Copy((Array)RecvBuffer, (Array)CMDRESULT, (long)(RecvLength - 2U));
                        return true;
                    }
                    if (str3 == "9000")
                    {
                        CMDRESULT = new byte[(int)RecvLength];
                        Array.Copy((Array)RecvBuffer, (Array)CMDRESULT, (long)RecvLength);
                        return true;
                    }
                    CMDRESULT = new byte[(int)RecvLength];
                    Array.Copy((Array)RecvBuffer, (Array)CMDRESULT, (long)RecvLength);
                    return false;
                }
                CMDRESULT = (byte[])null;
                return false;
            }
            CMDRESULT = (byte[])null;
            return false;
        }

        public bool SelectNgetFileLength(uint READERHANDEL, uint ACTIVPROTO, string FileName, ref int Length, ref int Record)
        {
            try
            {
                string Command = "00A4000402" + FileName;
                string CMDRESULT = string.Empty;
                return this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command, ref CMDRESULT) && this.GetFileLength(CMDRESULT, ref Length, ref Record);
            }
            catch
            {
                return false;
            }
        }

        public bool SelectNgetFileLength(uint READERHANDEL, uint ACTIVPROTO, string FileName)
        {
            try
            {
                string Command = "00A4000402" + FileName;
                string CMDRESULT = string.Empty;
                return this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command, ref CMDRESULT);
            }
            catch
            {
                return false;
            }
        }

        public bool ReadChipSrno(uint READERHANDEL, uint ACTIVPROTO, ref string ChipSrno)
        {
            try
            {
                string Command1 = "00CA024600";
                ChipSrno = string.Empty;
                if (this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command1, ref ChipSrno))
                    return true;
                if (!(ChipSrno.Substring(0, 2) == "6C") && !(ChipSrno.Substring(0, 2) == "0A"))
                    return false;
                string Command2 = "00CA0246" + ChipSrno.Substring(2, 2);
                if (this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command2, ref ChipSrno))
                    return false;
                ChipSrno = ChipSrno.Substring(0, ChipSrno.Length - 4);
                return true;
            }
            catch (Exception ex)
            {
                ChipSrno = ex.Message;
                return false;
            }
        }

        public string ReadBinaryFile(uint READERHANDEL, uint ACTIVPROTO, int ReadLength, ref byte[] OUTPUTDATA)
        {
            try
            {
                int destinationIndex = 0;
                byte[] numArray = new byte[(int)byte.MaxValue];
                string str = string.Empty;
                OUTPUTDATA = new byte[ReadLength + 1];
                if (ReadLength < (int)byte.MaxValue)
                {
                    string Command = "00B00000" + ReadLength.ToString("X").PadLeft(2, '0');
                    return this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command, ref OUTPUTDATA) ? "SUCESS" : "FAIL";
                }
                int num = ReadLength / 254;
                for (int index = 0; index < num; ++index)
                {
                    byte[] CMDRESULT = new byte[254];
                    string Command = "00B0" + destinationIndex.ToString("X").PadLeft(4, '0') + "FE";
                    if (!this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command, ref CMDRESULT))
                        return "FAIL";
                    Array.Copy((Array)CMDRESULT, 0, (Array)OUTPUTDATA, destinationIndex, 254);
                    destinationIndex += 254;
                }
                if (ReadLength % 254 == 0)
                    return "SUCESS";
                byte[] CMDRESULT1 = new byte[254];
                string Command1 = "00B0" + destinationIndex.ToString("X").PadLeft(4, '0') + (ReadLength % 254).ToString("X").PadLeft(2, '0');
                if (!this.ExecuteCommand(READERHANDEL, ACTIVPROTO, Command1, ref CMDRESULT1))
                    return "FAIL";
                Array.Copy((Array)CMDRESULT1, 0, (Array)OUTPUTDATA, destinationIndex, ReadLength % 254);
                return "SUCESS";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool CHECKMICFILE(uint HANDLE, uint PROTOCAL, ref bool ISMICCARD)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            ISMICCARD = false;
            string Command1 = "00A40000023F00";
            if (!this.ExecuteCommand(HANDLE, PROTOCAL, Command1, ref str2) || str2 != "9000")
                return false;
            string Command2 = "00A4000002B100";
            if (!this.ExecuteCommand(HANDLE, PROTOCAL, Command2, ref str2) || str2 != "9000")
                return false;
            string Command3 = "00A4000002B105";
            if (!this.ExecuteCommand(HANDLE, PROTOCAL, Command3, ref str2) || str2 != "9000")
                return false;
            this.Disconnect_Selected_Reader(HANDLE, ref str2);
            ISMICCARD = true;
            return true;
        }

        public bool GETMICCARDREADER(ref string ReaderName, ref string ERRMSG)
        {
            try
            {
                List<string> READERLIST = new List<string>();
                int SCHCONTEXT = 0;
                int index = 0;
                uint READERHANDEL = 0;
                uint READERACTIVEPROTOCAL = 0;
                bool ISMICCARD = false;
                if (!this.Get_Reader_List(ref READERLIST, ref SCHCONTEXT, ref ERRMSG))
                    return false;
                for (; index < READERLIST.Count; ++index)
                {
                    if (this.Connect_Selected_Reader(SCHCONTEXT, READERLIST[index], ref READERHANDEL, ref READERACTIVEPROTOCAL, ref ERRMSG) && this.CHECKMICFILE(READERHANDEL, READERACTIVEPROTOCAL, ref ISMICCARD))
                    {
                        if (ISMICCARD)
                            ReaderName = READERLIST[index];
                        int num1 = (int)SMARTCARDHELPER.SCardCancel(SCHCONTEXT);
                        int num2 = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                        return true;
                    }
                }
                ERRMSG = "MIC READER NOT FOUND.. ";
                return false;
            }
            catch (Exception ex)
            {
                ERRMSG = ex.Message;
                return false;
            }
        }

        public bool CheckBenFile(uint HANDEL, uint PROTO, ref string URMSG)
        {
            try
            {
                string str = string.Empty;
                string Command1 = "00A40000023F00";
                if (!this.ExecuteCommand(HANDEL, PROTO, Command1, ref str))
                {
                    URMSG = str;
                    return false;
                }
                if (str != "9000")
                {
                    URMSG = "UNABLE TO SELECT MASTER FILE ... \r\nERROR NO : " + str;
                    return false;
                }
                string Command2 = "00A4020002E100";
                if (!this.ExecuteCommand(HANDEL, PROTO, Command2, ref str))
                    return false;
                string Command3 = "00A4020002E104";
                if (!this.ExecuteCommand(HANDEL, PROTO, Command3, ref str))
                    return false;
                string Command4 = "00B0000013";
                str = string.Empty;
                if (!this.ExecuteCommand(HANDEL, PROTO, Command4, ref str))
                {
                    URMSG = str;
                    return false;
                }
                URMSG = str.Substring(4, 34);
                str = string.Empty;
                this.ConvertHextStringToString(URMSG, ref str);
                URMSG = str;
                return true;
            }
            catch (Exception ex)
            {
                URMSG = ex.Message;
                return false;
            }
        }

        public bool READURN(ref string URNNO)
        {
            try
            {
                uint READERHANDEL = 0;
                uint READERACTIVEPROTOCAL = 0;
                List<string> READERLIST = new List<string>();
                int SCHCONTEXT = 0;
                string str1 = string.Empty;
                if (!this.Get_Reader_List(ref READERLIST, ref SCHCONTEXT, ref str1))
                {
                    URNNO = str1;
                    return false;
                }
                string str2 = string.Empty;
                for (int index = 0; index < READERLIST.Count; ++index)
                {
                    string READERNAME = READERLIST[index];
                    if (!this.Connect_Selected_Reader(SCHCONTEXT, READERNAME, ref READERHANDEL, ref READERACTIVEPROTOCAL, ref str1))
                    {
                        URNNO = str1;
                        int num = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                        return false;
                    }
                    if (!this.CheckBenFile(READERHANDEL, READERACTIVEPROTOCAL, ref str1))
                    {
                        this.Disconnect_Selected_Reader(READERHANDEL, ref str1);
                    }
                    else
                    {
                        URNNO = str1;
                        this.Disconnect_Selected_Reader(READERHANDEL, ref str1);
                        int num = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                        return true;
                    }
                }
                int num1 = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                return false;
            }
            catch (Exception ex)
            {
                URNNO = ex.Message;
                return false;
            }
        }

        public bool HexStrtoDecimalStr(string Input, ref string Output)
        {
            if (Input.Length % 2 != 0)
            {
                Output = "String Should be multiple of 2";
                return false;
            }
            int startIndex = 0;
            string str = string.Empty;
            Output = string.Empty;
            while (startIndex < Input.Length)
            {
                int num = 0;
                this.HEX2DEC(Input.Substring(startIndex, 2), ref num);
                Output += num.ToString().PadLeft(2, '0');
                startIndex += 2;
            }
            return true;
        }

        public bool DecimalStrHexStr(string Input, ref string Output)
        {
            if (Input.Length % 2 != 0)
            {
                Output = "String Should be multiple of 2";
                return false;
            }
            int startIndex = 0;
           
            string str = string.Empty;
            Output = string.Empty;
            while (startIndex < Input.Length)
            {
               
                int num2 = Convert.ToInt32(Input.Substring(startIndex, 2));
                Output += num2.ToString("X").PadLeft(2, '0');
                startIndex += 2;
            }
            return true;
        }

        public bool CheckBeneficiaryReader(ref string URNNO, ref uint READERHANDEL, ref uint ACTIVPROTO)
        {
            try
            {
                READERHANDEL = 0U;
                ACTIVPROTO = 0U;
                List<string> READERLIST = new List<string>();
                int SCHCONTEXT = 0;
                string str1 = string.Empty;
                if (!this.Get_Reader_List(ref READERLIST, ref SCHCONTEXT, ref str1))
                {
                    URNNO = str1;
                    return false;
                }
                string str2 = string.Empty;
                for (int index = 0; index < READERLIST.Count; ++index)
                {
                    string READERNAME = READERLIST[index];
                    if (!this.Connect_Selected_Reader(SCHCONTEXT, READERNAME, ref READERHANDEL, ref ACTIVPROTO, ref str1))
                    {
                        URNNO = str1;
                        int num = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                        return false;
                    }
                    if (!this.CheckBenFile(READERHANDEL, ACTIVPROTO, ref str1))
                    {
                        this.Disconnect_Selected_Reader(READERHANDEL, ref str1);
                    }
                    else
                    {
                        URNNO = str1;
                        return true;
                    }
                }
                int num1 = (int)SMARTCARDHELPER.SCardReleaseContext(SCHCONTEXT);
                return false;
            }
            catch (Exception ex)
            {
                URNNO = ex.Message;
                return false;
            }
        }

        public bool HexToByte(string InputStr, ref byte[] OutputByte)
        {
            int startIndex = 0;
            int index = 0;
            OutputByte = new byte[InputStr.Length / 2];
            while (startIndex < InputStr.Length - 1)
            {
                OutputByte[index] = (byte)int.Parse(InputStr.Substring(startIndex, 2), NumberStyles.HexNumber);
                ++index;
                startIndex += 2;
            }
            return true;
        }

        public bool ByteToHex(byte[] InputBuffer, int DataLength, ref string HEXSTRING)
        {
            int index = 0;
            HEXSTRING = string.Empty;
            for (; index < DataLength; ++index)
                HEXSTRING += InputBuffer[index].ToString("X").ToString().PadLeft(2, '0');
            return true;
        }

        public bool ByteToHex(byte[] InputBuffer, ref string HEXSTRING)
        {
            int index = 0;
            HEXSTRING = string.Empty;
            for (int length = InputBuffer.Length; index < length; ++index)
                HEXSTRING += InputBuffer[index].ToString("X").ToString().PadLeft(2, '0');
            return true;
        }

        public bool HEX2DEC(string HexStr, ref int VALUE)
        {
            try
            {
                int index = 0;
                int length = HexStr.Length;
                VALUE = 0;
                HexStr = HexStr.ToUpper();
                for (; index < length; ++index)
                {
                    int num1;
                    if ((int)HexStr[index] > 64 && (int)HexStr[index] < 71)
                    {
                        num1 = Convert.ToInt32((int)HexStr[index] - 55);
                    }
                    else
                    {
                        if ((int)HexStr[index] <= 47 || (int)HexStr[index] >= 58)
                            return false;
                        num1 = Convert.ToInt32((int)HexStr[index] - 48);
                    }
                    int num2 = num1 * Convert.ToInt32(Math.Pow(16.0, (double)(length - (index + 1))));
                    VALUE += num2;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ConvertHextStringToString(string Input, ref string Output)
        {
            try
            {
                int startIndex = 0;
                int length = Input.Length;
                Output = string.Empty;
                if (Input.Length % 2 != 0)
                {
                    Output = "Input String not in proper Hex String format...";
                    return false;
                }
                while (startIndex < length)
                {
                    Output += (string)(object)Convert.ToChar(Convert.ToInt32(Input.Substring(startIndex, 2), 16));
                    startIndex += 2;
                }
                return true;
            }
            catch (Exception ex)
            {
                Output = ex.Message;
                return false;
            }
        }

        public string ConvertStringToHexString(string Input)
        {
            try
            {
                int index = 0;
                int length = Input.Length;
                string str = string.Empty;
                for (; index < length; ++index)
                    str += Convert.ToInt32(Input[index]).ToString("X");
                return str;
            }
            catch
            {
                return "";
            }
        }

        public bool WriteOnCurrentSelectedFile(uint ScHandle, uint ScProto, string HexInputData, string StartIndex, ref string ErrMsg)
    {
      try
      {
        int num1 = 0;
        string str1 = string.Empty;
        string CMDRESULT = string.Empty;
        int startIndex = 0;
        int num2 = 0;
        if (HexInputData.Length % 2 != 0)
        {
          ErrMsg = "Hex Input Data not in proper format";
          return false;
        }
        int num3 = HexInputData.Length / 2 / 250;
        str1 = string.Empty;
        int num4;
        for (; num1 < num3; ++num1)
        {
          string Command = "00D6" + StartIndex + "FA" + HexInputData.Substring(startIndex, 500).ToString();
          if (!this.ExecuteCommand(ScHandle, ScProto, Command, ref CMDRESULT))
          {
            // ISSUE: explicit reference operation
            // ISSUE: variable of a reference type
            string local = @ErrMsg;
            string str2 = "Smart card writing error , Segment ";
            num4 = num1 + 1;
            string str3 = num4.ToString().PadLeft(2, '0');
            string str4 = str2 + str3;
            // ISSUE: explicit reference operation
            local = str4;
            return false;
          }
          if (CMDRESULT != "9000")
          {
            // ISSUE: explicit reference operation
            // ISSUE: variable of a reference type
            string local = @ErrMsg;
            string str2 = "Smart card writing error , Segment ";
            num4 = num1 + 1;
            string str3 = num4.ToString().PadLeft(2, '0');
            string str4 = str2 + str3;
            // ISSUE: explicit reference operation
            local = str4;
            return false;
          }
          this.HEX2DEC(StartIndex, ref num2);
          num4 = num2 + 250;
          StartIndex = num4.ToString("X").PadLeft(4, '0');
          startIndex += 500;
        }
        int num5 = HexInputData.Length / 2 % 250;
        if (num5 == 0)
        {
          ErrMsg = "File Write Sucessfully";
          return true;
        }
        string Command1 = "00D6" + StartIndex + num5.ToString("X").PadLeft(2, '0') + HexInputData.Substring(startIndex, num5 * 2).ToString();
        if (this.ExecuteCommand(ScHandle, ScProto, Command1, ref CMDRESULT) || !(CMDRESULT == "9000"))
          return true;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        string local1 = @ErrMsg;
        string str5 = "Smart card writing error , Segment ";
        num4 = num1 + 1;
        string str6 = num4.ToString().PadLeft(2, '0');
        string str7 = str5 + str6;
        // ISSUE: explicit reference operation
        local1 = str7;
        return false;
      }
      catch (Exception ex)
      {
        ErrMsg = ex.Message;
        return false;
      }
    }

        public bool WriteBlank_RecordFile(uint readerHandle, uint readerProto, string strFileName, ref string strErrorMsg)
        {
            try
            {
                int Length = 0;
                int Record = 0;
                string str1 = string.Empty;
                if (!this.SelectNgetFileLength(readerHandle, readerProto, strFileName, ref Length, ref Record))
                {
                    strErrorMsg = "Master File Selection Error...";
                    return false;
                }
                int num = 1;
                for (; num <= Record; ++num)
                {
                    string str2 = "0".PadLeft(Length * 2, '0');
                    string Command = "00D2" + num.ToString("X").PadLeft(2, '0') + "04" + Length.ToString("X").PadLeft(2, '0') + str2;
                    string CMDRESULT = string.Empty;
                    if (!this.ExecuteCommand(readerHandle, readerProto, Command, ref CMDRESULT))
                    {
                        strErrorMsg = "Write Blank in File " + strFileName + "\n" + CMDRESULT;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrorMsg = "Exception in Blank data " + strFileName + " \n" + ex.Message;
                return false;
            }
        }

        public bool UpdateBlank_RecordFile(uint readerHandle, uint readerProto, string strFileName, ref string strErrorMsg)
        {
            try
            {
                int Length = 0;
                int Record = 0;
                string str1 = string.Empty;
                if (!this.SelectNgetFileLength(readerHandle, readerProto, strFileName, ref Length, ref Record))
                {
                    strErrorMsg = "Master File Selection Error...";
                    return false;
                }
                int num = 1;
                string CMDRESULT = "0";
                for (; num <= Record; ++num)
                {
                    string str2 = CMDRESULT.PadLeft(Length * 2, '0');
                    string Command = "00DC" + num.ToString("X").PadLeft(2, '0') + "04" + Length.ToString("X").PadLeft(2, '0') + str2;
                    CMDRESULT = string.Empty;
                    if (!this.ExecuteCommand(readerHandle, readerProto, Command, ref CMDRESULT))
                    {
                        strErrorMsg = "Update Blank in File " + strFileName + "\n" + CMDRESULT;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrorMsg = "Exception in Blank data " + strFileName + " \n" + ex.Message;
                return false;
            }
        }

        public bool WriteBlank_BinaryFile(uint readerHandle, uint readerProto, string strFileName, ref string strErrorMsg)
        {
            try
            {
                string str1 = string.Empty;
                string str2 = string.Empty;
                int Length = 0;
                int Record = 0;
                string str3 = string.Empty;
                if (!this.SelectNgetFileLength(readerHandle, readerProto, strFileName, ref Length, ref Record))
                {
                    strErrorMsg = "File Selection Error...";
                    return false;
                }
                string HexInputData = "0".PadLeft(Length * 2, '0');
                if (this.WriteOnCurrentSelectedFile(readerHandle, readerProto, HexInputData, "0000", ref strErrorMsg))
                    return true;
                strErrorMsg = "Write Blank in File " + strFileName + "\n" + strErrorMsg;
                return false;
            }
            catch (Exception ex)
            {
                strErrorMsg = "Exception in Blank data " + strFileName + " \n" + ex.Message;
                return false;
            }
        }

        public bool updateOnCurrentSelectedFile(uint ScHandle, uint ScProto, string HexInputData, string StartIndex, ref string ErrMsg)
    {
      try
      {
        int num1 = 0;
        string str1 = string.Empty;
        string CMDRESULT = string.Empty;
        int startIndex = 0;
        int num2 = 0;
        if (HexInputData.Length % 2 != 0)
        {
          ErrMsg = "Hex Input Data not in proper format";
          return false;
        }
        int num3 = HexInputData.Length / 2 / 250;
        str1 = string.Empty;
        int num4;
        for (; num1 < num3; ++num1)
        {
          string Command = "00D6" + StartIndex + "FA" + HexInputData.Substring(startIndex, 500).ToString();
          if (!this.ExecuteCommand(ScHandle, ScProto, Command, ref CMDRESULT))
          {
            // ISSUE: explicit reference operation
            // ISSUE: variable of a reference type
            string local = @ErrMsg;
            string str2 = "Smart card writing error , Segment ";
            num4 = num1 + 1;
            string str3 = num4.ToString().PadLeft(2, '0');
            string str4 = str2 + str3;
            // ISSUE: explicit reference operation
            local = str4;
            return false;
          }
          if (CMDRESULT != "9000")
          {
            // ISSUE: explicit reference operation
            // ISSUE: variable of a reference type
            string local = @ErrMsg;
            string str2 = "Smart card writing error , Segment ";
            num4 = num1 + 1;
            string str3 = num4.ToString().PadLeft(2, '0');
            string str4 = str2 + str3;
            // ISSUE: explicit reference operation
            local = str4;
            return false;
          }
          this.HEX2DEC(StartIndex, ref num2);
          num4 = num2 + 250;
          StartIndex = num4.ToString("X").PadLeft(4, '0');
          startIndex += 500;
        }
        int num5 = HexInputData.Length / 2 % 250;
        if (num5 == 0)
        {
          ErrMsg = "File Write Sucessfully";
          return true;
        }
        string Command1 = "00D6" + StartIndex + num5.ToString("X").PadLeft(2, '0') + HexInputData.Substring(startIndex, num5 * 2).ToString();
        if (this.ExecuteCommand(ScHandle, ScProto, Command1, ref CMDRESULT) || !(CMDRESULT == "9000"))
          return true;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        string local1 = @ErrMsg;
        string str5 = "Smart card writing error , Segment ";
        num4 = num1 + 1;
        string str6 = num4.ToString().PadLeft(2, '0');
        string str7 = str5 + str6;
        // ISSUE: explicit reference operation
        local1 = str7;
        return false;
      }
      catch (Exception ex)
      {
        ErrMsg = ex.Message;
        return false;
      }
    }
    }
}
