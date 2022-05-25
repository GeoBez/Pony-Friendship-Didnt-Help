using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_choose : MonoBehaviour
{
    public Modes mod;

    public void MakeMoodActive()
    {
        mod.Activate();
        var parent = GetComponentInParent<skill_choose>();
        foreach (var card in parent.cards)
        {
            card.button.GetComponent<button_choose>().mod.isUsed = false;
        }

        parent._allModes.Remove(mod);
                
        parent.skills_Canvas.SetActive(false);
    }
}
