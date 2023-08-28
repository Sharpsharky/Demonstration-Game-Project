namespace DemonstrationGameProject.Items.Inventory.Items.ItemsSO
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Items/ItemGivingItem")]
    public class ItemGivingItem : Item
    {
        [SerializeField] private Item itemToGetAfterUse;

        public ItemGivingItem(string name, int value) : base(name, value)
        {
        }
        
        public override void Use(InventoryController inventoryController)
        {
            Debug.Log($"Use {Name} and get {itemToGetAfterUse.name}");

            inventoryController.AddDifferentItem(itemToGetAfterUse);

        }
        
    }
}