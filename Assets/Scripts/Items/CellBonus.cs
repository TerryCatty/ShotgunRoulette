using UnityEngine;

public class CellBonus : MonoBehaviour
{
    [SerializeField] private BonusChoosingManager bonusChoosingManager;
    public bool isTaken;

    private void OnMouseDown()
    {
        ChooseCell();
    }

    public void ChooseCell()
    {
        if (!isTaken) bonusChoosingManager.ChooseCell(this);
    }
}
