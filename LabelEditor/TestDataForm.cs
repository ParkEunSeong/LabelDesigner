using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public partial class TestDataForm : Form
    {
        public TestDataForm()
        {
            InitializeComponent();
        }

        private void button_0_Send_Click(object sender, EventArgs e)
        {
            JObject j = new JObject();
            j.Add("hsptId", textBox_0_hsptId.Text);
            j.Add("patId", textBox_0_patId.Text);

            j.Add("patNm", textBox_0_patNm.Text);
            j.Add("patDtbr", textBox_0_patDtbr.Text);
            j.Add("patGndr", textBox_0_patGndr.Text);
            j.Add("patAge", textBox_0_patAge.Text);
            j.Add("wrType", textBox_0_wrType.Text);
            j.Add("deptCd", textBox_0_deptCd.Text);
            j.Add("ward", textBox_0_ward.Text);
            j.Add("room", textBox_0_room.Text);
            j.Add("wrDspl", textBox_0_wrDspl.Text);
            j.Add("ifflIndx", textBox_0_iffIndx.Text);
            j.Add("ifflAgeDvsn", textBox_0_ifflAgeDvsn.Text);
            j.Add("ifflDeptYn", textBox_0_iffIDeptYn.Text);
            j.Add("ifflYn", textBox_0_ifflYn.Text);
            j.Add("urgnDvsn", textBox_0_urgnDvsn.Text);

            j.Add("LABL_BRCL_WR_TYPE", textBox_0_LABL_BRCL_WR_TYPE.Text);
            j.Add("LABL_BRCL_IFFL_CHIL", textBox_0_LABL_BRCL_IFFL_CHIL.Text);
            j.Add("LABL_BRCL_IFFL_OLMN", textBox_0_LABL_BRCL_IFFL_OLMN.Text);
            j.Add("LABL_BRCL_IFFL_DEPT", textBox_0_LABL_BRCL_IFFL_DEPT.Text);
            j.Add("LABL_BRCL_IFFL_INDX", textBox_0_LABL_BRCL_IFFL_INDX.Text);
            j.Add("LABL_BRCL_URGN_DEPT", textBox_0_LABL_BRCL_URGN_DEPT.Text);

            j.Add("mdfrType", textBox_0_mdfrType.Text);
            j.Add("prntNm", textBox_0_prntNm.Text);
            var json = j.ToString();
            using (var sw = new StreamWriter("brcl.json"))
            {
                sw.Write(json);
            }
            JObject jObject;
            using (var sr = new StreamReader("brcl" +
                ".json"))
            {
                jObject = JObject.Parse(sr.ReadToEnd());
            }
            var hsptId = jObject["hsptId"].ToString();
        }

        private void button_2_Send_Click(object sender, EventArgs e)
        {
            JObject j = new JObject();
            j.Add("hsptId", textBox_1_hsptId.Text);
            j.Add("patId", textBox_1_patId.Text);
            j.Add("patNm", textBox_1_patNm.Text);
            j.Add("patDtbr", textBox_1_patDtbr.Text);
            j.Add("patGndr", textBox_1_patGndr.Text);
            j.Add("patAge", textBox_1_patAge.Text);
            j.Add("LABL_CARD_TYPE", textBox_2_LABL_CARD_TYPE.Text);

            j.Add("mdfrType", textBox_1_mdfrType.Text);
            j.Add("prntNm", textBox_1_prntNm.Text);
            var json = j.ToString();
            using (var sw = new StreamWriter("card.json"))
            {
                sw.Write(json);
            }
            JObject jObject;
            using (var sr = new StreamReader("card.json"))
            {
                jObject = JObject.Parse(sr.ReadToEnd());
            }
        }

        private void button_1_Send_Click(object sender, EventArgs e)
        {
            JObject j = new JObject();
            j.Add("hsptId", textBox_1_hsptId.Text);
            j.Add("patId", textBox_1_patId.Text);
            j.Add("patNm", textBox_1_patNm.Text);
            j.Add("patDtbr", textBox_1_patDtbr.Text);
            j.Add("patGndr", textBox_1_patGndr.Text);
            j.Add("patAge", textBox_1_patAge.Text);
            j.Add("wrType", textBox_1_wrType.Text);
            j.Add("deptCd", textBox_1_deptCd.Text);
            j.Add("ward", textBox_1_ward.Text);
            j.Add("room", textBox_1_room.Text);

            j.Add("recpDt", textBox_1_recpDt.Text);
            j.Add("accmDt", textBox_1_accmDt.Text);
            j.Add("apntDt", textBox_1_apntDt.Text);
            j.Add("spcmCnnr", textBox_1_spcmCnnr.Text);
            j.Add("slipNmType", textBox_1_slipNmType.Text);

            j.Add("dwrDspl", textBox_1_dwrDspl.Text);
            j.Add("prscEmpno", textBox_1_prscEmpno.Text);
            j.Add("slipRqst", textBox_1_slipRqst.Text);
            j.Add("spcmDt", textBox_1_spcmDt.Text);
            j.Add("spcmDtm", textBox_1_spcmDtm.Text);
            j.Add("spcmUserNm", textBox_1_spcmUserNm.Text);
            j.Add("prntDtm", textBox_1_prntDtm.Text);

            j.Add("LABL_SPCM_WR_TYPE", textBox_1_LABL_SPCM_WR_TYPE.Text);
            j.Add("LABL_SPCM_SLIP_NM", textBox_1_LABL_SPCM_SLIP_NM.Text);


            j.Add("mdfrType", textBox_1_mdfrType.Text);
            j.Add("prntNm", textBox_1_prntNm.Text);
            var json = j.ToString();
            using (var sw = new StreamWriter("spcm.json"))
            {
                sw.Write(json);
            }
            JObject jObject;
            using (var sr = new StreamReader("spcm.json"))
            {
                jObject = JObject.Parse(sr.ReadToEnd());
            }
        }
    }
}
