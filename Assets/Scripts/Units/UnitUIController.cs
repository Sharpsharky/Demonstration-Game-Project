namespace DemonstrationGameProject.Units
{
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    public class UnitUIController : SerializedMonoBehaviour
    {
        [SerializeField, BoxGroup("UI")] private TMP_Text unitName;
        [SerializeField, BoxGroup("UI")] private Image healthBar;
        [SerializeField, BoxGroup("UI")] private Image armorBar;

        public void SetName(string nameToSet)
        {
            unitName.text = nameToSet;
        }
        
        public void ReloadHealthPoints(int currentHealth, int maxHealth)
        {
            healthBar.fillAmount = (float) currentHealth / maxHealth;
        }
        
        public void ReloadArmorPoints(int currentArmor, int maxArmor)
        {
            armorBar.fillAmount = (float) currentArmor / maxArmor;
        }

        private void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0,180,0);
        }
    }
}