namespace DemonstrationGameProject.Items.Inventory.Items
{
    using System.Collections.Generic;
    using ItemsSO;
    using Sirenix.OdinInspector;
    using UnityEngine;
    
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField, InlineEditor] private List<Item> items = new List<Item>();

        public Item GetRandomItem()
        {
            if (items == null) return null;
            
            int rand = Random.Range(0, items.Count);

            return items[rand];
        }
    }
}
