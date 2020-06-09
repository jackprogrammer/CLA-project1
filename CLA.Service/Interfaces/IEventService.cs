using CLA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLA.Service.Interfaces
{
    public interface IEventService
    {
        Task<string> Add(Events item);
        Task<string> Update(Events item);
    }
}
