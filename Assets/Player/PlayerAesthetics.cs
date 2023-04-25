using UnityEngine;

namespace Assets.Player
{
    public class PlayerAesthetics : MonoBehaviour
    {
        public void SetColor(Material color)
        {
            // Capsule
            MeshRenderer mr = this.gameObject.GetComponent<MeshRenderer>();
            mr.material = color;

            // Goggles
            GameObject goggles = this.gameObject.transform.Find("Goggles").gameObject;
            mr = goggles.GetComponent<MeshRenderer>();
            mr.material = color;
        }
    }
}
