using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : Action_Animation
{
    [SerializeField] private GameObject moveObj;
    public Vector3 targetPos;
    public Vector3 targetRot;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        if (moveObj.transform.position != targetPos ||
            moveObj.transform.localPosition != targetPos ||
            moveObj.transform.rotation.eulerAngles != targetRot ||
            moveObj.transform.localRotation.eulerAngles != targetRot)
        {
            moveObj.transform.DOLocalMove(targetPos, 1.5f);
            moveObj.transform.DOLocalRotate(targetRot, 1.3f);
            yield return new WaitForSeconds(1.2f);
        }

        AnimationIsFinish = true;
    }
}
