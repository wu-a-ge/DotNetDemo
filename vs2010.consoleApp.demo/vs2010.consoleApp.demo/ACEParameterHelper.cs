using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace vs2010.consoleApp.demo
{
    class ACEParameterHelper
    {
        public List<OleDbParameter> paras = new List<OleDbParameter>();

        public OleDbParameter[] result = null;

        public ACEParameterHelper AddParameter<T>(string key, T value)
        {
            OleDbParameter para = new OleDbParameter(key, GetOleDbType<T>(value));
            para.Value = value;
            paras.Add(para);
            return this;
        }

        public OleDbParameter[] GetParameters()
        {
            return paras.ToArray();
        }

        public ACEParameterHelper ClearParameters()
        {
            paras.Clear();
            return this;
        }

        public OleDbType GetOleDbType<T>(T t)
        {
            OleDbType result = OleDbType.VarWChar;
            Type cType = t.GetType();

            if (cType == Type.GetType("System.Int32"))
            {
                result = OleDbType.Integer;
            }
            else if (cType == Type.GetType("System.String"))
            {
                result = OleDbType.LongVarWChar;
            }
            else if (cType == Type.GetType("System.DateTime"))
            {
                result = OleDbType.Date;
            }
            return result;
        }

    }
}
