using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class SpawnCartridges : MonoBehaviour
{
    [SerializeField] private GameObject cartridgeCombat;
    [SerializeField] private GameObject cartridgeBlank;
    [SerializeField] private Transform[] cells;
    [SerializeField] private Transform panel;
    [SerializeField] private ChangesManager changesManager;
    [SerializeField] private BonusChoosingManager bonusChoosingManager;

    [SerializeField] private List<Transform> cartridges;

    private int countCombat;
    private int countBlank;
    private int countCartridges;

    
    public void SetCountCombat(int count)
    {
        countCombat = count;
    }

    public void SetCountBlank(int count)
    {
        countBlank = count;
    }

    public void Spawn()
    {
        cartridges.Clear();
        //panel.transform.DORotate(new Vector3(180, 90, 0), 0f);
        countCartridges = countBlank + countCombat;
        for (int i = 0; i < countCartridges; i++)
        {
            if (i < countCombat)
                SpawnCombat(i);
            else
                SpawnBlank(i);
        }
        bonusChoosingManager.SetUnreadyToUse();
        changesManager.SpawnCartridges(cartridges);
        changesManager.StartAnimations();
    }
    private void SpawnCombat(int index)
    {
        GameObject spawnedCartridge = Instantiate(cartridgeCombat, cells[index].transform.position, Quaternion.identity);
        spawnedCartridge.transform.rotation = Quaternion.Euler(
            spawnedCartridge.transform.rotation.x + 90,
            spawnedCartridge.transform.rotation.y + 90,
            spawnedCartridge.transform.rotation.z);
        spawnedCartridge.transform.SetParent(panel);
        cartridges.Add(spawnedCartridge.transform);
    }

    private void SpawnBlank(int index)
    {
        GameObject spawnedCartridge = Instantiate(cartridgeBlank, cells[index].transform.position, Quaternion.identity);
        spawnedCartridge.transform.rotation = Quaternion.Euler(
            spawnedCartridge.transform.rotation.x + 90,
            spawnedCartridge.transform.rotation.y + 90,
            spawnedCartridge.transform.rotation.z);
        spawnedCartridge.transform.SetParent(panel);
        cartridges.Add(spawnedCartridge.transform);
    }
}
