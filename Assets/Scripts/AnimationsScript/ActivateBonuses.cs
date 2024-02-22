using System.Collections;
using UnityEngine;

public class ActivateBonuses : Action_Animation
{
    public TurnChanger turnChanger;
    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(0f);
        turnChanger.SetActiveItems();
        AnimationIsFinish = true;
    }
}
