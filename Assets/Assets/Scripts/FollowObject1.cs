using UnityEngine;

namespace Assets.Scripts
{
    public class FollowObject1 : MonoBehaviour
    {
        public GameObject player;
    
        void Update()
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
