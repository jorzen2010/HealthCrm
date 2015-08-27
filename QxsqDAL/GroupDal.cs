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
    public class GroupDal
    {

       #region 医生添加

        public static void AddGroup(GroupDto groupDto)
        {

            SqlParameter[] arParames = GroupDal.getParameters(groupDto);
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "CreateGroup", arParames);
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

        public static GroupDto GetOneGroup(string table,string strwhere)
        {
            GroupDto groupDto = new GroupDto();

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

                groupDto = GroupDal.getDataRowToGroupDto(dr);

            }


            return groupDto;

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
        public static List<GroupDto> GetGroupList(string tabel,string strwhere)
        {
            List<GroupDto> grouplist = new List<GroupDto>();



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
                GroupDto groupDto = new GroupDto();

                groupDto = GroupDal.getDataRowToGroupDto(dr);


                grouplist.Add(groupDto);

            }

            return grouplist;
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
        private static SqlParameter[] getParameters(GroupDto groupDto)
        {
            SqlParameter[] arParames = new SqlParameter[3];


            arParames[0] = new SqlParameter("@GroupId", SqlDbType.Int);
            arParames[0].Value = groupDto.GroupId;

            arParames[1] = new SqlParameter("@GroupName", SqlDbType.VarChar, 50);
            arParames[1].Value = groupDto.GroupName;

            arParames[2] = new SqlParameter("@GroupInfo", SqlDbType.Text);
            arParames[2].Value = groupDto.GroupInfo;



            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static GroupDto getDataRowToGroupDto(DataRow dr)
        {
            GroupDto groupDto = new GroupDto();

            groupDto.GroupId = int.Parse(dr["GroupId"].ToString());
            groupDto.GroupName = dr["GroupName"].ToString();
            groupDto.GroupInfo = dr["GroupInfo"].ToString();


            return groupDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static GroupDto getDataReaderToGroupDto(SqlDataReader dr)
        {
            GroupDto groupDto = new GroupDto();
            groupDto.GroupId = int.Parse(dr["GroupId"].ToString());
            groupDto.GroupName = dr["GroupName"].ToString();
            groupDto.GroupInfo = dr["GroupInfo"].ToString();
            return groupDto;
        }

        #endregion

        #region 删除一个Group对象DTO
        public static void DeleteGroupDto(string table, string strwhere)
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


        #region 更新一个Group
        public static void UpdateGroup(GroupDto groupDto)
        {

            SqlParameter[] arParames = GroupDal.getParameters(groupDto);
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "UpdateGroup", arParames);

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
        public static Pager GetGroupPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "GroupId";

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
            arParms[5].Value = "GroupId desc";

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
            GroupDto groupDto = null;
            List<GroupDto> list = new List<GroupDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(myconn, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                groupDto = GroupDal.getDataRowToGroupDto(dr);
                list.Add(groupDto);
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
