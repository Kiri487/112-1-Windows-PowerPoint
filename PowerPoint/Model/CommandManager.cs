using System.Collections.Generic;

namespace PowerPoint.Model
{
    public class CommandManager
    {
        // Variable
        Stack<ICommand> _undoStack = new Stack<ICommand>();
        Stack<ICommand> _redoStack = new Stack<ICommand>();

        public CommandManager()
        {
        }

        // Excute command
        public void Execute(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        // Undo
        public void Undo()
        {
            if (IsUndo())
            {
                ICommand command = _undoStack.Pop();
                command.CancelExecute();
                _redoStack.Push(command);
            }

        }

        // Redo
        public void Redo()
        {
            if (IsRedo())
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }

        // Is undo
        public bool IsUndo()
        {
            if (_undoStack.Count > 0)
                return true;
            else
                return false;
        }

        // Is redo
        public bool IsRedo()
        {
            if (_redoStack.Count > 0)
                return true;
            else
                return false;
        }
    }
}
