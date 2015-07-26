using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QxsqDTO;
using QxsqDAL;
using Common;

namespace QxsqBLL
{
    public class JiwangshiBll
    {



        public static List<JiwangshiDto> GetJiwangshiDtoList(string table,string strwhere)
        {
            return JiwangshiDal.GetJiwangshiList(table,strwhere);
        }



        #region 得到一个JiwangshiPager 
        public static Pager GetJiwangshiPager(Pager pager,string strwhere,string table)
        {


            //return JiwangshiDal.GetJiwangshiPage(pager, strwhere,table);
            return JiwangshiDal.GetJiwangshiPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddJiwangshi(JiwangshiDto jiwangshiDto)
        {
            JiwangshiDal.AddJiwangshi(jiwangshiDto);
     
        }


        #endregion

        #region 获取一个Jiwangshi
        public static JiwangshiDto GetOneJiwangshiDto(string table,string strwhere)
        {
            JiwangshiDto jiwangshiDto=new JiwangshiDto();

            jiwangshiDto = JiwangshiDal.GetOneJiwangshi(table, strwhere);

            return jiwangshiDto;
        }


        #endregion

        #region 更新Jiwangshi

        public static void UpdateJiwangshiDto(JiwangshiDto jiwangshiDto)
        {
            JiwangshiDal.UpdateJiwangshi(jiwangshiDto);
        }

        #endregion

        #region 删除Jiwangshi
        public static void DeleteJiwangshiDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
