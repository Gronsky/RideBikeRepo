﻿using Ninject.Modules;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectDAL.Repositories;
using System.Data.Entity;

namespace RideBikeProjectBLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<DbContext>().To<RideBikeContext>();
            Bind<IRepository<Bike>>().To<EntityRepository<Bike>>();
            Bind<IRepository<BikeSubtype>>().To<EntityRepository<BikeSubtype>>();
            Bind<IRepository<BikeType>>().To<EntityRepository<BikeType>>();
            Bind<IRepository<Event>>().To<EntityRepository<Event>>();
            Bind<IRepository<EventType>>().To<EntityRepository<EventType>>();
            Bind<IRepository<Image>>().To<EntityRepository<Image>>();
            Bind<IRepository<Producer>>().To<EntityRepository<Producer>>();
            Bind<IRepository<Role>>().To<EntityRepository<Role>>();
            Bind<IRepository<Team>>().To<EntityRepository<Team>>();
            Bind<IRepository<User>>().To<EntityRepository<User>>();
            Bind<IRepository<EventUser>>().To<EntityRepository<EventUser>>();
        }
    }
}