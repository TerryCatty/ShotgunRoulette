using UnityEngine;
using System.Collections.Generic;

public class ChangesManager : MonoBehaviour
{
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private Transform ShotgunPin;

    public Player currentPlayer;
    [Header("Animations")]
    [SerializeField] private Action_Animation spawnCartridges;
    [SerializeField] private Action_Animation showCartridges;
    [SerializeField] private Action_Animation cameraBack;
    [SerializeField] private Action_Animation deleteCartridges;
    [SerializeField] private Action_Animation healthChangesShow;
    [SerializeField] private Action_Animation shotgunBackup;
    [SerializeField] private Action_Animation shotgunPickupPlayer;
    [SerializeField] private Action_Animation shotgunShootingPlayerOpponent;
    [SerializeField] private Action_Animation shotgunShootingPlayerHimself;
    [SerializeField] private Action_Animation changePlayerShotgun;
    [SerializeField] private Action_Animation changeTurnPlayer;
    [SerializeField] private Action_Animation activateBonus;
    [SerializeField] private Action_Animation setControlTrue;
    [SerializeField] private Action_Animation setControlFalse;
    [SerializeField] private Action_Animation useCan;

    public void ActivateBonuses()
    {
        animationsManager.AddAnimation(activateBonus);
    }

    public void UseCan(CanItem item)
    {
        useCan.GetComponent<UseCan>().canItem = item;
        //CameraUp();
        animationsManager.AddAnimation(useCan);
    }
    public void ChangeSideShotgun()
    {
        changePlayerShotgun.GetComponent<MoveObject>().targetPos = currentPlayer.transform.position;
        changePlayerShotgun.GetComponent<MoveObject>().targetRot = currentPlayer.transform.rotation.eulerAngles;
        //Debug.Log(player.name);
        animationsManager.AddAnimation(changePlayerShotgun);
    }

    public void ChangeTurnPlayer(Player player)
    {
        changeTurnPlayer.GetComponent<ChangeTurnPlayer>().player = player;
        animationsManager.AddAnimation(changeTurnPlayer);
    }
    public void ChangeHealth(Player player, int value)
    {
        player.ChangeHealth(value);
        animationsManager.AddAnimation(healthChangesShow);
    }

    public void ShotgunBackup()
    {
        animationsManager.AddAnimation(shotgunBackup);
        ChangeSideShotgun();
    }

    public void ShotgunPickup(GameObject player)
    {
        shotgunPickupPlayer.GetComponent<ShotgunPickupPlayer>().SetHands(
            player.GetComponent<Player>().GetLeftHand(),
            player.GetComponent<Player>().GetRightHand());
        animationsManager.AddAnimation(shotgunPickupPlayer);
    }

    public void PlayerShootOpponent()
    {
        animationsManager.AddAnimation(shotgunShootingPlayerOpponent);
        animationsManager.AddAnimation(shotgunPickupPlayer);
        ShotgunBackup();
    }

    public void PlayerShootHimself()
    {
        animationsManager.AddAnimation(shotgunShootingPlayerHimself);
        animationsManager.AddAnimation(shotgunPickupPlayer);
        ShotgunBackup();
    }


    public void OpponentShoot()
    {
        animationsManager.AddAnimation(shotgunPickupPlayer);
        animationsManager.AddAnimation(shotgunShootingPlayerOpponent);
        animationsManager.AddAnimation(shotgunPickupPlayer);
        ShotgunBackup();
    }

    public void OpponentShootHimself()
    {
        animationsManager.AddAnimation(shotgunPickupPlayer);
        animationsManager.AddAnimation(shotgunShootingPlayerHimself);
        animationsManager.AddAnimation(shotgunPickupPlayer);
        ShotgunBackup();
    }

    public void SpawnCartridges(List<Transform> cartridges)
    {
        deleteCartridges.GetComponent<DeleteCartridges>().cartridges = cartridges;
        animationsManager.AddAnimation(setControlFalse);
        animationsManager.AddAnimation(showCartridges);
        animationsManager.AddAnimation(spawnCartridges);
        animationsManager.AddAnimation(deleteCartridges);
        animationsManager.AddAnimation(cameraBack);
        animationsManager.AddAnimation(setControlTrue);

    }
    
    public void StartAnimations()
    {
        animationsManager.StartPlayAnimations();
    }

    public bool GetAnimationWork()
    {
        return animationsManager.animationIsWork;
    }
}
