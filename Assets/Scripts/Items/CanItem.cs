using UnityEngine;

public class CanItem : ChooseItem
{

    public override void Choose()
    {
        base.Choose();
        changesManager.UseCan(this);
        changesManager.ChangeHealth(player, 1);
        changesManager.StartAnimations();
    }
}
