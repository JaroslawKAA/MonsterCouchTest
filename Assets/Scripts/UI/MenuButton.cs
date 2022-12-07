using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private MenuButtonsGroup group;

        public Image Image { get; private set; }
        public Button Button { get; private set; }

        private void Awake()
        {
            group = GetComponentInParent<MenuButtonsGroup>();
            Assert.IsNotNull(group);

            Image = GetComponent<Image>();
            Button = GetComponent<Button>();
            
            group.Subscribe(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            group.ResetAll();
            Image.color = group.SelectedColor;
        }

        public void OnPointerExit(PointerEventData eventData) => 
            Image.color = group.DefaultColor;
    }
}
