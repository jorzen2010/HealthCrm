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
    public class HealthBll
    {
         


        public static List<HealthDto> GetHealthDtoList(string table,string strwhere)
        {
            return HealthDal.GetHealthList(table,strwhere);
        }



        #region 得到一个HealthPager 
        public static Pager GetHealthPager(Pager pager,string strwhere,string table)
        {


            //return HealthDal.GetHealthPage(pager, strwhere,table);
            return HealthDal.GetHealthPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddHealth(HealthDto healthDto)
        {
            HealthDal.AddHealth(healthDto);
     
        }


        #endregion

        #region 获取一个Health
        public static HealthDto GetOneHealthDto(string table,string strwhere)
        {
            HealthDto healthDto=new HealthDto();

            healthDto = HealthDal.GetOneHealth(table, strwhere);

            return healthDto;
        }


        #endregion

        #region 更新Health

        public static void UpdateHealthDto(HealthDto healthDto)
        {
            HealthDal.UpdateHealth(healthDto);
        }

        #endregion

        #region 删除Health
        public static void DeleteHealthDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
