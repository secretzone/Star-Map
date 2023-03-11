using System;
using System.Collections;
using TMPro;
using UnityEngine;


public class ClickableStar : MonoBehaviour
{

    public StarData starData;
    private SpriteRenderer _spriteRenderer;
    private bool _displaying;
    
    private bool _inProgress;
    private StarMapUI _starMapUI;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _starMapUI = GameManager.instance.starMapUI;
        _starMapUI.starNameText.gameObject.SetActive(false);
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
        Camera camera = GameManager.instance.starMapUI.starMapCamera; //TODO: Does this need to be here?
        if (camera.isActiveAndEnabled)
        {
            if (!_displaying) //just need to run this once
            {
                _displaying = true;
                _starMapUI.starNameText.gameObject.SetActive(true);
                _starMapUI.SetStarNameTextPosition(starData.GetPosition());
                String text = $"{starData.GetFullName()}";
                _starMapUI.starNameText.text = text;
                _starMapUI.starNameText.color = starData.GetStarColor();
                _starMapUI.starNameText.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Clicked {starData.name}");
                GameManager.instance.ShowSolarSystemView(starData);
            }     
        }
    }

    private void OnMouseExit()
    {
        _displaying = false;
        _starMapUI.starNameText.gameObject.SetActive(false);
    }
}
