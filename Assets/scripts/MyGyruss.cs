using UnityEngine;
using UnityGameBase;
using UnityGameBase.Core.Input;

public class MyGyruss : Game
{

    #region implemented abstract members of Game

    protected override void Initialize()
    {

    }

    protected override void GameSetupReady()
    {
        InitKeys();        
    }
    #endregion

    // init keymapping 
    void InitKeys()
    {
        // init keymappingsettings for the leftArrow-button
        UnityGameBase.Core.Input.KeyMapping leftArrow = new UnityGameBase.Core.Input.KeyMapping();
        leftArrow.name = "leftArrow";
        leftArrow.keyMode = UnityGameBase.Core.Input.KeyMapping.EKeyMode.Down;
        leftArrow.keyCode = KeyCode.LeftArrow;
        leftArrow.isTap = true;
        // init keymappingsettings for the rightArrow-button
        UnityGameBase.Core.Input.KeyMapping rightArrow = new UnityGameBase.Core.Input.KeyMapping();
        rightArrow.name = "rightArrow";
        rightArrow.keyMode = UnityGameBase.Core.Input.KeyMapping.EKeyMode.Down;
        rightArrow.keyCode = KeyCode.RightArrow;
        rightArrow.isTap = true;
        // init keymappingsettings for the spaceButton
        UnityGameBase.Core.Input.KeyMapping spaceButton = new UnityGameBase.Core.Input.KeyMapping();
        spaceButton.name = "spaceButton";
        spaceButton.keyMode = UnityGameBase.Core.Input.KeyMapping.EKeyMode.Up;
        spaceButton.keyCode = KeyCode.Space;
        spaceButton.isTap = true;
        // add custom-settings
        gameInput.keyMappings.Add(leftArrow);
        gameInput.keyMappings.Add(rightArrow);
        gameInput.keyMappings.Add(spaceButton);
    }
}