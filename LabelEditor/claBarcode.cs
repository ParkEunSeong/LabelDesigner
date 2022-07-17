using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code128
{
    public class claBarcode
    {
		public string strBarcode(string strSData)
		{
			//생성된 바코드 데이터를 문자열로 리턴한다.
			//매개변수 : 문자열
			return strBarcode(strSData, 0);
		}

		/// <summary>
		/// 생성된 바코드 데이터를 문자열로 리턴한다
		/// </summary>
		/// <param name="strSData">바코드를 생성할 문자열</param>
		/// <param name="intType">스타트 타입 : 0=A타입, 1=B타입, 2=C타입</param>
		/// <returns></returns>
		public string strBarcode(string strSData, int intType)
		{
			//try
			//{				
			//코드데이터인스턴스를 생성한다.
			claCodeData insCodedata = new claCodeData();

			//바코드 형식 여백,스타트,데이터,체크캐릭터,스톱,여백
			string strData = "";	//리턴해줄 바코드 정보를 넣어둔다.

			//스타트타입은 A,B,C타입이 있다.
			//A:211412, B:211214, C:211232
			switch (intType)
			{
				case 1:	//B타입
					strData = "211214";
					break;
				case 2:	//C타입
					strData = "211232";
					break;
				default: //A타입
					strData = "211412";
					break;
			}


			//체크 캐릭터 구하는 공식
			//(스타트*1 + 데이터1*1 + 데이터2*2 + 데이터3*3 ... + 데이터15*15 ) Mod 103 = 캐릭터 코드
			int intChar = 0;	//체크캐릭터를 구하기위한 변수

			intChar = 103;		//스타트의 가중치는 1이기때문에 103만 제공한다.


			for (int i = 1; i <= strSData.Length; i++)
			{
				//받아온 데이터의 차수를 구하고
				int intTemp = insCodedata.intReTurnN(strSData.Substring(i - 1, 1), intType);
				//데이터를 기호코드로 변환하여 바코드 데이터로 입력한다.
				strData += insCodedata.intChar[intTemp, 1];
				//체크캐릭터 계산용 데이터에 수치에 가중치를 곱한 값을 더한다.
				intChar += intTemp * i;
			}

			//체크캐릭터의 값을 103으로 나눈 나머지를 구한다.
			intChar %= 103;
			//체크캐릭터에 해당하는 수치를 찾아 바코드를 반환한다.
			strData += insCodedata.intChar[intChar, 1];
			//스톱은 2331112가 고정이다.
			strData += "2331112";

			//MessageBox.Show(strData.Length + " ");
			return strData;	//결과를 리턴한다.
			//}
			//catch( Exception ex )
			//{
			//    // 테스트용 코드 시작**************
			//    MessageBox.Show("에러내용:"+ ex );
			//    //테스트용 코드 끝*****************
			//    return "0";
			//}
		}

		/// <summary>
		/// 바코드 데이터를 받아 이미지 처리를 할수 있게 2진수를 리턴해준다.10011식으로
		/// </summary>
		/// <param name="strData">바코드 데이터</param>
		/// <returns></returns>
		public string strBarcodeToBar(string strData)
		{
			try
			{
				//바코드의 색을 표시하기위한 변수
				//바코드는 검정(1,true),백색(0,false)이 번갈아 가면서 나온다.
				bool booBlackAndWhite = true;

				//리턴할 바 데이터를 저장한다.
				string strTempBar = "";

				for (int i = 0; i < strData.Length; i++)
				{
					//바꺼야할 위치의 데이터를 읽어온다.
					int intTemp = Convert.ToInt32(strData.Substring(i, 1));

					//데이터의 내용은 검정색(혹은 하얀색)이 몇번출력되야하는지에 대한 내용이기때문에
					//for문을 이용하여 데이터의 내용만큼 돌린다.
					for (int j = 1; j <= intTemp; j++)
					{
						if (booBlackAndWhite == true)
						{
							//검정색
							strTempBar += "1";
						}
						else
						{
							//하얀색
							strTempBar += "0";
						}
					}

					//검정색을 출력했으면 다음은 하얀색이고 반대의 경우는 반대의 값이 필요한다.
					booBlackAndWhite = !booBlackAndWhite;

				}

				return strTempBar;
			}
			catch (Exception ex)
			{
				//MessageBox.Show("에러내용:" + ex);
				return "0";
			}

		}
    }
}
