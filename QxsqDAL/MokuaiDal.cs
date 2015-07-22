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
    public class MokuaiDal
    {

        #region 模块添加

        public static void AddMokuai(MokuaiDto mokuaiDto)
        {

            SqlParameter[] arParames = MokuaiDal.getParameters(mokuaiDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateMokuai", arParames);

        }
        #endregion

        #region 获取一个模块DTO

        public static MokuaiDto GetOneMokuai(string table,string strwhere)
        {
            MokuaiDto mokuaiDto = new MokuaiDto();

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

                mokuaiDto = MokuaiDal.getDataRowToMokuaiDto(dr);

            }


            return mokuaiDto;



        }
        #endregion

        #region 获取模块List数据
        public static List<MokuaiDto> GetMokuaiList(string strwhere)
        {
            List<MokuaiDto> mokuailist = new List<MokuaiDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqMokuai";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                MokuaiDto MokuaiDto = new MokuaiDto();

                MokuaiDto = MokuaiDal.getDataRowToMokuaiDto(dr);


                mokuailist.Add(MokuaiDto);

            }

            return mokuailist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(MokuaiDto mokuaiDto)
        {
            SqlParameter[] arParames = new SqlParameter[6];


            arParames[0] = new SqlParameter("@MokuaiId", SqlDbType.Int);
            arParames[0].Value = mokuaiDto.MokuaiId;

            arParames[1] = new SqlParameter("@MokuaiTitle", SqlDbType.VarChar, 500);
            arParames[1].Value = mokuaiDto.MokuaiTitle;

            arParames[2] = new SqlParameter("@MokuaiImg", SqlDbType.VarChar, 500);
            arParames[2].Value = mokuaiDto.MokuaiImg;

            arParames[3] = new SqlParameter("@MokuaiContent", SqlDbType.Text);
            arParames[3].Value = mokuaiDto.MokuaiContent;

            arParames[4] = new SqlParameter("@MokuaiInfo", SqlDbType.Text);
            arParames[4].Value = mokuaiDto.MokuaiInfo;

            arParames[5] = new SqlParameter("@MokuaiDateTime", SqlDbType.DateTime);
            arParames[5].Value = mokuaiDto.MokuaiDateTime;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static MokuaiDto getDataRowToMokuaiDto(DataRow dr)
        {
            MokuaiDto mokuaiDto = new MokuaiDto();

            mokuaiDto.MokuaiId = int.Parse(dr["MokuaiId"].ToString());
            mokuaiDto.MokuaiTitle = dr["MokuaiTitle"].ToString();
            mokuaiDto.MokuaiImg = dr["MokuaiImg"].ToString();

            mokuaiDto.MokuaiContent = dr["MokuaiContent"].ToString();
            mokuaiDto.MokuaiInfo = dr["MokuaiInfo"].ToString();

            mokuaiDto.MokuaiDateTime = DateTime.Parse(dr["MokuaiDateTime"].ToString());

            return mokuaiDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static MokuaiDto getDataReaderToMokuaiDto(SqlDataReader dr)
        {
            MokuaiDto mokuaiDto = new MokuaiDto();

            mokuaiDto.MokuaiId = int.Parse(dr["MokuaiId"].ToString());
            mokuaiDto.MokuaiTitle = dr["MokuaiTitle"].ToString();
            mokuaiDto.MokuaiImg = dr["MokuaiImg"].ToString();

            mokuaiDto.MokuaiContent = dr["MokuaiContent"].ToString();
            mokuaiDto.MokuaiInfo = dr["MokuaiInfo"].ToString();

            mokuaiDto.MokuaiDateTime = DateTime.Parse(dr["MokuaiDateTime"].ToString());

            return mokuaiDto;
        }

        #endregion


        #region 删除一个Mokuai对象DTO
        public static void DeleteMokuaiDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion
        
        #region 更新一个Mokuai
        public static void UpdateMokuai(MokuaiDto mokuaiDto)
        {

            SqlParameter[] arParames = MokuaiDal.getParameters(mokuaiDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateMokuai", arParames);


        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetMokuaiPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "MokuaiId";

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
            arParms[5].Value = "MokuaiId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            MokuaiDto MokuaiDto = null;
            List<MokuaiDto> list = new List<MokuaiDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                MokuaiDto = MokuaiDal.getDataRowToMokuaiDto(dr);
                list.Add(MokuaiDto);
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
