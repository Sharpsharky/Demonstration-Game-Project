namespace DemonstrationGameProject.Battle
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using General;
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;

    public class BattlePanelController : SerializedMonoBehaviour
    {
        [SerializeField] private TMP_Text timeCounterText;
        [SerializeField] private TMP_Text informationText;
        
        [SerializeField] private float timeCounting = 1;
        [SerializeField] private float timeNoUnitAvailable = 4;
        [SerializeField] private float initialScaleOfTimeCounter = 1;
        [SerializeField] private float scaleMultiplicationOfTimeCounter = -0.5f;

        [SerializeField] private List<string> counterInfos = new List<string>();

        public void StartCountingTime(int timeToCount, Action OnFinishCurrentState)
        {
            StartCoroutine(CountTime(timeToCount, OnFinishCurrentState));
            timeCounterText.gameObject.SetActive(true);
        }        
        public void DisplayWinningTeam(string teamName)
        {
            informationText.text = $"Team {teamName} won!";
            informationText.gameObject.SetActive(true);
        }
        
        public void DisplayNoUnitAvailableForAMoment(string teamName, Action OnFinishCurrentState)
        {
            StartCoroutine(DisplayNoUnitAvailable(teamName, OnFinishCurrentState));
        }
        private IEnumerator DisplayNoUnitAvailable(string teamName, Action OnFinishCurrentState)
        {
            informationText.text = $"No unit in team {teamName} is available now!";
            informationText.gameObject.SetActive(true);
            
            yield return new WaitForSeconds(timeNoUnitAvailable);

            informationText.gameObject.SetActive(false);
            OnFinishCurrentState();
        }
        

        private IEnumerator CountTime(int timeToCount, Action OnFinishCurrentState)
        {
            for (int i = timeToCount; i >= 1; i--)
            {
                DoTweenCustomAnimations.DoBlinkScale(timeCounterText.transform,initialScaleOfTimeCounter,
                    scaleMultiplicationOfTimeCounter);
                timeCounterText.text = i.ToString();
                yield return new WaitForSeconds(timeCounting);
            }
            foreach (string counterInfo in counterInfos)
            {
                DoTweenCustomAnimations.DoBlinkScale(timeCounterText.transform,initialScaleOfTimeCounter,
                    scaleMultiplicationOfTimeCounter);
                timeCounterText.text = counterInfo;
                yield return new WaitForSeconds(2*timeCounting);
            }

            OnFinishCurrentState();
            
            timeCounterText.transform.DOScale(0, timeCounting).SetDelay(0);
            yield return new WaitForSeconds(timeCounting);
            timeCounterText.gameObject.SetActive(false);

            yield return null;
        }
    }
}