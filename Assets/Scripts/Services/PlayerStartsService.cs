namespace Services
{
    public class PlayerStartsService
    {
        
        /// <summary>
        /// Current money
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Has paused
        /// </summary>
        public bool HasPaused { get; set; }
        
        /// <summary>
        /// Has game over
        /// </summary>
        public bool HasGameOver { get; set; }
    }
}