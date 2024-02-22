using System.Collections;
using UnityEngine;

public class ChangeTurnPlayer : Action_Animation
{
    public Player player;
    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.8f);
        player.ChangeTurn(true);
        AnimationIsFinish = true;
    }
}
