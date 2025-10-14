using UnityEngine;

public class HammerCollider : MonoBehaviour
{   
    public Collider2D hitCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (hitCollider != null)
            hitCollider.enabled = false;
    }

    public void EnableHit()
    {
        if (hitCollider != null)
            hitCollider.enabled = true;
    }

    public void DisableHit() 
    {
        if (hitCollider != null)
            hitCollider.enabled = false;
    }
}
