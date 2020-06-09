using CLA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLA.Service.Interfaces
{
    public interface ICourseService
    {
        Task<string> Add(Course item);
        Task<string> Update(Course item);
    }
}
