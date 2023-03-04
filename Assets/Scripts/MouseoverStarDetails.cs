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

    public Vector3 offset;
    // Start is called before the first frame update
    private GameObject starNameText;
    private GameObject starNameAnchor;
    private bool _displaying = false;
    void Start()
    {
        starNameText = GameManager.instance.starMapCanvas.GetComponent<StarMapUI>().starNameText;
        starNameAnchor = GameManager.instance.starMapCanvas.GetComponent<StarMapUI>().starNameAnchor;
        starNameText.SetActive(false);
    }

    void OnMouseOver()
    {
        Camera camera = GameManager.instance.starMapCamera;
        if (camera.isActiveAndEnabled)
        {
            if (!_displaying) //just need to run this once
            {
                _displaying = true;

                starNameAnchor.transform.position = star.transform.position;// + offset;//camera.WorldToScreenPoint(star.transform.position);
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

    }

    void OnMouseExit()
    {
        _displaying = false;
        starNameText.SetActive(false);
    }
}
