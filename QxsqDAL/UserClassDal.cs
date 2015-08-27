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
    public class UserClassDal
    {

       #region 医生添加

        public static void AddUserClass(UserClassDto userClassDto)
        {

            SqlParameter[] arParames = UserClassDal.getParameters(userClassDto);
             SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
            SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "CreateUserClass", arParames);
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

        #region 获取一个医生DTO

        public static UserClassDto GetOneUserClass(string table,string strwhere)
        {
            UserClassDto userClassDto = new UserClassDto();

            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
             SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                userClassDto = UserClassDal.getDataRowToUserClassDto(dr);

            }


            return userClassDto;

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
        #region 获取医生List数据
        public static List<UserClassDto> GetUserClassList(string tabel,string strwhere)
        {
            List<UserClassDto> userClasslist = new List<UserClassDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = tabel;

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
                UserClassDto userClassDto = new UserClassDto();

                userClassDto = UserClassDal.getDataRowToUserClassDto(dr);


                userClasslist.Add(userClassDto);

            }

            return userClasslist;
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
        private static SqlParameter[] getParameters(UserClassDto userClassDto)
        {
            SqlParameter[] arParames = new SqlParameter[2];


            arParames[0] = new SqlParameter("@UserClassId", SqlDbType.Int);
            arParames[0].Value = userClassDto.UserClassId;

            arParames[1] = new SqlParameter("@UserClassName", SqlDbType.VarChar, 50);
            arParames[1].Value = userClassDto.UserClassName;




            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static UserClassDto getDataRowToUserClassDto(DataRow dr)
        {
            UserClassDto userClassDto = new UserClassDto();

            userClassDto.UserClassId = int.Parse(dr["UserClassId"].ToString());
            userClassDto.UserClassName = dr["UserClassName"].ToString();


            return userClassDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static UserClassDto getDataReaderToUserClassDto(SqlDataReader dr)
        {
            UserClassDto userClassDto = new UserClassDto();
            userClassDto.UserClassId = int.Parse(dr["UserClassId"].ToString());
            userClassDto.UserClassName = dr["UserClassName"].ToString();
            return userClassDto;
        }

        #endregion

        #region 删除一个UserClass对象DTO
        public static void DeleteUserClassDto(string table, string strwhere)
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


        #region 更新一个UserClass
        public static void UpdateUserClass(UserClassDto userClassDto)
        {

            SqlParameter[] arParames = UserClassDal.getParameters(userClassDto);
             SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "UpdateUserClass", arParames);
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
        public static Pager GetUserClassPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "UserClassId";

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
            arParms[5].Value = "UserClassId desc";

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
            UserClassDto userClassDto = null;
            List<UserClassDto> list = new List<UserClassDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                userClassDto = UserClassDal.getDataRowToUserClassDto(dr);
                list.Add(userClassDto);
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
