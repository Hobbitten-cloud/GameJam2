namespace JourneyGame.Models.Menu;

public class Program
{
    static void Main(string[] args)
    {
        // NOTES 
        // Ascii font used = Doom
        // Website = https://patorjk.com/software/taag/#p=display&f=Doom&t=John+Journey&x=none&v=4&h=4&w=80&we=false

        // Init game components here
        var houseRulesMenu = new HouseRulesMenu();
        var characterCreationMenu = new CharacterCreationMenu(houseRulesMenu);
        var mainMenu = new MainMenu(characterCreationMenu);
        var gameOverMenu = new GameOverMenu(mainMenu);
        var battleMenu = new BattleMenu();


        // Game initialization and main loop would go here
        mainMenu.StartMenu();

        battleMenu.CombatMenu();
    }
}
