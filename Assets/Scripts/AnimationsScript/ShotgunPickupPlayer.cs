using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ShotgunPickupPlayer : Action_Animation
{
    [SerializeField] private GameObject shotgun;
    [SerializeField] private Transform rightHand, leftHand, targetRightHand, targetLeftHand;
    [SerializeField] private Vector3 targetPosShotgun;
    [SerializeField] private Vector3 targetRotShotgun;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    public void SetHands(Transform leftHand, Transform rightHand)
    {
        this.leftHand = leftHand;
        this.rightHand = rightHand;
    }

    private IEnumerator Animation()
    {

        if (shotgun.transform.localPosition == targetPosShotgun || shotgun.transform.localRotation.eulerAngles == targetRotShotgun)
        {
            yield return new WaitForSeconds(0f);
        }
        else
        {
            rightHand.DOLocalMoveY(rightHand.transform.position.y + 2, 0.2f);
            yield return new WaitForSeconds(0.1f);
            rightHand.DOLocalMove(targetRightHand.position, 0.6f);
            yield return new WaitForSeconds(0.5f);
            targetRightHand.gameObject.SetActive(true);
            rightHand.gameObject.SetActive(false);

            shotgun.transform.DOLocalMove(targetPosShotgun, 1f);
            shotgun.transform.DOLocalRotate(targetRotShotgun, 0.8f);
            yield return new WaitForSeconds(0.6f);
            leftHand.DOLocalRotate(new Vector3(-90, leftHand.transform.rotation.y, leftHand.transform.rotation.z), 0.2f);
            leftHand.DOMove(targetLeftHand.position, 0.6f);
            yield return new WaitForSeconds(0.5f);
            targetLeftHand.gameObject.SetActive(true);
            leftHand.gameObject.SetActive(false);
        }
       
        AnimationIsFinish = true;
    }
}
