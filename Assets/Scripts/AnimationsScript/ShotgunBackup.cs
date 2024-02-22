using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ShotgunBackup : Action_Animation
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
       
        shotgun.transform.DOLocalMove(targetPosShotgun, 1f);
        shotgun.transform.DOLocalRotate(targetRotShotgun, 1f);
        yield return new WaitForSeconds(0.8f);
        AnimationIsFinish = true;
    }
}
