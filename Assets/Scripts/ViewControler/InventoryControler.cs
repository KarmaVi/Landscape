using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

namespace UnityEngine
{   
    public class InventoryControler : MonoBehaviour
    {
        [SerializeField] private FirstPersonController _playerController;
        [SerializeField] private GameObject _inventoryRoot;

        [SerializeField] private Transform _commonCategoryGrid;
        [SerializeField] private Transform _keysCategoryGrid;
        [SerializeField] private Transform _weaponCategoryGrid;

        [SerializeField] private Transform _controllersRoot;

        [SerializeField] private List<InventoryItem> _allItems;

        //айди предмета на количество
        private Dictionary<int, int> _playerInventory;

        private bool _isShow;

        protected void Awake()
        {
            _playerInventory = new Dictionary<int, int>()
            {
                {0, 1},  // 1 ключ от машины
                {1, 1}, // 1 ключ от дома
                {2, 2}, // 2 пистолета
                {4, 1} // 1 фонарик
            };
        }

        private void SetVisible(bool isVisible)
        {
            if (isVisible)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }

            _playerController.enabled = !isVisible;
            _inventoryRoot.SetActive(isVisible);
        }

        private void OpenInventory()
        {
            foreach(var InventoryItem in _playerInventory)
            {
                var itemData = _allItems.First(Item => Item.Id == InventoryItem.Key);
                var itemCount = InventoryItem.Value;

                var go = new GameObject { name = "InventoryItemController" };
                go.transform.parent = _controllersRoot;
                var controller = go.AddComponent<InventoryItemControler>();

                controller.Init(itemData, itemCount, GetCategoryRoot);
            }
        }

        private Transform GetCategoryRoot(ItemCategory category)
        {
            switch (category)
            {
                case ItemCategory.Common:
                    return _commonCategoryGrid;
                case ItemCategory.Keys:
                    return _keysCategoryGrid;
                case ItemCategory.Weapon:
                    return _weaponCategoryGrid;
            }
            return transform;
        }

        private void CloseInventory()
        {
            DestroyAllChildren(_controllersRoot);
            DestroyAllChildren(_commonCategoryGrid);
            DestroyAllChildren(_keysCategoryGrid);
            DestroyAllChildren(_weaponCategoryGrid);
        }

        private void DestroyAllChildren(Transform root)
        {
           for(int i = root.childCount - 1; i >= 0; i--)
            {
                var child = root.GetChild(i);
                Destroy(child.gameObject);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _isShow = !_isShow;
                SetVisible(_isShow);
            }
        }
    }
}

