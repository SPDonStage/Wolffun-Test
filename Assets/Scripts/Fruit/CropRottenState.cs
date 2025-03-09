using System.Collections;
using UnityEngine;

public class CropRottenState : CropBaseState
{
    public int currentTime = 0;
    public override void EnterState(CropStateManager manager)
    {
        //   Debug.Log("Rotten State");
        // currentTime = manager.timeToBeRotten;
        manager.rottenBar.enabled = true;
        manager.StartCoroutine(RottenTime(manager.timeToBeRotten));
    }

    public override void UpdateState(CropStateManager manager)
    {
    //    Debug.Log(((float)manager.timeToBeRotten - (float)currentTime) / (float)manager.timeToBeRotten);
        manager.rottenBar.fillAmount = ((float)manager.timeToBeRotten - (float)currentTime) / (float)manager.timeToBeRotten;
        if (currentTime >= manager.timeToBeRotten)
        {
            manager.BeRotten();
        } 
    }
    public IEnumerator RottenTime(int timeToBeRotten)
    {
        if (timeToBeRotten != 0)
        {
            while (currentTime < timeToBeRotten)
            {
                yield return new WaitForSeconds(1);
                //    currentProgress += (1 / manager.timeToBeWhole) * Vector2.one; //progress grow up over time
                currentTime++;
            }
        }
    }
}
