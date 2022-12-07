using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class MenuButtonsGroup : MonoBehaviour
    {
        private List<MenuButton> group = new List<MenuButton>();

        /// <summary>
        /// Selected button index;
        /// </summary>
        private int selectedIndex = 0;

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                if (selectedIndex >= group.Count) selectedIndex = 0;
                else if (selectedIndex < 0) selectedIndex = group.Count - 1;
                Select(group[SelectedIndex]);
            }
        }


        // @formatter:off
        [SerializeField]
        private Color _selectedColor = Color.green;

        public Color SelectedColor => _selectedColor;

        [SerializeField] 
        private Color _defaultColor = Color.white;

        /// <summary>
        /// Default state button color.
        /// </summary>
        public Color DefaultColor => _defaultColor;
        // @formatter:on

        public void Subscribe(MenuButton button) => group.Add(button);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S)
                || Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectedIndex++;
            }

            if (Input.GetKeyDown(KeyCode.W)
                || Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectedIndex--;
            }

            if (Input.GetKeyDown(KeyCode.Return)
                && IsSelectionActive())
            {
                group[SelectedIndex].Button.onClick.Invoke();
            }
        }

        /// <summary>
        /// Select button. Change color of button.
        /// </summary>
        /// <param name="button"></param>
        private void Select(MenuButton button)
        {
            ResetAll();
            button.Image.color = SelectedColor;
        }

        private bool IsSelectionActive() => 
            group[SelectedIndex].Image.color == SelectedColor;

        /// <summary>
        /// Reset highlighting of all buttons.
        /// </summary>
        public void ResetAll() => group.ForEach(btn => btn.Image.color = DefaultColor);
    }
}