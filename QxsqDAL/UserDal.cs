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
    public class UserDal
    {

        #region 客户添加



        public static void AddUser(UserDto userDto)
        {

            SqlParameter[] arParames = UserDal.getParameters(userDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateUser", arParames);

        }
        #endregion

        #region 获取一个客户DTO

        public static UserDto GetOneUser(string table,string strwhere)
        {
            UserDto userDto = new UserDto();

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

                userDto = UserDal.getDataRowToUserDto(dr);

            }


            return userDto;



        }
        #endregion

        #region 获取客户List数据
        public static List<UserDto> GetUserList(string strwhere)
        {
            List<UserDto> userlist = new List<UserDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqUser";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                UserDto UserDto = new UserDto();

                UserDto = UserDal.getDataRowToUserDto(dr);


                userlist.Add(UserDto);

            }

            
            return userlist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(UserDto userDto)
        {
            SqlParameter[] arParames = new SqlParameter[29];


            arParames[0] = new SqlParameter("@UserId", SqlDbType.Int);
            arParames[0].Value = userDto.UserId;

            arParames[1] = new SqlParameter("@UserPassword ", SqlDbType.VarChar, 50);
            arParames[1].Value = userDto.UserPassword;

            arParames[2] = new SqlParameter("@UserName ", SqlDbType.VarChar, 50);
            arParames[2].Value = userDto.UserName;

            arParames[3] = new SqlParameter("@UserSex ", SqlDbType.VarChar, 50);
            arParames[3].Value = userDto.UserSex;

            arParames[4] = new SqlParameter("@UserBirthday ", SqlDbType.DateTime);
            arParames[4].Value = userDto.UserBirthday;

            arParames[5] = new SqlParameter("@UserNumber ", SqlDbType.VarChar, 50);
            arParames[5].Value = userDto.UserNumber;

            arParames[6] = new SqlParameter("@UserTel ", SqlDbType.VarChar, 50);
            arParames[6].Value = userDto.UserTel;

            arParames[7] = new SqlParameter("@UserFirstPerson ", SqlDbType.VarChar, 50);
            arParames[7].Value = userDto.UserFirstPerson;

            arParames[8] = new SqlParameter("@UserFirstPersonTel ", SqlDbType.VarChar, 50);
            arParames[8].Value = userDto.UserFirstPersonTel;

            arParames[9] = new SqlParameter("@UserJiedaoName ", SqlDbType.VarChar, 50);
            arParames[9].Value = userDto.UserJiedaoName;

            arParames[10] = new SqlParameter("@UserJuweihuiName", SqlDbType.VarChar, 50);
            arParames[10].Value = userDto.UserJuweihuiName;

            arParames[11] = new SqlParameter("@UserHuji", SqlDbType.VarChar, 50);
            arParames[11].Value = userDto.UserHuji;

            arParames[12] = new SqlParameter("@UserMinzu", SqlDbType.VarChar, 50);
            arParames[12].Value = userDto.UserMinzu;

            arParames[13] = new SqlParameter("@UserWenhua", SqlDbType.VarChar, 50);
            arParames[13].Value = userDto.UserWenhua;

            arParames[14] = new SqlParameter("@UserZhiye", SqlDbType.VarChar, 50);
            arParames[14].Value = userDto.UserZhiye;

            arParames[15] = new SqlParameter("@UserHunyin", SqlDbType.VarChar, 50);
            arParames[15].Value = userDto.UserHunyin;

            arParames[16] = new SqlParameter("@UserBeizhu", SqlDbType.Text);
            arParames[16].Value = userDto.UserBeizhu;

            arParames[17] = new SqlParameter("@UserDoctor", SqlDbType.Int);
            arParames[17].Value = userDto.UserDoctor;

            arParames[18] = new SqlParameter("@UserGroup", SqlDbType.Int);
            arParames[18].Value = userDto.UserGroup;

            arParames[19] = new SqlParameter("@UserClass", SqlDbType.VarChar, 500);
            arParames[19].Value = userDto.UserClass;

            arParames[20] = new SqlParameter("@UserNowAddress", SqlDbType.VarChar, 500);
            arParames[20].Value = userDto.UserNowAddress;

            arParames[21] = new SqlParameter("@UserOldAddress", SqlDbType.VarChar, 500);
            arParames[21].Value = userDto.UserOldAddress;

            arParames[22] = new SqlParameter("@UserJobGroup", SqlDbType.VarChar, 500);
            arParames[22].Value = userDto.UserJobGroup;

            arParames[23] = new SqlParameter("@UserDiy1", SqlDbType.VarChar, 500);
            arParames[23].Value = userDto.UserDiy1;

            arParames[24] = new SqlParameter("@UserDiy2", SqlDbType.VarChar, 500);
            arParames[24].Value = userDto.UserDiy2;

            arParames[25] = new SqlParameter("@UserDiy3", SqlDbType.VarChar, 500);
            arParames[25].Value = userDto.UserDiy3;

            arParames[26] = new SqlParameter("@UserDiy4", SqlDbType.VarChar, 500);
            arParames[26].Value = userDto.UserDiy4;

            arParames[27] = new SqlParameter("@UserDiy5", SqlDbType.VarChar, 500);
            arParames[27].Value = userDto.UserDiy5;

            arParames[28] = new SqlParameter("@UserDiy6", SqlDbType.VarChar, 500);
            arParames[28].Value = userDto.UserDiy6;



            
            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static UserDto getDataRowToUserDto(DataRow dr)
        {
            UserDto userDto = new UserDto();

            userDto.UserId = int.Parse(dr["UserId"].ToString());
            userDto.UserPassword = dr["UserPassword"].ToString();
            userDto.UserName = dr["UserName"].ToString();
            userDto.UserSex = dr["UserSex"].ToString();
            userDto.UserBirthday =DateTime.Parse(dr["UserBirthday"].ToString());
            userDto.UserNumber = dr["UserNumber"].ToString();
            userDto.UserTel = dr["UserTel"].ToString();
            userDto.UserFirstPerson = dr["UserFirstPerson"].ToString();
            userDto.UserFirstPersonTel = dr["UserFirstPersonTel"].ToString();
            userDto.UserJiedaoName = dr["UserJiedaoName"].ToString();
            userDto.UserJuweihuiName = dr["UserJuweihuiName"].ToString();
            userDto.UserHuji = dr["UserHuji"].ToString();
            userDto.UserMinzu = dr["UserMinzu"].ToString();
            userDto.UserWenhua = dr["UserWenhua"].ToString();
            userDto.UserZhiye = dr["UserZhiye"].ToString();
            userDto.UserHunyin = dr["UserHunyin"].ToString();
            userDto.UserDoctor = int.Parse(dr["UserDoctor"].ToString());
            userDto.UserGroup = int.Parse(dr["UserGroup"].ToString());
            userDto.UserClass = dr["UserClass"].ToString();
            userDto.UserNowAddress = dr["UserNowAddress"].ToString();
            userDto.UserOldAddress = dr["UserOldAddress"].ToString();
            userDto.UserJobGroup = dr["UserJobGroup"].ToString();
            userDto.UserDiy1 = dr["UserDiy1"].ToString();
            userDto.UserDiy2 = dr["UserDiy2"].ToString();
            userDto.UserDiy3 = dr["UserDiy3"].ToString();
            userDto.UserDiy4 = dr["UserDiy4"].ToString();
            userDto.UserDiy5 = dr["UserDiy5"].ToString();
            userDto.UserDiy6 = dr["UserDiy6"].ToString();
            userDto.UserBeizhu = dr["UserBeizhu"].ToString();

            

            return userDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static UserDto getDataReaderToUserDto(SqlDataReader dr)
        {
            UserDto userDto = new UserDto();

            userDto.UserId = int.Parse(dr["UserId"].ToString());
            userDto.UserPassword = dr["UserPassword"].ToString();
            userDto.UserName = dr["UserName"].ToString();
            userDto.UserSex = dr["UserSex"].ToString();
            userDto.UserBirthday = DateTime.Parse(dr["UserBirthday"].ToString());
            userDto.UserNumber = dr["UserNumber"].ToString();
            userDto.UserTel = dr["UserTel"].ToString();
            userDto.UserFirstPerson = dr["UserFirstPerson"].ToString();
            userDto.UserFirstPersonTel = dr["UserFirstPersonTel"].ToString();
            userDto.UserJiedaoName = dr["UserJiedaoName"].ToString();
            userDto.UserJuweihuiName = dr["UserJuweihuiName"].ToString();
            userDto.UserHuji = dr["UserHuji"].ToString();
            userDto.UserMinzu = dr["UserMinzu"].ToString();
            userDto.UserWenhua = dr["UserWenhua"].ToString();
            userDto.UserZhiye = dr["UserZhiye"].ToString();
            userDto.UserHunyin = dr["UserHunyin"].ToString();
            userDto.UserDoctor = int.Parse(dr["UserDoctor"].ToString());
            userDto.UserGroup = int.Parse(dr["UserGroup"].ToString());
            userDto.UserClass = dr["UserClass"].ToString();
            userDto.UserNowAddress = dr["UserNowAddress"].ToString();
            userDto.UserOldAddress = dr["UserOldAddress"].ToString();
            userDto.UserJobGroup = dr["UserJobGroup"].ToString();
            userDto.UserDiy1 = dr["UserDiy1"].ToString();
            userDto.UserDiy2 = dr["UserDiy2"].ToString();
            userDto.UserDiy3 = dr["UserDiy3"].ToString();
            userDto.UserDiy4 = dr["UserDiy4"].ToString();
            userDto.UserDiy5 = dr["UserDiy5"].ToString();
            userDto.UserDiy6 = dr["UserDiy6"].ToString();
            userDto.UserBeizhu = dr["UserBeizhu"].ToString();

            return userDto;
        }

        #endregion


        #region 删除一个User对象DTO
        public static void DeleteUserDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion
        
        #region 更新一个User
        public static void UpdateUser(UserDto userDto)
        {

            SqlParameter[] arParames = UserDal.getParameters(userDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateUser", arParames);


        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetUserPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "UserId";

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
            arParms[5].Value = "UserId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            UserDto UserDto = null;
            List<UserDto> list = new List<UserDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                UserDto = UserDal.getDataRowToUserDto(dr);
                list.Add(UserDto);
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
