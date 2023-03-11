using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class StarMap : MonoBehaviour
{

    public ClickableStar clickableStarPrefab;
    
    public List<ClickableStar> clickableStars;

    public void Initialize(List<ClusterData> clusters)
    {
        foreach (ClusterData cluster in clusters){
            foreach (StarData star in cluster.stars)
            {
                Vector3 position = new Vector3(star.x, star.y, 0f);
                ClickableStar cStar = Instantiate(clickableStarPrefab, position,
                    quaternion.identity, transform);
                cStar.Initialize(star);
                clickableStars.Add(cStar);
            }
        }
    }
}
