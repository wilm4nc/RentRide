using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class PaginationExtension
{
    public static IQueryable<T> OrderByPropertyOrField<T>(
        this IQueryable<T> queryable,
        string propertyOrFielName,
        bool ascending =true
    ){
        var elemenType = typeof(T);
        var orderByMethodName = ascending ? "Orderby" : "OrderByDescending";

        var parameterExpression = Expression.Parameter(elemenType);
        var propertyOrFieldExpression = Expression
        .PropertyOrField(parameterExpression, propertyOrFielName);

        var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

        var orderByExpression = Expression.Call(
        typeof(Queryable), 
        orderByMethodName
        ,new [] { elemenType, propertyOrFieldExpression.Type},
        queryable.Expression,
        selector
        );

        return queryable.Provider.CreateQuery<T>(orderByExpression);

    }
    
}