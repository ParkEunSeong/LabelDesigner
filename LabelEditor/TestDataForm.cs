﻿using Newtonsoft.Json.Linq;
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

            var text = File.ReadAllText("brcl.json");
            var res = (new HTTPConnection.Builder())
              .SetURL(textBox_0_url.Text)
              .SetMethod(HTTPConnection.Method.POST)
              .Build().PostJson(text);
        }

        private void button_2_Send_Click(object sender, EventArgs e)
        {
            JObject j = new JObject();
            j.Add("hsptId", textBox_2_hsptId.Text);
            j.Add("patId", textBox_2_patId.Text);
            j.Add("patNm", textBox_2_patNm.Text);
            j.Add("patDtbr", textBox_2_patDtbr.Text);
            j.Add("patAge", textBox_2_patAge.Text);

            j.Add("mdfrType", textBox_2_mdfrType.Text);
            j.Add("prntNm", textBox_2_prntNm.Text);
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

            var text = File.ReadAllText("card.json");
            var res = (new HTTPConnection.Builder())
  .SetURL(textBox_2_url.Text)
              .SetMethod(HTTPConnection.Method.POST)
              .Build().PostJson(text);
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

            j.Add("spcmNo", textBox_1_spcmNo.Text);
            j.Add("spcmNm", textBox_1_spcmNm.Text);
            j.Add("slipNm", textBox_1_slipNm.Text);
            j.Add("dwrDspl", textBox_1_dwrDspl.Text);
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
            var text = File.ReadAllText("spcm.json");
            var res = (new HTTPConnection.Builder())
               .SetURL(textBox_1_url.Text)
              .SetMethod(HTTPConnection.Method.POST)
              .Build().PostJson(text);
        }

        private void textBox_3_frqn_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JObject j = new JObject();
            j.Add("hsptId", textBox_3_hsptId.Text);
            j.Add("patId", textBox_3_patId.Text);
            j.Add("patNm", textBox_3_patNm.Text);
            j.Add("bndNo", textBox_3_bndNo.Text);
            j.Add("accmDt", textBox_3_accmDt.Text);
            j.Add("itemNm", textBox_3_itemNm.Text);
            j.Add("qty", textBox_3_qty.Text);
            j.Add("frqn", textBox_3_frqn.Text);
            j.Add("nody", textBox_3_nody.Text);
            j.Add("injcMthd", textBox_3_injcMthd.Text);
            j.Add("ref", textBox_3_ref.Text);

            j.Add("mdfrType", textBox_3_mdfrType.Text);
            j.Add("prntNm", textBox_3_prntNm.Text);
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

            var text = File.ReadAllText("card.json");
            var res = (new HTTPConnection.Builder())
  .SetURL(textBox_2_url.Text)
              .SetMethod(HTTPConnection.Method.POST)
              .Build().PostJson(text);
        }

        private void textBox_1_spcmNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
