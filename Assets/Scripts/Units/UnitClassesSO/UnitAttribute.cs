namespace DemonstrationGameProject.Units.UnitClassesSO
{
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

        [CreateAssetMenu(menuName = "UnitAttribute")]
        public class UnitAttribute : SerializedScriptableObject
        {
            [SerializeField] private Dictionary<UnitAttribute, int> attackDamageForSpecificUnits = 
               new Dictionary<UnitAttribute, int>();

            public Dictionary<UnitAttribute, int> AttackDamageForSpecificUnits => attackDamageForSpecificUnits;

        }
    
   
}