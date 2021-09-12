using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialColliderCheck : MonoBehaviour
{
    private bool isCollided;

    public bool IsCollided
    {
        get { return isCollided; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Health")
        {
            isCollided = true;
        }
    }

    public void ResetCollision()
    {
        isCollided = false;
    }
}
