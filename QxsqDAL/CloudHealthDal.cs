using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QxsqDTO;
using Common;

namespace QxsqDAL
{
    public class CloudHealthDal
    {

       #region 医生添加

        public static void AddCloudHealth(CloudHealthDto cloudHealthDto)
        {

            SqlParameter[] arParames = CloudHealthDal.getParameters(cloudHealthDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateCloudHealth", arParames);

        }
        #endregion

        #region 获取一个医生DTO

        public static CloudHealthDto GetOneCloudHealth(string table,string strwhere)
        {
            CloudHealthDto cloudHealthDto = new CloudHealthDto();

            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;

            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                cloudHealthDto = CloudHealthDal.getDataRowToCloudHealthDto(dr);

            }


            return cloudHealthDto;



        }
        #endregion
        #region 获取医生List数据
        public static List<CloudHealthDto> GetCloudHealthList(string table,string strwhere)
        {
            List<CloudHealthDto> cloudHealthlist = new List<CloudHealthDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                CloudHealthDto cloudHealthDto = new CloudHealthDto();

                cloudHealthDto = CloudHealthDal.getDataRowToCloudHealthDto(dr);


                cloudHealthlist.Add(cloudHealthDto);

            }

            return cloudHealthlist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(CloudHealthDto cloudHealthDto)
        {
            SqlParameter[] arParames = new SqlParameter[8];


            arParames[0] = new SqlParameter("@CloudId", SqlDbType.Int);
            arParames[0].Value = cloudHealthDto.CloudId;

            arParames[1] = new SqlParameter("@CloudDiya", SqlDbType.VarChar, 50);
            arParames[1].Value = cloudHealthDto.CloudDiya;

            arParames[2] = new SqlParameter("@CloudGaoya", SqlDbType.VarChar, 50);
            arParames[2].Value = cloudHealthDto.CloudGaoya;

            arParames[3] = new SqlParameter("@CloudMaibo", SqlDbType.VarChar, 50);
            arParames[3].Value = cloudHealthDto.CloudMaibo;

            arParames[4] = new SqlParameter("@CloudTel", SqlDbType.VarChar, 50);
            arParames[4].Value = cloudHealthDto.CloudTel;

            arParames[5] = new SqlParameter("@CloudImei", SqlDbType.VarChar, 50);
            arParames[5].Value = cloudHealthDto.CloudImei;

            arParames[6] = new SqlParameter("@CloudUser", SqlDbType.VarChar, 50);
            arParames[6].Value = cloudHealthDto.CloudUser;

            arParames[7] = new SqlParameter("@CloudTime", SqlDbType.DateTime);
            arParames[7].Value = cloudHealthDto.CloudTime;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static CloudHealthDto getDataRowToCloudHealthDto(DataRow dr)
        {
            CloudHealthDto cloudHealthDto = new CloudHealthDto();

            cloudHealthDto.CloudId = int.Parse(dr["CloudHealthId"].ToString());
            cloudHealthDto.CloudTel = dr["CloudHealthUserName"].ToString();
            cloudHealthDto.CloudDiya = dr["CloudHealthRealName"].ToString();
            cloudHealthDto.CloudGaoya = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudMaibo = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudImei = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudUser = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudTime = DateTime.Parse(dr["CloudHealthRegTime"].ToString());

            return cloudHealthDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static CloudHealthDto getDataReaderToCloudHealthDto(SqlDataReader dr)
        {
            CloudHealthDto cloudHealthDto = new CloudHealthDto();

            cloudHealthDto.CloudId = int.Parse(dr["CloudHealthId"].ToString());
            cloudHealthDto.CloudTel = dr["CloudHealthUserName"].ToString();
            cloudHealthDto.CloudDiya = dr["CloudHealthRealName"].ToString();
            cloudHealthDto.CloudGaoya = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudMaibo = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudImei = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudUser = dr["CloudHealthPassword"].ToString();
            cloudHealthDto.CloudTime = DateTime.Parse(dr["CloudHealthRegTime"].ToString());
            return cloudHealthDto;
        }

        #endregion

        #region 删除一个CloudHealth对象DTO
        public static void DeleteCloudHealthDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion


        #region 更新一个CloudHealth
        public static void UpdateCloudHealth(CloudHealthDto cloudHealthDto)
        {

            SqlParameter[] arParames = CloudHealthDal.getParameters(cloudHealthDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateCloudHealth", arParames);


        }

        #endregion


        #region 取得单表的查询并进行分页数据
        public static Pager GetCloudHealthPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "CloudId";

            //@PageCurrent --要显示的页码
            arParms[2] = new SqlParameter("@PageCurrent", SqlDbType.Int);
            arParms[2].Value = pager.PageNo + 1;

            // @PageSize --每页的大小(记录数)
            arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[3].Value = pager.PageSize;

            //@FieldShow  --以逗号分隔的要显示的字段列表,如果不指定,则显示所有字段
            arParms[4] = new SqlParameter("@FieldShow", SqlDbType.NVarChar, 500);
            arParms[4].Value = "*";

            //@FieldOrder --以逗号分隔的排序字段列表,可以指定在字段后面指定DESC/ASC用于指定排序顺序

            arParms[5] = new SqlParameter("@FieldOrder", SqlDbType.NVarChar, 500);
            arParms[5].Value = "CloudId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            CloudHealthDto cloudHealthDto = null;
            List<CloudHealthDto> list = new List<CloudHealthDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                cloudHealthDto = CloudHealthDal.getDataRowToCloudHealthDto(dr);
                list.Add(cloudHealthDto);
            }

            var totalItems = (int)arParms[8].Value;

            pager.Amount = totalItems;
            pager.Entity = list.AsQueryable();
            pager.PageCount = (int)arParms[7].Value;

            return pager;
        }
        #endregion
    }
}
