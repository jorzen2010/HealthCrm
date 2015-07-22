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
    public class ArticleDal
    {

        #region 模块添加

        public static void AddArticle(ArticleDto articleDto)
        {

            SqlParameter[] arParames = ArticleDal.getParameters(articleDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "CreateArticle", arParames);

        }
        #endregion

        #region 获取一个模块DTO

        public static ArticleDto GetOneArticle(string table,string strwhere)
        {
            ArticleDto articleDto = new ArticleDto();

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

                articleDto = ArticleDal.getDataRowToArticleDto(dr);

            }


            return articleDto;



        }
        #endregion

        #region 获取模块List数据
        public static List<ArticleDto> GetArticleList(string strwhere)
        {
            List<ArticleDto> articlelist = new List<ArticleDto>();



            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = "QxsqArticle";

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "getModelByWhere", arParames);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ArticleDto ArticleDto = new ArticleDto();

                ArticleDto = ArticleDal.getDataRowToArticleDto(dr);


                articlelist.Add(ArticleDto);

            }

            return articlelist;

        }
        #endregion

        #region 将DTO映射成数据库参数
        private static SqlParameter[] getParameters(ArticleDto articleDto)
        {
            SqlParameter[] arParames = new SqlParameter[10];


            arParames[0] = new SqlParameter("@ArticleId", SqlDbType.Int);
            arParames[0].Value = articleDto.ArticleId;

            arParames[1] = new SqlParameter("@ArticleTitle", SqlDbType.VarChar, 500);
            arParames[1].Value = articleDto.ArticleTitle;

            arParames[2] = new SqlParameter("@ArticleClass", SqlDbType.VarChar, 500);
            arParames[2].Value = articleDto.ArticleClass;

            arParames[3] = new SqlParameter("@ArticleImg", SqlDbType.VarChar, 500);
            arParames[3].Value = articleDto.ArticleImg;

            arParames[4] = new SqlParameter("@ArticleContent", SqlDbType.Text);
            arParames[4].Value = articleDto.ArticleContent;

            arParames[5] = new SqlParameter("@ArticleDateTime", SqlDbType.DateTime);
            arParames[5].Value = articleDto.ArticleDateTime;

            arParames[6] = new SqlParameter("@ArticleTop", SqlDbType.Bit);
            arParames[6].Value = articleDto.ArticleTop;

            arParames[7] = new SqlParameter("@ArticleHot", SqlDbType.Bit);
            arParames[7].Value = articleDto.ArticleHot;

            arParames[8] = new SqlParameter("@ArticleImportant", SqlDbType.Bit);
            arParames[8].Value = articleDto.ArticleImportant;

            arParames[9] = new SqlParameter("@ArticleInfo", SqlDbType.Text);
            arParames[9].Value = articleDto.ArticleInfo;


            return arParames;
        }

        #endregion

        #region 将数据集映射成DTO
        private static ArticleDto getDataRowToArticleDto(DataRow dr)
        {
            ArticleDto articleDto = new ArticleDto();

            articleDto.ArticleId = int.Parse(dr["ArticleId"].ToString());
            articleDto.ArticleTitle = dr["ArticleTitle"].ToString();
            articleDto.ArticleClass = dr["ArticleClass"].ToString();
            articleDto.ArticleImg = dr["ArticleImg"].ToString();

            articleDto.ArticleContent = dr["ArticleContent"].ToString();
            articleDto.ArticleInfo = dr["ArticleInfo"].ToString();

            articleDto.ArticleHot = bool.Parse(dr["ArticleHot"].ToString());
            articleDto.ArticleTop = bool.Parse(dr["ArticleTop"].ToString());
            articleDto.ArticleImportant = bool.Parse(dr["ArticleImportant"].ToString());

            articleDto.ArticleDateTime = DateTime.Parse(dr["ArticleDateTime"].ToString());

            return articleDto;
        }

        #endregion

        #region 将数据集映射成DTO
        private static ArticleDto getDataReaderToArticleDto(SqlDataReader dr)
        {
            ArticleDto articleDto = new ArticleDto();

            articleDto.ArticleId = int.Parse(dr["ArticleId"].ToString());
            articleDto.ArticleTitle = dr["ArticleTitle"].ToString();
            articleDto.ArticleClass = dr["ArticleClass"].ToString();
            articleDto.ArticleImg = dr["ArticleImg"].ToString();

            articleDto.ArticleContent = dr["ArticleContent"].ToString();
            articleDto.ArticleInfo = dr["ArticleInfo"].ToString();

            articleDto.ArticleHot = bool.Parse(dr["ArticleHot"].ToString());
            articleDto.ArticleTop = bool.Parse(dr["ArticleTop"].ToString());
            articleDto.ArticleImportant = bool.Parse(dr["ArticleImportant"].ToString());

            articleDto.ArticleDateTime = DateTime.Parse(dr["ArticleDateTime"].ToString());

            return articleDto;
        }

        #endregion

        #region 删除一个Article对象DTO
        public static void DeleteArticleDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "deleteModelByWhere", arParames);



        }
        #endregion
        
        #region 更新一个Article
        public static void UpdateArticle(ArticleDto ArticleDto)
        {

            SqlParameter[] arParames = ArticleDal.getParameters(ArticleDto);

            SqlHelper.ExecuteNonQuery(CommonDal.ConnectionString, CommandType.StoredProcedure, "UpdateArticle", arParames);


        }

        #endregion
        
        #region 取得单表的查询并进行分页数据
        public static Pager GetArticlePage(Pager pager, string strwhere, string table)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            //@tbname   --要分页显示的表名
            arParms[0] = new SqlParameter("@tbname", SqlDbType.NVarChar, 30);
            arParms[0].Value = table;

            // @FieldKey --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
            arParms[1] = new SqlParameter("@FieldKey", SqlDbType.NVarChar, 40);
            arParms[1].Value = "ArticleId";

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
            arParms[5].Value = "ArticleId desc";

            //@Where   --查询条件
            arParms[6] = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            arParms[6].Value = strwhere;

            //@PageCount --总页数
            arParms[7] = new SqlParameter("@PageCount", SqlDbType.Int);
            arParms[7].Direction = ParameterDirection.Output;

            //@RecordCount --总记录数
            arParms[8] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParms[8].Direction = ParameterDirection.Output;

            ArticleDto articleDto = null;
            List<ArticleDto> list = new List<ArticleDto>();
            DataTable dt = null;
            DataSet ds = SqlHelper.ExecuteDataset(CommonDal.ConnectionString, CommandType.StoredProcedure, "sp_AspNetPageView", arParms);
            dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                articleDto = ArticleDal.getDataRowToArticleDto(dr);
                list.Add(articleDto);
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
