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
    public class UserClassBll
    {
         


        public static List<UserClassDto> GetUserClassDtoList(string table,string strwhere)
        {
            return UserClassDal.GetUserClassList(table,strwhere);
        }



        #region 得到一个UserClassPager 
        public static Pager GetUserClassPager(Pager pager,string strwhere,string table)
        {


            //return UserClassDal.GetUserClassPage(pager, strwhere,table);
            return UserClassDal.GetUserClassPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddUserClass(UserClassDto userClassDto)
        {
            UserClassDal.AddUserClass(userClassDto);
     
        }


        #endregion

        #region 获取一个UserClass
        public static UserClassDto GetOneUserClassDto(string table,string strwhere)
        {
            UserClassDto userClassDto=new UserClassDto();

            userClassDto = UserClassDal.GetOneUserClass(table, strwhere);

            return userClassDto;
        }


        #endregion

        #region 更新UserClass

        public static void UpdateUserClassDto(UserClassDto userClassDto)
        {
            UserClassDal.UpdateUserClass(userClassDto);
        }

        #endregion

        #region 删除UserClass
        public static void DeleteUserClassDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
