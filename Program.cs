Console.Clear();
decimal playerMoney = 100, playerBet = 0, increaseMoney = 0;
int totalValuePlayer = 0, totalValueComputer = 0;
int round = 0, randomCard = Random.Shared.Next(1, 14);
string playerInput = "";
bool playerTurn = true, ComputerTurn = true;

Console.WriteLine("Welcome to the BlackJack simulator you have 100$ on your bank account");
do
{
    totalValueComputer = 0; totalValuePlayer = 0;
    round++;
    playerTurn = true; ComputerTurn = false;
    Console.WriteLine($"****Round {round}****");
    Console.WriteLine("**Player**");

    randomCard = Random.Shared.Next(1, 14);
    Console.WriteLine($"You have a {HandOutCard(randomCard)}");
    totalValuePlayer += GiveValue(randomCard, 0);
    AskForBet();
    do
    {
        randomCard = Random.Shared.Next(1, 14);
        Console.WriteLine($"You have a {HandOutCard(randomCard)}");
        totalValuePlayer += GiveValue(randomCard, 0);
        PrintTotalValue();
    } while (totalValuePlayer < 21 && playerInput != "n");

    if (totalValuePlayer <= 21)
    {
        playerTurn = false; ComputerTurn = true;
        Console.WriteLine("**Computer**");
        do
        {
            randomCard = Random.Shared.Next(1, 14);
            Console.WriteLine($"You have a {HandOutCard(randomCard)}");
            totalValueComputer += GiveValue(randomCard, 0);
        } while (totalValueComputer < 17);
    }
    if ((totalValueComputer <= 21 && totalValueComputer > totalValuePlayer) || totalValuePlayer > 21) { Console.WriteLine("Winner: Bank"); playerBet = 0; }
    else { Console.WriteLine("Winner: Player"); increaseMoney = playerBet * 2; playerMoney += increaseMoney; increaseMoney = 0; }
} while (playerMoney < 200 && playerMoney >= 10);

string HandOutCard(int card)
{
    switch (card)
    {
        case 1: return "Card: Ace, Value: 11";
        case 11: return "Card: Jack, Value: 10";
        case 12: return "Card: Dame, Value: 10";
        case 13: return "Card: King, Value: 10";
        default: return $"{card}";
    }
}
int GiveValue(int card, int value)
{
    switch (card)
    {
        case 1: value = 11; break;
        case 11: value = 10; break;
        case 12: value = 10; break;
        case 13: value = 10; break;
        default: value = card; break;
    }
    return value;
}
void AskForBet()
{
    Console.WriteLine("How much money do you want to bet: ");
    playerBet = decimal.Parse(Console.ReadLine()!);
    playerMoney -= playerBet;
}
void PrintTotalValue()
{
    Console.WriteLine($"Your total Value is {totalValuePlayer}");
    if (totalValuePlayer <= 21) { Console.WriteLine("Do you want to continue?[y/n] "); playerInput = Console.ReadLine()!.ToLower(); }
}