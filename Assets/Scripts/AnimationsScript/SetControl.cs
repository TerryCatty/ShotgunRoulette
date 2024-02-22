using System.Collections;
using UnityEngine;

public class SetControl : Action_Animation
{
    [SerializeField] private CameraMove camera;
    public bool control;

    public override void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        camera.GetComponent<CameraMove>().SetControl(control);
        yield return new WaitForSeconds(0);
        AnimationIsFinish = true;
    }
}
