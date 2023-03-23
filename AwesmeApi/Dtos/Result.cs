namespace AwesmeApi.Dtos
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }

        public static Result<T> SuccessResult(T content) => new() { IsSuccess = true, Content = content };
        public static Result<T> FailureResult(T content, string message) => new() { IsSuccess = false, Content = content, Message = message };

    }
}
