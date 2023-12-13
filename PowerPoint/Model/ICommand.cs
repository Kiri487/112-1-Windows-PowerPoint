namespace PowerPoint.Model
{
    public interface ICommand
    {
        // Excute
        void Execute();

        // Cancel excute
        void CancelExecute();
    }
}
