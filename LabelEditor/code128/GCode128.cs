using System;
using System.Collections.Generic;
using System.Text;

using GenCode128;   //참조요함 : DLL\GenCode128.dll
using System.Drawing;
using System.Drawing.Drawing2D;


namespace BARCODE_LABEL
{

    public class GCode128 : IDisposable
    {
        // GenCode128.dll
        // https://github.com/SourceCodeBackup/GenCode128
        // https://www.codeproject.com/Articles/14409/GenCode128-A-Code128-Barcode-Generator
        // https://www.nuget.org/packages/GenCode128/

        public GCode128()
        {
        }


        #region "Dispose"
        // https://medium.com/rkttu/idisposable-%ED%8C%A8%ED%84%B4%EC%9D%98-%EC%98%AC%EB%B0%94%EB%A5%B8-%EA%B5%AC%ED%98%84-%EB%B0%A9%EB%B2%95-4fa0fcf0e67a
        // https://storycompiler.tistory.com/223
        private bool disposed;      // 중복 호출을 검색하려면
        ~GCode128()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요. 
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if (disposing)
            {
                // IDisposable 인터페이스를 구현하는 멤버들을 여기서 정리합니다.
                //try { _ntx1.Dispose(); } catch { }
            }

            // .NET Framework에 의하여 관리되지 않는 외부 리소스들을 여기서 정리합니다.
            this.disposed = true;
        }

        #endregion //Dispose



        #region "송장번호등 바코드 만들때 사용"
        /// <summary>
        /// 송장번호등 바코드 만들때 사용
        /// </summary>
        /// <param name="pBarCode">바코드번호</param>
        /// <returns></returns>
        public System.Drawing.Image BASE_MAKE_IV_BARCODE(string pBarCode)
        {
            System.Drawing.Image img = null;

            try
            {
                if (pBarCode.Equals("")) { return img; }

                //string InputData  : 인코딩 할 메시지
                //int BarWeight     : 출력에서 막대의 기준선 너비입니다. 일반적으로 1 또는 2가 좋습니다
                //bool AddQuietZone : False 인 경우 바코드의 시작과 끝에서 필요한 공백을 생략합니다. 레이아웃이 이미지 주변에 좋은 여백을 제공하지 않으면 true를 사용해야합니다.

                img = Code128Rendering.MakeBarcodeImage(pBarCode, 1, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return img;
            /*
               사용예제
                string strBARCODE1 = "358616930005";

                Image imgBARCODE1 = null;
                Image imgBARCODE2 = null;

                using (Code128 code128 = new Code128())
                {
                    imgBARCODE1 = code128.BASE_MAKE_BARCODE(strBARCODE1);
                    imgBARCODE2 = code128.ImageResize(imgBARCODE1, 200, 400);

                }
                pictureBox1.Image = imgBARCODE2;
             */

        }
        #endregion


        /// <summary>
        /// 바코드이미지 사이즈 조절
        /// </summary>
        /// <param name="img">원본이미지</param>
        /// <param name="width">너비</param>
        /// <param name="height">높이</param>
        /// <returns></returns>
        public System.Drawing.Image ImageResize(System.Drawing.Image img, int width, int height)
        {
            //조정할 비율을 계산한다.
            float w = (width * 1.0f) / img.Width;
            float h = (height * 1.0f) / img.Height;
            float gtRate = 0f;
            float ltRate = 0f;

            if (w > h) { gtRate = w; ltRate = h; }
            else { gtRate = h; ltRate = w; }

            //비율에 따라 넓이, 높이를 결정한다.
            int nWidth = 0;
            int nHeight = 0;

            nWidth = width;
            nHeight = height;

            /*
            if ((int)Math.Round((decimal)(img.Width * ltRate)) <= width &&
                (int)Math.Round((decimal)(img.Height * ltRate)) <= height)
            {
                //작은 비율로 계산된 넓이 높이가 최대 널빙, 높이를 초과하지 않으면 작은 비율을 선택
                nWidth = (int)Math.Round((decimal)(img.Width * ltRate));
                nHeight = (int)Math.Round((decimal)(img.Height * ltRate));
            }
            else
            {
                nWidth = (int)Math.Round((decimal)(img.Width * gtRate));
                nHeight = (int)Math.Round((decimal)(img.Height * gtRate));
            }
            */


            Bitmap bmp = new Bitmap(nWidth, nHeight);


            Graphics graphic = Graphics.FromImage((System.Drawing.Image)bmp);
            try
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.PageUnit = GraphicsUnit.Pixel;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.RenderingOrigin = new Point(0, 0);
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                //draw the newly resized image
                graphic.DrawImage(img, 0, 0, nWidth, nHeight);
                graphic.Flush(FlushIntention.Sync);
                //return the image
                return (System.Drawing.Image)bmp;
            }
            catch (Exception ex)
            {
                throw new Exception("리사이된 이미지 생성중 오류가 발생했습니다", ex);
            }
            finally
            {
                graphic.Dispose();

            }

        }



    }
}
