using LedIce.Data;

namespace LedIce.Services;

public abstract class Service
{
    public Service(Context context)
    {
        Context = context;
    }

    protected Context Context { get; private init; }
}
