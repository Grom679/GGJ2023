using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Updates
{
    public class UpradeUIHandler : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TMP_Text _title;
        [SerializeField]
        private TMP_Text _description;
        [SerializeField]
        private TMP_Text _level;
        #endregion

        #region Fields
        private BaseUpgrade _upgrade;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _upgrade = GetComponent<BaseUpgrade>();

            _icon.sprite = _upgrade.UpgradeData.Icon;
            _title.text = _upgrade.UpgradeData.Name;
            _description.text = _upgrade.UpgradeData.Description;
            _level.text = "Level " + _upgrade.UpgradeData.Level.ToString();
        }
        #endregion
    }
}
