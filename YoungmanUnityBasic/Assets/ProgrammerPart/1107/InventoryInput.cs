using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class InventoryInput : MonoBehaviour
{
    public InventoryMoveIcon moveicon;
    private bool _isClicked;
    private Vector2 _currentMousePosition;

    private void OnClickDown(InputValue p_value)
    {
        Vector2 t_mousepos = Mouse.current.position.ReadValue(); // 눌렀을 때의 Mouse 좌표를 가져옴
        Debug.Log($"{t_mousepos} : 마우스 누름");

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = t_mousepos;

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerData, results);

        Debug.Log(results.Count);
        // Slot 컴포넌트 찾기
        foreach (RaycastResult result in results)
        {
            Debug.Log(result.gameObject.name);
            InventorySlot targetslot = result.gameObject.GetComponent<InventorySlot>();

            if(targetslot != null)
            {
                Debug.Log(targetslot._slot.itemimage);

                moveicon.SetMoveSlot(targetslot._slot, targetslot._slotImage);
                moveicon.transform.position = t_mousepos;
                moveicon.ActiveObject();
                break; // 오브젝트를 찾았으므로 종료
            }
            else
            {

            }
        }
        _isClicked = true;
    }

    private void OnMousePosition(InputValue p_value)
    {
        if(_isClicked)
        {
            _currentMousePosition = p_value.Get<Vector2>();
            moveicon.transform.position = _currentMousePosition;
        }
    }

    // 2. GetMouseButtonUp 역할
    private void OnClickUp(InputValue p_value)
    {
        Debug.Log($"{Mouse.current.position.ReadValue()} : 마우스 뗌");

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = _currentMousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerData, results);

        Debug.Log(results.Count);
        // Slot 컴포넌트 찾기
        foreach (RaycastResult result in results)
        {
            InventorySlot targetslot = result.gameObject.GetComponent<InventorySlot>();

            if (targetslot != null) // 옮길 슬롯을 찾았으면
            {
                // Deep copy
                Slot t_slot = new Slot();
                t_slot.itemimage = moveicon.slot.itemimage;
                t_slot.itemName = moveicon.slot.itemName;

                moveicon.slot.itemimage = null;
                moveicon.slot.itemName = null;

                targetslot.SetSlot(t_slot);
                moveicon.DeactiveObject(true);
                break;
            }
        }
        moveicon.DeactiveObject(false); // 못 찾으면 드래그 아이콘만 없앰
        _isClicked = false;
    }

    private void Update()
    {
        // 3. GetMouseButton 역할 (누르고 있는 중인지 확인)
        if (_isClicked)
        {
            // Debug.Log($"{_currentMousePosition} : 마우스 누르는 중");
        }
    }
}
