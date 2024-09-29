using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] Camera fpcCamera;

    [SerializeField] string[] tags; // массив тегов, объекты которых можно двигать

    private Ray ray;
    private RaycastHit hit;
    float maxDistanceRay = 2f;
    float step = 5;
    float mass;
    private Transform curObj;//use GrabUP

    void Update()
    {
        Ray();
        DrawRay();

        Interact();

        InteractObject();
    }

    private void Ray()//create ray
    {
        ray = fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    void DrawRay()//for test
    {
        if(Physics.Raycast(ray,out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
        }
        if(hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
        }
    }

    void Interact()//open door
    {
        if (hit.transform != null && hit.transform.GetComponent<Door>())
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.GetComponent<Door>().Open();
            }
        }
    }

    bool GetTag(string curTag)
    {
        bool result = false;
        foreach (string t in tags)
        {
            if (t == curTag) result = true;
        }
        return result;
    }

    void InteractObject()
    {
        if (Input.GetMouseButton(0)) // Удерживать правую кнопку мыши
        {
            if (Physics.Raycast(ray, out hit, maxDistanceRay))
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);

                if (GetTag(hit.transform.tag) && hit.rigidbody && !curObj)
                {

                    curObj = hit.transform;
                    mass = curObj.GetComponent<Rigidbody>().mass; // запоминаем массу объекта
                    curObj.GetComponent<Rigidbody>().mass = 0.0001f; // убираем массу, чтобы не сбивать другие объекты
                    curObj.GetComponent<Rigidbody>().useGravity = false; // убираем гравитацию
                    curObj.GetComponent<Rigidbody>().freezeRotation = true; // заморозка вращения
                    curObj.position += new Vector3(0, 0.5f, 0); // немного приподымаем выбранный объект
                }
            }

            if (curObj)
            {
                Vector3 mousePosition = fpcCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, fpcCamera.transform.position.y));
                curObj.GetComponent<Rigidbody>().MovePosition(new Vector3(mousePosition.x, curObj.position.y + Input.GetAxis("Mouse ScrollWheel") * step, mousePosition.z));
            }
        }
        else if (curObj)
        {
            if (curObj.GetComponent<Rigidbody>())
            {
                curObj.GetComponent<Rigidbody>().freezeRotation = false;
                curObj.GetComponent<Rigidbody>().useGravity = true;
                curObj.GetComponent<Rigidbody>().mass = mass;
            }
            else
            {
                curObj.GetComponent<Rigidbody2D>().freezeRotation = false;
                curObj.GetComponent<Rigidbody2D>().mass = mass;
                curObj.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            curObj = null;
        }
    }
}
