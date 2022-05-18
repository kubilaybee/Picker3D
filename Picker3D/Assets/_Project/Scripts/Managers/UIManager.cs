using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public string CanvasElementsResourcePathName;

    public enum UIElementsID { None,UIStart,UIGamePlay, UILevelSuccess, UILevelFail }

    [Serializable]
    public class UIElements
    {
        public string UIElementResourceName;
        public UIElementsID uIElementID;
    }

    public List<UIElements> uIElements = new List<UIElements>();
    public Transform UIPanels;

    private void Awake()
    {
        Instance = this;
    }

    public void createUIElement(UIElementsID uIElement)
    {
        foreach (Transform item in UIPanels)
        {
            // destroy last panel
            Destroy(item.gameObject);
        }
        for(int i = 0; i < uIElements.Count; i++)
        {
            if (uIElements[i].uIElementID == uIElement)
            {
                string tempPath = CanvasElementsResourcePathName + "/" + uIElements[i].UIElementResourceName;
                var tempPanel = Instantiate(Resources.Load(tempPath), UIPanels) as GameObject;
            }
        }
    }
}
