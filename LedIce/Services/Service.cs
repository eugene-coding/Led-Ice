using LedIce.Data;

namespace LedIce.Services;

internal abstract class Service
{
    public Service(Context context)
    {
        Context = context;
    }

    protected Context Context { get; init; }
}
