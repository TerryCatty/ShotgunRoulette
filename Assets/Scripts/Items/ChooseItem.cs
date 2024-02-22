using UnityEngine;
using DG.Tweening;

public class ChooseItem : MonoBehaviour
{
    public bool mouseEnter;
    public bool canItteract = true;
    public bool isChoose;
    public Vector3 startPos;
    public BonusChoosingManager bonusChoosingManager;
    public ChangesManager changesManager;
    public Player player;
    public CellBonus cellBonus;

    private void Start()
    {
        startPos = transform.position;
    }
    private void OnMouseEnter()
    {
        if (changesManager.GetAnimationWork() == false)
        {
            if (isChoose || canItteract == false) return;
            mouseEnter = true;
            transform.DOMove(startPos + new Vector3(0, 0.2f, 0), 0.2f);
        } 
       
    }

    private void OnMouseOver()
    {
        if (changesManager.GetAnimationWork() == false)
        {
            if (isChoose || canItteract == false) return;
            mouseEnter = true;
            transform.DOMove(startPos + new Vector3(0, 0.2f, 0), 0.2f);
        }
    }

    private void OnMouseDown()
    {
        if (changesManager.GetAnimationWork() == false)
        {
            if (isChoose || canItteract == false) return;
            Choose();
        }
    }
    private void OnMouseExit()
    {
        if (changesManager.GetAnimationWork() == false)
        {
            if (isChoose || canItteract == false) return;
            mouseEnter = false;
            transform.DOMove(startPos, 0.2f);
        }
    }

    public virtual void Choose()
    {
        if(cellBonus != null)
            cellBonus.isTaken = false;
        bonusChoosingManager.ChangeItem(this);
    }
}

