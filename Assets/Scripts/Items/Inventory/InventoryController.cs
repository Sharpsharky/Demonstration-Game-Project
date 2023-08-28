
namespace DemonstrationGameProject.Items.Inventory
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using Sirenix.OdinInspector;
	using Items.ItemsSO;

	public class InventoryController : SerializedMonoBehaviour
	{
		[SerializeField, InlineEditor] private List<Item> items;
		[SerializeField] private int money;
		
		public event Action<int> OnReloadMoneyText;

		public int ItemsCount => items.Count;

		private void Start()
		{
			OnReloadMoneyText?.Invoke(money);
		}

		public void SellAllItemsUpToValue(int maxValue)
		{
			for (var i = items.Count - 1; i >= 0; i--)
			{
				var itemValue = items[i].Value;
				if (itemValue > maxValue)
					continue;
				
				money += itemValue;
				items.RemoveAt(i);
			}

			OnReloadMoneyText?.Invoke(money);

		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}

		public void UseFirstItem()
		{
			if (items.Count == 0) return;
			
			items[0].Use(this);			
			
			items.RemoveAt(0);
		}

		public void AddMoney(int moneyToAdd)
		{
			money += moneyToAdd;
			OnReloadMoneyText?.Invoke(money);
		}
		
		public void AddDifferentItem(Item item)
		{
			items.Add(item);
		}
		
	}
}