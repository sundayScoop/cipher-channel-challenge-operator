using Docker.DotNet;

public interface ITeamService
{
    Team RegisterTeam(Team newTeam);
    Team FindTeam(string teamName);
}
public class TeamService(DockerClient dockerClient) : ITeamService
{
    public Team RegisterTeam(Team newTeam)
    {
        throw new NotImplementedException();
    }
    public Team FindTeam(string teamName)
    {
        throw new NotImplementedException();
    }
}