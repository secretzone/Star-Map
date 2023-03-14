using System;
using System.Collections;
using TMPro;
using UnityEngine;


public class ClickableStar : MonoBehaviour
{
    [NonSerialized]
    public StarData starData;
    private SpriteRenderer _spriteRenderer;
    private bool _displaying;
    
    private bool _inProgress;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // _starMapUI = GameManager.instance.starMapUI;
        // _starMapUI.starNameText.gameObject.SetActive(false);
    }
    
    
    public void Initialize(StarData starData)
    {
        this.starData = starData;
        GetComponent<SpriteRenderer>().color = this.starData.GetStarColor();
        transform.localScale = this.starData.GetStarSize();
        gameObject.name = this.starData.GetFullName();
    }
    
    void OnMouseOver()
    {
        if (!_displaying) //just need to run this once
        {
            _displaying = true;
            StarMap.instance.ShowStarNameText($"{starData.GetFullName()}", 
                starData.GetPosition(), 
                starData.GetStarColor());
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Clicked {starData.name}");
            GameManager.instance.ShowSolarSystemView(starData);
        }     
        
    }
    
    private void OnMouseExit()
    {
        _displaying = false;
        StarMap.instance.HideStarNameText();
    }
}
