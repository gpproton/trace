using Microsoft.EntityFrameworkCore;

namespace Trace.Common.Domain.Context;

public abstract class DefaultSeeder : ISeeder {
    protected ModelBuilder? ModelBuilder;

    public DateTimeOffset Time => DateTimeOffset.Now;

    public ISeeder Initialize(ModelBuilder builder) {
        ModelBuilder = builder;

        return this;
    }

    protected List<T> Load<T>(List<T> value) where T : class {
        ModelBuilder!.Entity<T>().HasData(value);

        return value;
    }

    public virtual void Run() { }
}