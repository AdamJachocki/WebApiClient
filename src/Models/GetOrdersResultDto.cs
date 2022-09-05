namespace Models
{
    public class GetOrdersResultDto
    {
        public IEnumerable<OrderDto> Data { get; init; }
        public int Offset { get; init; }

        public GetOrdersResultDto(IEnumerable<OrderDto> data, int offset)
        {
            Data = data;
            Offset = offset;
        }
    }
}
