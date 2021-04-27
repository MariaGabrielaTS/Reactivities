using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                /* 
                    CancellationToken gives us the ability to actually cancel a long running request
                    THIS IS JUST AN EXAMPLE OF CancellationToken
                    try
                    {
                        for (var i = 0; i < 10; i++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            await Task.Delay(1000, cancellationToken);
                            _logger.LogInformation($"Task {i} has completed");
                        }
                    }
                    catch (Exception ex) when (ex is TaskCanceledException)
                    {
                        _logger.LogInformation("Task was cancelled");
                    }
                */
                
                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}