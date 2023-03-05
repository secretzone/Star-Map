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
    private bool _inProgress = false;
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
                String clusterName = star.transform.parent.GetComponent<Cluster>().clusterName;
                String starName = star.starName;
                String text = "";
                if (starName.ToLower() == "prime")
                {
                    text = $"{clusterName}";
                }
                else
                {
                    text = $"{starName} {clusterName}";
                }
                TextMeshPro tmp = starNameText.GetComponent<TextMeshPro>();
                tmp.text = text;
                tmp.color = star.GetStarColor();
                starNameText.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Clicked {star.starName}");
                StartCoroutine(ShowSolarSystem());
            }     
        }

    }


    IEnumerator ShowSolarSystem()
    {
        if (_inProgress)
        {
            yield return null;
        }
        else
        {
            _inProgress = true;
        }
        SolarSystemSpawner.instance.ClearSystem();
        SolarSystemSpawner.instance.Initialize(star);
        GameManager.instance.ShowSolarSystemView();
        _inProgress = false;
    }
    

    void OnMouseExit()
    {
        _displaying = false;
        starNameText.SetActive(false);
    }
}
