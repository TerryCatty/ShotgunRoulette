using UnityEngine;

abstract public class Action_Animation : MonoBehaviour
{
     public bool AnimationIsFinish;

    public abstract void StartAnimation();

    public bool GetAnimationsFinish()
    {
        return AnimationIsFinish;
    }
}
