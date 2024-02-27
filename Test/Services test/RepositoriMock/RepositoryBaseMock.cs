using DigitalMarket_API.Domain.Repositories;
using System.Reflection;

namespace DigitalMarket_API.Test.Services_test.RepositoriMock
{
    public class RepositoryBaseMock<T> : IRepository<T>
     where T : class
    {
        protected readonly List<T> entities = new();
        private int currentIndex = 0;

        public PropertyInfo IdProperty { get; }

        public IReadOnlyList<T> Entities => entities;

        public RepositoryBaseMock()
        {
            var typeInfo = typeof(T).GetTypeInfo();
            IdProperty = typeInfo.GetProperty("Id") ??
                throw new InvalidOperationException($"{typeInfo.Name} does not have an 'Id' property of type int");
        }

        public Task AddAsync(T entity)
        {
            IdProperty.SetValue(entity, currentIndex++);
            entities.Add(entity);
            return Task.CompletedTask;
        }

        public Task<T> Delete(int id)
        {
            var index = entities.FindIndex(c => (int)(IdProperty?.GetValue(c) ?? -1) == id);
            if (index < 0)
                return null!;
            var entity = entities[index];
            entities.RemoveAt(index);
            return Task.FromResult(entity);
        }

        public Task<List<T>> GetAll() => Task.FromResult(entities);

        public Task<T> GetOne(int id)
        {
            var e = entities.Find(c => (int)(IdProperty?.GetValue(c) ?? -1) == id);
            return Task.FromResult(e!);
        }

        public Task UpdateAsync(T entity)
        {
            var index = entities.FindIndex(c => IdProperty.GetValue(c) == IdProperty.GetValue(entity));
            if (index < 0)
                return null!;
            entities[index] = entity;
            return Task.CompletedTask;
        }
    }

}
