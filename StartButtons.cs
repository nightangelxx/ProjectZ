
using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine;

namespace HelloWorld
{
    public class StartButtons : MonoBehaviour
    {
        public static bool isHost;
        public static bool isClient;
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                Buttons();
                //
                GUILayout.Label("ConnectAddress: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetComponent<UNetTransport>().ConnectAddress);
                GUILayout.Label("ConnectPort: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetComponent<UNetTransport>().ConnectPort);
            }
            else
            {
                //StatusLabels();

                //SubmitNewPosition();
            }

            GUILayout.EndArea();
        }

        void Buttons()
        {
            //spawnPoint почему то только для StartHost
            GameObject spawnPoints = GameObject.FindGameObjectWithTag("spawnPoint");
            if (GUILayout.Button("Host")) 
            {
                NetworkManager.Singleton.StartHost(new Vector3(spawnPoints.transform.position.x, spawnPoints.transform.position.y, spawnPoints.transform.position.z));
                this.gameObject.GetComponent<MapInit>().SpawnMonster();
                //grave.GetComponent<MonsterSpawnPoint>().enabled = true;
                isHost = true;
            }
            if (GUILayout.Button("Client")) 
            {
                NetworkManager.Singleton.StartClient();
                isClient = true;
            }
            if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
        }

        static void StatusLabels()
        {
            var mode = NetworkManager.Singleton.IsHost ?
                "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

        static void SubmitNewPosition()
        {
            if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
            {
                if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
                    out var networkedClient))
                {
                    var player = networkedClient.PlayerObject.GetComponent<HelloWorldPlayer>();
                    if (player)
                    {
                        player.Move();
                    }
                }
            }
        }
    }
}