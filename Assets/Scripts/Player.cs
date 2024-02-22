using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string nickname;
    public TurnChanger turnChanger;
    public AnimationsManager animationsManager;
    public BonusChoosingManager bonusManager;
    public PickUpBonus box;
    public GameObject shotChoose;
    public int health = 3;
    public bool myTurn = false;
    public bool bonusesChoose = false;
    public bool myShot = false;

    [SerializeField] private Transform leftHand, rightHand;

    public Transform GetRightHand() { return rightHand; }

    public Transform GetLeftHand() {  return leftHand; }

    public void ChangeHealth(int damage)
    {
        health += damage;

        if(health > 5)
            health = 5;

        if (health <= 0)
            Death();
    }

    public virtual void ChangeTurn(bool value)
    {
        myShot = value;
        myTurn = value;
        StartCoroutine(CheckMyTurn());
        //turnChanger.ChangeTurnPlayer(this);
    }
    public bool GetShot()
    {
        return myShot;
    }
    private void Death()
    {
        Debug.Log($"Игрок {nickname} выбыл");
    }

    public virtual void StartLogicPlayer()
    {

    }

    public virtual void ClickBox() { }
    public virtual void SetItemsCell() { }

    IEnumerator CheckMyTurn()
    {
        yield return new WaitUntil(animationsManager.GetAnimationsState);
        StartLogicPlayer();
    }
}
