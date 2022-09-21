namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class ProcessHandler : IProcessHandler
    {
        private IProcessHandler _nextProssesHandler;
        public virtual object handle(object o)
        {
            if (_nextProssesHandler != null)
            {
                return _nextProssesHandler.handle(o);
            }
            return null;
        }

        public IProcessHandler SetNext(IProcessHandler prossesHandler)
        {
           _nextProssesHandler = prossesHandler;
            return _nextProssesHandler;
        }
    }
}
