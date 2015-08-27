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
    public class HealthDal
    {

        #region 客户添加



        public static void AddHealth(HealthDto healthDto)
        {

            SqlParameter[] arParames = HealthDal.getParameters(healthDto);
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
            SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "CreateHealth", arParames);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }
        }
        #endregion

        #region 获取一个客户DTO

        public static HealthDto GetOneHealth(string table,string strwhere)
        {
            HealthDto healthDto = new HealthDto();

            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
            DataTable dt = null;

            DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                healthDto = HealthDal.getDataRowToHealthDto(dr);

            }


            return healthDto;
}
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }


        }
        #endregion

        #region 获取客户List数据
        public static List<HealthDto> GetHealthList(string table,string strwhere)
        {
            List<HealthDto> userlist = new List<HealthDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                HealthDto HealthDto = new HealthDto();

                HealthDto = HealthDal.getDataRowToHealthDto(dr);


                userlist.Add(HealthDto);

            }

            
            return userlist;
}
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }
        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(HealthDto healthDto)
        {
            SqlParameter[] arParames = new SqlParameter[22];


            arParames[0] = new SqlParameter("@HealthId", SqlDbType.Int);
            arParames[0].Value = healthDto.HealthId;

            arParames[1] = new SqlParameter("@HealthUserId  ", SqlDbType.Int);
            arParames[1].Value = healthDto.HealthUserId;

            arParames[2] = new SqlParameter("@HealthXuexing  ", SqlDbType.VarChar, 50);
            arParames[2].Value = healthDto.HealthXuexing;

            arParames[3] = new SqlParameter("@HealthRH  ", SqlDbType.VarChar, 50);
            arParames[3].Value = healthDto.HealthRH;

            arParames[4] = new SqlParameter("@HealthFeiyong  ", SqlDbType.VarChar, 500);
            arParames[4].Value = healthDto.HealthFeiyong;

            arParames[5] = new SqlParameter("@HealthGuomin  ", SqlDbType.VarChar, 50);
            arParames[5].Value = healthDto.HealthGuomin;

            arParames[6] = new SqlParameter("@HealthBaolou  ", SqlDbType.VarChar, 50);
            arParames[6].Value = healthDto.HealthBaolou;

            arParames[7] = new SqlParameter("@HealthJibing  ", SqlDbType.VarChar, 50);
            arParames[7].Value = healthDto.HealthJibing;

            arParames[8] = new SqlParameter("@HealthShoushu  ", SqlDbType.VarChar, 50);
            arParames[8].Value = healthDto.HealthShoushu;

            arParames[9] = new SqlParameter("@HealthWaishang  ", SqlDbType.VarChar, 50);
            arParames[9].Value = healthDto.HealthWaishang;

            arParames[10] = new SqlParameter("@HealthShuxue ", SqlDbType.VarChar, 50);
            arParames[10].Value = healthDto.HealthShuxue;

            arParames[11] = new SqlParameter("@HealthJiazuDady ", SqlDbType.VarChar, 50);
            arParames[11].Value = healthDto.HealthJiazuDady;

            arParames[12] = new SqlParameter("@HealthJiazuMama ", SqlDbType.VarChar, 50);
            arParames[12].Value = healthDto.HealthJiazuMama;

            arParames[13] = new SqlParameter("@HealthJiazuXiongdi ", SqlDbType.VarChar, 50);
            arParames[13].Value = healthDto.HealthJiazuXiongdi;

            arParames[14] = new SqlParameter("@HealthJiazuZinv ", SqlDbType.VarChar, 50);
            arParames[14].Value = healthDto.HealthJiazuZinv;

            arParames[15] = new SqlParameter("@HealthYichuan ", SqlDbType.VarChar, 50);
            arParames[15].Value = healthDto.HealthYichuan;

            arParames[16] = new SqlParameter("@HealthCanji ", SqlDbType.VarChar, 50);
            arParames[16].Value = healthDto.HealthCanji;

            arParames[17] = new SqlParameter("@HealthChufang ", SqlDbType.VarChar, 50);
            arParames[17].Value = healthDto.HealthChufang;

            arParames[18] = new SqlParameter("@HealthRanliao ", SqlDbType.VarChar, 50);
            arParames[18].Value = healthDto.HealthRanliao;

            arParames[19] = new SqlParameter("@HealthYinshui ", SqlDbType.VarChar, 50);
            arParames[19].Value = healthDto.HealthYinshui;

            arParames[20] = new SqlParameter("@HealthCesuo ", SqlDbType.VarChar, 50);
            arParames[20].Value = healthDto.HealthCesuo;

            arParames[21] = new SqlParameter("@HealthQichulan ", SqlDbType.VarChar, 500);
            arParames[21].Value = healthDto.HealthQichulan;




            
            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static HealthDto getDataRowToHealthDto(DataRow dr)
        {
            HealthDto healthDto = new HealthDto();

            healthDto.HealthId = int.Parse(dr["HealthId"].ToString());
            healthDto.HealthUserId = int.Parse(dr["HealthUserId"].ToString());
            healthDto.HealthXuexing = dr["HealthXuexing"].ToString();
            healthDto.HealthRH = dr["HealthRH"].ToString();
            healthDto.HealthFeiyong = dr["HealthFeiyong"].ToString();
            healthDto.HealthGuomin = dr["HealthGuomin"].ToString();
            healthDto.HealthBaolou = dr["HealthBaolou"].ToString();
            healthDto.HealthJibing = dr["HealthJibing"].ToString();
            healthDto.HealthShoushu = dr["HealthShoushu"].ToString();
            healthDto.HealthWaishang = dr["HealthWaishang"].ToString();
            healthDto.HealthShuxue = dr["HealthShuxue"].ToString();
            healthDto.HealthJiazuDady = dr["HealthJiazuDady"].ToString();
            healthDto.HealthJiazuMama = dr["HealthJiazuMama"].ToString();
            healthDto.HealthJiazuXiongdi = dr["HealthJiazuXiongdi"].ToString();
            healthDto.HealthJiazuZinv = dr["HealthJiazuZinv"].ToString();
            healthDto.HealthYichuan = dr["HealthYichuan"].ToString();
            healthDto.HealthCanji = dr["HealthCanji"].ToString();
            healthDto.HealthChufang = dr["HealthChufang"].ToString();
            healthDto.HealthRanliao = dr["HealthRanliao"].ToString();
            healthDto.HealthYinshui = dr["HealthYinshui"].ToString();
            healthDto.HealthCesuo = dr["HealthCesuo"].ToString();
            healthDto.HealthQichulan = dr["HealthQichulan"].ToString();

            

            return healthDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static HealthDto getDataReaderToHealthDto(SqlDataReader dr)
        {
            HealthDto healthDto = new HealthDto();

            healthDto.HealthId = int.Parse(dr["HealthId"].ToString());
            healthDto.HealthUserId = int.Parse(dr["HealthUserId"].ToString());
            healthDto.HealthXuexing = dr["HealthXuexing"].ToString();
            healthDto.HealthRH = dr["HealthRH"].ToString();
            healthDto.HealthFeiyong = dr["HealthFeiyong"].ToString();
            healthDto.HealthGuomin = dr["HealthGuomin"].ToString();
            healthDto.HealthBaolou = dr["HealthBaolou"].ToString();
            healthDto.HealthJibing = dr["HealthJibing"].ToString();
            healthDto.HealthShoushu = dr["HealthShoushu"].ToString();
            healthDto.HealthWaishang = dr["HealthWaishang"].ToString();
            healthDto.HealthShuxue = dr["HealthShuxue"].ToString();
            healthDto.HealthJiazuDady = dr["HealthJiazuDady"].ToString();
            healthDto.HealthJiazuMama = dr["HealthJiazuMama"].ToString();
            healthDto.HealthJiazuXiongdi = dr["HealthJiazuXiongdi"].ToString();
            healthDto.HealthJiazuZinv = dr["HealthJiazuZinv"].ToString();
            healthDto.HealthYichuan = dr["HealthYichuan"].ToString();
            healthDto.HealthCanji = dr["HealthCanji"].ToString();
            healthDto.HealthChufang = dr["HealthChufang"].ToString();
            healthDto.HealthRanliao = dr["HealthRanliao"].ToString();
            healthDto.HealthYinshui = dr["HealthYinshui"].ToString();
            healthDto.HealthCesuo = dr["HealthCesuo"].ToString();
            healthDto.HealthQichulan = dr["HealthQichulan"].ToString();

            return healthDto;
        }

        #endregion


        #region 删除一个Health对象DTO
        public static void DeleteHealthDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "deleteModelByWhere", arParames);

}
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

        }
        #endregion
        
        #region 更新一个Health
        public static void UpdateHealth(HealthDto healthDto)
        {

            SqlParameter[] arParames = HealthDal.getParameters(healthDto);
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "UpdateHealth", arParames);
}
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetHealthPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "HealthId";

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
            arParms[5].Value = "HealthId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
            HealthDto HealthDto = null;
            List<HealthDto> list = new List<HealthDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                HealthDto = HealthDal.getDataRowToHealthDto(dr);
                list.Add(HealthDto);
            }

            var totalItems = (int)arParms[8].Value;

            pager.Amount = totalItems;
            pager.Entity = list.AsQueryable();
            pager.PageCount = (int)arParms[7].Value;

            return pager;
                }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }
        }
        #endregion
    }
}
