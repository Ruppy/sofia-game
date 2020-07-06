using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class RemapControls : MonoBehaviour
{
    public string interactionKey = "r";
    public Hotspot selectedHotspot = null;
    public Menu interactionMenu = null;
    public Menu inventoryMenu = null;
    public Menu hotspotNameMenu = null;

    public GameObject cameraFollowObject = null;
    public GameObject resetCameraObject = null;

    public DragTrack_Straight track = null;
    private bool isMoving = false;
    private Moveable_Drag dragObject = null;

    // Start is called before the first frame update
    void Start()
    {
      //Debug.Log(Input.GetJoystickNames()[0]);
      this.interactionMenu = PlayerMenus.GetMenuWithName("Interaction2");
      this.inventoryMenu = PlayerMenus.GetMenuWithName("Inventory");
      this.hotspotNameMenu = PlayerMenus.GetMenuWithName("Hotspot");
      //this.dragObject = GameObject.Find("BoxDraggable").GetComponent<Moveable_Drag>();
      //KickStarter.playerInput.InputGetButtonDownDelegate = CustomGetButtonDown;
    }

    private void OnGUI ()
    {
      if (KickStarter.stateHandler.gameState != GameState.Normal) {return; }
      if (selectedHotspot == null) { return ; }

      ShowInteractions();
    }

    private void ShowInteractions() {
      GUILayout.BeginArea(new Rect (0f, ACScreen.height * 0.2f, ACScreen.width * 0.3f, ACScreen.height * 0.8f));

      GUILayout.BeginVertical("Button");
      GUILayout.Label ("Hotspot: " + selectedHotspot.GetName(0));
      GUILayout.EndVertical();

      GUILayout.EndArea();
    }

    void Update() {
      if (Input.GetButtonDown("ShowInteractionsMenu") || Input.GetKeyDown(KeyCode.JoystickButton5)) {
        Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
        if (hotspot) {
          if (this.interactionMenu.IsOff()) { this.interactionMenu.TurnOn(); }
          else { this.interactionMenu.TurnOff(); }
        }
      }

      if (Input.GetButtonDown("Icon_Use") || Input.GetKeyDown(KeyCode.JoystickButton2)) {
        if (this.inventoryMenu.IsOn()) { return; }

        Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
        if (hotspot) {
          hotspot.RunUseInteraction(0);
        }
      }

      if (Input.GetButtonDown("Icon_Talkto")) {
        Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
        if (hotspot) {
          hotspot.RunUseInteraction(1);
        }
      }

      if (Input.GetButtonDown("Icon_Lookat") || Input.GetKeyDown(KeyCode.JoystickButton0)) {
        Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
        if (hotspot) {
          hotspot.RunUseInteraction(2);
        }
      }

      if (this.inventoryMenu.IsOff()) {
        float horizontalInput = Input.GetAxis("CameraHorizontal");
        float verticalInput = Input.GetAxis("CameraVertical");
        Vector3 cameraPosition = resetCameraObject.transform.position + new Vector3(horizontalInput * 15.01f, verticalInput * 15.01f, 0);
        cameraFollowObject.transform.position = cameraPosition;
      }

      if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
        this.isMoving = !this.isMoving;
      }

      if (this.isMoving) {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0) {
          this.track.ApplyDragForce(new Vector3(1,0,0), this.dragObject);
        }
        else if (horizontalInput < 0) {
          this.track.ApplyDragForce(new Vector3(-1,0,0), this.dragObject);
        }

      }

      if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
  Debug.Log("JoystickButton0");
}
if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
  Debug.Log("JoystickButton1");
}
if (Input.GetKeyDown(KeyCode.JoystickButton2)) {
  Debug.Log("JoystickButton2");
}
if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
  Debug.Log("JoystickButton3");
}
if (Input.GetKeyDown(KeyCode.JoystickButton4)) {
  Debug.Log("JoystickButton4");
}
if (Input.GetKeyDown(KeyCode.JoystickButton5)) {
  Debug.Log("JoystickButton5");
}
if (Input.GetKeyDown(KeyCode.JoystickButton6)) {
  Debug.Log("JoystickButton6");
}
if (Input.GetKeyDown(KeyCode.JoystickButton7)) {
  Debug.Log("JoystickButton7");
}
if (Input.GetKeyDown(KeyCode.JoystickButton8)) {
  Debug.Log("JoystickButton8");
}
if (Input.GetKeyDown(KeyCode.JoystickButton9)) {
  Debug.Log("JoystickButton9");
}
if (Input.GetKeyDown(KeyCode.JoystickButton10)) {
  Debug.Log("JoystickButton10");
}
if (Input.GetKeyDown(KeyCode.JoystickButton11)) {
  Debug.Log("JoystickButton11");
}
if (Input.GetKeyDown(KeyCode.JoystickButton12)) {
  Debug.Log("JoystickButton12");
}
if (Input.GetKeyDown(KeyCode.JoystickButton13)) {
  Debug.Log("JoystickButton13");
}
if (Input.GetKeyDown(KeyCode.JoystickButton14)) {
  Debug.Log("JoystickButton14");
}
if (Input.GetKeyDown(KeyCode.JoystickButton15)) {
  Debug.Log("JoystickButton15");
}
if (Input.GetKeyDown(KeyCode.JoystickButton16)) {
  Debug.Log("JoystickButton16");
}
if (Input.GetKeyDown(KeyCode.JoystickButton17)) {
  Debug.Log("JoystickButton17");
}
if (Input.GetKeyDown(KeyCode.JoystickButton18)) {
  Debug.Log("JoystickButton18");
}
if (Input.GetKeyDown(KeyCode.JoystickButton19)) {
  Debug.Log("JoystickButton19");
}
    }
}
