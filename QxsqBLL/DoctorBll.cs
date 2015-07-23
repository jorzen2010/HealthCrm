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
    public class DoctorBll
    {

        #region   医生以下拉框显示
        public static List<SelectListItem> GetDoctorForSelect(int? DoctorId = 0)
        {
            string strwhere = "";
            if (DoctorId == 0)
            {
                strwhere = "1=1";
            }
            else
            {
                strwhere = "DoctorId=" + DoctorId.ToString();
            
            }
            List<DoctorDto> DoctorDtoList = DoctorDal.GetDoctorList("CrmDoctor", strwhere);

            List<SelectListItem> items = new List<SelectListItem>();



            foreach (DoctorDto doctorDto in DoctorDtoList)
            {

                items.Add(new SelectListItem { Text = doctorDto.DoctorRealName, Value = doctorDto.DoctorId.ToString() });
            }

            return items;
        }
        #endregion

        public static List<DoctorDto> GetDoctorDtoList(string table,string strwhere)
        {
            return DoctorDal.GetDoctorList(table,strwhere);
        }



        #region 得到一个DoctorPager 
        public static Pager GetDoctorPager(Pager pager,string strwhere,string table)
        {


            //return DoctorDal.GetDoctorPage(pager, strwhere,table);
            return DoctorDal.GetDoctorPage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddDoctor(DoctorDto doctorDto)
        {
            DoctorDal.AddDoctor(doctorDto);
     
        }


        #endregion

        #region 获取一个Doctor
        public static DoctorDto GetOneDoctorDto(string table,string strwhere)
        {
            DoctorDto doctorDto=new DoctorDto();

            doctorDto = DoctorDal.GetOneDoctor(table, strwhere);

            return doctorDto;
        }


        #endregion

        #region 更新Doctor

        public static void UpdateDoctorDto(DoctorDto doctorDto)
        {
            DoctorDal.UpdateDoctor(doctorDto);
        }

        #endregion

        #region 删除Doctor
        public static void DeleteDoctorDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
