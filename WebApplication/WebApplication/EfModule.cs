using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApplication.Models;

namespace WebApplication
{

    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(MovieDBContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
        }

    }

    public class Repo : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("WebApplication")).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(DbContext)).InstancePerLifetimeScope();
        }

    }

}