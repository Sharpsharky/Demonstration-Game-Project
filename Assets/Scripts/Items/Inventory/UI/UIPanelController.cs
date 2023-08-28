namespace DemonstrationGameProject.Items.Inventory.UI
{
    using TMPro;
    using UnityEngine;
    
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyValueText;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private string moneyTextPrefix = "Money: ";

        private void Awake()
        {
            inventoryController.OnReloadMoneyText += ReloadMoneyValueText;
        }

        private void ReloadMoneyValueText(int currentValue)
        {
            moneyValueText.text = moneyTextPrefix + currentValue;
        }
        
    }
}