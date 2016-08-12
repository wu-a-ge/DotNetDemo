using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Test
{
    public class ZWQKInfo
    {
        public string LngID { get; set; }//ID号
        public string Title_C { get; set; }//题名
        public string Writer { get; set; }//作者
        public string ShowWriter { get; set; }//显示作者
        public string GBYWriter { get; set; }//作者ID列表
        public string ShowOrgan { get; set; }//显示机构
        public string GBYOrgan { get; set; }//机构ID列表
        public string Years { get; set; }//年份
        public string Name_C { get; set; }//刊名
        public string Remark_C { get; set; }//文摘
        public string QKID { get; set; }//所属期刊ID
        public string BEPage { get; set; }//开始页-结束页
        public string BeginPage { get; set; }//开始页
        public string EndPage { get; set; }//结束页
        public string GCH { get; set; }//馆藏号
        public string Vol { get; set; }//卷
        public string Num { get; set; }//期
        public string StrYVN { get; set; }//年卷期
        public string StrPages { get; set; }//页码串
        public int PageCount { get; set; }//文章页数
        public string KeyWord { get; set; }//关键字
        public string ClassNo { get; set; }//分类号
        public string Imburse { get; set; }//基金
        public string StrType { get; set; }//文章类型
        public int ReferCount { get; set; }//参考文献数量
        public int CouplingCount { get; set; }//耦合文献数量
        public int BYCount { get; set; }//被引量（引证文献数量）
        public int BYCountNotSelf { get; set; }
        public int IntViewDetail { get; set; }//显示摘要标志
        public int IntGBY { get; set; }//高被引标志
        public int IntRD { get; set; }//热点标志
        public int IntHadYJQY { get; set; }//前沿标志
        public string ReferIDs { get; set; }//参考文献ID列表
        public string StrBYIDs { get; set; }//被引ID列表
        public string CouplingIDs { get; set; }
        public string StrPubAddress { get; set; }
        public string FirstWriter { get; set; }
        //4.19.2011
        public string ClassTypeIDs { get; set; }//学科分类ID列表
        //5.26.2011
        public string BYInfo { get; set; }
        public string BYInfo_NotSelf { get; set; }
        //9.2.2011
        public string StrByIDsYear { get; set; }
        //12.19.2011
        public string Title_E { get; set; }//英文题名
        public string Name_E { get; set; }
        public string Volumn { get; set; }//光盘号
    }
}
