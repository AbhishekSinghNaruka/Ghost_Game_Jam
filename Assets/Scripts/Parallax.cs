using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector2(startPos + distance, transform.position.y);
    }
}
