using System;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;


namespace CrmWeb.Controllers
{
    public class WordController : Controller
    {
        //
        // GET: /Word/
        public ActionResult Index()
        {
            string templateFile = "E:\\dsc\\wwwroot\\download\\导出模版.doc";
            string fileNameWord = "E:\\dsc\\wwwroot\\download\\temp\\20140804110822.doc";
            

            bool ret = false;
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            object Obj_FileName = fileNameWord;
            object Visible = false;
            object ReadOnly = false;
            object missing = System.Reflection.Missing.Value;
            try
            {
                File.Copy(templateFile, fileNameWord, true);
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref Visible, ref missing, ref missing, ref missing, ref missing);
                doc.Activate();

                doc.Tables[1].Select();//复制第一个表格,如果有多条粘贴到尾部
                app.Selection.Copy();//如果导入多条要把原来的模版粘贴下来

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object replaceArea = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        object replaceKey = "$" + dt.Columns[j].ToString() + "$";
                        object replaceValue = dt.Rows[i][j].ToString();
                        doc.Tables[i + 1].Range.Find.Execute(ref replaceKey, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref  replaceValue, ref replaceArea, ref missing, ref missing, ref missing, ref missing);
                    }
                    if (i + 1 != dt.Rows.Count)//这里是导入多条把刚才的模版粘贴到尾部
                    {
                        object mymissing = System.Reflection.Missing.Value;
                        object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                        app.Selection.EndKey(ref myunit, ref mymissing);
                        object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                        app.Selection.TypeParagraph();
                        app.Selection.Paste();
                    }
                }
                doc.Save();
                ret = true;
            }
            catch (Exception)
            {


            }
            finally
            {
                object o = false;
                doc.Close(ref o, ref missing, ref missing);
                app.Quit(ref o, ref missing, ref missing);
            }
            return ret;
            return View();
        }
	}
}