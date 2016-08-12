using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NDOCOMLib;

namespace VS2008.ConsoleApp.Test
{
    public class NdoBase
    {
        #region 保护字段
        protected NDOComRecordSet ywnrs;
        protected NDOComConn ywndoconn;
        #endregion

        #region 属性
        public int PageCount { get; private set; }
        public int RecordCount { get; private set; }
        #endregion

        #region NDO数据层专门方法
        /// <summary>
        /// 判断当前记录集是否到末尾
        /// </summary>
        /// <returns></returns>
        protected bool IsEOF()
        {
            bool result = false;
            try
            {
                if (Convert.ToBoolean(ywnrs.Eof()))
                {
                    result = true;
                }
            }
            catch
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 关闭NDO库连接，并且把ywnrs,ywndoconn置为空
        /// </summary>
        protected void Close()
        {

            if (ywnrs != null)
            {
                ywnrs.CloseRecorderSet();
                ywnrs = null;
            }
            if (ywndoconn != null)
            {
                try
                {
                    ywndoconn.CloseConn();
                    ywndoconn = null;
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 将字段值转换为字符串,不应该抛出异常，抛出异常说明数据有问题
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        protected string ObjectToStr(object tmp)
        {
            string result = string.Empty;
            try
            {

                result = Convert.ToString(tmp);
            }
            catch
            {
                result = "";
            }
            //result = tmp.ToString().Trim();

            return result;
        }
        /// <summary>
        /// 将字段值转换为整数,不应该抛出异常，抛出异常说明数据有问题
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        protected int ObjectToInt(object tmp)
        {
            int result = 0;
            try
            {

                result = Convert.ToInt32(tmp);
            }
            catch
            {
                result = 0;
            }
            //result = Convert.ToInt32(tmp);
            return result;
        }
        /// <summary>
        /// 查询NDO库，取得指定表的所有字段
        /// </summary>
        /// <param name="Express">表达式</param>
        /// <returns></returns>
        protected virtual bool NdoQuery(string ndoExpress)
        {

            return NdoQuery(ndoExpress, null);

        }
        /// <summary>
        /// 查询NDO库，取得指定表的某些字段
        /// </summary>
        /// <param name="ndoExpress"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        protected bool NdoQuery(string ndoExpress, string columnsName)
        {

            return NdoQuery(ndoExpress, columnsName, null, null);
        }
        /// <summary>
        /// 查询NDO库，取得指定表的某些字段,并且分页
        /// </summary>
        /// <param name="ndoExpress"></param>
        /// <param name="cursorIndex">索引从0开始的</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected bool NdoQuery(string ndoExpress, int? cursorIndex, int? pageSize)
        {

            return NdoQuery(ndoExpress, null, cursorIndex, pageSize);
        }
        /// <summary>
        /// 查询NDO库，取得指定表的某些字段,并且分页
        /// </summary>
        /// <param name="ndoExpress">表达式</param>
        /// <param name="columnsName">检索字段名</param>
        /// <param name="cursorIndex">索引从0开始的</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        protected bool NdoQuery(string ndoExpress, string columnsName, int? cursorIndex, int? pageSize)
        {
            try
            {
                ywndoconn = new NDOComConn();
                ywnrs = new NDOComRecordSet();

                ywndoconn.CreateConn(ConfigurationManager.AppSettings["Server"], int.Parse(ConfigurationManager.AppSettings["Port"]), ConfigurationManager.AppSettings["Database"]);
                //检索时为空，抛出异常,指定字段不为空
                if (!string.IsNullOrEmpty(columnsName))
                    ywnrs = ywndoconn.SearchDefineColumn(ndoExpress, columnsName);
                else
                    ywnrs = ywndoconn.Search(ndoExpress);
                ywnrs.MoveFirst();//如果返回数据，指定到第一条记录
                //
                if (null != cursorIndex && null != pageSize)
                {
                    //设置页大小，及光标位置
                    SetPageSize((int)pageSize);
                    SetCursor((int)cursorIndex);
                    //取得总页数
                    SetPageCount();
                }
                //总记录数
                SetRecordCount();

                return true;
            }
            catch//记录为空也抛出异常
            {

                Close();
                return false;
            }
        }
        /// <summary>
        /// 设置每页大小
        /// </summary>
        /// <param name="pagesize"></param>
        private void SetPageSize(int pagesize)
        {
            if (ywnrs != null)
            {
                ywnrs.SetPageSize(Convert.ToUInt32(pagesize));
            }
        }
        /// <summary>
        /// 设置光标位置
        /// </summary>
        /// <param name="cursor"></param>
        private void SetCursor(int cursor)
        {
            if (ywnrs != null)
            {
                ywnrs.SetCursor(Convert.ToUInt32(cursor));
            }
        }
        /// <summary>
        /// 取得总记录条数
        /// </summary>
        /// <returns></returns>
        private void SetRecordCount()
        {
            if (ywnrs != null)
            {
                RecordCount = Convert.ToInt32(ywnrs.GetRecordCount());
            }
            else
            {
                RecordCount = 0;
            }

        }
        /// <summary>
        /// 取得总页数
        /// </summary>
        /// <returns></returns>
        private void SetPageCount()
        {
            if (ywnrs != null)
            {
                PageCount = Convert.ToInt32(ywnrs.GetMaxPageNO());
            }
            else
            {
                PageCount = 0;
            }

        }
        #endregion

    }
}
