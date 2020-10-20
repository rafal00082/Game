namespace Simple.Game.Contract.Play
{
    public class PlayResponse
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Wins { get; set; }
        public bool IsWinner { get; set; }
    }
}
