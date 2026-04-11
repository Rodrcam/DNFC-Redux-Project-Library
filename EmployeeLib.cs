namespace DNFC_Redux_Library
{
    public class EmployeeLib
    {
        
        // moved this code here from CoreLib.cs, previously Library.cs
        
      
        /*public void CheckWorkerCount()
        {
            if(SharedData.Workers.Count != SharedData.CharactersInUse.transform.childCount)
            {
                MelonLogger.Msg("Worker count has changed. Updating worker list...");
                GetAllWorkers();
            }
        }

        public void GetWorker()
        {
            if (SharedData.Workers != null)
            {
                for (int i = 0; i < SharedData.Workers.Count; i++)
                {
                    MelonLogger.Msg($"Worker {i}: {SharedData.Workers[i].name}");
                }
            }
        }*/
        
        
        /*
        private void GetWorkerCharacterComponent()
        {
            if (SharedData.Workers != null)
            {
                for (int i = 0; i < SharedData.Workers.Count; i++)
                {
                    GameObject worker = SharedData.Workers[i];
                    string workerName = (worker.name).Substring(17, worker.name.Length - 17); 
                    MelonLogger.Msg("Checking Worker " + i + ": " + workerName);
                    //Component characterComponent = worker.GetComponent($"Character{workerName)");
                    //if (characterComponent != null)
                    //{
                    //    MelonLogger.Msg($"Worker {i} has Character component.");
                    //}
                    //else
                    //{
                    //    MelonLogger.Msg($"Worker {i} does NOT have Character component.");
                    //}
                }
            }
        }
        */

        // MOVE TO OWN CLASS
        /*private void GetAllWorkers()
        {
            SharedData.Workers = new List<GameObject>();
            FindCharactersInUse();
            if (SharedData.CharactersInUse != null)
            {
                SetWorkerCount(SharedData.CharactersInUse.transform.childCount);
                MelonLogger.Msg("Total Workers found: " + SharedData.WorkerCount);
                for (int i = 0; i < SharedData.WorkerCount; i++)
                {
                    GameObject worker = SharedData.CharactersInUse.transform.GetChild(i).gameObject;
                    SharedData.Workers.Add(worker);
                }
            }
        }*/
        
        /*public GameObject GetCharactersInUse()
        {
            if (SharedData.CharactersInUse != null)
            {
                return SharedData.CharactersInUse;
            }
            else
            {
                MelonLogger.Msg("GetCharactersInUse: CharactersInUse GameObject is not set.");
                return null;
            }
        }*/
        
        /*public int GetWorkerListCount()
        {
            return SharedData.Workers.Count;
        }

        public int GetWorkerCount()
        {
            return SharedData.WorkerCount;
        }

        public void SetWorkerCount(int count)
        {
            SharedData.WorkerCount = count;
        }*/
        
    }
}