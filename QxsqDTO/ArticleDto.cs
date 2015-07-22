using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QxsqDTO
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }

        public string ArticleTitle { get; set; }
        public string ArticleClass { get; set; }
        public string ArticleImg { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleInfo { get; set; }
        public DateTime ArticleDateTime { get; set; }

        public bool ArticleTop { get; set; }
        public bool ArticleHot { get; set; }
        public bool ArticleImportant { get; set; }
    }
}
