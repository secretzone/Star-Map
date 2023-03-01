using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MouseoverStarDetails : MonoBehaviour
{
    public Star star;
    // Start is called before the first frame update
    private GameObject starNameText;

    void Start()
    {
        starNameText = GameManager.instance.starMapCanvas.GetComponent<StarMapUI>().starNameText;
        starNameText.SetActive(false);
    }
    void OnMouseOver()
    {
        Camera cameraObj = GameManager.instance.mainCamera;
        starNameText.transform.position = Input.mousePosition;
        String text = $"{star.transform.parent.GetComponent<Cluster>().clusterName} {star.starName}";
        TextMeshPro tmp = starNameText.GetComponent<TextMeshPro>();
        tmp.text = text;
        tmp.color = star.GetStarColor();
        starNameText.SetActive(true);
    }

    void OnMouseExit()
    {
        starNameText.SetActive(false);
    }
}
