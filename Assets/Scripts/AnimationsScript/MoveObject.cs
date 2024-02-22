using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoveObject : Action_Animation
{
    [SerializeField] private GameObject moveObj;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject tempObj;
    public Vector3 targetPos;
    public Vector3 targetRot;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        shotgun.transform.SetParent(tempObj.transform);
        yield return new WaitForSeconds(0.1f);
        /*if (moveObj.transform.position != targetPos ||
            moveObj.transform.localPosition != targetPos ||
            moveObj.transform.rotation.eulerAngles != targetRot ||
            moveObj.transform.localRotation.eulerAngles != targetRot)
        {
           
        }*/
        moveObj.transform.position = targetPos;
        moveObj.transform.rotation = Quaternion.Euler(targetRot);
        yield return new WaitForSeconds(0.5f);
        shotgun.transform.SetParent(moveObj.transform);
        AnimationIsFinish = true;
    }
}
