using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalProduction.Forms;
using LabelEditor.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Threading;

namespace LabelEditor
{
    public class BXLPrint
    {


        //1 mm =  2.83465 pt(point)
        //1 inch = 72 pt(point)
        //1 point = 1/72 inch
        //1 pixel = 1/96 inch(dpi 96)
        //Pixel 값 = (pointValue) * 96(dpi) / 72
        //Point 값 = (pixelValue) * 72 / 96(dpi)
        StatusBar statusBar1 = new StatusBar();
        // Create two StatusBarPanel objects to display in the StatusBar.
        StatusBarPanel m_statusBarPanel1 = new StatusBarPanel();
        StatusBarPanel m_statusBarPanel2 = new StatusBarPanel();
        private BXLConfiguration m_config;
        private bool m_isDrag;
        private Point m_startPoint;
        private Control m_selectedCtrl;
        private Paper m_paper;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn                            //파라미터
        (
            int nLeftRect,      // x-coordinate of upper-left corner
            int nTopRect,       // y-coordinate of upper-left corner
            int nRightRect,     // x-coordinate of lower-right corner
            int nBottomRect,    // y-coordinate of lower-right corner   
            int nWidthEllipse,  // height of ellipse
            int nHeightEllipse  // width of ellipse  
        );
        private frmMain m_labelSetForm;
        private List<RotatedLabel> m_labelList = new List<RotatedLabel>();
        private List<RotatedLabel> m_dateTimeList = new List<RotatedLabel>();
        private List<Barcode> m_barcodeList = new List<Barcode>();
        private List<QRCode> m_qrList = new List<QRCode>();
        public Action OnEndPrint;
        public BXLPrint()
        {

        }
        public void SetLabelFrom(frmMain frm)
        {

        }

        private void Canvas1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PanelLabel_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                var pt = e.Location;

