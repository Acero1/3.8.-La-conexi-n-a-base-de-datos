using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;

    private void Update()
    {
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0 f, 1.0f, 1.0f); 
        else transform.localScale =new Vector3(-1.0f, 1.0f, 1.0f);
    }
}
