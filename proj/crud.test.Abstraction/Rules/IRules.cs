namespace crud.test.Application.Rules;

public interface IRules<TEntity>
{
    bool IsConditionMet(TEntity entity);
}