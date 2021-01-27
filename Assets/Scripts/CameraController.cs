using UnityEngine;

public class CameraController : MonoBehaviour
{


    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    [Header("Restrict Camera")]
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 10f;
    public float maxX = 80f;
    public float minZ = 10f;
    public float maxZ = 80f;


    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }


        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            Vector3 dist = Vector3.forward * panSpeed * Time.deltaTime;
            if (transform.position.z + dist.z < maxZ)
                transform.Translate(dist, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            Vector3 dist = Vector3.back * panSpeed * Time.deltaTime;
            if (transform.position.z - dist.z > minZ)
                transform.Translate(dist, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            Vector3 dist = Vector3.right * panSpeed * Time.deltaTime;
            if (transform.position.x + dist.x < maxX)
                transform.Translate(dist, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            Vector3 dist = Vector3.left * panSpeed * Time.deltaTime;
            if (transform.position.x - dist.x > minX)
                transform.Translate(dist, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;



    }
}
