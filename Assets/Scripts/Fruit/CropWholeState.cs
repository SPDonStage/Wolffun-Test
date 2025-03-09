using System.Collections;
using UnityEngine;

public class CropWholeState : CropBaseState
{
    public bool canHarvest;
    public int numOfCrop;
    public int maxRemainCrop;
    public override void EnterState(CropStateManager manager)
    {
        //  Debug.Log("Whole State");
        canHarvest = true;
      //  manager.SwitchState(manager.rottenState);
        manager.StartCoroutine(ProduceCrop(manager));
        maxRemainCrop = (int)manager.maxLifeTime / (int)manager.intervalToProduce;
    }

    public override void UpdateState(CropStateManager manager)
    {
        manager.cropText.text = numOfCrop.ToString() + "/" + maxRemainCrop.ToString();
        if (numOfCrop == maxRemainCrop)
        {
            manager.SwitchState(manager.rottenState);
        }
    }
    public IEnumerator ProduceCrop(CropStateManager manager)
    {
        int currentTime = 0;
        if (manager.maxLifeTime > 0)
        {
            while (currentTime <= manager.maxLifeTime)
            {
                if (currentTime % manager.intervalToProduce == 0 && currentTime != 0)
                {
                    //  Debug.Log(manager.numOfCrop);
                    if (numOfCrop < maxRemainCrop)
                    {
                        numOfCrop++;
                    }
                }
                yield return new WaitForSeconds(1);
              //  Debug.Log("current:" + currentTime);
                currentTime++;
            }
        }
    }
}
