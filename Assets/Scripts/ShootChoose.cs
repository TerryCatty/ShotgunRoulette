using UnityEngine;

public class ShootChoose : MonoBehaviour
{
    public TurnChanger turnChanger;
    public string target;
    private void OnMouseDown()
    {
        if(target == "Dealer")
        {
            turnChanger.SetTargetOpponent();
        }
        else
        {
            turnChanger.SetTargetYourself();
        }
    }
}
