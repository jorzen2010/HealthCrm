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
    public class JiwangshiDal
    {

       #region 医生添加

        public static void AddJiwangshi(JiwangshiDto jiwangshiDto)
        {

            SqlParameter[] arParames = JiwangshiDal.getParameters(jiwangshiDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateJiwangshi", arParames);

        }
        #endregion

        #region 获取一个医生DTO

        public static JiwangshiDto GetOneJiwangshi(string table,string strwhere)
        {
            JiwangshiDto jiwangshiDto = new JiwangshiDto();

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

                jiwangshiDto = JiwangshiDal.getDataRowToJiwangshiDto(dr);

            }


            return jiwangshiDto;



        }
        #endregion
        #region 获取医生List数据
        public static List<JiwangshiDto> GetJiwangshiList(string table,string strwhere)
        {
            List<JiwangshiDto> jiwangshilist = new List<JiwangshiDto>();



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
                JiwangshiDto jiwangshiDto = new JiwangshiDto();

                jiwangshiDto = JiwangshiDal.getDataRowToJiwangshiDto(dr);


                jiwangshilist.Add(jiwangshiDto);

            }

            return jiwangshilist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(JiwangshiDto jiwangshiDto)
        {
            SqlParameter[] arParames = new SqlParameter[6];


            arParames[0] = new SqlParameter("@JiwangshiId", SqlDbType.Int);
            arParames[0].Value = jiwangshiDto.JiwangshiId;

            arParames[1] = new SqlParameter("@JiwangshiName", SqlDbType.VarChar, 50);
            arParames[1].Value = jiwangshiDto.JiwangshiName;

            arParames[2] = new SqlParameter("@JiwangshiJibingClass", SqlDbType.VarChar, 50);
            arParames[2].Value = jiwangshiDto.JiwangshiJibingClass;

            arParames[3] = new SqlParameter("@JiwangshiUserId", SqlDbType.Int);
            arParames[3].Value = jiwangshiDto.JiwangshiUserId;

            arParames[4] = new SqlParameter("@JiwangshiTime", SqlDbType.DateTime);
            arParames[4].Value = jiwangshiDto.JiwangshiTime;

            arParames[5] = new SqlParameter("@JiwangshiClass", SqlDbType.VarChar, 50);
            arParames[5].Value = jiwangshiDto.JiwangshiClass;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static JiwangshiDto getDataRowToJiwangshiDto(DataRow dr)
        {
            JiwangshiDto jiwangshiDto = new JiwangshiDto();

            jiwangshiDto.JiwangshiId = int.Parse(dr["JiwangshiId"].ToString());
            jiwangshiDto.JiwangshiName = dr["JiwangshiName"].ToString();
            jiwangshiDto.JiwangshiJibingClass = dr["JiwangshiJibingClass"].ToString();

            jiwangshiDto.JiwangshiUserId = int.Parse(dr["JiwangshiUserId"].ToString());
            jiwangshiDto.JiwangshiClass = dr["JiwangshiClass"].ToString();

            jiwangshiDto.JiwangshiTime = DateTime.Parse(dr["JiwangshiTime"].ToString());

            return jiwangshiDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static JiwangshiDto getDataReaderToJiwangshiDto(SqlDataReader dr)
        {
            JiwangshiDto jiwangshiDto = new JiwangshiDto();

            jiwangshiDto.JiwangshiId = int.Parse(dr["JiwangshiId"].ToString());
            jiwangshiDto.JiwangshiName = dr["JiwangshiName"].ToString();
            jiwangshiDto.JiwangshiJibingClass = dr["JiwangshiJibingClass"].ToString();

            jiwangshiDto.JiwangshiUserId = int.Parse(dr["JiwangshiPassword"].ToString());
            jiwangshiDto.JiwangshiClass = dr["JiwangshiClass"].ToString();

            jiwangshiDto.JiwangshiTime = DateTime.Parse(dr["JiwangshiTime"].ToString());
            return jiwangshiDto;
        }

        #endregion

        #region 删除一个Jiwangshi对象DTO
        public static void DeleteJiwangshiDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion


        #region 更新一个Jiwangshi
        public static void UpdateJiwangshi(JiwangshiDto jiwangshiDto)
        {

            SqlParameter[] arParames = JiwangshiDal.getParameters(jiwangshiDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateJiwangshi", arParames);


        }

        #endregion


        #region 取得单表的查询并进行分页数据
        public static Pager GetJiwangshiPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "JiwangshiId";

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
            arParms[5].Value = "JiwangshiId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            JiwangshiDto jiwangshiDto = null;
            List<JiwangshiDto> list = new List<JiwangshiDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                jiwangshiDto = JiwangshiDal.getDataRowToJiwangshiDto(dr);
                list.Add(jiwangshiDto);
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
