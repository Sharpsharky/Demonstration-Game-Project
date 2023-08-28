namespace DemonstrationGameProject.Items.Inventory.Items.ItemsSO
{
	using UnityEngine;

	[CreateAssetMenu(menuName = "Items/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField] private string name;
		[SerializeField] private int value;

		public string Name => name;
		public int Value => value;

		public Item(string name, int value)
		{
			this.name = name;
			this.value = value;
		}

		public virtual void Use(InventoryController inventoryController)
		{
			Debug.Log("Using" + Name);
		}
	}
}