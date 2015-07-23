using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QxsqDTO;
using QxsqDAL;
using Common;

namespace QxsqBLL
{
    public class GroupBll
    {

        #region   用户归档以下拉框显示
        public static List<SelectListItem> GetGroupForSelect(int? GroupId = 0)
        {
            List<GroupDto> GroupDtoList = GroupDal.GetGroupList("CrmGroup","1=1");

            List<SelectListItem> items = new List<SelectListItem>();



            foreach (GroupDto groupDto in GroupDtoList)
            {

                items.Add(new SelectListItem { Text = groupDto.GroupName, Value = groupDto.GroupId.ToString() });
            }

            return items;
        }
        #endregion


        public static List<GroupDto> GetGroupDtoList(string table,string strwhere)
        {
            return GroupDal.GetGroupList(table,strwhere);
        }



        #region 得到一个GroupPager 
        public static Pager GetGroupPager(Pager pager,string strwhere,string table)
        {


            //return GroupDal.GetGroupPage(pager, strwhere,table);
            return GroupDal.GetGroupPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddGroup(GroupDto groupDto)
        {
            GroupDal.AddGroup(groupDto);
     
        }


        #endregion

        #region 获取一个Group
        public static GroupDto GetOneGroupDto(string table,string strwhere)
        {
            GroupDto groupDto=new GroupDto();

            groupDto = GroupDal.GetOneGroup(table, strwhere);

            return groupDto;
        }


        #endregion

        #region 更新Group

        public static void UpdateGroupDto(GroupDto groupDto)
        {
            GroupDal.UpdateGroup(groupDto);
        }

        #endregion

        #region 删除Group
        public static void DeleteGroupDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
