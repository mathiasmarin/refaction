using System.Data.Entity.Migrations;
using Application.Common;
using Application.Core.CommandHandlers;
using Application.Core.CommandHandlers.Decorators;
using Domain.Common;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Infrastructure.DAL;
using Infrastructure.DAL.EF;
using Infrastructure.DAL.QueryHandlers;

namespace Infrastructure.Autowiring
{
    public static class Boostrapper
    {
        public static Container ConfigureServices()
        {
            var container = new Container();

            var hybridLifeStyle = Lifestyle.CreateHybrid(new AsyncScopedLifestyle(), new ThreadScopedLifestyle());

            container.Register<IDbContext,ProductDbContext>(hybridLifeStyle);

            //Repository
            container.Register(typeof(IRepository<>), typeof(Repository<>),hybridLifeStyle);

            //Querhandlers
            container.Register(typeof(IQueryHandler<,>), new[] { typeof(GetProductByNameQueryHandler).Assembly });

            //Register all commandhandler
            container.Register(typeof(ICommandHandler<>), new[] { typeof(AddNewProductCommandHandler).Assembly });
            //Transaction decorator
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(TransactionScopeDecorator<>));

            //Setup db
            using (var db = new ProductDbContext()) // Drop create database
            {
                db.Database.Delete();
            }

            var dbMigrator = new DbMigrator(new Seeding());

            dbMigrator.Update(); //Allows developers to use "automatic migrations" while developing, 

            container.Verify();

            return container;

            
        }
    }
}
