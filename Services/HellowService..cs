public class HelloWorldService : IHelloWordService
{
    public string GetHelloWorld(){
        return "Hello Word";
    }
}

public interface IHelloWordService
{
    public abstract string GetHelloWorld();
}