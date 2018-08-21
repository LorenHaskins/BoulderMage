public class GoldCoinScript : LootDrops
{
    protected override string LootType { get { return "gold"; } } //Change Loot Animation Type Here

    void Start()
    {
        value = 10;
        ObjectComponents();
    }
}