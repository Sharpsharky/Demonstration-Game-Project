using DemonstrationGameProject.Items.Inventory.Items.ItemsSO;

namespace DemonstrationGameProject.Items.Inventory.Items
{
	using General;
	using UnityEngine;
	using Sirenix.OdinInspector;

	public class ItemPresenter : SerializedMonoBehaviour, IItemHolder, IGameObjectPooled
	{
		[SerializeField, InlineEditor] private Item item;
		public GameObjectPool Pool { get; set; }


		public void SetItem(Item item)
		{
			this.item = item;
		}
		
		public Item GetItem(bool disposeHolder)
		{
			if (disposeHolder) 
				Pool.ReturnToPool(gameObject);
			
			return item;
		}

	}
}