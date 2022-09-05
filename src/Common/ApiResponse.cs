namespace Common
{
    public class BaseResponse
    {
        public int StatusCode { get; init; }
        public bool IsSuccess { get { return StatusCode >= 200 && StatusCode <= 299 && string.IsNullOrWhiteSpace(ErrorMsg); } }
        public string ErrorMsg { get; init; }

        public BaseResponse(int statusCode = 200, string errMsg = "")
        {
            StatusCode = statusCode;
            ErrorMsg = errMsg;
        }
    }

    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; init; }

        public DataResponse(T data, int statusCode = 200, string errMsg = "")
            : base(statusCode, errMsg)
        {
            Data = data;
        }
    }
}




















