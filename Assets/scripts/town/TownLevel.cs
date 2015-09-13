using UnityEngine.UI;
using System;
using config;
using common;
using UnityEngine;

public class TownLevel : LevelView {

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
        moveUp();
    }

    public void onDungeonClick()
    {
        SendMessageUpwards(MsgID.TRY_ENTER_DUNGEON);
    }
}
