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
    public class ArticleClassDal
    {

        #region 文章类别添加

        public static void AddArticleClass(ArticleClassDto articleClassDto)
        {

            SqlParameter[] arParames = ArticleClassDal.getParameters(articleClassDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateArticleClass", arParames);

        }
        #endregion

        #region 获取一个文章类别DTO

        public static ArticleClassDto GetOneArticleClass(string table,string strwhere)
        {
            ArticleClassDto articleClassDto = new ArticleClassDto();

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

                articleClassDto = ArticleClassDal.getDataRowToArticleClassDto(dr);

            }


            return articleClassDto;



        }
        #endregion

        #region 获取文章类别List数据
        public static List<ArticleClassDto> GetArticleClassList(string strwhere)
        {
            List<ArticleClassDto> articleClasslist = new List<ArticleClassDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqArticleClass";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ArticleClassDto articleClassDto = new ArticleClassDto();

                articleClassDto = ArticleClassDal.getDataRowToArticleClassDto(dr);


                articleClasslist.Add(articleClassDto);

            }

            return articleClasslist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(ArticleClassDto articleClassDto)
        {
            SqlParameter[] arParames = new SqlParameter[2];


            arParames[0] = new SqlParameter("@ArticleClassId", SqlDbType.Int);
            arParames[0].Value = articleClassDto.ArticleClassId;

            arParames[1] = new SqlParameter("@ArticleClassName", SqlDbType.VarChar, 500);
            arParames[1].Value = articleClassDto.ArticleClassName;



            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static ArticleClassDto getDataRowToArticleClassDto(DataRow dr)
        {
            ArticleClassDto articleClassDto = new ArticleClassDto();

            articleClassDto.ArticleClassId = int.Parse(dr["ArticleClassId"].ToString());
            articleClassDto.ArticleClassName = dr["ArticleClassName"].ToString();


            return articleClassDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static ArticleClassDto getDataReaderToArticleClassDto(SqlDataReader dr)
        {
            ArticleClassDto articleClassDto = new ArticleClassDto();

            articleClassDto.ArticleClassId = int.Parse(dr["ArticleClassId"].ToString());
            articleClassDto.ArticleClassName = dr["ArticleClassName"].ToString();


            return articleClassDto;
        }

        #endregion

        #region 删除一个ArticleClass对象DTO
        public static void DeleteArticleClassDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion
        
        #region 更新一个ArticleClass
        public static void UpdateArticleClass(ArticleClassDto ArticleClassDto)
        {

            SqlParameter[] arParames = ArticleClassDal.getParameters(ArticleClassDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateArticleClass", arParames);


        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetArticleClassPage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "ArticleClassId";

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
            arParms[5].Value = "ArticleClassId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            ArticleClassDto articleClassDto = null;
            List<ArticleClassDto> list = new List<ArticleClassDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                articleClassDto = ArticleClassDal.getDataRowToArticleClassDto(dr);
                list.Add(articleClassDto);
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
