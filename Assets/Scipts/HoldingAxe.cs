using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingAxe : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    GameObject _axes;

    [SerializeField]
    private DesctructibleTree _tree;
    #endregion

    #region Public

    public bool _haveAxes = false;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && _haveAxes && _onTreeTrigger )
        {
            _axes.SetActive(true);
            _tree._isDestroy = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            _onTreeTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            _onTreeTrigger = false;
            _axes.SetActive(false);
        }
    }

    #endregion

    #region Methodes

    private void HaveAxe()
    {
       
    }

    #endregion

    #region Private & Protected
   

    private bool _onTreeTrigger;

    #endregion
}
