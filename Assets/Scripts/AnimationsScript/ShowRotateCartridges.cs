using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShowRotateCartridges : Action_Animation
{
    [SerializeField] private Transform panel;
    public Vector3 targetRot;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        panel.DOLocalRotate(targetRot, 1f);
        yield return new WaitForSeconds(3f);

        AnimationIsFinish = true;
    }
}
