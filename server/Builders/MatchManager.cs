using Docker.DotNet;

public class MatchManager(string matchId, Team attacker, Team defender, DockerClient dockerClient)
{
    private MatchContainer Container {get;set;}
    public void CreateMatchContainer()
    {
        // includes downloading team docker images

        // set match container
    }
    public void StartDefenderServer()
    {
        // starts the defender docker server
    }
    public byte[] ExecuteAndValidateClientRequest(string requestCode)
    {
        // starts docker client container -> makes request -> ensures the server logs the correct request

        // -> return the tcp dump log of the request in that time period

        throw new NotImplementedException();
    }

    public void StopMatch()
    {
        
    }
    



    private class MatchContainer
    {
        
    }
}