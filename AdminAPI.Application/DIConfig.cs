using System;
using System.Reflection;
using AdminAPI.Application.Queries.GetProfile;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AdminAPI.Application
{
	public static class DIConfig
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(List.Handler).Assembly);

            return services;
        }
    }
}

