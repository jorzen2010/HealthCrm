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
    public class DoctorDal
    {

       #region 网站管理员添加

        public static void AddDoctor(DoctorDto doctorDto)
        {

            SqlParameter[] arParames = DoctorDal.getParameters(doctorDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateDoctor", arParames);

        }
        #endregion

        #region 获取一个网站管理员DTO

        public static DoctorDto GetOneDoctor(string table,string strwhere)
        {
            DoctorDto doctorDto = new DoctorDto();

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

                doctorDto = DoctorDal.getDataRowToDoctorDto(dr);

            }


            return doctorDto;



        }
        #endregion
        #region 获取网站管理员List数据
        public static List<DoctorDto> GetDoctorList(string strwhere)
        {
            List<DoctorDto> doctorlist = new List<DoctorDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqDoctor";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                DoctorDto doctorDto = new DoctorDto();

                doctorDto = DoctorDal.getDataRowToDoctorDto(dr);


                doctorlist.Add(doctorDto);

            }

            return doctorlist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(DoctorDto doctorDto)
        {
            SqlParameter[] arParames = new SqlParameter[5];


            arParames[0] = new SqlParameter("@DoctorId", SqlDbType.Int);
            arParames[0].Value = doctorDto.DoctorId;

            arParames[1] = new SqlParameter("@DoctorUserName", SqlDbType.VarChar, 50);
            arParames[1].Value = doctorDto.DoctorUserName;

            arParames[2] = new SqlParameter("@DoctorPassword", SqlDbType.VarChar, 50);
            arParames[2].Value = doctorDto.DoctorPassword;

            arParames[3] = new SqlParameter("@DoctorRealName", SqlDbType.VarChar, 50);
            arParames[3].Value = doctorDto.DoctorRealName;

            arParames[4] = new SqlParameter("@DoctorRegTime", SqlDbType.DateTime);
            arParames[4].Value = doctorDto.DoctorRegTime;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static DoctorDto getDataRowToDoctorDto(DataRow dr)
        {
            DoctorDto doctorDto = new DoctorDto();

            doctorDto.DoctorId = int.Parse(dr["DoctorId"].ToString());
            doctorDto.DoctorUserName = dr["DoctorUserName"].ToString();
            doctorDto.DoctorRealName = dr["DoctorRealName"].ToString();

            doctorDto.DoctorPassword = dr["DoctorPassword"].ToString();

            doctorDto.DoctorRegTime = DateTime.Parse(dr["DoctorRegTime"].ToString());

            return doctorDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static DoctorDto getDataReaderToDoctorDto(SqlDataReader dr)
        {
            DoctorDto doctorDto = new DoctorDto();


            doctorDto.DoctorId = int.Parse(dr["DoctorId"].ToString());
            doctorDto.DoctorUserName = dr["DoctorUserName"].ToString();
            doctorDto.DoctorRealName = dr["DoctorRealName"].ToString();

            doctorDto.DoctorPassword = dr["DoctorPassword"].ToString();

            doctorDto.DoctorRegTime = DateTime.Parse(dr["DoctorRegTime"].ToString());
            return doctorDto;
        }

        #endregion

        #region 删除一个Doctor对象DTO
        public static void DeleteDoctorDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion


        #region 更新一个Doctor
        public static void UpdateDoctor(DoctorDto doctorDto)
        {

            SqlParameter[] arParames = DoctorDal.getParameters(doctorDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateDoctor", arParames);


        }

        #endregion


        #region 取得单表的查询并进行分页数据
        public static Pager GetDoctorPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "DoctorId";

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
            arParms[5].Value = "DoctorId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            DoctorDto doctorDto = null;
            List<DoctorDto> list = new List<DoctorDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                doctorDto = DoctorDal.getDataRowToDoctorDto(dr);
                list.Add(doctorDto);
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
