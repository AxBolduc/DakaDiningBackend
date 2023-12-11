namespace DakaDiningBackend.Shared.Mappers;

public abstract class AbstractMapper<TSource, TOutput>
{
    public TOutput? Transform(TSource? value)
    {
        if (value == null)
        {
            return default(TOutput);
        }

        return TransformValue(value);
    }

    public ICollection<TOutput> TransformCollection(ICollection<TSource> values)
    {
        List<TOutput> returnValues = new List<TOutput>();
        foreach (var value in values)
        {
            var transformedValue = Transform(value);
            if (transformedValue != null)
            {
                returnValues.Add(transformedValue);
            }
        }

        return returnValues;
    }

    protected abstract TOutput TransformValue(TSource value);
}
