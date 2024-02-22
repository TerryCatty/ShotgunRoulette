using UnityEngine;

public class ShotgunItem : ChooseItem
{
    [SerializeField] private GameObject chooseShot;
    [SerializeField] private TurnChanger turnChanger;
    [SerializeField] private GameObject leftHand, rightHand;

    public override void Choose()
    {
        base.Choose();
        chooseShot.SetActive(true);
        changesManager.ShotgunPickup(turnChanger.currentPlayer.gameObject);
        changesManager.StartAnimations();
    }

    public void SetActiveHands(bool active)
    {
        rightHand.SetActive(active);
        leftHand.SetActive(active);
    }
}
