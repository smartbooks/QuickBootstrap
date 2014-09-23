using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class DepartmentService : ServiceContext, IDepartmentService
    {
        public PagedResult<DepartmentManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<DepartmentManagePageItem>()
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize
            };

            var query = from p in DbContext.Department
                        orderby p.CreateTime descending
                        select new DepartmentManagePageItem
                        {
                            Id = p.Id,
                            CreateTime = p.CreateTime,
                            IsEnable = p.IsEnable,
                            Order = p.Order,
                            Title = p.Title
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            return queryPageResult;
        }

        public List<Department> GetAllList()
        {
            return DbContext.Department.OrderByDescending(p => p.CreateTime).ToList();
        }
    }
}