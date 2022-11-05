public enum CollectableItems
{
    PowersupplyKey = 0
}

public interface ICollectable
{
    public CollectableItems Name { get; }
    public void Collect();
}
