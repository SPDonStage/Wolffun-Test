using Unity.VisualScripting;
using UnityEngine;

public abstract class CropBaseState
{
    public abstract void EnterState(CropStateManager manager);
    public abstract void UpdateState(CropStateManager manager);
  //  public abstract void ExitState();

}
