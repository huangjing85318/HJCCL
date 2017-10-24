using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services
{
    public interface IWriteToJsonRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">json format</param>
        void WriteJson(string result);
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        void WriteJson(string status, string result);

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
        void WriteJson(int status, string result);
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">bool format</param>
        /// <param name="result">json format</param>
        void WriteJson(bool status, string result);


        #region Write Jsonp

        void WriteJsonP(string result);
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        void WriteJsonP(string status, string result);
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        void WriteJsonP(int status, string result);
        /// <summary>
        /// 0 false, 1 success; 
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        void WriteJsonP(bool status, string result);
        #endregion

        string StringToJson(string par);


        string DelComma_AddBracket(string par);

        string DelComma_AddBracket(string par, bool IsSquare);


        string Json2_Replace(string par);



        string Json2_SafeValue(string par);

        List<IDictionary<string, string>> Json2Data(string par);

        void Json2Data_part(string par, List<IDictionary<string, string>> list);

        IDictionary<string, string> Json2Data_part2(string par);

        string ClassToJson<T>(T t);
        
        string ObjectToJson(object obj);

        string DataTableToJson(DataTable dt);

        string DataRowToJson(DataTable dt);

        string DataRowToJson(DataTable dt, bool isGetColName);
    }
}
