using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class DesctructibleTree : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Sprite _TreeBeforeDes;

    [SerializeField] 
    private Sprite _TreeAfterDes;


    public bool _isDestroy;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _imageTree = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

        

    }

    void Update()
    { 
        if(_isDestroy)
        {
            _imageTree.sprite = _TreeAfterDes;
        }
        else
        {
            _imageTree.sprite = _TreeBeforeDes;
        }   
    }


    #endregion

    #region Methodes
    #endregion

    #region Private & Protected
    private SpriteRenderer _imageTree;
 
    #endregion
}
