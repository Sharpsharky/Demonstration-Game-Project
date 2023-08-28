namespace DemonstrationGameProject.Units.UnitClasses.MainClasses
{
    using System;
    using System.Collections;
    using DG.Tweening;
    using UnityEngine;

    public abstract class LongRangeUnitPresenter : UnitPresenter
    {
        [SerializeField] private GameObject projectilePrefab;
        
        public override void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            attackInterval = unit.AttackInterval;

            int damage = GetDamage(unitPresenter.UnitAttributes);
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            MoveProjectileToEnemy(projectile, unitPresenter.transform.position);
            
            StartCoroutine(ExecuteAttack(projectile, unitPresenter, damage));
            StartCoroutine(FinishStateWhenUnitIsBackInPlace(OnFinishCurrentState));

            attackInterval = unit.AttackInterval;

        }
        
        public void MoveProjectileToEnemy(GameObject projectile, Vector3 enemyPosition)
        {
            projectile.transform.DOMove(enemyPosition, TimeToHitEnemy).SetDelay(0).SetEase(Ease.Flash);
        }

        public IEnumerator FinishStateWhenUnitIsBackInPlace(Action OnFinishCurrentState)
        {
            yield return new WaitForSeconds(TimeToHitEnemy);
            OnFinishCurrentState();
        }
        
        private IEnumerator ExecuteAttack(GameObject projectile, UnitPresenter unitPresenter, int damage)
        {
            yield return new WaitForSeconds(TimeToHitEnemy);
            Destroy(projectile);
            unitPresenter.AcquireDamage(damage);        
        }
    }
}