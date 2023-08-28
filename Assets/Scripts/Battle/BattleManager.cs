namespace DemonstrationGameProject.Battle
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using System;

    public class BattleManager : SerializedMonoBehaviour
    {
        private BattleState currentBattleState;

        [SerializeField] private TeamController firstTeamController;
        [SerializeField] private TeamController secondTeamController;
        
        [SerializeField] private int secondsToStartBattle = 3;
        [SerializeField] private float timeToChangeState = 1;
        
        [SerializeField] private BattlePanelController battlePanelController;

        private Action OnFinishCurrentState;
        private string teamNameThatWon;
        
        private void Awake()
        {
            OnFinishCurrentState += ChangeBattleStateAfterTime;
        }

        private void Start()
        {
            ChangeState(BattleState.Start);
        }

        private void ChangeBattleStateAfterTime()
        {
            Invoke(nameof(ChangeBattleState), timeToChangeState);
        }
        
        private void ChangeBattleState()
        {
            Debug.Log($"Change Battle State: {currentBattleState}");

            switch (currentBattleState)
            {
                case BattleState.Start:
                {
                    int rand = UnityEngine.Random.Range(0, 2);
                    
                    if(rand == 0) ChangeState(BattleState.FirstTeamTurn);
                    else ChangeState(BattleState.SecondTeamTurn);
                    
                    break;
                }
                case BattleState.FirstTeamTurn:
                {
                    if (secondTeamController.GetAliveUnits() <= 0)
                    {
                        teamNameThatWon = firstTeamController.GetTeamName();
                        ChangeState(BattleState.Finish);
                    }
                    else
                        ChangeState(BattleState.SecondTeamTurn);

                    break;
                }
                case BattleState.SecondTeamTurn:
                {
                    if (firstTeamController.GetAliveUnits() <= 0)
                    {
                        teamNameThatWon = secondTeamController.GetTeamName();
                        ChangeState(BattleState.Finish);

                    }
                    else
                        ChangeState(BattleState.FirstTeamTurn);                    
                    
                    break;
                }
            }
        }

        private void ChangeState(BattleState newState)
        {
            currentBattleState = newState;

            switch (currentBattleState)
            {
                case BattleState.Start:
                {
                    battlePanelController.StartCountingTime(secondsToStartBattle, OnFinishCurrentState);
                    break;
                }
                case BattleState.FirstTeamTurn:
                {
                    firstTeamController.DecreaseAttackIntervalOfUnits();
                    firstTeamController.AttackEnemyTeam(secondTeamController, OnFinishCurrentState);
                    break;
                }
                case BattleState.SecondTeamTurn:
                {
                    secondTeamController.DecreaseAttackIntervalOfUnits();
                    secondTeamController.AttackEnemyTeam(firstTeamController, OnFinishCurrentState);
                    break;
                }
                case BattleState.Finish:
                {
                    battlePanelController.DisplayWinningTeam(teamNameThatWon);
                    break;
                }
            }
            
        }
        
        
        
    }
}