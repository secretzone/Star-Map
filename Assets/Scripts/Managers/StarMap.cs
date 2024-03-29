using System;
using System.Collections.Generic;
using Clickable;
using Data;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class StarMap : MonoBehaviour
    {
        public static StarMap instance;
        [FormerlySerializedAs("clickableStarPrefab")] public Star starPrefab;
        public List<Star> clickableStars;
        public GameObject ui;
        public TextMeshPro starNameText;
        public Transform starNameAnchor;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
                Initialize(GameManager.instance.starParser.starClusters);
            }
            else
            {
                Destroy(this);
            }
        
        }

        private void Initialize(List<ClusterData> clusters)
        {
            starNameText.gameObject.SetActive(false);
            foreach (ClusterData cluster in clusters){
                foreach (StarData star in cluster.stars)
                {
                    Vector3 position = new Vector3(star.x, star.y, 0f);
                    Star cStar = Instantiate(starPrefab, position,
                        quaternion.identity, transform);
                    cStar.Initialize(star);
                    clickableStars.Add(cStar);
                }
            }
        }

        public void ShowStarNameText(String text, Vector3 position, Color color)
        {
            starNameAnchor.position = position;
            starNameText.text = text;
            starNameText.color = color;
            starNameText.gameObject.SetActive(true);
        }

        public void HideStarNameText()
        {
            starNameText.gameObject.SetActive(false);
        }
    }
}
