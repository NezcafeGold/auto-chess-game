using DefaultNamespace;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    [SerializeField] private Text logText;
    [SerializeField] private Text playerName;
    [SerializeField] private Text playerList;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(0, 100);
        playerName.text = "You are " + PhotonNetwork.NickName;
        UpdatePlayerList();
        Connect();
    }

    private void UpdatePlayerList()
    {
        playerList.text = "Player list: \n";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerList.text += player.NickName + "\n";
        }
    }

    public void EnterToLobby()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
            PhotonNetwork.LoadLevel(Scene.BATTLE_SCENE);
        Log("Player in room less than 2 or more");
    }

    #region Public Methods

    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    ///
    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

    private void Log(string mess)
    {
        Debug.Log(mess);
        logText.text += mess + "\n";
    }

    public override void OnConnectedToMaster()
    {
        Log("ConnectedToMaster");
    }

    public override void OnJoinedRoom()
    {
        Log(PhotonNetwork.NickName + "connected to Room");
        UpdatePlayerList();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log("No random room available, so we create one");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 2});
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Log(newPlayer.NickName + " entered to the Room");
        UpdatePlayerList();
    }
}