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
    public class MokuaiBll
    {
         


        public static List<MokuaiDto> GetMokuaiDtoList(string strwhere)
        {
            return MokuaiDal.GetMokuaiList(strwhere);
        }



        #region 得到一个MokuaiPager 
        public static Pager GetMokuaiPager(Pager pager,string strwhere,string table)
        {


            //return MokuaiDal.GetMokuaiPage(pager, strwhere,table);
            return MokuaiDal.GetMokuaiPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddMokuai(MokuaiDto mokuaiDto)
        {
            MokuaiDal.AddMokuai(mokuaiDto);
     
        }


        #endregion

        #region 获取一个Mokuai
        public static MokuaiDto GetOneMokuaiDto(string table,string strwhere)
        {
            MokuaiDto mokuaiDto=new MokuaiDto();

            mokuaiDto = MokuaiDal.GetOneMokuai(table, strwhere);

            return mokuaiDto;
        }


        #endregion

        #region 更新Mokuai

        public static void UpdateMokuaiDto(MokuaiDto mokuaiDto)
        {
            MokuaiDal.UpdateMokuai(mokuaiDto);
        }

        #endregion

        #region 删除Mokuai
        public static void DeleteMokuaiDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
