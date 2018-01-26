using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Coffee2018.Models;

namespace Coffee2018.Services
{
    public interface ICoffeeService
    {
        Task<List<Record>> GetCoffeeListAsync(CancellationToken ct);
    }
}
