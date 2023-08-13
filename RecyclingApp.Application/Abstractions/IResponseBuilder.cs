namespace RecyclingApp.Application.Abstractions;

public interface IResponseBuilder<TInput, TResponce>
{
    TResponce Build(TInput input);
}
