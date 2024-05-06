namespace Conway.Library;

public class LifeRules
{
    public static CellState GetNewState(
        CellState currentState, int liveNeighbors)
    {
        if (liveNeighbors < 0 || liveNeighbors > 8)
            throw new ArgumentOutOfRangeException(
                nameof(liveNeighbors), 
                "liveNeighbors must be between 0 and 8");

        return currentState switch
        {
            CellState.Alive =>
                liveNeighbors switch
                {
                    2 => CellState.Alive,
                    3 => CellState.Alive,
                    _ => CellState.Dead,
                },
            CellState.Dead =>
                liveNeighbors switch
                {
                    3 => CellState.Alive,
                    _ => CellState.Dead,
                },
            _ => throw new ArgumentOutOfRangeException(nameof(currentState)),
        };
    }
}