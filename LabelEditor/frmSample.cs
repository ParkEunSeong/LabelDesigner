using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using LabelEditor;

namespace SampleProgram
{
    public partial class frmSample : Form
    {
        // Interface Type
        public const int ISerial    = 0;
        public const int IParallel  = 1;
        public const int IUsb       = 2;
        public const int ILan       = 3;
        public const int IBluetooth = 5;

        public frmSample()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            try
            {
                StringBuilder strVersion = new StringBuilder(256);

                if (BXLLApi.GetDllVersion(strVersion))
                    lblDllVersion.Text = "Version " + strVersion.ToString();
                else
                    lblDllVersion.Text = "Unknown";
                
                // Interface
                rdoIF_Usb.Checked = true;
                EnableIFControls(IUsb);

                // Communication setting
                cmbLPT_Port.SelectedIndex       = 0;
                cmbSerial_Port.SelectedIndex    = 0;
                cmbSerial_Baudrate.SelectedItem = "115200";
                cmbSerial_Databits.SelectedItem = "8";
                cmbSerial_Parity.SelectedItem   = "NONE";
                cmbSerial_Stopbits.SelectedItem = "1";
                // Paper Width
                double value = 4 * 25.4;
                txtP_Width.Text = value.ToString("###0.###");
                // Paper Height
                value = 6 * 25.4;
                txtP_Height.Text = value.ToString("###0.###");
                // Margin
                txtMargin_X.Text = "0";
                txtMargin_Y.Text = "0";
                // Print Speed
                cmbSpeed.SelectedIndex = 0;
                // Density
                cmbDensity.SelectedIndex = (14 - 1);
                // Media type
                rdoGap.Checked = true;
            }
            catch (System.Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void EnableIFControls(int nInterface)
        {
            cmbLPT_Port.Enabled         = (nInterface == IParallel);
            cmbSerial_Port.Enabled      = (nInterface == ISerial || nInterface == IBluetooth);
            cmbSerial_Baudrate.Enabled  = (nInterface == ISerial);
            cmbSerial_Databits.Enabled  = (nInterface == ISerial);
            cmbSerial_Parity.Enabled    = (nInterface == ISerial);
            cmbSerial_Stopbits.Enabled  = (nInterface == ISerial);
            txtNet_IPAddr.Enabled       = (nInterface == ILan);
            txtNet_PortNum.Enabled      = (nInterface == ILan);
        }

        private void rdoIF_Serial_CheckedChanged(object sender, EventArgs e)
        {
            EnableIFControls(ISerial);
        }

        private void rdoIF_Bluetooth_CheckedChanged(object sender, EventArgs e)
        {
            EnableIFControls(IBluetooth);
        }

        private void rdoIF_Parallel_CheckedChanged(object sender, EventArgs e)
        {
            EnableIFControls(IParallel);
        }

        private void rdoIF_Usb_CheckedChanged(object sender, EventArgs e)
        {
            EnableIFControls(IUsb);
        }

        private void rdoIF_Lan_CheckedChanged(object sender, EventArgs e)
        {
            EnableIFControls(ILan);
        }

        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR:         errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER:         errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN:       errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM:       errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT:    errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING:     errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON:        errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_BOARD_OVER_HEAT:  errMsg = "Board overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_MOTOR_OVER_HEAT:  errMsg = "Motor overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_WAIT_LABEL_TAKEN: errMsg = "Waiting for the label to be taken"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT:          errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME:          errMsg = "Unknown (or Not supported) printer name"; break;
                case SLCS_ERROR_CODE.ERR_CODE_OFFLINE:          errMsg = "Offline (The printer is in an error status)"; break;
                default:                                        errMsg = "Unknown error";   break;
            }
            return errMsg;
        }

