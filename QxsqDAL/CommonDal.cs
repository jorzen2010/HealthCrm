using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QxsqDTO;
using Microsoft.ApplicationBlocks.Data;

namespace QxsqDAL
{
    public class CommonDal
    {
        public static string ConnectionString = "server=(local);database=HealthCrm;uid=sa;password=8;min pool size=512;max pool size=512;";

        #region 删除一个对象
        public static void DeleteObject(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);


        }
        #endregion



        #region 更新一个对象的一个字段
        public static void SetModelBitByAjax(string table, string strwhere, string columnname, string columnvalue)
        {



            SqlParameter[] arParames = new SqlParameter[4];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            arParames[2] = new SqlParameter("@columnname ", SqlDbType.VarChar, 200);
            arParames[2].Value = columnname;

            arParames[3] = new SqlParameter("@columnvalue ", SqlDbType.VarChar, 200);
            arParames[3].Value = columnvalue;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommonDal.ConnectionString, CommandType.StoredProcedure, "setModelBitByAjax", arParames);


        }
        #endregion setBitFiledByAjax



        #region 删除一个Editor对象DTO
        public static void DeleteOneDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion

    }
}
