using AutoMapper;
using CLA.Data;
using CLA.Models.Model;
using CLA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLA.Service.Implements
{
    public class CourseService : BaseService<CLAContext, Course>, ICourseService
    {
        public CourseService()
            : base(new CLAContext())
        {
        }

        public async Task<string> Add(Course item)
        {
            var rs = await AddAsync(item);
            return rs == null ? string.Empty : rs.Id;
        }

        public async Task<string> Update(Course item)
        {
            var rs = await UpdateAsync(item, item.Id);
            return rs == null ? string.Empty : rs.Id;
        }
    }
}
