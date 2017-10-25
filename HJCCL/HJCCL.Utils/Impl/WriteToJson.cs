using HJCCL.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace HJCCL.Utils
{
    public  class WriteToJson:IWriteToJson
    {
        public IWriteToJsonRepository _writeToJsonRepository;

        public WriteToJson(IWriteToJsonRepository writeToJsonRepository) {
            _writeToJsonRepository = writeToJsonRepository;
        }

        #region Write Json

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">json format</param>
        public  void WriteJson(string result)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(result);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public  void WriteJson(string status, string result)
        {
            string temp = "{\"status\":\"" + status + "\",\"context\":" + result + "}";
            WriteJson(temp);
        }

        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">int format</param>
        /// <param name="result">json format</param>
        //public  void WriteJson(int status, string result)
        //{
        //    string temp = "{\"status\":\"" + status + "\",\"context\":" + result + "}";
        //    WriteJson(temp);
        //}
        public  void WriteJson(int status, string result)
        {
            string temp = "{" + result + "}";
            WriteJson(temp);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">bool format</param>
        /// <param name="result">json format</param>
        public  void WriteJson(bool status, string result)
        {
            string i = "0";
            if (status) { i = "1"; }
            WriteJson(i, result);
        }

        #endregion

        #region Write Jsonp

        public  void WriteJsonP(string result)
        {
            _writeToJsonRepository.WriteJsonP(result);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public  void WriteJsonP(string status, string result)
        {
            _writeToJsonRepository.WriteJsonP(result);
            string temp = "{status:'" + status + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public  void WriteJsonP(int status, string result)
        {
            string temp = "{status:'" + status + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public  void WriteJsonP(bool status, string result)
        {
            string i = "0";
            if (status) { i = "1"; }
            string temp = "{status:'" + i + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        #endregion

        public  string StringToJson(string par)
        {
            return ObjectToJson(par);
        }

        public string DelComma_AddBracket(string par)
        {
            return DelComma_AddBracket(par, false);
        }
        public string DelComma_AddBracket(string par, bool IsSquare)
        {
            return _writeToJsonRepository.DelComma_AddBracket(par, IsSquare); 
        }


        public  string Json2_Replace(string par)
        {
            return _writeToJsonRepository.Json2_Replace(par);
        }


        public  string Json2_SafeValue(string par)
        {
            return _writeToJsonRepository.Json2_SafeValue(par); ;
        }

       public  List<IDictionary<string, string>> Json2Data(string par)
        {
            return _writeToJsonRepository.Json2Data(par);
        }

        public void Json2Data_part(string par, List<IDictionary<string, string>> list)
        {
            _writeToJsonRepository.Json2Data_part(par, list);
        }

        public IDictionary<string, string> Json2Data_part2(string par)
        {
            return _writeToJsonRepository.Json2Data_part2(par);
        }

       public   string ClassToJson<T>(T t)
        {
            return _writeToJsonRepository.ClassToJson(t);
        }
        public  string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public  string DataTableToJson(DataTable dt)
        {
            return ObjectToJson(dt);
        }

        public  string DataRowToJson(DataTable dt)
        {
            return _writeToJsonRepository.DataRowToJson(dt);
        }

        public  string DataRowToJson(DataTable dt, bool isGetColName)
        {
            return _writeToJsonRepository.DataRowToJson(dt);
        }
    }
}
