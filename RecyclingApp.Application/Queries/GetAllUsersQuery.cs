using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Filters;
using RecyclingApp.Application.Helpers;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Queries
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<UserDto>>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderBy { get; set; }

        public GetAllUsersQuery(int page, int limit, string firstName, string lastName, string orderBy)
        {
            Page = page;
            Limit = limit;
            FirstName = firstName;
            LastName = lastName;
            OrderBy = orderBy;
        }

        /*public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UserDto>>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var parameters = _mapper.Map<PaginationFilter>(request);
                var userParamiters = _mapper.Map<UserFilters>(request);

                var query = _context.Set<User>().AsQueryable();
                var users = await query
                    .SearchUsers(userParamiters)
                    .ApplaySorting(userParamiters.OrderBy)
                    .ApplyPaging(parameters.Page, parameters.Limit)
                    .ToListAsync(cancellationToken: cancellationToken);

                return new PageResponse<IEnumerable<UserDto>>(_mapper.Map<IEnumerable<UserDto>>(users), new PagingInfo());
            }
        }*/

    }
}
