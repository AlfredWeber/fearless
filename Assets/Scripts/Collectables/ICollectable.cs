public enum CollectableItems
{
    PowersupplyKey = 0
}

public interface ICollectable
{
    CollectableItems Name { get; }
    void Collect();
}
