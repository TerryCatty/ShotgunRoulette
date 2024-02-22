using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusChoosingManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ChangesManager changesManager;

    public List<ChooseItem> items;
    [SerializeField] private ChooseItem currentItem;

    [SerializeField] private TurnChanger turnChanger;

    [SerializeField] private ChooseItem[] spawningItems;
    [SerializeField] private Transform box;
    private CellBonus choosenCell;
    public CellBonus[] cells;
    [SerializeField] private bool canStandBonus = false;

    public void ChangeItem(ChooseItem Item)
    {
        currentItem = Item;
        foreach (var item in items)
        {
            item.canItteract = false;
            item.isChoose = false;
        }

        currentItem.isChoose = true;
    }

    public void SetReadyToUse()
    {
        foreach (var item in items)
        {
            item.canItteract = true;
            item.isChoose = false;
        }
    }

    public void SetUnreadyToUse()
    {
        foreach (var item in items)
        {
            item.canItteract = false;
            item.isChoose = false;
        }
    }

    public void SpawnBonuses()
    {
       StartCoroutine(QueueBonuses());
    }

    IEnumerator QueueBonuses()
    {
        Debug.Log(gameObject.name);
        player.bonusesChoose = false;
        yield return new WaitWhile(turnChanger.GetAnimationsWork);
        int countFreeCells = 0;

        foreach(var cell in cells)
        {
            if (!cell.isTaken) countFreeCells++;
        }
        int randomCountBonuses = 0;

        if (countFreeCells >= 4)
            randomCountBonuses = Random.Range(1, 4);
        else
            randomCountBonuses = Random.Range(1, randomCountBonuses);

       
        box.gameObject.SetActive(true);

        if (countFreeCells == 0)
        {
            randomCountBonuses = 0;
            box.gameObject.SetActive(false);
        }

        for (int i = 0; i < randomCountBonuses; i++)
        {
            SetUnreadyToUse();
            yield return new WaitWhile(turnChanger.GetAnimationsWork);
            player.ClickBox();
            yield return new WaitUntil(() => { return canStandBonus == true; });
            canStandBonus = false;
            int randomIndex = Random.Range(0, spawningItems.Length);
            GameObject spawnedBonus = Instantiate(spawningItems[randomIndex].gameObject, box.transform.position, Quaternion.identity);
            spawnedBonus.GetComponent<ChooseItem>().player = this.player;
            spawnedBonus.GetComponent<ChooseItem>().changesManager = changesManager;
            spawnedBonus.GetComponent<ChooseItem>().bonusChoosingManager = this;

            spawnedBonus.transform.SetParent(transform);    


            player.SetItemsCell();
            yield return new WaitUntil(() => { return choosenCell != null; });
            items.Add(spawnedBonus.GetComponent<ChooseItem>());
            spawnedBonus.transform.position = choosenCell.gameObject.transform.position;
            spawnedBonus.GetComponent<ChooseItem>().startPos = spawnedBonus.transform.position;
            choosenCell = null;
            box.GetComponent<PickUpBonus>().canClick = true;
        }
        box.gameObject.SetActive(false);

        player.bonusesChoose = true;

        yield return new WaitWhile(turnChanger.GetAnimationsWork);
        turnChanger.SetNewTurn();
    }

    public void ChooseCell(CellBonus cell)
    {
        cell.isTaken = true;
        choosenCell = cell;
    }

    public void ClickBox()
    {
        canStandBonus = true;
    }

}
