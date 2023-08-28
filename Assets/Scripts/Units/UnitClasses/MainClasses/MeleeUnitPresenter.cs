namespace DemonstrationGameProject.Units.UnitClasses.MainClasses
{
    using System;
    using System.Collections;
    using DG.Tweening;
    using UnityEngine;

    public abstract class MeleeUnitPresenter : UnitPresenter
    {
        public override void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            int damage = GetDamage(unitPresenter.UnitAttributes);
            MoveToEnemy(unitPresenter.transform.position);
            StartCoroutine(ExecuteAttack(unitPresenter, damage));
            StartCoroutine(FinishStateWhenUnitIsBackInPlace(OnFinishCurrentState));
            attackInterval = unit.AttackInterval;
        }
        
        public void MoveToEnemy(Vector3 enemyPosition)
        {
            Vector3 currentPos = transform.position;
            
            transform.DOMove(enemyPosition, TimeToHitEnemy).SetDelay(0);
            transform.DOMove(currentPos,TimeToHitEnemy).SetDelay(TimeToHitEnemy).SetEase(Ease.OutBack);
        }

        public IEnumerator FinishStateWhenUnitIsBackInPlace(Action OnFinishCurrentState)
        {
            yield return new WaitForSeconds(2 * TimeToHitEnemy);
            OnFinishCurrentState();
        }

        private IEnumerator ExecuteAttack(UnitPresenter unitPresenter, int damage)
        {
            yield return new WaitForSeconds(TimeToHitEnemy);
            unitPresenter.AcquireDamage(damage);        
        }
    }
}