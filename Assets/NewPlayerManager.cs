using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



namespace my.player.manager
{
    public class NewPlayerManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        // Start is called before the first frame update
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
}