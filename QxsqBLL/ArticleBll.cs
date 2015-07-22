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
    public class ArticleBll
    {
         


        public static List<ArticleDto> GetArticleDtoList(string strwhere)
        {
            return ArticleDal.GetArticleList(strwhere);
        }



        #region 得到一个ArticlePager 
        public static Pager GetArticlePager(Pager pager,string strwhere,string table)
        {


            //return ArticleDal.GetArticlePage(pager, strwhere,table);
            return ArticleDal.GetArticlePage(pager, strwhere, table);
        }


        #endregion

        #region 新增一个
        public static void AddArticle(ArticleDto articleDto)
        {
            ArticleDal.AddArticle(articleDto);
     
        }


        #endregion

        #region 获取一个Article
        public static ArticleDto GetOneArticleDto(string table,string strwhere)
        {
            ArticleDto articleDto=new ArticleDto();

            articleDto = ArticleDal.GetOneArticle(table, strwhere);

            return articleDto;
        }


        #endregion

        #region 更新Article

        public static void UpdateArticleDto(ArticleDto articleDto)
        {
            ArticleDal.UpdateArticle(articleDto);
        }

        #endregion

        #region 删除Article
        public static void DeleteArticleDto(string table,string strwhere)
        {
            CommonDal.DeleteOneDto(table,strwhere);
        }
        #endregion
    }
}
