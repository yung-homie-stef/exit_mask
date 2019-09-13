using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public bool is_dead;

    GameObject character;
    public GameObject ObjectToFollow;
    
    public float maxHeadRotation = 80.0f;
    public float minHeadRotation = -80.0f;
    
    public float currentHeadRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
        transform.position = ObjectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamPosition();
        //get where the mouse is moving
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //make it slower or faster
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        mouseLook.y = Mathf.Clamp(mouseLook.y, minHeadRotation, maxHeadRotation);
        currentHeadRotation = mouseLook.y;

        //lerping
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        if (is_dead == false && Pause.isPaused == false)
        {
            mouseLook += smoothV; // the player cannot look around when they are dying. quickly gets flagged back to false when you respawn.
        }

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        // how much you rotate -- what you rotate
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
    void UpdateCamPosition()
    {
        transform.position = ObjectToFollow.transform.position;
    }
}
