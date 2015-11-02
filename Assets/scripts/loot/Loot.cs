namespace loot
{
    public struct Loot
    {
        public LootType lootType;
        public uint amount;

        public Loot( LootType lootType, uint amount = 1)
        {
            this.lootType = lootType;
            this.amount = amount;
        }
    }
};