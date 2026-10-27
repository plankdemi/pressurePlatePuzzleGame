using UnityEngine;

public class doorController : MonoBehaviour
{
    [SerializeField]
    private pressurePlateController pPC;

    private bool openDoor = false;
    private bool closeDoor = false;
    Quaternion openCloseDoorRotation = Quaternion.Euler(Vector3.zero);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pPC.pressedBtn += OpenDoor;
        pPC.unpressedBtn += CloseDoor;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor || closeDoor)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, openCloseDoorRotation, 180f * Time.deltaTime);
        }

    }

    private void OpenDoor()
    {
        openCloseDoorRotation = Quaternion.Euler(new Vector3(0, 90f, 0f));
        openDoor = true;
        closeDoor = false;
    }
    private void CloseDoor()
    {
        openCloseDoorRotation = Quaternion.Euler(new Vector3(0, 0f, 0f));
        openDoor = false;
        closeDoor = true;
    }
}
