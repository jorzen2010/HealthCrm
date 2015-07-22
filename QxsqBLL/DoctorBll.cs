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
    public class DoctorBll
    {
         


        public static List<DoctorDto> GetDoctorDtoList(string strwhere)
        {
            return DoctorDal.GetDoctorList(strwhere);
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
