using System.Collections;
using UnityEngine;

public class CropGrowingState : CropBaseState
{
   // private Vector2 currentProgress;
    public int currentTime = 0;
    public override void EnterState(CropStateManager manager)
    {
     //   Debug.Log("Growing State"); 
        manager.StartCoroutine(GrowingTime(manager.timeToBeWhole));
    }

    public override void UpdateState(CropStateManager manager)
    {
        ProgressSpriteChange(manager);
        if (currentTime >= manager.timeToBeWhole)
        {
            manager.SwitchState(manager.wholeState);
        }
    }
    public IEnumerator GrowingTime(int timeToGrowUp)
    {
        if (timeToGrowUp != 0)
        {
           while (currentTime < timeToGrowUp)
           {
                yield return new WaitForSeconds(1);
            //    currentProgress += (1 / manager.timeToBeWhole) * Vector2.one; //progress grow up over time
                currentTime++;
           }
        }
    }
    public void ProgressSpriteChange(CropStateManager manager)
    {
        if (currentTime >= 0 && (currentTime < (manager.timeToBeWhole * 20 / 100)))
        {
            manager.spriteRenderer.sprite = manager.progress1;
        } 
        if (currentTime >= (manager.timeToBeWhole * 20 / 100) && (currentTime < (manager.timeToBeWhole * 40 / 100)))
        {
            manager.spriteRenderer.sprite = manager.progress2; 
        }
        if (currentTime >= (manager.timeToBeWhole * 40 / 100) && (currentTime < (manager.timeToBeWhole * 60 / 100)))
        {
            manager.spriteRenderer.sprite = manager.progress3;
        }
        if (currentTime >= (manager.timeToBeWhole * 60 / 100) && (currentTime < (manager.timeToBeWhole * 80 / 100)))
        {
            manager.spriteRenderer.sprite = manager.progress4;
        }
        if (currentTime >= (manager.timeToBeWhole * 80 / 100) && currentTime < manager.timeToBeWhole)
        {
            manager.spriteRenderer.sprite = manager.progress5;
        }
        if (currentTime >= manager.timeToBeWhole)
        {
            manager.spriteRenderer.sprite = manager.progress6; 
        }
    }
}
