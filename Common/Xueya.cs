using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Common
{
    public class Xueya
    {
        public static string sendMsg(string name,string gaoya,string diya,string maibo)
        {
            string content =name+"的血压报告：高压："+gaoya+" 毫米汞柱，低压"+diya+" 毫米汞柱，每分钟心跳次数"+maibo+"次。祝您健康。【黑龙江医养结合】";
            //POST
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append("apikey=fc6ae1c5e0ce6756929e69bd660f115b&username=18611541073&password=jorzen2008&mobile=18611541073&content=" + content);
            byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());
            String result = PostRequest("http://m.5c.com.cn/api/send/?", bTemp);
            return "ok";
        }
        private static String PostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }
        private static void WriteErrLog(string strErr)
        {
            Console.WriteLine(strErr);
            System.Diagnostics.Trace.WriteLine(strErr);
        }
    }
}
