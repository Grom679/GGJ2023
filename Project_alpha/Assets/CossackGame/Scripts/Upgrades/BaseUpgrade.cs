using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Updates
{
    public class BaseUpgrade : MonoBehaviour
    {
        #region Properties
        public UpgradeData UpgradeData => _upgradeData;
        #endregion

        #region Editor Fields
        [SerializeField]
        private UpgradeData _upgradeData;
        #endregion
    }
}
