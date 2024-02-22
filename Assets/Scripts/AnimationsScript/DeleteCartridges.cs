using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class DeleteCartridges : Action_Animation
{
    [SerializeField] private Transform panel;
    public List<Transform> cartridges;
    public Vector3 targetRot;
    [SerializeField] private BonusChoosingManager bonusChoosingManager;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        panel.DOLocalRotate(targetRot, 1f);
        yield return new WaitForSeconds(1f);

        AnimationIsFinish = true;
        foreach (Transform t in cartridges)
        {
            Destroy(t.gameObject);
        }

        bonusChoosingManager.SetReadyToUse();
    }
}
