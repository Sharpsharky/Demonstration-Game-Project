namespace DemonstrationGameProject.Units.UnitClasses.MainClasses
{
    using System;
    using System.Collections.Generic;
    using Battle;
    using UnitClassesSO;
    using UnitsSO;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using General;

    public abstract class UnitPresenter : SerializedMonoBehaviour 
    {
        [SerializeField, InlineEditor] protected Unit unit;
        [SerializeField] private UnitUIController unitUIController;
        [SerializeField] private float timeToHitEnemy = 1;
        [SerializeField] private float scaleWhenHitByEnemy = 0.5f;
        
        protected string unitName;
        protected int currentHealth;
        protected int currentArmor;
        protected int attackDamage;
        protected int attackInterval;
        protected List<UnitAttribute> unitAttributes = new List<UnitAttribute>();

        private float initialScale;
        
        private TeamController teamController;

        public List<UnitAttribute> UnitAttributes => unitAttributes;
        public string UnitName => unitName;
        public float TimeToHitEnemy => timeToHitEnemy;
        public int AttackInterval => attackInterval;

        private void Awake()
        {
            InitializeUnit();
            InitializeUI();
            initialScale = transform.localScale.x;
        }

        public void Initialize(TeamController teamController)
        {
            this.teamController = teamController;
        }
        
        public virtual void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            Debug.Log($"{unit.name} attacked {unitPresenter.UnitName}");
            int damage = GetDamage(unitPresenter.UnitAttributes);
            unitPresenter.AcquireDamage(damage);
            attackInterval = unit.AttackInterval;
        }

        public void DecreaseAttackInterval()
        {
            attackInterval--;
            if (attackInterval < 0) 
                attackInterval = 0;
        }
        
        protected int GetDamage(List<UnitAttribute> enemyUnitAttributes)
        {
            int potentialAttackDamage = 0;
            
            foreach (var unitAttribute in unitAttributes)
            {
                foreach (var enemyUnitAttribute in enemyUnitAttributes)
                {

                    if (unitAttribute.AttackDamageForSpecificUnits.ContainsKey(enemyUnitAttribute))
                    {
                        int dmg = unitAttribute.AttackDamageForSpecificUnits[enemyUnitAttribute];
                        if (dmg > potentialAttackDamage) potentialAttackDamage = dmg;
                    }
                    
                }
            }

            if (potentialAttackDamage > 0) return potentialAttackDamage;
            return attackDamage;
        }

        public virtual void AcquireDamage(int damage)
        {
            currentArmor -= damage;
            if (currentArmor < 0)
            {
                currentHealth += currentArmor;
            }
            currentArmor = 0;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GetKilled();
            }

            unitUIController.ReloadHealthPoints(currentHealth, unit.HealthPoints);
            unitUIController.ReloadArmorPoints(currentArmor, unit.ArmorPoints);
            
            DoTweenCustomAnimations.DoBlinkScale(transform, initialScale, 
                initialScale - scaleWhenHitByEnemy);

        }

        protected virtual void GetKilled()
        {
            gameObject.SetActive(false);
            teamController.RemoveUnitFromList(this);
        }
        
        private void InitializeUnit()
        {
            unitName = unit.Name;
            currentHealth = unit.HealthPoints;
            currentArmor = unit.ArmorPoints;
            attackDamage = unit.AttackDamage;
            attackInterval = 0;
            unitAttributes = unit.UnitAttributes;
        }
        
        private void InitializeUI()
        {
            unitUIController.ReloadHealthPoints(currentArmor, unit.ArmorPoints);
            unitUIController.ReloadArmorPoints(currentHealth, unit.HealthPoints);
            unitUIController.SetName(unitName);
        }
        
    }
}