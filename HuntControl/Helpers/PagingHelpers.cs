using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<PageInfo, MvcHtmlString> pageUrl)
        {
            pageInfo.FirstPage = (int)(pageInfo.CurrentPage - (int)(pageInfo.MaxPageList / 2));
            if (pageInfo.FirstPage <= 1)
            {
                pageInfo.FirstPage = 1;
            }
            else
            {
                if (pageInfo.TotalPages - pageInfo.FirstPage < pageInfo.MaxPageList)
                {
                    pageInfo.FirstPage = pageInfo.TotalPages - pageInfo.MaxPageList + 1;
                    if (pageInfo.FirstPage <= 1)
                    {
                        pageInfo.FirstPage = 1;
                    }
                }
            }
            pageInfo.LastPage = pageInfo.FirstPage + pageInfo.MaxPageList - 1;
            if (pageInfo.LastPage > pageInfo.TotalPages)
            {
                pageInfo.LastPage = pageInfo.TotalPages;
            }
            StringBuilder result = new StringBuilder();
            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination m-b-0");

            //---B-M---переход на первую страницу
            if (pageInfo.CurrentPage > 3)
            {
                TagBuilder tagLiFirst = new TagBuilder("li");
                tagLiFirst.InnerHtml = pageUrl(new PageInfo() { CurrentPage = 1, NameLink = "«" }).ToHtmlString();
                result.Append(tagLiFirst.ToString());
            }

            if (1 != pageInfo.CurrentPage)
            {
                TagBuilder tagLiPrev = new TagBuilder("li");
                tagLiPrev.InnerHtml = pageUrl(new PageInfo() { CurrentPage = pageInfo.CurrentPage - 1, NameLink = "‹" }).ToHtmlString();
                result.Append(tagLiPrev.ToString());
            }


            for (int i = pageInfo.FirstPage; i <= pageInfo.LastPage; i++)
            {

                TagBuilder tagLiNum = new TagBuilder("li");
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.CurrentPage)
                {
                    tagLiNum.AddCssClass("active");
                }
                tagLiNum.InnerHtml = pageUrl(new PageInfo() { CurrentPage = i, NameLink = i.ToString() }).ToHtmlString();
                result.Append(tagLiNum.ToString());

            }

            if (pageInfo.TotalPages > pageInfo.CurrentPage)
            {
                TagBuilder tagLiLast = new TagBuilder("li");
                tagLiLast.InnerHtml = pageUrl(new PageInfo() { CurrentPage = pageInfo.CurrentPage + 1, NameLink = "›" }).ToHtmlString();
                result.Append(tagLiLast.ToString());
            }
            //---B-M---переход на первую страницу
            if (pageInfo.CurrentPage < pageInfo.TotalPages - 2)
            {
                TagBuilder tagLiLast = new TagBuilder("li");
                tagLiLast.InnerHtml = pageUrl(new PageInfo() { CurrentPage = pageInfo.TotalPages, NameLink = "»" }).ToHtmlString();
                result.Append(tagLiLast.ToString());
            }

            tagUl.InnerHtml = result.ToString();
            return MvcHtmlString.Create(tagUl.ToString());
        }
    }
}