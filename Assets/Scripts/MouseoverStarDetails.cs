using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseoverStarDetails : MonoBehaviour
{
    public Star star;
    // Start is called before the first frame update
    private GameObject starNameText;

    private bool _displaying = false;
    void Start()
    {
        starNameText = GameManager.instance.starMapCanvas.GetComponent<StarMapUI>().starNameText;
        starNameText.SetActive(false);
    }
    void OnMouseOver()
    {
        if (!_displaying)
        {
            _displaying = true;
            starNameText.transform.position = Input.mousePosition;
            String text = $"{star.transform.parent.GetComponent<Cluster>().clusterName} {star.starName}";
            TextMeshPro tmp = starNameText.GetComponent<TextMeshPro>();
            tmp.text = text;
            tmp.color = star.GetStarColor();
            starNameText.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Clicked {star.starName}");
            GameManager.instance.ShowSolarSystemView();
        }
    }

    void OnMouseExit()
    {
        _displaying = false;
        starNameText.SetActive(false);
    }
}
