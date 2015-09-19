using UnityEngine.UI;
using System;
using config;
using UnityEngine;

public class TownView : MonoBehaviour {

    public Button dungeonBtn;


    void Start()
    {
        try
        {
            dungeonBtn.onClick.AddListener(onDungeonClick);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    void setButtonsActive(bool value)
    {
        dungeonBtn.interactable = value;
    }

    public void OnDescend()
    {
        setButtonsActive(false);
        Destroy(gameObject);
    }

    public void onDungeonClick()
    {
        SendMessageUpwards(MsgID.TRY_ENTER_DUNGEON);
    }
}
