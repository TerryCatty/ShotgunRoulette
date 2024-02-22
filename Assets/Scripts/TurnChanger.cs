using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChanger : MonoBehaviour
{
    [SerializeField] private List<Player> players;
    public Player localPlayer;
    public Player currentPlayer;
    [SerializeField] private Shotgun shotgun;
    [SerializeField] private GameObject shotgunPin;
    [SerializeField] private GameObject shotChoose;


    private ChangesManager changeManager;
    [SerializeField] private AnimationsManager animationsManager;

    private bool playerTurn;

    [SerializeField] private int indexCurrentPlayer = 0;
    private int countSteps = 1;

    private void Start()
    {
        changeManager = FindAnyObjectByType<ChangesManager>();
    }

    public void SpawnBonuses()
    {
        foreach (var player in players)
        {
            player.bonusManager.SpawnBonuses();
        }
    }

    public void SetNewTurn()
    {
        foreach(var player in players)
        {
            if (player.bonusesChoose == false) return;
        }

        int randomTurn = UnityEngine.Random.Range(0, players.Count);
        if(randomTurn >= players.Count)
        {
            randomTurn = players.Count - 1;
        }
        indexCurrentPlayer = randomTurn;

        StartCoroutine(NewTurnWait());

    }

    IEnumerator NewTurnWait()
    {
        yield return new WaitWhile(GetAnimationsWork);
        /*indexCurrentPlayer++;
        if (indexCurrentPlayer >= players.Count)
            indexCurrentPlayer = 0;
*/
        currentPlayer = players[indexCurrentPlayer];

        changeManager.currentPlayer = currentPlayer;
        changeManager.ChangeSideShotgun();

        foreach(var player in players)
        {
            player.bonusManager.SetUnreadyToUse();
        }
        currentPlayer.bonusManager.SetReadyToUse();

       

        //SetPlayerShotgun(currentPlayer);
       
        currentPlayer.ChangeTurn(true);
       
        yield return new WaitWhile(() => currentPlayer.GetShot() == true);

        changeManager.StartAnimations();
    }

    public bool GetAnimationsWork()
    {
        return changeManager.GetAnimationWork();
    }
    public void CheckPlayers()
    {
        List<Player> tempList = new List<Player>();
        foreach (Player player in players)
        {
            if(player.health > 0)
            {
                tempList.Add(player);
            }
        }

        players.Clear();
        players = tempList;

        if(players.Count == 1)
        {
            playerTurn = true;
            Debug.Log($"{players[0]} победил");
        }
    }
    public void StartAnimations()
    {
        StartCoroutine(AnimationsPlay());
    }

    IEnumerator AnimationsPlay()
    {
        /* int tempId = indexCurrentPlayer;
         tempId += 1;
         if (tempId >= players.Count)
         {
             tempId = 0;
         }

         if (countSteps == 1)
         {
             if (players[tempId] == localPlayer)
             {
                 changeManager.CameraDown();
             }
             else
             {
                 changeManager.CameraUp();
             }
         }*/
        yield return new WaitUntil(animationsManager.GetAnimationsState);

        changeManager.ActivateBonuses(); 
        animationsManager.StartPlayAnimations();

        yield return new WaitWhile(() => { return animationsManager.GetAnimationsState() == false; });

        animationsManager.AnimationsIsFinish = false;

        NextStep();
    }

    private void NextStep()
    {
        if (players.Count == 1) return;

        playerTurn = false;
        if (countSteps <= 0)
        {
            currentPlayer.ChangeTurn(false);
            indexCurrentPlayer++;
            if (indexCurrentPlayer >= players.Count)
                indexCurrentPlayer = 0;

            currentPlayer = players[indexCurrentPlayer];
            countSteps = 1;
        }


        currentPlayer = players[indexCurrentPlayer];

        currentPlayer.ChangeTurn(true);

        foreach (var player in players)
        {
            player.bonusManager.SetUnreadyToUse();
        }
        currentPlayer.bonusManager.SetReadyToUse();


        changeManager.currentPlayer = currentPlayer;
        changeManager.ChangeSideShotgun();

    }

    private void SetPlayerShotgun(Player player)
    {
        //changeManager.ChangeSideShotgun(player.gameObject);
        shotgun.transform.SetParent(null);
        shotgunPin.transform.position = player.transform.position;
        shotgunPin.transform.rotation = player.transform.rotation;
        shotgun.transform.SetParent(shotgunPin.transform);
    }
    
    public void SetTargetYourself()
    {
        if (playerTurn || animationsManager.animationIsWork) return;

        foreach (var player in players)
        {
            player.bonusManager.SetUnreadyToUse();
        }
        currentPlayer.bonusManager.SetReadyToUse();

        shotChoose.SetActive(false);


        int temp = indexCurrentPlayer;
        if (temp >= players.Count) temp = 0;
        if (players[temp] == localPlayer)
        {
            changeManager.PlayerShootHimself();
        }
        else
        {
            changeManager.OpponentShootHimself();
        }
        playerTurn = true;
        shotgun.SetTarget(players[temp]);
        players[temp].myShot = false;
    }

    public void SetTargetOpponent()
    {
        if (playerTurn || animationsManager.animationIsWork) return;

        foreach (var player in players)
        {
            player.bonusManager.SetUnreadyToUse();
        }
        currentPlayer.bonusManager.SetReadyToUse();

        countSteps -= 1;
        int temp = indexCurrentPlayer + 1;
        if (temp >= players.Count) temp = 0;
        //indexCurrentPlayer++;

        /*if (indexCurrentPlayer >= players.Count)
        {
            indexCurrentPlayer = 0;
        }*/
        //currentPlayer = players[indexCurrentPlayer];

        shotChoose.SetActive(false);
        if (players[temp] == localPlayer)
        {
            changeManager.PlayerShootOpponent();
        }
        else
        {
            changeManager.OpponentShoot();
        }
        playerTurn = true;
        int indexTarget = temp;

        //indexTarget++;

        if (indexTarget >= players.Count) indexTarget = 0;

        shotgun.SetTarget(players[indexTarget]);
        players[temp].myShot = false;
    }


    


    public void SetActiveItems()
    {
        foreach (var player in players)
        {
            player.bonusManager.SetUnreadyToUse();
        }
        currentPlayer.bonusManager.SetReadyToUse();
    }
}
