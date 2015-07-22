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
    public class GuahaoDal
    {

        #region 挂号添加



        public static void AddGuahao(GuahaoDto guahaoDto)
        {

            SqlParameter[] arParames = GuahaoDal.getParameters(guahaoDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateGuahao", arParames);

        }
        #endregion

        #region 获取一个挂号DTO

        public static GuahaoDto GetOneGuahao(string table,string strwhere)
        {
            GuahaoDto guahaoDto = new GuahaoDto();

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

                guahaoDto = GuahaoDal.getDataRowToGuahaoDto(dr);

            }


            return guahaoDto;



        }
        #endregion

        #region 获取挂号List数据
        public static List<GuahaoDto> GetGuahaoList(string strwhere)
        {
            List<GuahaoDto> guahaolist = new List<GuahaoDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqGuahao";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                GuahaoDto GuahaoDto = new GuahaoDto();

                GuahaoDto = GuahaoDal.getDataRowToGuahaoDto(dr);


                guahaolist.Add(GuahaoDto);

            }

            
            return guahaolist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(GuahaoDto guahaoDto)
        {
            SqlParameter[] arParames = new SqlParameter[9];


            arParames[0] = new SqlParameter("@GuahaoId", SqlDbType.Int);
            arParames[0].Value = guahaoDto.GuahaoId;

            arParames[1] = new SqlParameter("@GuahaoName", SqlDbType.VarChar, 500);
            arParames[1].Value = guahaoDto.GuahaoName;

            arParames[2] = new SqlParameter("@GuahaoTel", SqlDbType.VarChar, 50);
            arParames[2].Value = guahaoDto.GuahaoTel;

            arParames[3] = new SqlParameter("@GuahaoTime", SqlDbType.DateTime);
            arParames[3].Value = guahaoDto.GuahaoTime;

            arParames[4] = new SqlParameter("@GuahaoInfo", SqlDbType.Text);
            arParames[4].Value = guahaoDto.GuahaoInfo;

            arParames[5] = new SqlParameter("@GuahaoStatus", SqlDbType.Int);
            arParames[5].Value = guahaoDto.GuahaoStatus;

            arParames[6] = new SqlParameter("@GuahaoDateTime", SqlDbType.DateTime);
            arParames[6].Value = guahaoDto.GuahaoDateTime;

            arParames[7] = new SqlParameter("@GuahaoDoctor", SqlDbType.VarChar, 50);
            arParames[7].Value = guahaoDto.GuahaoDoctor;

            arParames[8] = new SqlParameter("@GuahaoGroup", SqlDbType.VarChar, 50);
            arParames[8].Value = guahaoDto.GuahaoGroup;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static GuahaoDto getDataRowToGuahaoDto(DataRow dr)
        {
            GuahaoDto guahaoDto = new GuahaoDto();

            guahaoDto.GuahaoId = int.Parse(dr["GuahaoId"].ToString());

            guahaoDto.GuahaoName = dr["GuahaoName"].ToString();

            guahaoDto.GuahaoTel = dr["GuahaoTel"].ToString();

            guahaoDto.GuahaoTime = DateTime.Parse(dr["GuahaoTime"].ToString());

            guahaoDto.GuahaoDateTime = DateTime.Parse(dr["GuahaoDateTime"].ToString());
            
            guahaoDto.GuahaoInfo = dr["GuahaoInfo"].ToString();

            guahaoDto.GuahaoDoctor = dr["GuahaoDoctor"].ToString();

            guahaoDto.GuahaoGroup = dr["GuahaoGroup"].ToString();

            guahaoDto.GuahaoStatus =int.Parse(dr["GuahaoStatus"].ToString());

            

            return guahaoDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static GuahaoDto getDataReaderToGuahaoDto(SqlDataReader dr)
        {
            GuahaoDto guahaoDto = new GuahaoDto();

            guahaoDto.GuahaoId = int.Parse(dr["GuahaoId"].ToString());

            guahaoDto.GuahaoName = dr["GuahaoName"].ToString();

            guahaoDto.GuahaoTel = dr["GuahaoTel"].ToString();

            guahaoDto.GuahaoTime = DateTime.Parse(dr["GuahaoTime"].ToString());

            guahaoDto.GuahaoDateTime = DateTime.Parse(dr["GuahaoDateTime"].ToString());

            guahaoDto.GuahaoInfo = dr["GuahaoInfo"].ToString();

            guahaoDto.GuahaoDoctor = dr["GuahaoDoctor"].ToString();

            guahaoDto.GuahaoGroup = dr["GuahaoGroup"].ToString();

            guahaoDto.GuahaoStatus = int.Parse(dr["GuahaoStatus"].ToString());

            return guahaoDto;
        }

        #endregion


        #region 删除一个Guahao对象DTO
        public static void DeleteGuahaoDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion
        
        #region 更新一个Guahao
        public static void UpdateGuahao(GuahaoDto guahaoDto)
        {

            SqlParameter[] arParames = GuahaoDal.getParameters(guahaoDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateGuahao", arParames);


        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetGuahaoPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "GuahaoId";

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
            arParms[5].Value = "GuahaoId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            GuahaoDto GuahaoDto = null;
            List<GuahaoDto> list = new List<GuahaoDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                GuahaoDto = GuahaoDal.getDataRowToGuahaoDto(dr);
                list.Add(GuahaoDto);
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
