using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] healthSticks;
    [SerializeField] private Player player;
    public void RefreshSticks()
    {
        for(int i = 0; i < healthSticks.Length; i++)
        {
            if(i >= player.health) healthSticks[i].SetActive(false);
            else healthSticks[i].SetActive(true);
        }
    }
}
