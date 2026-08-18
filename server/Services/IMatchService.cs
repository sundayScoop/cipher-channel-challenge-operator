public interface IMatchService
{
    Match CreateMatch(Team attacker, Team defender);
    void StartMatch(string matchId);
    void StopAndRemoveMatch(string matchId);
}
