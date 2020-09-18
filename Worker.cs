using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using POC.Employee.Worker.Contexts;
using POC.Employee.Worker.Models;

namespace POC.Employee.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly EmployeeContext _context;

        private int _lastStart_LNS = 0;

        public Worker(ILogger<Worker> logger, EmployeeContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                GetChanges();
                await Task.Delay(10000, stoppingToken);
            }
        }

        private void GetChanges()
        {
            try
            {
                var changes = _context.Employees.ToList();
                LogChanges(changes);
                // TODO : determine what events to dispatch based on OperationType
                // TODO : In the scenario that multiple instances of this worker are running
                //        we need to determine the last record pulled off the cdc table
                //        and insert that into another table for tracking. Don't cross paths
                //        between instances of the worker service.

                // TODO : After processing is completed, delete the records? Or let a SQL Agent
                //        job come in later for cleanup?
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error logging employee change event: {ex.Message}");
            }
        }

        private void LogChanges(IEnumerable<EmployeeCT> changes)
        {
            _logger.LogInformation($"changes: {changes}");
        }
    }
}
