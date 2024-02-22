using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private List<string> cartridges;
    [SerializeField] private Player targetShoot;
    [SerializeField] private TurnChanger turnChanger;
    [SerializeField] private SpawnCartridges spawnCartridges;

    private ChangesManager changeManager;

    private int index;


    private void Start()
    {
        changeManager = FindAnyObjectByType<ChangesManager>();
        ReloadShotgun();
    }

  
    private void ReloadShotgun()
    {
        index = 0;
        cartridges = new List<string>();
        int countOfCartridges = Random.Range(3, 6);
        int countOfLoaded = Random.Range(2, countOfCartridges - 1);
        int countOfBlankCartridges = countOfCartridges - countOfLoaded;

        spawnCartridges.SetCountCombat(countOfLoaded);
        spawnCartridges.SetCountBlank(countOfBlankCartridges);
        spawnCartridges.Spawn();


        for (int i = 0; i < countOfCartridges; i++)
        {
            if(countOfBlankCartridges == 0)
            {
                cartridges.Add("loaded");
                countOfLoaded--;
            }
            else if(countOfLoaded == 0)
            {
                cartridges.Add("blank");
                countOfBlankCartridges--;
            }
            else
            {
                int chanceBlank = Random.Range(0, 100);

                if(chanceBlank >= 50)
                {
                    cartridges.Add("blank");
                    countOfBlankCartridges--;
                }
                else
                {
                    cartridges.Add("loaded");
                    countOfLoaded--;
                }
            }

        }

        turnChanger.SpawnBonuses();

    }

    public void StartShooting()
    {
        if (cartridges[index] == "blank"){
            BlankShot();
        }
        else if (cartridges[index] == "loaded")
        {
            CombatShot();
        }

        index++;
        StartCoroutine(ShootingWait());

        if (index >= cartridges.Count)
        {
            ReloadShotgun();
        }
    }

    private void BlankShot()
    {

    }

    private void CombatShot()
    {

        changeManager.ChangeHealth(targetShoot, damage * (-1));
    }

    public void SetTarget(Player player)
    {
        targetShoot = player;

        StartShooting();
    }

    private IEnumerator ShootingWait()
    {
        turnChanger.CheckPlayers();
        yield return new WaitForSeconds(0.2f);
        turnChanger.StartAnimations();
    }
}
