using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class InventoryHandler : MonoBehaviour
{
    private Menu inventoryMenu = null;
    private MenuLabel lblAction = null;
    //private GameObject followCamera = null;
    private GameCamera2D followCamera2D = null;

    // Start is called before the first frame update
    void Start()
    {
      this.inventoryMenu = PlayerMenus.GetMenuWithName("Inventory");
      this.lblAction = PlayerMenus.GetElementWithName("Inventory", "lblAction") as MenuLabel;
      GameObject navCam = GameObject.Find("NavCam 1");
      Debug.Log(navCam);
      this.followCamera2D = navCam.GetComponent<GameCamera2D>();
    }

    void Update() {
      if (this.inventoryMenu.IsOn()) {
        InvItem item = KickStarter.runtimeInventory.SelectedItem;
        InvItem hoverItem = KickStarter.runtimeInventory.hoverItem;
        if (KickStarter.runtimeInventory.localItems.Count == 0) {
          this.lblAction.label = "Você não tem nenhum item ainda.";
        }
        else if ((item == null && hoverItem == null)) {
          this.lblAction.label = "";
        }
        else if (item == null && hoverItem != null) {
          Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
          if (hotspot) {
            this.lblAction.label = "Usar " + hoverItem.GetLabel(0) + " em " + hotspot.GetFullLabel(0);
          }
          else {
            this.lblAction.label = "Usar " + hoverItem.GetLabel(0);
          }

        }
        else if (item == hoverItem) {
          this.lblAction.label = "Usar " + item.GetLabel(0);
        }
        else if (item != null && hoverItem != null) {
          this.lblAction.label = "Combinar " + item.GetLabel(0) + " com " + hoverItem.GetLabel(0);
        }
      }

      if (Input.GetButtonDown("Icon_Use") || Input.GetKeyDown(KeyCode.JoystickButton2)) {
        if (this.inventoryMenu.IsOff()) { return;}

        InvItem item = KickStarter.runtimeInventory.SelectedItem;
        InvItem hoverItem = KickStarter.runtimeInventory.hoverItem;

        if (item == null) {
          Hotspot hotspot = KickStarter.playerInteraction.GetActiveHotspot();
          if (hotspot) {
            hotspot.RunInventoryInteraction(hoverItem);
          }
          else {
            hoverItem.Select();
          }
        }
        else {
          //KickStarter.runtimeInventory.SetNull();
          item.CombineWithItem(hoverItem);
          KickStarter.runtimeInventory.hoverItem = KickStarter.runtimeInventory.localItems[0];
        }

      }

      if (Input.GetButtonDown("Icon_Inventory") || Input.GetKeyDown(KeyCode.JoystickButton3)) {
        if (this.inventoryMenu.IsOff()) {
          this.inventoryMenu.TurnOn();
          this.followCamera2D.lockHorizontal = true;
          this.followCamera2D.lockVertical = true;
        }
        else {
          this.inventoryMenu.TurnOff();
          this.followCamera2D.lockHorizontal = false;
          this.followCamera2D.lockVertical = false;

          InvItem item = KickStarter.runtimeInventory.SelectedItem;
          if (item == null) {return;}
          Debug.Log("Deselect: " + item.GetLabel(0));
          KickStarter.runtimeInventory.SetNull();
        }
      }
    }
}
