
public class Game
{
    public Logic logic;
    public Player player;//more playes can be added if game extends. when become an  online game etc...


    public Game()
    {
        logic = new Logic();
        player = new Player();
    }
}
