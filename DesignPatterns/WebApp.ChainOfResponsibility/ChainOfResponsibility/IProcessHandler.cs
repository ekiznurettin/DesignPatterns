using System;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public interface IProcessHandler
    {
        IProcessHandler SetNext(IProcessHandler prossesHandler);
        Object handle(Object o); 
    }
}
