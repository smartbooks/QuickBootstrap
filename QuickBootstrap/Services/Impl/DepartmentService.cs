using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public void Create(Department model)
        {
            DbContext.Department.Add(model);
            DbContext.SaveChanges();
        }

        public Department Get(int id)
        {
            return DbContext.Department.FirstOrDefault(p => p.Id == id);
        }

        public void Edit(Department model)
        {
            DbContext.Department.Update(
                p => p.Id == model.Id,
                m => new Department { Order = model.Order, IsEnable = model.IsEnable, Title = model.Title });
        }
    }
}