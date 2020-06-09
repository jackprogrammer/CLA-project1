using CLA.Data;
using CLA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLA.Service.Implements
{
    public class EventService : BaseService<CLAContext, Events>, IEventService
    {
        public EventService()
            : base(new CLAContext())
        {
        }

        public async Task<string> Add(Events item)
        {
            var rs = await AddAsync(item);
            return rs == null ? string.Empty : rs.Id;
        }

        public async Task<string> Update(Events item)
        {
            var rs = await UpdateAsync(item, item.Id);
            return rs == null ? string.Empty : rs.Id;
        }
    }
}
