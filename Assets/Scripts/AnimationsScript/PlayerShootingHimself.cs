using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerShootingHimself : Action_Animation
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
        shotgun.transform.DOLocalMove(targetPosShotgun, 1.5f);
        shotgun.transform.DOLocalRotate(targetRotShotgun, 1.3f);
        yield return new WaitForSeconds(2f);
        AnimationIsFinish = true;
    }
}
