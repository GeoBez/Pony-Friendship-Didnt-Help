using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_choose : MonoBehaviour
{
    public Modes mod;
    public int index;
    private skill_choose parent;
    private Skill_Canvas skill_canvas;

    private void Start()
    {
        parent = GetComponentInParent<skill_choose>();
        skill_canvas = GetComponentInParent<Skill_Canvas>();
    }

    public void MakeMoodActive()
    {
        mod.Activate();
        
        foreach (var card in parent.cards)
        {
            card.button.GetComponent<button_choose>().mod.isUsed = false;
        }
              
        //parent._allModes.Remove(mod);
        if (index != -1)
            parent._allModes.RemoveAt(index);

        skill_canvas.skill_Points--;
        parent.xp_Bar.skill_Points--;

        parent._isItWork = false;

        //Debug.Log(parent._allModes.Count);

        /*if (skill_canvas.skill_Points > 0)
        {

        }*/
    }
}
