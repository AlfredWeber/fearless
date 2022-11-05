public enum CollectableItems
{
    PowersupplyKey,
    NONE
}

public interface ICollectable
{
    public CollectableItems Name { get; }
    public void Collect();
}
