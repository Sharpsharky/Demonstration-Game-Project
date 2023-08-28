namespace DemonstrationGameProject.Items.Inventory.Items.ItemsSO
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Items/EatableItem")]
    public class EatableItem : Item
    {
        public EatableItem(string name, int value) : base(name, value)
        {
        }
        
        public override void Use(InventoryController inventoryController)
        {
            Debug.Log($"Consuming {Name}");

            inventoryController.AddMoney(Value);

        }
        
    }
}