using System.Collections;
using UnityEngine;
using DG.Tweening;

public class UseCan : Action_Animation
{
    public BonusChoosingManager bonusManager;
    public CanItem canItem;
    public Vector3[] targetPosCan;
    public Vector3[] targetRotCan;
    public float[] timeRotCan;
    public float[] timePosCan;
    /*public new Transform camera;
    public Vector3[] targetPosCam;
    public Vector3[] targetRotCam;
    public float[] timeRotCam;
    public float[] timePosCam;*/

    public float[] timeBetweenFrames;
    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        /*Vector3 startPosCam = camera.transform.localPosition;
        Vector3 startRotCam = camera.transform.localEulerAngles;*/
        Vector3 startPosCan = canItem.transform.localPosition;
        Vector3 startRotCan = canItem.transform.localEulerAngles;

        for(int i = 0; i < timeRotCan.Length; i++)
        {
           /* camera.transform.DOLocalMove(targetPosCam[i], timePosCam[i]);
            camera.transform.DOLocalRotate(targetRotCam[i], timeRotCam[i]);*/
            canItem.transform.DOLocalMove(targetPosCan[i], timePosCan[i]);
            canItem.transform.DOLocalRotate(targetRotCan[i], timeRotCan[i]);
            yield return new WaitForSeconds(timeBetweenFrames[i]);
        }
        bonusManager.SetReadyToUse();
        Destroy(canItem.gameObject);

        AnimationIsFinish = true;
    }
}
