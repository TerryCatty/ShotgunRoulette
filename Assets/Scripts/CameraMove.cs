using DG.Tweening;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float mouseSensivity;
    private float mouseX;
    private float mouseY;
    private float xRotation;
    private float yRotation;
    public Transform playerFace;
    public Transform target;
    private bool canControl = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70, 70);
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -45, 45);

        if (canControl == false) return;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public void SetControl(bool control)
    {
        canControl = control;
    }
}
