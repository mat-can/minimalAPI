public class ShoppingList
{
    public Priorities Priority { get; set; }
    public string Item { get; set; }
}

public enum Priorities
{
    Low,
    Medium,
    High
}