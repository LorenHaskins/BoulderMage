public class SilverCoinScript : LootDrops
{
    protected override string LootType { get { return "silver"; } } //Change Loot Animation Type Here

    void Start()
    {
        value = 5;
        ObjectComponents();
    }
}