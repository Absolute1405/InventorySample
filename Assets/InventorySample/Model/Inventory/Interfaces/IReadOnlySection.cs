using System.Collections.Generic;

public interface IReadOnlySection 
{
    public ItemType ItemKind { get; }
    public IReadOnlyList<IReadOnlyCell> Cells { get; }
}
