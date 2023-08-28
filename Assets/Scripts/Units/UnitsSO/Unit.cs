namespace DemonstrationGameProject.Units.UnitsSO
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnitClassesSO;
    using System.Collections.Generic;

    [CreateAssetMenu(menuName = "Unit")]
    public class Unit : SerializedScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int attackDamage;
        [SerializeField] private int healthPoints;
        [SerializeField] private int armorPoints;
        [SerializeField] private int attackInterval;
        [SerializeField] private List<UnitAttribute> unitAttributes;

        public string Name => name;
        public int AttackDamage => attackDamage;
        public int HealthPoints => healthPoints;
        public int ArmorPoints => armorPoints;
        public int AttackInterval => attackInterval;
        public List<UnitAttribute> UnitAttributes => unitAttributes;


    }
    
}