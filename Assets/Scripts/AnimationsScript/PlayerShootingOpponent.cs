using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerShootingOpponent : Action_Animation
{
    [SerializeField] private GameObject shotgun;
    [SerializeField] private Vector3 targetPosShotgun;
    [SerializeField] private Vector3 targetRotShotgun;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        shotgun.transform.DOLocalMove(targetPosShotgun, 0.7f);
        shotgun.transform.DOLocalRotate(targetRotShotgun, 1f);
        yield return new WaitForSeconds(2f);
        shotgun.GetComponent<Animator>().Play("Shoot", 0, 0.25f);
        yield return new WaitForSeconds(0.2f);
        AnimationIsFinish = true;
    }
}
