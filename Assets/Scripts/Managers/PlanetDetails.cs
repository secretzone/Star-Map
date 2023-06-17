using Data;
using UnityEngine;

namespace Managers
{
    public class PlanetDetails : MonoBehaviour
    {
        private PlanetData _planetData;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Initialize(PlanetData data)
        {
            _planetData = data;
        }

        public void GoToPlanetSystemView()
        {
            GameManager.instance.ShowPlanetSystemView();
        }
    }
}