                if (IntersectRect(e.Location))
                {

                }
            }
        }

        private void PanelLabel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (IntersectRect(e.Location))
                {

                }
            }
        }

        public void Initalize(BXLConfiguration config, Paper paper)
        {
            m_config = config;
            m_paper = paper;

            TRACE.Log("texts");
            for (int i = 0; i < paper.texts.Count; i++)
            {
                var label = new RotatedLabel();
                label.AutoSize = true;
                label.Name = paper.texts[i].key;
                label.Location = new Point(paper.texts[i].x, paper.texts[i].y);
                label.Font = new Font(paper.texts[i].font_name, paper.texts[i].font_size, paper.texts[i].bold ? FontStyle.Bold : FontStyle.Regular);
                label.Angle = PropUtil.GetIdxToAngle(paper.texts[i].rotation);
                label.Text = label.Name;
                label.Tag = 0;
                label.Fix = paper.texts[i].Fix;
                label.Multiple = paper.texts[i].Multile;
                label.IsArray = paper.texts[i].IsArray;
                label.Separator = paper.texts[i].Separator;
                foreach (var it in paper.texts[i].m_multiple)
                {
                    label.m_multple.Add(new data.Text(it.key, it.Fix));
                }
                label.Selected();

                m_labelList.Add(label);

            }
            TRACE.Log("datetimes");
            for (int i = 0; i < paper.dateTimes.Count; i++)
            {
                var label = new RotatedLabel();
                label.AutoSize = true;
                label.Name = paper.dateTimes[i].key;
                label.Location = new Point(paper.dateTimes[i].x, paper.dateTimes[i].y);
                label.Font = new Font(paper.dateTimes[i].font_name, paper.dateTimes[i].font_size, paper.dateTimes[i].bold ? FontStyle.Bold : FontStyle.Regular);
                label.Angle = PropUtil.GetIdxToAngle(paper.dateTimes[i].rotation);
                label.Text = label.Name;
                label.Tag = 3;
                label.Selected();
                label.m_dateTimeFormat = paper.dateTimes[i].datetime_type;

                m_dateTimeList.Add(label);

            }
            TRACE.Log("qrs");
            for (int i = 0; i < paper.qrs.Count; i++)
            {
                var pb = new QRCode();
                pb.Name = paper.qrs[i].key;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = paper.qrs[i].width;
                pb.Height = paper.qrs[i].height;
                pb.Text = pb.Name;
                pb.Location = new Point(paper.qrs[i].x, paper.qrs[i].y);
                pb.ECC_LEVEL = paper.qrs[i].bxl_ecc_level;
                pb.QR_ROTATION = paper.qrs[i].bxl_qr_rotation;
                pb.QR_MODEL = paper.qrs[i].bxl_qr_model;
                pb.QR_SIZE = paper.qrs[i].bxl_qr_size;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = 1;
                

               m_qrList.Add(pb);

            }
            TRACE.Log("barcodes");
            for (int i = 0; i < paper.barcodes.Count; i++)
            {
                try
                {
                    var pb = new Barcode();
                    Image img = null;
                    pb.Name = paper.barcodes[i].key;
                    pb.Angle = paper.barcodes[i].Angle;
                    pb.narrowWidth = paper.barcodes[i].narrow_width;
                    if (paper.barcodes[i].barcode39 == 0)
                    {
                        pb.code39 = 0;
                        Barcode39 barcode39 = new Barcode39();
                        barcode39.Code = "12345678";
                        barcode39.BarHeight = paper.barcodes[i].height;
                        img = barcode39.CreateDrawingImage(Color.Black, Color.White);
                    }
                    else
                    {
                        pb.code39 = 1;
                        Barcode128 barcode128 = new Barcode128();
                        barcode128.Code = "12345678";
                        barcode128.BarHeight = paper.barcodes[i].height;
                        img = barcode128.CreateDrawingImage(Color.Black, Color.White);
                    }
                    pb.font = paper.barcodes[i].font;
                    pb.Image = img;
                    pb.Location = new Point(paper.barcodes[i].x, paper.barcodes[i].y);
                    pb.Width = paper.barcodes[i].width;
                    pb.Height = paper.barcodes[i].height;
                    pb.Padding = paper.barcodes[i].Padding;
                    pb.Length = paper.barcodes[i].Length;
                    pb.Tag = 2;

                    m_barcodeList.Add(pb);

                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());

                }
            }
            ConnectPrinter();
            Thread.Sleep(100);
            buttonPrint_Click(null, null);
        }


        private bool IntersectRect(Point pt)
        {
            for (int i = 0; i < m_labelList.Count; i++)
            {
                if (m_labelList[i].Location.X <= pt.X &&
                    pt.X <= m_labelList[i].Location.X + m_labelList[i].Width &&
                    m_labelList[i].Location.Y <= pt.Y &&
                    pt.Y <= m_labelList[i].Location.Y + m_labelList[i].Height)
                {
                    return true;
                }

            }
            return false;
        }



        private void textBoxX_TextChanged(object sender, EventArgs e)
        {

        }
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;
        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR: errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER: errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN: errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM: errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT: errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING: errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON: errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_BOARD_OVER_HEAT: errMsg = "Board overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_MOTOR_OVER_HEAT: errMsg = "Motor overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_WAIT_LABEL_TAKEN: errMsg = "Waiting for the label to be taken"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT: errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME: errMsg = "Unknown (or Not supported) printer name"; break;
                case SLCS_ERROR_CODE.ERR_CODE_OFFLINE: errMsg = "Offline (The printer is in an error status)"; break;
                default: errMsg = "Unknown error"; break;
            }
            return errMsg;
        }

        private bool ConnectPrinter()
        {
            string strPort = "";
            int nInterface = ISerial;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;



            // USB
            nInterface = IUsb;
            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }
        private void SendPrinterSettingCommand(BXLConfiguration configuration)
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            TRACE.Log("dotsPer1mm =" + dotsPer1mm);
            int nPaper_Width = configuration.width;
            int nPaper_Height = configuration.height;
            int nMarginX = configuration.margin_x;
            int nMarginY = configuration.margin_y;
            int nSpeed = configuration.speed;
            int nDensity = configuration.density;
            int nOrientation = (int)configuration.orientation;

            int nSensorType = (int)configuration.sensor_type;


            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            if ((BXLConfiguration.OPERATION_MODE)configuration.orientation == BXLConfiguration.OPERATION_MODE.REWINDER)
            {
                BXLLApi.PrintDirect("RWDy", true);
            }

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            var cut = configuration.cut;
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, cut, 1, true);
            TRACE.Log($"BXL nSpeed={nSpeed},nDensity={nDensity},nOrientation={nOrientation},cut={cut}");
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
            TRACE.Log($"BXL SetPaper MarinX={nMarginX},MarginY={nMarginY},PaperWidth={nPaper_Width},PaperHeight={nPaper_Height},SensorType={nSensorType}");
            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
            //     if (m_config.MEDIA == LabelConfiguration.MEDIA_TPYE.DirectThermal)
            TRACE.Log("    BXLLApi.PrintDirect(STd, true);");
            BXLLApi.PrintDirect("STd", true);
            //    else // Thermal transfer
            //        BXLLApi.PrintDirect("STt", true);
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {

            if (!ConnectPrinter())
                return;
            SendPrinterSettingCommand(m_config);
            var list = m_labelList;
            for (int i = 0; i < list.Count; i++)
            {
                var label = list[i];
                BXLLApi.PrintTrueFont(label.Location.X, label.Location.Y, label.Font.Name, (int)label.Font.Size < 14 ? 14 : (int)label.Font.Size, 0, false, label.Font.Bold, false, label.Text, false);
            }
            var dtList = m_dateTimeList;
            for (int i = 0; i < dtList.Count; i++)
            {
                var label = list[i];
                BXLLApi.PrintTrueFont(label.Location.X, label.Location.Y, label.Font.Name, (int)label.Font.Size < 14 ? 14 : (int)label.Font.Size, 0, false, label.Font.Bold, false, label.Text, false);
            }
            var qrList = m_qrList;
            for (int i = 0; i < qrList.Count; i++)
            {
                var pb = qrList[i];
                BXLLApi.PrintQRCode(pb.Location.X, pb.Location.Y, (int)pb.QR_MODEL, (int)pb.ECC_LEVEL, (int)pb.QR_SIZE, (int)pb.QR_ROTATION, pb.Text);

            }
            var barList = m_barcodeList;
            for (int i = 0; i < barList.Count; i++)
            {
                var bar = barList[i];

                BXLLApi.Print1DBarcode(bar.Location.X, bar.Location.Y, (int)SLCS_BARCODE.CODE128, bar.narrowWidth, bar.Width, bar.Height, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, "1234567890");
            }

            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
            OnEndPrint?.Invoke();
        }



        private void DrawText(Graphics g, int x, int y, string text)
        {

            // Create font and brush.
            Font drawFont = new Font("맑은 고딕", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            //   drawFormat.FormatFlags = StringFormatFlags.;

            // Draw string to screen.
            g.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
        }


    }
}
