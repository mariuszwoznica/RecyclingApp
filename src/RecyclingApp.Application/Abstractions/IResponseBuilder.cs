namespace RecyclingApp.Application.Abstractions;

public interface IResponseBuilder<TInput, TResponse>
{
    TResponse Build(TInput input);
}
