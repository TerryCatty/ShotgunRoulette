using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    [SerializeField] private BonusChoosingManager choosingManager;
    public bool canClick = true;
    private void OnMouseDown()
    {
        Click();
    }

    public void Click()
    {
        if (canClick == false) return;
        choosingManager.ClickBox();
        canClick = false;
    }
}
