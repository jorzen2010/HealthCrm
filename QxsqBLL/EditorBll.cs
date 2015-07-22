using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QxsqDTO;
using QxsqDAL;
using Common;

namespace QxsqBLL
{
    public class EditorBll
    {
         


        public static List<EditorDto> GetEditorDtoList(string strwhere)
        {
            return EditorDal.GetEditorList(strwhere);
        }



        #region 得到一个EditorPager 
        public static Pager GetEditorPager(Pager pager,string strwhere,string table)
        {


            //return EditorDal.GetEditorPage(pager, strwhere,table);
            return EditorDal.GetEditorPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddEditor(EditorDto editorDto)
        {
            EditorDal.AddEditor(editorDto);
     
        }


        #endregion

        #region 获取一个Editor
        public static EditorDto GetOneEditorDto(string table,string strwhere)
        {
            EditorDto editorDto=new EditorDto();

            editorDto = EditorDal.GetOneEditor(table, strwhere);

            return editorDto;
        }


        #endregion

        #region 更新Editor

        public static void UpdateEditorDto(EditorDto editorDto)
        {
            EditorDal.UpdateEditor(editorDto);
        }

        #endregion

        #region 删除Editor
        public static void DeleteEditorDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
