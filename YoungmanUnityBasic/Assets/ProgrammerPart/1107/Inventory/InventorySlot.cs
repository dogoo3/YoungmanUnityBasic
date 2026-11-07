using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Slot
{
    public Sprite itemimage;
    public string itemName;
}

public class InventorySlot : MonoBehaviour
{
    public Slot _slot = new Slot();

    public Image _slotImage; // 슬롯 자식 오브젝트의 이미지

    private void Awake()
    {

    }

    public Slot GetSlotData()
    {
        return _slot;
    }

    public void SetSlot(Slot p_slot)
    {
        this._slot = p_slot;

        _slotImage.sprite = _slot.itemimage; // 이미지 업데이트
    }
}
