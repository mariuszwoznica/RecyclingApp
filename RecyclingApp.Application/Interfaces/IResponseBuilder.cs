namespace RecyclingApp.Application.Interfaces;

public interface IResponseBuilder<TInput, TResponce>
{
    TResponce Build(TInput input);
}
