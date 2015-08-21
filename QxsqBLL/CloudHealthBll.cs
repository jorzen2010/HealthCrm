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
    public class CloudHealthBll
    {

       

        

        public static List<CloudHealthDto> GetCloudHealthDtoList(string table,string strwhere)
        {
            return CloudHealthDal.GetCloudHealthList(table,strwhere);
        }



        #region 得到一个CloudHealthPager 
        public static Pager GetCloudHealthPager(Pager pager,string strwhere,string table)
        {


            //return CloudHealthDal.GetCloudHealthPage(pager, strwhere,table);
            return CloudHealthDal.GetCloudHealthPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddCloudHealth(CloudHealthDto cloudHealthDto)
        {
            CloudHealthDal.AddCloudHealth(cloudHealthDto);
     
        }


        #endregion

        #region 获取一个CloudHealth
        public static CloudHealthDto GetOneCloudHealthDto(string table,string strwhere)
        {
            CloudHealthDto cloudHealthDto=new CloudHealthDto();

            cloudHealthDto = CloudHealthDal.GetOneCloudHealth(table, strwhere);

            return cloudHealthDto;
        }


        #endregion

        #region 更新CloudHealth

        public static void UpdateCloudHealthDto(CloudHealthDto cloudHealthDto)
        {
            CloudHealthDal.UpdateCloudHealth(cloudHealthDto);
        }

        #endregion

        #region 删除CloudHealth
        public static void DeleteCloudHealthDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
