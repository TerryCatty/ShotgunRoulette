using System.Collections;
using DG.Tweening;
using UnityEngine;

public class AnimationHealthShow : Action_Animation
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 targetRot;
    [SerializeField] private HealthBar[] healthParent;
    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        _camera.gameObject.GetComponent<CameraMove>().SetControl(false);
        Vector3 startPos = _camera.transform.position;
        Vector3 startRot = _camera.transform.rotation.eulerAngles;
        _camera.transform.DOMove(targetPos, 1.5f);
        _camera.transform.DORotate(targetRot, 1.3f);
        yield return new WaitForSeconds(2f);
        foreach (HealthBar healthBar in healthParent)
        {
            healthBar.RefreshSticks();
        }
        
        yield return new WaitForSeconds(1.5f);
        _camera.transform.DOMove(startPos, 1.5f);
        _camera.transform.DORotate(startRot, 1.3f);
        yield return new WaitForSeconds(1.2f);
        _camera.gameObject.GetComponent<CameraMove>().SetControl(true);
        AnimationIsFinish = true;
    }
}
