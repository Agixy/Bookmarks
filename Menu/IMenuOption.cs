namespace ConsoleTools.Menu
{
    /// <summary>
    /// Interface for option
    /// </summary>
    public interface IMenuOption
    {
        /// <summary>
        /// User-friendly description of option
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Called when option is chosen
        /// </summary>
        void Execute();
    }
}
