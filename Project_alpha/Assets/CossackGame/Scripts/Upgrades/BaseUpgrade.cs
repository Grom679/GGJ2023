using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Updates
{
    public class BaseUpgrade : MonoBehaviour
    {
        #region Properties
        public Action<BaseUpgrade> OnClick { get; set; }

        public UpgradeData UpgradeData => _upgradeData;
        #endregion

        #region Editor Fields
        [SerializeField]
        private UpgradeData _upgradeData;
        #endregion

        #region Methods
        public void Click()
        {
            OnClick?.Invoke(this);
        }
        #endregion
    }
}
