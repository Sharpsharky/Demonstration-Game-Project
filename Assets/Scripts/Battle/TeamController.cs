namespace DemonstrationGameProject.Battle
{
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using Random = UnityEngine.Random;
    using System;
    using Units.UnitClasses.MainClasses;
    
    public class TeamController : SerializedMonoBehaviour
    {
        [SerializeField] private string teamName;
        [SerializeField] private BattlePanelController battlePanelController;
        private List<UnitPresenter> aliveUnits = new List<UnitPresenter>();

        private void Awake()
        {
            InitializeUnits();
        }

        public void AttackEnemyTeam(TeamController enemyTeam, Action OnFinishCurrentState)
        {
            var attackingEnemy = DrawUnitToAttack();
            var defendingEnemy = enemyTeam.DrawUnitToDefend();

            if (attackingEnemy == null)
            {
                battlePanelController.DisplayNoUnitAvailableForAMoment(teamName, OnFinishCurrentState);
                return;
            }
            
            attackingEnemy.AttackEnemy(defendingEnemy, OnFinishCurrentState);
            
        }

        public void DecreaseAttackIntervalOfUnits()
        {
            foreach (var unit in aliveUnits)
            {
                unit.DecreaseAttackInterval();
            }
        }

        public void RemoveUnitFromList(UnitPresenter unitToRemove)
        {
            aliveUnits.Remove(unitToRemove);
        }
        
        public int GetAliveUnits()
        {
            return aliveUnits.Count;
        }
        
        public UnitPresenter DrawUnitToAttack()
        {
            List<UnitPresenter> availableUnits = new List<UnitPresenter>();

            foreach (var unit in aliveUnits)
            {
                if(unit.AttackInterval <= 0) availableUnits.Add(unit);
            }

            if (availableUnits.Count == 0) return null;
            
            int rand = Random.Range(0, availableUnits.Count);
            return availableUnits[rand];
        }
        
        public UnitPresenter DrawUnitToDefend()
        {
            int rand = Random.Range(0, aliveUnits.Count);
            return aliveUnits[rand];
        }

        public string GetTeamName()
        {
            return teamName;
        }
        
        private void InitializeUnits()
        {
            foreach (Transform unit in transform)
            {
                UnitPresenter unitPresenter = unit.GetComponent<UnitPresenter>();
                aliveUnits.Add(unitPresenter);
                unitPresenter.Initialize(this);
            }
        }


        
    }
}