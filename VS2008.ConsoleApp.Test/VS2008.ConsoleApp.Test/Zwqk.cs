using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Test
{
   public  class Zwqk:NdoBase
    {
       public List<ZWQKInfo> GetArticleList(int cursorIndex, int pageSize, string ndoExpress)
       {
           ndoExpress = "[zwqk_othertype_tbl]:"+ndoExpress;
           if (!NdoQuery(ndoExpress, cursorIndex, pageSize)) return null;
           List<ZWQKInfo> result = new List<ZWQKInfo>();
           int current = 0;
           while (!IsEOF() && current < pageSize)
           {
               ZWQKInfo zwqkInfo = GetALLFieldValue();

               result.Add(zwqkInfo);

               ywnrs.MoveNext();
               current++;
           }
           Close();
           return result;
       }
       private ZWQKInfo GetALLFieldValue()
       {
           ZWQKInfo zwqkInfo = null;
           if (ywnrs != null)
           {
               zwqkInfo = new ZWQKInfo();
               zwqkInfo.LngID = ObjectToStr(ywnrs.GetFieldValue2("LngID"));
               zwqkInfo.IntViewDetail = ObjectToInt(ywnrs.GetFieldValue2("intViewDetail"));
               zwqkInfo.IntGBY = ObjectToInt(ywnrs.GetFieldValue2("intGBY"));
               zwqkInfo.IntHadYJQY = ObjectToInt(ywnrs.GetFieldValue2("intHadYJQY"));
               zwqkInfo.IntRD = ObjectToInt(ywnrs.GetFieldValue2("intRD"));
               zwqkInfo.GCH = ObjectToStr(ywnrs.GetFieldValue2("GCH"));//馆藏号
               zwqkInfo.Years = ObjectToStr(ywnrs.GetFieldValue2("Years"));
               zwqkInfo.Vol = ObjectToStr(ywnrs.GetFieldValue2("Vol"));
               zwqkInfo.Num = ObjectToStr(ywnrs.GetFieldValue2("Num"));
               zwqkInfo.Title_C = ObjectToStr(ywnrs.GetFieldValue2("Title_C"));
               zwqkInfo.Writer = ObjectToStr(ywnrs.GetFieldValue2("Writer"));
               zwqkInfo.ShowWriter = ObjectToStr(ywnrs.GetFieldValue2("ShowWriter"));
               zwqkInfo.GBYWriter = ObjectToStr(ywnrs.GetFieldValue2("GBYWriter"));
               zwqkInfo.Remark_C = ObjectToStr(ywnrs.GetFieldValue2("Remark_C"));
               zwqkInfo.Name_C = ObjectToStr(ywnrs.GetFieldValue2("Name_C"));
               zwqkInfo.BYCount = ObjectToInt(ywnrs.GetFieldHtmlValue2("BYCount"));
               zwqkInfo.QKID = ObjectToStr(ywnrs.GetFieldValue2("QKID"));

               zwqkInfo.Imburse = ObjectToStr(ywnrs.GetFieldValue2("Imburse"));//基金

               zwqkInfo.ShowOrgan = ObjectToStr(ywnrs.GetFieldValue2("ShowOrgan"));
               zwqkInfo.GBYOrgan = ObjectToStr(ywnrs.GetFieldValue2("GBYOrgan"));
               zwqkInfo.BEPage = ObjectToStr(ywnrs.GetFieldValue2("BeginPage")) + "-" + ObjectToStr(ywnrs.GetFieldValue2("EndPage"));
               zwqkInfo.StrPages = ObjectToStr(ywnrs.GetFieldValue2("strPages"));//页码
               zwqkInfo.StrYVN = ObjectToStr(ywnrs.GetFieldValue2("strYVN"));
               zwqkInfo.BeginPage = ObjectToStr(ywnrs.GetFieldValue2("BeginPage"));
               zwqkInfo.EndPage = ObjectToStr(ywnrs.GetFieldValue2("EndPage"));
               zwqkInfo.ClassNo = ObjectToStr(ywnrs.GetFieldValue2("Class"));
               zwqkInfo.KeyWord = ObjectToStr(ywnrs.GetFieldValue2("KeyWord_C"));
               zwqkInfo.StrType = ObjectToStr(ywnrs.GetFieldValue2("strType"));
               zwqkInfo.ReferCount = ObjectToInt(ywnrs.GetFieldValue2("ReferCount"));
               zwqkInfo.CouplingCount = ObjectToInt(ywnrs.GetFieldValue2("CouplingCount"));
               zwqkInfo.PageCount = ObjectToInt(ywnrs.GetFieldValue2("PageCount"));//文章页数
               zwqkInfo.StrPubAddress = ObjectToStr(ywnrs.GetFieldValue2("strPubAddress"));
               zwqkInfo.FirstWriter = ObjectToStr(ywnrs.GetFieldValue2("FirstWriter"));
               //
               zwqkInfo.CouplingIDs = ObjectToStr(ywnrs.GetFieldValue2("CouplingIDs"));
               zwqkInfo.ReferIDs = ObjectToStr(ywnrs.GetFieldValue2("ReferIDs"));
               zwqkInfo.StrBYIDs = ObjectToStr(ywnrs.GetFieldValue2("strBYIDs"));
               //4.19.2011添加
               zwqkInfo.ClassTypeIDs = ObjectToStr(ywnrs.GetFieldValue2("ClassTypeIDs"));
               //5.26.2011添加
               zwqkInfo.BYInfo = ObjectToStr(ywnrs.GetFieldValue2("BYInfo"));
               zwqkInfo.BYInfo_NotSelf = ObjectToStr(ywnrs.GetFieldValue2("BYInfo_NotSelf"));
               //9.2.2011添加
               zwqkInfo.StrByIDsYear = ObjectToStr(ywnrs.GetFieldValue2("strByIDsYear"));
               //12.19.2011
               zwqkInfo.Name_E = ObjectToStr(ywnrs.GetFieldHtmlValue2("Name_E"));
               zwqkInfo.Title_E = ObjectToStr(ywnrs.GetFieldHtmlValue2("Title_E"));
               zwqkInfo.Volumn = ObjectToStr(ywnrs.GetFieldHtmlValue2("Volumn"));
           }
           return zwqkInfo;
       }
    }
}
