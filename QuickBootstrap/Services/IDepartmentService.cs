using System.Collections.Generic;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services
{
    public interface IDepartmentService
    {
        PagedResult<DepartmentManagePageItem> GetList(Paging paging);

        List<Department> GetAllList();

        void Create(Department model);

        Department Get(int id);

        void Edit(Department model);
    }
}
