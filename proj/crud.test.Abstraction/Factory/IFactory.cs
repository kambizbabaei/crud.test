using System.Reflection;
using crud.test.Application.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace crud.test.Abstraction.Factory;

public abstract class EntityFactory<TEntity> : IFactory
{
    protected List<IRules<TEntity>> Conditions = new();

    public EntityFactory()
    {
        var rules = Assembly.Load("crud.test.Application").GetTypes();
        var notabsrules = rules.Where(type =>
            !type.IsAbstract && !type.IsInterface && type.IsAssignableTo(typeof(IRules<TEntity>))).ToList();
        IServiceProvider serviceProvider = ServiceLocator.ServiceLocator.ServiceProvider;


        foreach (var implementingType in notabsrules)
        {
            IRules<TEntity> instance =
                (IRules<TEntity>)ActivatorUtilities.CreateInstance(serviceProvider, implementingType);
            Conditions.Add(instance);
        }
    }
}

public interface IFactory
{
}