        private bool ConnectPrinter()
        {
            string strPort  = "";
            int nInterface  = ISerial;
            int nBaudrate   = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus     = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;
            
            if (rdoIF_Serial.Checked){
                // SERIAL (COM)
                nInterface = ISerial;
                strPort = cmbSerial_Port.Text;
                nBaudrate = Convert.ToInt32(cmbSerial_Baudrate.Text);
                nDatabits = Convert.ToInt32(cmbSerial_Databits.Text);
                nParity = cmbSerial_Parity.SelectedIndex;
                nStopbits = cmbSerial_Stopbits.SelectedIndex;
            }
            else if (rdoIF_Bluetooth.Checked){
                // BLUETOOTH (COM)
                nInterface = IBluetooth;
                strPort = cmbSerial_Port.Text;
            }
            else if (rdoIF_Parallel.Checked){
                // PARALLEL (LPT)
                nInterface = IParallel;
                strPort = cmbLPT_Port.Text;
            }
            else if (rdoIF_Usb.Checked){
                // USB
                nInterface = IUsb;
            }
            else if (rdoIF_Lan.Checked){
                // NETWORK
                nInterface = ILan;
                strPort = txtNet_IPAddr.Text;
                nBaudrate = Convert.ToInt32(txtNet_PortNum.Text);
            }

            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR){
                BXLLApi.DisconnectPrinter();
                MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }

        // byte[] -> String 
        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        // String -> byte[] 
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

        private void btnPrintSample_Click(object sender, EventArgs e)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int w = 0;
            if ( int.TryParse( txtP_Width.Text, out w ))
            {
                w = (int)(w / 25.4 * BXLLApi.GetPrinterDPI());
            }
            int h = 0;
            if (int.TryParse(txtP_Height.Text, out h))
            {
                h = (int)(h / 25.4 * BXLLApi.GetPrinterDPI());
            }
            

            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            int xString = (2 * dotsPer1mm);
            int yString = (5 * dotsPer1mm);
            // string DataMatrix_data = "BIXOLON Label Printer, This is for test.";
            //BXLLApi.PrintDataMatrix(xString, yString, (int)SLCS_DATAMATRIX_SIZE.DATAMATRIX_SIZE_4, false, (int)SLCS_ROTATION.ROTATE_0, DataMatrix_data);
            int x = 0;
            int y = 0;
            for (int i = 0; i < 1; i++)
            {
                string fontName = "맑은 고딕";
                x = 310 * dotsPer1mm;
                y = 1 * dotsPer1mm;
                BXLLApi.PrintTrueFont(x, y, fontName, 14, 0, true, true, false, i.ToString(), false);
                Debug.Print("Sample Label-1 x=" + x + ",y=" + y);
            }
            
            //	Draw Lines
        
