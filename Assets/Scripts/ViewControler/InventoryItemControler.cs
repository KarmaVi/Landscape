using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEngine
{
    public class InventoryItemControler : MonoBehaviour
    {
        private InventoryItem _data;
        private InventoryItemViews _view;

        private bool _isDescriptionVisible;

        public void Init (InventoryItem data, int itemCount, Func<ItemCategory, Transform> getCategoryRoot)
        {
            _data = data;
            _view = CreateView(getCategoryRoot(_data.Category));

            _view.Icon = _data.Texture;
            _view.Name = _data.Name;
            _view.Count = itemCount;
        }

        private InventoryItemViews CreateView(Transform parent)
        {
            var prefab = Resources.Load<InventoryItemViews>("InventoryItemView");
            var view = Instantiate(prefab, parent);
            return view;
        }

    }
}