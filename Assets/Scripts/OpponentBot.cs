using System;
using System.Collections;
using UnityEngine;

public class OpponentBot : Player
{
    public ShotgunItem shotgun;
    public int chanceShootHimself;
    public override void StartLogicPlayer()
    {
        if(myTurn == false) return;
        StartCoroutine(UseBonus());
    }

    private IEnumerator UseBonus()
    {
        bonusManager.items[1].Choose();
        yield return new WaitForSeconds(0.2f);
        yield return new WaitWhile(() => { return animationsManager.animationIsWork == true; });

        shotgun.Choose();
        yield return new WaitWhile(() => { return animationsManager.animationIsWork == true; });
        ChooseTarget();
        myTurn = false;
    }

    private void ChooseTarget()
    {
        
        int randomValue = UnityEngine.Random.Range(0, 100);
        if(randomValue <= chanceShootHimself)
            turnChanger.SetTargetYourself();
        else
            turnChanger.SetTargetOpponent();
    }

    public override void ChangeTurn(bool value)
    {
        base.ChangeTurn(value);
        StartCoroutine(CheckMyTurn());
    }

    public override void ClickBox()
    {
        base.ClickBox();
        box.Click();
    }

    public override void SetItemsCell()
    {
        base.SetItemsCell();
        foreach (CellBonus cell in bonusManager.cells)
        {
            if (cell.isTaken == false)
            {
                cell.ChooseCell();
                break;
            }
        }
    }

    IEnumerator CheckMyTurn()
    {
        yield return new WaitUntil(animationsManager.GetAnimationsState);
        StartLogicPlayer();
    }
}
