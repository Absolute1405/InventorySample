using System.Collections.Generic;

public interface IReadOnlyInventory
{
    public float MaxWeight { get; }
    public float OverallWeight { get; }
    public IReadOnlyList<IReadOnlySection> Sections { get; }
}
