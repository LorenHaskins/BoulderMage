public class BronzeCoinScript : LootDrops
{
    protected override string LootType { get { return "bronze"; } } //Change Loot Animation Type Here

    void Start()
    {
        value = 1;
        ObjectComponents();
    }
}