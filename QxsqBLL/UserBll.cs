using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QxsqDTO;
using QxsqDAL;
using Common;

namespace QxsqBLL
{
    public class UserBll
    {
         


        public static List<UserDto> GetUserDtoList(string strwhere)
        {
            return UserDal.GetUserList(strwhere);
        }



        #region 得到一个UserPager 
        public static Pager GetUserPager(Pager pager,string strwhere,string table)
        {


            //return UserDal.GetUserPage(pager, strwhere,table);
            return UserDal.GetUserPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddUser(UserDto userDto)
        {
            UserDal.AddUser(userDto);
     
        }


        #endregion

        #region 获取一个User
        public static UserDto GetOneUserDto(string table,string strwhere)
        {
            UserDto userDto=new UserDto();

            userDto = UserDal.GetOneUser(table, strwhere);

            return userDto;
        }


        #endregion

        #region 更新User

        public static void UpdateUserDto(UserDto userDto)
        {
            UserDal.UpdateUser(userDto);
        }

        #endregion

        #region 删除User
        public static void DeleteUserDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
