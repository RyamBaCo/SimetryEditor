using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Serialization;

namespace Simetry.Interface.Globals
{
    public class GameObjectValueManager
    {
        #region Singleton Pattern
        private static readonly GameObjectValueManager instance = new GameObjectValueManager();
        public static GameObjectValueManager Instance { get { return instance; } }
        #endregion

        private Dictionary<string, GameObjectValue> gameObjects = new Dictionary<string, GameObjectValue>();
        private Dictionary<string, HashSet<string>> actionIDs = new Dictionary<string, HashSet<string>>();

        private GameObjectValueManager() { }

        public void RegisterActionID(string actionName, string ID)
        {
            if (!actionIDs.ContainsKey(actionName))
                actionIDs.Add(actionName, new HashSet<string>());
            actionIDs[actionName].Add(ID);
        }

        public void RegisterGameObject(GameObjectValue gameObject)
        {
            if (gameObjects.ContainsKey(gameObject.ID))
                throw new System.Exception("GameObjectManager::RegisterGameObject: Can not register GameObject! ID " + gameObject.ID + " already exists!");

            gameObjects[gameObject.ID] = gameObject;
        }

        public void UnregisterAllGameObjects()
        {
            gameObjects.Clear();
            actionIDs.Clear();
        }

        public GameObjectValue GetGameObjectByID(string ID)
        {
            if (!gameObjects.ContainsKey(ID))
                throw new System.Exception("GameObjectManager::GetGameObjectByID: GameObject with the ID " + ID + " not found!");

            return gameObjects[ID];
        }

        public bool ContainsActionID(string ID)
        {
            foreach (HashSet<string> ids in actionIDs.Values)
                if (ids.Contains(ID))
                    return true;

            return false;
        }

        public bool ContainsActionID(string actionName, string ID)
        {
            if (!actionIDs.ContainsKey(actionName) || !actionIDs[actionName].Contains(ID))
                return false;

            return true;
        }
    }
}