            //Print string using Vector Font
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font selection
            //        U: ASCII (1Byte code)
            //        K: KS5601 (2Byte code)
            //        B: BIG5 (2Byte code)
            //        G: GB2312 (2Byte code)
            //        J: Shift-JIS (2Byte code)
            // P4  : Font width (W)[dot]
            // P5  : Font height (H)[dot]
            // P6  : Right-side character spacing [dot], Plus (+)/Minus (-) option can be used. Ex) 5, +3, -10	
            // P7  : Bold
            // P8  : Reverse printing
            // P9  : Text style  (N : Normal, I : Italic)
            // P10 : Rotation (0 ~ 3)
            // P11 : Text Alignment
            //        L: Left
            //        R: Right
            //        C: Center
            // P12 : Text string write direction (0 : left to right, 1 : right to left)
            // P13 : data to print
            // ※ : Third parameter, 'ASCII' must be set if Bixolon printer is SLP-T400, SLP-T403, SRP-770 and SRP-770II.
            //BXLLApi.PrintVectorFont(22, 65, "U", 34, 34, "0", false, false, false, (int)SLCS_ROTATION.ROTATE_0, SLCS_FONT_ALIGNMENT.LEFTALIGN.ToString(), (int)SLCS_FONT_DIRECTION.LEFTTORIGHT, "Sample Label-2");
            x = 2 * dotsPer1mm;
            y = 12 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "SHIP TO:");
            Debug.Print("SHIP TO: x=" + x + ",y=" + y);
            x = 2 * dotsPer1mm;
            y = 17 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_19X30, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "BIXOLON");
            Debug.Print("BIXOLON: x=" + x + ",y=" + y);
            x = 2 * dotsPer1mm;
            y = 21 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "7th FL, MiraeAsset Venture Tower,");
            Debug.Print("7th FL, MiraeAsset Venture Tower,: x=" + x + ",y=" + y);
            x = 2 * dotsPer1mm;
            y = 24 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(2 * dotsPer1mm, y, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "685, Sampyeong-dong, Bundang-gu,");
            Debug.Print("685, Sampyeong-dong, Bundang-gu, x=" + x + "y=" + y);

            x = 2 * dotsPer1mm;
            y = 27 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Seongnam-si, Gyeonggi-do,");
            Debug.Print("Seongnam-si, Gyeonggi-do, x=" + x + "y=" + y);

            x = 2 * dotsPer1mm;
            y = 30 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "463-400, KOREA");
            Debug.Print("463-400, KOREA, x=" + x + "y=" + y);

            x = 3 * dotsPer1mm;
            y = 36 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x,y, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "POSTAL CODE");
            Debug.Print("POSTAL CODE x=" + x + ",y=" + y);

            x = 3 * dotsPer1mm;
            y = 40 * dotsPer1mm;
            BXLLApi.Print1DBarcode(x, y, (int)SLCS_BARCODE.CODE39, 4 * multiplier, 6 * multiplier, 48 * multiplier, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, "1234567890");
            Debug.Print("1234567890 x=" + x + ",y=" + y);

            x = 3 * dotsPer1mm;
            y = 50 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(x, y, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "AWB:");
            Debug.Print("AWB x=" + x + ",y=" + y);

            x = 3 * dotsPer1mm;
            y = 53 * dotsPer1mm;
            BXLLApi.Print1DBarcode(x, y, (int)SLCS_BARCODE.CODE93, 4 * multiplier, 8 * multiplier, 90 * multiplier, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, "8741493121");
            Debug.Print("8741493121 x=" + x + ",y=" + y);


            x = 3 * dotsPer1mm;
            y = 69 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(4 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "WEIGHT:");
            Debug.Print("WEIGHT x=" + x + ",y=" + y);
            x = 3 * dotsPer1mm;
            y = 69 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(29 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "DELIVERY NO:");
            x = 3 * dotsPer1mm;
            y = 69 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(53 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "DESTINATION");

            x = 3 * dotsPer1mm;
            y = 73 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(3 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "30Kg");
            Debug.Print("30Kg x=" + x + ",y=" + y);
            x = 3 * dotsPer1mm;
            y = 73 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(26 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "425518");
            x = 3 * dotsPer1mm;
            y = 73 * dotsPer1mm;
            BXLLApi.PrintDeviceFont(55 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "ICN");

            // Prints a DATAMATRIX
           

            // Prints a QRCode
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : MODEL selection (1, 2)
            //  P4 : ECC Level (1 ~ 4)
            //  P5 : Size of QRCode (1 ~ 9)
            //  P6 : Rotation (0 ~ 3)
            //  P7 : data to print
            string QRCode_data = "QRCode sample test 123";
            BXLLApi.PrintQRCode(50 * dotsPer1mm, 83 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_M, (int)SLCS_QRCODE_SIZE.QRSIZE_4, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

            // Prints a PDF417
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Maximum Row Count : 3 ~ 90
            //  P4 : Maximum Column Count : 1 ~ 90
            //  P5 : Error Correction Level
            //  P6 : Data compression method
            //  P7 : HRI
            //  P8 : Barcode Origin Point
            //  P9 : Module Width : 2 ~ 9
            //  P10 : Module Height : 4 ~ 99
            //  P11 : Rotation (0 ~ 3)
            //  P12 : data to print
            xString = (2 * dotsPer1mm);
            yString = (97 * dotsPer1mm);
            string PDF417_data = "BIXOLON Label Printer, This is for test.";
            BXLLApi.PrintPDF417(xString, yString, 8, 8, 0, 0, false, 1, 3 * multiplier, 14 * multiplier, (int)SLCS_ROTATION.ROTATE_0, PDF417_data);

            // Draw BOX (Fill color is black)
            BXLLApi.PrintBlock(1 * dotsPer1mm, 80 * dotsPer1mm, 71 * dotsPer1mm, 112 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.BOX, 4);
            //BXLLApi.PrintCircle(10, 1055, 3, 2);

            // Print Image
            BXLLApi.PrintImageLib(1 * dotsPer1mm, 112 * dotsPer1mm, "BIXOLON.bmp", (int)SLCS_DITHER_OPTION.DITHER_1, false);

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }

        private void SendPrinterSettingCommand()
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int nPaper_Width = Convert.ToInt32(double.Parse(txtP_Width.Text) * dotsPer1mm);
            int nPaper_Height = Convert.ToInt32(double.Parse(txtP_Height.Text) * dotsPer1mm);
            int nMarginX = Convert.ToInt32(double.Parse(txtMargin_X.Text) * dotsPer1mm);
            int nMarginY = Convert.ToInt32(double.Parse(txtMargin_Y.Text) * dotsPer1mm);
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = Convert.ToInt32(cmbDensity.Text);
            int nOrientation = rdoTop2Bottom.Checked ? (int)SLCS_ORIENTATION.TOP2BOTTOM : (int)SLCS_ORIENTATION.BOTTOM2TOP;

            int nSensorType = (int)SLCS_MEDIA_TYPE.GAP;
            if (rdoBmark.Checked) nSensorType = (int)SLCS_MEDIA_TYPE.BLACKMARK;
            else if (rdoContinuous.Checked) nSensorType = (int)SLCS_MEDIA_TYPE.CONTINUOUS;

            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            if (rdoRewind.Checked){
                BXLLApi.PrintDirect("RWDy", true);
            }

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, rdoCut.Checked, 1, true);

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_USA, (int)SLCS_CODEPAGE.FCP_CP1252);

            /* 
                1 Inch : 25.4mm
                1 mm   :  7.99 Dots (XT5-40, SLP-TX400, SLP-DX420, SLP-DX220, SLP-DL410, SLP-T400, SLP-D420, SLP-D220, SRP-770/770II/770III)
                1 mm   :  7.99 Dots (SPP-L310, SPP-L410, SPP-L3000, SPP-L4000) 
                1 mm   :  7.99 Dots (XD3-40d, XD3-40t, XD5-40d, XD5-40t, XD5-40LCT)
                1 mm   : 11.81 Dots (XT5-43, SLP-TX403, SLP-DX423, SLP-DX223, SLP-DL413, SLP-T403, SLP-D423, SLP-D223)
                1 mm   : 11.81 Dots (XD5-43d, XD5-43t, XD5-43LCT)
                1 mm   : 23.62 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
            if (rdoDt.Checked)
                BXLLApi.PrintDirect("STd", true);
            else // Thermal transfer
                BXLLApi.PrintDirect("STt", true);
        }        

        private void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            if (!ConnectPrinter()) 
                return;

            int nStatus = BXLLApi.CheckStatus(); // ^cu command
            MessageBox.Show(GetStatusMsg(nStatus));

            BXLLApi.DisconnectPrinter();
        }

        private void btnDirectIO_Click(object sender, EventArgs e)
        {
            if (!ConnectPrinter()) 
                return;

            int lResult = 0;
            string strResult = "";

            // Get printer name (^PI0 command)
            string strCommand = "^PI0\r\n"; // 0x5e, 49, 30, 0x0d, 0x0a
            byte[] byCommand = Encoding.Default.GetBytes(strCommand);

            if (BXLLApi.WriteBuff(byCommand, byCommand.Length, ref lResult))
            {
                System.Threading.Thread.Sleep(100);
                byte[] byReadPrtName = new byte[32];
                if (BXLLApi.ReadBuff(byReadPrtName, byReadPrtName.Length, ref lResult) == true)
                {
                    strResult = ByteToString(byReadPrtName);
                    MessageBox.Show(strResult);
                }
            }

            BXLLApi.DisconnectPrinter();
        }
    }
}
