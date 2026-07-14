using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public float treeGrowDuration;


    private float treeGrowProgress = 0f;
    private bool onGrowPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onGrowPressed)
        {
            treeGrowProgress += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, treeGrowProgress / treeGrowDuration);
        }
        
    }

    public void OnGrow()
    {
        onGrowPressed = true;
    }
}