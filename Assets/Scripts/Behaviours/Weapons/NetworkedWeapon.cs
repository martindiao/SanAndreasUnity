﻿using UnityEngine;
using Mirror;
using SanAndreasUnity.Utilities;

namespace SanAndreasUnity.Behaviours.Weapons
{

    public class NetworkedWeapon : NetworkBehaviour
    {

        [SyncVar] int m_net_modelId;
        [SyncVar] int m_net_ammoInClip;
        [SyncVar] int m_net_amooOutsideOfClip;

        public int ModelId { get { return m_net_modelId; } set { m_net_modelId = value; } }



        public override void OnStartClient()
        {
            base.OnStartClient();

            if (NetUtils.IsServer)
                return;

            // create weapon
            F.RunExceptionSafe( () => Weapon.OnCreatedByServer(m_net_modelId) );
        }

        void Start()
        {
            
        }

    }

}