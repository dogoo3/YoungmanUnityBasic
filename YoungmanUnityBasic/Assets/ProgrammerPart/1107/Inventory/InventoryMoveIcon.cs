using UnityEngine;
using UnityEngine.UI;

public class InventoryMoveIcon : MonoBehaviour
{
    public Image moveiconimage; // 드래그 오브젝트의 Image 컴포넌트
        
    private Image oldSlotImageComponent; // 드래그를 시작한 Slot의 Image 컴포넌트(나중에 삭제 위함)

    public Slot slot;

    private void Awake()
    {
        moveiconimage = GetComponent<Image>();
        // object가 OFF된 동안 값 속성이 바뀌기 때문에 Active가 True인 상태에서 시작해야 함
        // 처음부터 Disable돼 있으면 Awake가 동작하지 않음
        gameObject.SetActive(false); 
    }

    public void SetMoveSlot(Slot p_slot, Image p_oldslotImage)
    {
        this.slot = p_slot;
        moveiconimage.sprite = this.slot.itemimage; // Image Component 내의 Sprite만 변경
        oldSlotImageComponent = p_oldslotImage; // 슬롯을 옮겼을 때 삭제를 위해 드래그를 시작한 Image 컴포넌트 저장
    }

    public void ActiveObject()
    {
        gameObject.SetActive(true);
    }

    public void DeactiveObject(bool p_isdelete)
    {
        if(p_isdelete)
            oldSlotImageComponent.sprite = null;
        gameObject.SetActive(false);
    }
}
