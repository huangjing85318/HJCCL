using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace HJCCL.Utils
{
    public  class WriteToJson
    {

        #region Write Json

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">json format</param>
        public static void WriteJson(string result)
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
        public static void WriteJson(string status, string result)
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
        public static void WriteJson(int status, string result)
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
        public static void WriteJson(bool status, string result)
        {
            string i = "0";
            if (status) { i = "1"; }
            WriteJson(i, result);
        }

        #endregion

        #region Write Jsonp

        public static void WriteJsonP(string result)
        {
            string callback = ConvertObject.ToString(HttpContext.Current.Request.Params["callback"]);
            string re_value = callback + "({result:" + result + "})";
            HttpContext.Current.Response.Write(re_value);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public static void WriteJsonP(string status, string result)
        {
            string temp = "{status:'" + status + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// use status to control other number.
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public static void WriteJsonP(int status, string result)
        {
            string temp = "{status:'" + status + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        /// <summary>
        /// 0 false, 1 success; 
        /// </summary>
        /// <param name="status">string format</param>
        /// <param name="result">json format</param>
        public static void WriteJsonP(bool status, string result)
        {
            string i = "0";
            if (status) { i = "1"; }
            string temp = "{status:'" + i + "',context:" + result + "}";
            WriteJsonP(temp);
        }
        #endregion

        public static string StringToJson(string par)
        {
            return ObjectToJson(par);
        }

        public static string DelComma_AddBracket(string par)
        {
            return DelComma_AddBracket(par, false);
        }
        public static string DelComma_AddBracket(string par, bool IsSquare)
        {
            string result = par;
            if (result.EndsWith(","))
            {
                result = result.Substring(0, result.Length - 1);
            }
            if (IsSquare)
            {
                result = "[" + result + "]";
            }
            else
            {
                result = "{" + result + "}";
            }
            return result;
        }


        public static string Json2_Replace(string par)
        {
            string result = par;
            result = result.Replace("!AND!", "&");
            result = result.Replace("!WEN!", "?");
            result = result.Replace("!JING!", "#");
            //result = result.Replace("!DYIN!", "'");
            result = result.Replace("!HEN!", "-");
            result = result.Replace("!br!", "\n");
            return result;
        }


       public static string Json2_SafeValue(string par)
        {
            string result = par;
            result = result.Replace("\"", "\\\"");
            return result;
        }

        static List<IDictionary<string, string>> Json2Data(string par)
        {
            string par_temp = Json2_Replace(par);
            List<IDictionary<string, string>> list = new List<IDictionary<string, string>>();
            int begin = par_temp.IndexOf("{");
            string temp = par_temp.Substring(begin + 1);
            Json2Data_part(temp, list);
            return list;
        }

        public static void Json2Data_part(string par, List<IDictionary<string, string>> list)
        {
            int end = par.IndexOf("}");
            int begin = par.IndexOf("{");
            if (begin > end || begin < 0)
            {
                string temp = par.Split('}')[0];
                list.Add(Json2Data_part2(temp));
                if (begin >= 0)
                {
                    temp = par.Substring(begin + 1);
                    Json2Data_part(temp, list);
                }
            }
            else
            {
                string temp = par.Substring(begin + 1);
                Json2Data_part(temp, list);
            }

        }

        public static IDictionary<string, string> Json2Data_part2(string par)
        {
            IDictionary<string, string> ht = new Dictionary<string, string>();
            string[] temp = par.Split('\'');
            for (int i = 1; i < temp.Length; i = i + 4)
            {
                ht.Add(temp[i], temp[i + 2]);
            }
            return ht;
        }

        public static string ClassToJson<T>(T t)
        {
            string result = "";
            Type type = typeof(T);
            foreach (System.Reflection.PropertyInfo info in type.GetProperties())
            {
                if (info.PropertyType.IsValueType || info.PropertyType.Name.StartsWith("String"))
                    result += info.Name + ":\"" + ConvertObject.ToString(info.GetValue(t, null)) + "\",";
            }
            result = DelComma_AddBracket(result);
            return result;
        }
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string DataTableToJson(DataTable dt)
        {
            return ObjectToJson(dt);
        }

        public static string DataRowToJson(DataTable dt)
        {
            string re = ObjectToJson(dt);
            re = re.Substring(1, re.Length - 2);
            return re;
        }

        public static string DataRowToJson(DataTable dt, bool isGetColName)
        {
            string result = "";
            if (dt.Rows.Count > 0)
            {
                result = ObjectToJson(dt);
                result = result.Substring(1, result.Length - 2);
            }
            else
            {
                if (isGetColName)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result += dc.ColumnName + ":\"\",";
                    }
                    result = DelComma_AddBracket(result);
                }
            }
            return result;
        }
    }
}
