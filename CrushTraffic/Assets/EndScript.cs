using UnityEngine;

public class EndScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.Lifes = -1;
        }

        Destroy(collision.gameObject, 1);
    }
}
