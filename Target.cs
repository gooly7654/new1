using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player tag is set properly
        {
            // Notify the TargetManager that this target has been hit
            FindObjectOfType<TargetManager>().TargetHit();
            
            // Optionally, disable or destroy the target
            gameObject.SetActive(false); // Or `Destroy(gameObject);`
        }
    }
}
